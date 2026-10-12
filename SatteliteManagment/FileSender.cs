using SatteliteManagment.Entities;
using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Selector;
using SatteliteManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal enum TableType : byte
    {
        SendingTable = 0x00,
        RequestingTable = 0x01
    }

    internal class FileSender : IDisposable
    {
        private readonly DuplexTcpClient _client;
        private readonly GridViewLogManager _logRequestingManager;
        private readonly GridViewLogManager _logSendingManager;
        private readonly DbServices _dbServices;

        private readonly FileReceiverAlt _fileReceiver;

        private readonly Dictionary<ushort, RawPacket> _fileData = new Dictionary<ushort, RawPacket>();

        private readonly Dictionary<ushort, FileRequestState> _requestData = new Dictionary<ushort, FileRequestState>();

        /*
         * Номер следующего пакета в автоматической отправке.
         *
         * Не изменяется при ручной отправке другого номера.
         * Не изменяется от самого факта отправки.
         * Переходит дальше только после ACK.
         */
        private ushort _nextSendIndex;

        /*
         * Номер следующего request в автоматическом приёме.
         *
         * Переходит дальше только после ACK этого request.
         */
        private ushort _nextReceiveIndex;

        public Dictionary<ushort, RawPacket> FileData => _fileData;

        public Dictionary<ushort, FileRequestState> RequestData => _requestData;

        public ushort CurrentPacketIndex => _nextSendIndex;

        public ushort CurrentReceiveIndex => _nextReceiveIndex;

        public int? ReceiveFileSize { get; private set; }

        public byte DestinationId { get; set; }

        public byte PacketSize { get; private set; }

        public bool IsSendNextIfAck { get; set; }

        public bool IsSendRequestIfGetPacket { get; set; }

        public bool IsTxSet { get; set; }

        public bool IsDbWritingEnable { get; set; }

        public event Action SenderLastFileReceived;
        public event Action SenderLastACKReceived;

        public FileSender(
            DuplexTcpClient client,
            GridViewLogManager logSendingManager,
            GridViewLogManager logRequestingManager,
            DbServices dbServices)
        {
            _client = client;
            _logSendingManager = logSendingManager;
            _logRequestingManager = logRequestingManager;
            _dbServices = dbServices;

            _fileReceiver = new FileReceiverAlt();

            _client.AckReceived += OnAckReceived;
            _client.FileReceived += OnFileReceived;
            _client.LastFileReceived += OnLastFileReceived;
            _client.FileNackReceived += OnNackReceived;
        }

        #region File sending

        public void SetAndSplitFile(byte[] data, byte packetSize)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (packetSize == 0)
                throw new ArgumentOutOfRangeException(nameof(packetSize));

            int count = (int)Math.Ceiling(
                (double)data.Length / packetSize);

            if (count > ushort.MaxValue + 1)
                throw new InvalidOperationException(
                    "Количество пакетов превышает диапазон ushort.");

            _fileData.Clear();

            PacketSize = packetSize;
            _nextSendIndex = 0;

            for (int i = 0; i < count; i++)
            {
                int offset = i * packetSize;
                int length = Math.Min(packetSize, data.Length - offset);
                byte[] packetData = new byte[length];

                Array.Copy(data, offset, packetData, 0,  length);

                _fileData.Add((ushort)i, new RawPacket( (ushort)i, packetData));
            }
        }

        public async Task SendNextPacketAsync()
        {
            if (_nextSendIndex >= _fileData.Count)
                return;

            ushort number = (ushort)_nextSendIndex;
            if (!_fileData.TryGetValue(number, out RawPacket packet))
                return;
            /*
             * Если пакет уже отправлен и ждёт ACK,
             * автоматическую отправку не повторяем.
             */
            if (packet.IsSent && !packet.IsAckReceived)
                return;

            await SendPacketAsyncByNumber(number);
        }

        public async Task SendPacketAsyncByNumber(ushort number)
        {
            if (!_fileData.TryGetValue(number,  out RawPacket rawPacket))
            {
                throw new ArgumentException( $"Пакет №{number} не найден.");
            }

            byte[] packet = BuildProtocolPackage(  PacketType.FileSending, rawPacket.Number, rawPacket.Data);
            await SendPackageAsync(packet, rawPacket.Number, TableType.SendingTable);
            rawPacket.IsSent = true;
            await SaveFilePacketToDbAsync(rawPacket);
        }

        private void AdvanceSendIndex()
        {
            while (_nextSendIndex < _fileData.Count)
            {
                ushort number = (ushort)_nextSendIndex;

                if (!_fileData.TryGetValue(
                        number,
                        out RawPacket packet))
                {
                    break;
                }

                if (!packet.IsAckReceived)
                    break;

                _nextSendIndex++;
            }
        }

        private bool AllSendPacketsAckReceived()
        {
            return _fileData.Count > 0 &&
                   _fileData.Values.All(
                       p => p.IsAckReceived);
        }

        #endregion

        #region Sending ACK

        private async Task HandleSendingAckAsync(
            FileTransferPacket packet,
            PacketInfo packetInfo)
        {
            if (!_fileData.TryGetValue(
                    packet.number,
                    out RawPacket rawPacket))
            {
                return;
            }

            /*
             * Повторный ACK ничего не делает.
             */
            if (rawPacket.IsAckReceived)
                return;

            /*
             * Важно запомнить, был ли ACK именно
             * текущего автоматического пакета.
             */
            bool wasCurrentPacket =
                _nextSendIndex == packet.number;

            rawPacket.IsAckReceived = true;

            _logSendingManager.MarkPacketAsReceived(
                packet.id,
                packet.number);

            /*
             * Result меняем ДО ProcessAckAsync().
             * ProcessAckAsync() сохранит и leaf, и PacketInfo
             * одним SaveChangesAsync().
             */
            if (IsDbWritingEnable)
            {
                FileTransferPacketEntity ftpe =
                    await _dbServices.FileTransferPacketService
                        .GetByFileIdAndNumberAsync(
                            DestinationId,
                            packet.number);

                if (ftpe != null)
                {
                    ftpe.Result = CommandResult.ACK;

                    PacketInfoEntity packetInfoEntity =
                        PacketInfoService.MapToEntity(packetInfo);

                    await _dbServices.PacketStoreService
                        .ProcessAckAsync(
                            ftpe,
                            packetInfoEntity);
                }
            }

            AdvanceSendIndex();

            if (AllSendPacketsAckReceived())
            {
                SenderLastACKReceived?.Invoke();
                return;
            }

            /*
             * Только ACK текущего автоматического пакета
             * позволяет отправить следующий.
             *
             * Если вручную отправили №17 при CurrentPacketIndex=2,
             * ACK №17 не переключит автомат на №3.
             */
            if (wasCurrentPacket &&
                IsSendNextIfAck)
            {
                await SendNextPacketAsync();
            }
        }

        #endregion

        #region File requesting

        public void SetReceiveFileInfo(
            int fileSize,
            byte packetSize)
        {
            if (fileSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(fileSize));

            if (packetSize == 0)
                throw new ArgumentOutOfRangeException(nameof(packetSize));

            int packetCount =
                (int)Math.Ceiling(
                    (double)fileSize / packetSize);

            if (packetCount > ushort.MaxValue + 1)
                throw new InvalidOperationException(
                    "Количество пакетов превышает диапазон ushort.");

            ReceiveFileSize = fileSize;
            PacketSize = packetSize;

            _requestData.Clear();
            _nextReceiveIndex = 0;

            for (int i = 0; i < packetCount; i++)
            {
                int offset = i * packetSize;

                int remaining =
                    fileSize - offset;

                byte size =
                    (byte)Math.Min(
                        packetSize,
                        remaining);

                _requestData.Add(
                    (ushort)i,
                    new FileRequestState(
                        (ushort)i,
                        size));
            }
        }

        /*
         * Размер файла пока неизвестен.
         *
         * RequestData будет заполняться только
         * при фактическом запросе конкретного номера.
         */
        public void SetReceivePacketSize(byte packetSize)
        {
            if (packetSize == 0)
                throw new ArgumentOutOfRangeException(nameof(packetSize));

            PacketSize = packetSize;

            ReceiveFileSize = null;

            _requestData.Clear();
            _nextReceiveIndex = 0;
        }

        public async Task SendFileRequestAsync()
        {
            if (_nextReceiveIndex > ushort.MaxValue)
                return;

            ushort number =
                (ushort)_nextReceiveIndex;

            /*
             * Если предыдущий request уже отправлен,
             * но ACK ещё не пришёл, автоматически
             * новый request не отправляем.
             *
             * Его всё ещё можно переотправить вручную
             * SendFileRequestAsync(number).
             */
            if (_requestData.TryGetValue(
                    number,
                    out FileRequestState request))
            {
                if (request.IsAckReceived)
                {
                    AdvanceReceiveIndex();

                    if (_nextReceiveIndex <= ushort.MaxValue)
                        await SendFileRequestAsync();

                    return;
                }

                if (request.IsSent)
                    return;
            }

            await SendFileRequestAsync(number);
        }

        /*
         * Основной метод request.
         * Используется и автоматикой, и таблицей.
         */
        public async Task SendFileRequestAsync(
            ushort number)
        {
            if (!_fileReceiver.IsReceiving)
            {
                throw new InvalidOperationException(
                    "Сначала необходимо выбрать путь для сохранения файла.");
            }

            byte requestSize =
                GetRequestPacketSize(number);

            if (!_requestData.TryGetValue(
                    number,
                    out FileRequestState request))
            {
                request = new FileRequestState(
                    number,
                    requestSize);

                _requestData.Add(
                    number,
                    request);
            }
            else
            {
                request.Size = requestSize;
            }

            /*
             * Если ACK уже был получен,
             * повторять этот request не надо.
             */
            if (request.IsAckReceived)
            {
                throw new InvalidOperationException(
                    $"ACK для пакета №{number} уже получен.");
            }

            byte[] packet = BuildProtocolPackage(
                PacketType.FileRequesting,
                number,
                requestSize,
                Array.Empty<byte>());

            await SendPackageAsync(
                packet,
                number,
                TableType.RequestingTable);

            request.IsSent = true;

            await SaveFileRequestToDbAsync(request);
        }

        private byte GetRequestPacketSize(
            ushort number)
        {
            if (PacketSize == 0)
            {
                throw new InvalidOperationException(
                    "Размер пакета не задан.");
            }

            /*
             * Размер файла неизвестен.
             * Поэтому запрашиваем полный пакет.
             */
            if (!ReceiveFileSize.HasValue)
                return PacketSize;

            int packetCount =
                (int)Math.Ceiling(
                    (double)ReceiveFileSize.Value / PacketSize);

            if (number >= packetCount)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(number));
            }

            int offset =
                number * PacketSize;

            int remaining =
                ReceiveFileSize.Value - offset;

            return (byte)Math.Min(
                PacketSize,
                remaining);
        }

        private void AdvanceReceiveIndex()
        {
            while (_nextReceiveIndex <= ushort.MaxValue)
            {
                ushort number =
                    (ushort)_nextReceiveIndex;

                if (!_requestData.TryGetValue(
                        number,
                        out FileRequestState request))
                {
                    break;
                }

                if (!request.IsAckReceived)
                    break;

                _nextReceiveIndex++;
            }
        }

        #endregion

        #region Request ACK + data

        /*
         * Именно здесь находится важное отличие
         * от предыдущей версии:
         *
         * ACK FileRequesting содержит packet.data,
         * поэтому этот метод одновременно:
         *
         * 1. отмечает request как подтвержденный;
         * 2. передает packet.data в FileReceiver;
         * 3. обновляет БД;
         * 4. запускает следующий request.
         */
        private async Task HandleRequestAckAsync(
            FileTransferPacket packet,
            PacketInfo packetInfo)
        {
            if (!_requestData.TryGetValue(
                    packet.number,
                    out FileRequestState request))
            {
                return;
            }

            /*
             * Повторный ACK с тем же номером
             * повторно в файл писать не нужно.
             */
            if (request.IsAckReceived)
                return;

            bool wasCurrentRequest =
                _nextReceiveIndex == packet.number;

            request.IsAckReceived = true;

            /*
             * ACK содержит данные файла.
             */
            bool isLastPacket =
                IsLastRequestedPacket(
                    packet,
                    request);

            bool complete =
                _fileReceiver.AddPacket(
                    packet,
                    isLastPacket);

            _logRequestingManager.MarkPacketAsReceived(
                packet.id,
                packet.number);

            /*
             * Результат FileRequest = ACK.
             *
             * И packet.data тоже сохраняем в leaf.
             */
            if (IsDbWritingEnable)
            {
                FileRequestEntity fre =
                    await _dbServices.FileRequestService
                        .GetByFileIdAndNumberAsync(
                            DestinationId,
                            packet.number);

                if (fre != null)
                {
                    fre.Result = CommandResult.ACK;

                    /*
                     * Если у FileRequestEntity есть Data:
                     * fre.Data = packet.data;
                     *
                     * Если имя поля другое — подставить его.
                     */

                    PacketInfoEntity packetInfoEntity =
                        PacketInfoService.MapToEntity(packetInfo);

                    await _dbServices.PacketStoreService
                        .ProcessAckAsync(
                            fre,
                            packetInfoEntity);
                }
            }

            AdvanceReceiveIndex();

            /*
             * Если файл уже полностью собран,
             * новый request не отправляем.
             */
            if (complete)
            {
                SenderLastFileReceived?.Invoke();
                return;
            }

            /*
             * Автоматический переход вперёд
             * только после ACK + получения его данных.
             */
            if (wasCurrentRequest &&
                IsSendRequestIfGetPacket)
            {
                await SendFileRequestAsync();
            }
        }

        private bool IsLastRequestedPacket(
            FileTransferPacket packet,
            FileRequestState request)
        {
            /*
             * Если размер файла известен,
             * последний номер известен заранее.
             */
            if (ReceiveFileSize.HasValue)
            {
                int lastNumber =
                    (int)Math.Ceiling(
                        (double)ReceiveFileSize.Value / PacketSize) - 1;

                return packet.number == lastNumber;
            }

            /*
             * Если полный размер неизвестен,
             * последним считаем пакет, пришедший короче
             * запрошенного размера.
             *
             * Если протокол имеет отдельный флаг LAST,
             * здесь лучше использовать его.
             */
            return packet.data.Length < request.Size;
        }

        #endregion

        #region Other incoming file events

        /*
         * Эти события оставляем на случай,
         * если МК может присылать FileReceived
         * вне механизма request/ACK.
         */
        private async void OnFileReceived(
            FileTransferPacket packet)
        {
            try
            {
                if (!_fileReceiver.IsReceiving)
                    return;

                bool complete =
                    _fileReceiver.AddPacket(
                        packet,
                        false);

                _logRequestingManager.MarkPacketAsReceived(
                    packet.id,
                    packet.number);

                if (complete)
                {
                    _fileReceiver.Finish();
                    SenderLastFileReceived?.Invoke();
                }
            }
            catch (Exception)
            {
                // Передать ошибку наружу через event
            }
        }

        private async void OnLastFileReceived(
            FileTransferPacket packet)
        {
            try
            {
                if (!_fileReceiver.IsReceiving)
                    return;

                bool complete =
                    _fileReceiver.AddPacket(
                        packet,
                        true);

                _logRequestingManager.MarkPacketAsReceived(
                    packet.id,
                    packet.number);

                if (complete)
                {
                    _fileReceiver.Finish();
                    SenderLastFileReceived?.Invoke();
                }
            }
            catch (Exception)
            {
                // Передать ошибку наружу через event
            }
        }

        #endregion

        #region NACK

        private async void OnNackReceived()
        {
            try
            {
                /*
                 * NACK относится к текущему
                 * автоматическому пакету отправки.
                 */
                if (_nextSendIndex >= _fileData.Count)
                    return;

                await SendPacketAsyncByNumber(
                    (ushort)_nextSendIndex);
            }
            catch (Exception)
            {
                // Передать ошибку наружу через event
            }
        }

        #endregion

        #region Database

        private async Task SaveFilePacketToDbAsync(
            RawPacket packet)
        {
            if (!IsDbWritingEnable)
                return;

            FileTransferPacketEntity existing =
                await _dbServices.FileTransferPacketService
                    .GetByFileIdAndNumberAsync(
                        DestinationId,
                        packet.Number);

            /*
             * Повторная отправка того же пакета
             * не создает новую запись.
             */
            if (existing != null)
                return;

            FileTransferPacketEntity entity =
                new FileTransferPacketEntity(
                    DestinationId,
                    packet.Number,
                    (byte)packet.Data.Length,
                    packet.Data);

            await _dbServices.PacketStoreService
                .SavePacketAwaitingAckAsync(
                    PacketType.FileSending,
                    entity);
        }

        private async Task SaveFileRequestToDbAsync(
            FileRequestState request)
        {
            if (!IsDbWritingEnable)
                return;

            FileRequestEntity existing =
                await _dbServices.FileRequestService
                    .GetByFileIdAndNumberAsync(
                        DestinationId,
                        request.Number);

            /*
             * Повторный request не создает
             * новую строку в БД.
             */
            if (existing != null)
                return;

            FileRequestEntity entity =
                new FileRequestEntity(
                    DestinationId,
                    request.Number,
                    request.Size,
                    Array.Empty<byte>());

            await _dbServices.PacketStoreService
                .SavePacketAwaitingAckAsync(
                    PacketType.FileRequesting,
                    entity);
        }

        #endregion

        #region Receive setup

        public void SetPathToSave(
            string path)
        {
            if (PacketSize == 0)
            {
                throw new InvalidOperationException(
                    "Размер пакета не задан.");
            }

            _fileReceiver.Start(
                path,
                PacketSize,
                ReceiveFileSize);
        }

        public void ClearSendData()
        {
            _fileData.Clear();
            _nextSendIndex = 0;
        }

        public void ClearReceiveData()
        {
            _requestData.Clear();

            _nextReceiveIndex = 0;
            ReceiveFileSize = null;

            _fileReceiver.Cancel();
        }

        #endregion

        #region Other commands

        public async Task CheckSumVerify()
        {
            if (IsDbWritingEnable)
            {
                VerifyCheckSumEntity entity =
                    new VerifyCheckSumEntity
                    {
                        FileId = DestinationId,
                        Crc = 0,
                        Result = CommandResult.NoResult
                    };

                await _dbServices.PacketStoreService
                    .SavePacketAwaitingAckAsync(
                        PacketType.VerifyCheckSum,
                        entity);
            }

            byte[] packet =
                BuildProtocolPackage(
                    PacketType.VerifyCheckSum,
                    0,
                    Array.Empty<byte>());

            await _client.SendTextAsync(packet);
        }

        public async Task StartReprogramming()
        {
            await _client.SendTextAsync(
                BuildSmallPackage(
                    PacketType.ReprogrammingStart,
                    DestinationId));
        }

        public async Task SetTime()
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;

            int unixTimestamp = (int)now.ToUnixTimeSeconds();
            byte[] timeBytes = BitConverter.GetBytes( unixTimestamp);

            await _client.SendTextAsync( BuildTimePackage(PacketType.TimeSet, timeBytes));
        }

        public async Task SetCoilMagnetMoment(ushort moment)
        {
            await _client.SendTextAsync(BuildSmallPackage(PacketType.SetCoilMagnetMoment, moment));
        }

        public async Task SetMotorSpeed(ushort speed)
        {
            await _client.SendTextAsync(BuildSmallPackage(PacketType.SetMotorSpeed, speed));
        }

        public async Task GetModuleStatus(byte moduleId)
        {
            await _client.SendTextAsync(BuildSmallPackage(PacketType.GetModuleStatus, moduleId));
        }

        public async Task GetPhoto()
        {
            await _client.SendTextAsync(BuildSmallPackage(PacketType.PhotoGet, DestinationId));
        }

        public async Task GetPhotoSize()
        {
            await _client.SendTextAsync(BuildSmallPackage(PacketType.PhotoGetSize, DestinationId));
        }

        #endregion

        #region ACK dispatch

        private async void OnAckReceived(FileTransferPacket packet, PacketInfo packetInfo)
        {
            try
            {
                /*
                 * Для FileRequesting ACK содержит данные файла.
                 *
                 * Поэтому наличие request с этим номером
                 * используем как признак request-операции.
                 *
                 * Если по протоколу можно достоверно определить
                 * тип ACK другим способом, лучше использовать его.
                 */
                if (_requestData.ContainsKey(packet.number) &&
                    packet.data != null &&
                    packet.data.Length > 0)
                {
                    await HandleRequestAckAsync(
                        packet,
                        packetInfo);

                    return;
                }

                if (_fileData.ContainsKey(packet.number))
                {
                    await HandleSendingAckAsync(
                        packet,
                        packetInfo);
                }
            }
            catch (Exception)
            {
                // Передать ошибку наружу через event
            }
        }

        #endregion

        #region Packet building

        private async Task SendPackageAsync(byte[] packet, ushort number, TableType tableType)
        {
            await _client.SendTextAsync(packet);

            if (tableType == TableType.SendingTable)
            {
                _logSendingManager.AddRow(
                    packet,
                    DestinationId,
                    number,
                    "Пакет отправлен");
            }
            else
            {
                _logRequestingManager.AddRow(
                    packet,
                    DestinationId,
                    number,
                    "Запрос отправлен");
            }
        }

        private byte[] BuildProtocolPackage(PacketType type, ushort number, byte[] value)
        {
            return BuildProtocolPackage(type, number, (byte)value.Length, value);
        }

        private byte[] BuildProtocolPackage(PacketType type, ushort number, byte size, byte[] value)
        {
            FileTransferPacket packet = new FileTransferPacket(type, DestinationId, number, size, value);

            return packet.ToByteArray();
        }

        private static byte[] BuildSmallPackage(PacketType packetType, byte value)
        {
            return new[]
            {
                (byte)packetType, value
            };
        }

        private static byte[] BuildSmallPackage(PacketType packetType, ushort value)
        {
            byte[] result = new byte[3];

            result[0] = (byte)packetType;
            byte[] bytes = BitConverter.GetBytes(value);
            result[1] = bytes[0];
            result[2] = bytes[1];

            return result;
        }

        private static byte[] BuildTimePackage(PacketType packetType, byte[] timeBytes)
        {
            byte[] result = new byte[timeBytes.Length + 1];
            result[0] = (byte)packetType;
            Array.Copy(timeBytes, 0, result, 1, timeBytes.Length);

            return result;
        }

        #endregion

        public void Dispose()
        {
            _client.AckReceived -= OnAckReceived;       //???
            _client.FileReceived -= OnFileReceived;
            _client.LastFileReceived -= OnLastFileReceived;
            _client.FileNackReceived -= OnNackReceived;

            _fileReceiver.Dispose();
        }
    }
}
