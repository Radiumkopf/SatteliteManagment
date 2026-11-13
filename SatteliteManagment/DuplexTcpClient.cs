using SatteliteManagment.Orientation;
using SatteliteManagment.Services;
using SatteliteManagment.Telemetry;
using SBandSerialReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class DuplexTcpClient
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts;

        public event Action<PacketInfo> PacketReceived;

        public event Action<FileTransferPacket, PacketInfo> AckReceived;

        public event Action FileNackReceived;

        public event Action<uint> CRCReceived;

        public event Action<bool> ReprogrammingResult;

        public event Action<FileTransferPacket> FileReceived;

        public event Action<FileTransferPacket> LastFileReceived;

        public event Action<FileTransferPacket> ServerAddrChanged;

        public event Action<TlmPacket, PacketInfo> TelemetryReceived;
        public event Action<ModelOrientation, PacketInfo> OrientationReceived;
        public event Action<bool> MotorSpeedReceived;
        public event Action<bool> CoilMagnetMomentReceived;
        public event Action<byte, ushort> ModuleStatusReceived;
        public event Action<bool> PhotoResultReceived;
        public event Action<bool, long> PhotoSizeReceived;

        public event Action<Exception> ConnectionError;
        public event Action<Exception, byte[]> PacketProcessingError;
        public event Action<bool> ConnectionStateChanged;

        private Task _receiveTask;

        public bool IsConnected { get; private set; }




        private const int OFFSET = 25;

        public async Task ConnectAsync(string ip, int port)
        {
            if (IsConnected)
                throw new InvalidOperationException("Соединение уже установлено.");

            _client = new TcpClient();

            try
            {
                await _client.ConnectAsync(ip, port);
                _stream = _client.GetStream();
                _cts = new CancellationTokenSource();
                SetConnectionState(true);
                _receiveTask = ReceiveLoop(_cts.Token);
            }
            catch
            {
                CloseTransport();
                SetConnectionState(false);
                throw;
            }
        }

        public async Task SendTextAsync(byte[] bytes, CancellationToken token = default)
        {
            await PacketProtocol.WritePacketAsync(_stream, bytes, token);
        }

        //private async Task ReceiveLoop(CancellationToken token)
        //{
        //    try
        //    {
        //        while (!token.IsCancellationRequested)
        //        {
        //            byte[] data = await PacketProtocol.ReadPacketAsync(_stream, token);

        //            //if (data.Length == 10)
        //            //{
        //            //    ServerAddrChanged?.Invoke(SatellitePacketParser.Parse(data));
        //            //    continue;
        //            //}

        //            if(data.Length < 28)
        //            {
        //                continue;
        //            }

        //            byte[] packetInfoHeaderBytes = new byte[28];

        //            Array.Copy(data, packetInfoHeaderBytes, OFFSET);
        //            PacketType packetType = SatellitePacketParser.GetPacketType(data[OFFSET]);

        //            if(packetType == PacketType.AddressChanging)
        //            {
        //                FileTransferPacket addrpacket = SatellitePacketParser.ParseFilePacket(data, OFFSET);
        //                ServerAddrChanged?.Invoke(addrpacket);
        //                continue;
        //            }

        //                PacketInfo packetInfo;
        //                try
        //                {
        //                    packetInfo = PacketInfoParser.Parse(packetInfoHeaderBytes);

        //                    //if (packetType != PacketType.Telemetry)
        //                    //{
        //                    //    PacketReceived?.Invoke(packetInfo);     //чтоб не вешало ресивер
        //                    //}

        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine(ex.Message);
        //                    continue;
        //                }
                    

        //            FileTransferPacket packet;
        //            switch (packetType)
        //            {

        //                case PacketType.FileSendingAck:
        //                    packet = SatellitePacketParser.ParseFilePacket(data, OFFSET);
        //                    AckReceived?.Invoke(packet, packetInfo);
        //                    break;

        //                case PacketType.FileSendingNack:
        //                    FileNackReceived?.Invoke();
        //                    break;

        //                case PacketType.FileRequestingAck:
        //                    packet = SatellitePacketParser.ParseFilePacket(data, OFFSET);
        //                    FileReceived?.Invoke(packet);
        //                    break;

        //                case PacketType.FileRequestingLast:
        //                    packet = SatellitePacketParser.ParseFilePacket(data, OFFSET);
        //                    LastFileReceived?.Invoke(packet);
        //                    break;

        //                //case PacketType.AddressChanging:
        //                //    packet = SatellitePacketParser.Parse(data, OFFSET);
        //                //    ServerAddrChanged?.Invoke(packet);
        //                //    break;
        //                case PacketType.VerifyCheckSumAck:
        //                    uint satCRC = SatellitePacketParser.Parse4Bytes(data, OFFSET);
        //                    CRCReceived?.Invoke(satCRC);
        //                    break;
        //                //Small packets ack/nack
        //                case PacketType.ReprogrammingStartACK:
        //                    ReprogrammingResult?.Invoke(true);
        //                    break;
        //                case PacketType.ReprogrammingStartNACK:
        //                    ReprogrammingResult?.Invoke(false);
        //                    break;
        //                case PacketType.ModuleStatus:
        //                    var (moduleId, status) = SatellitePacketParser.ParseModuleStatus(data, OFFSET);
        //                    ModuleStatusReceived?.Invoke(moduleId, status);
        //                    break;
        //                case PacketType.SetCoilMagnetMomentAck:
        //                    CoilMagnetMomentReceived?.Invoke(true);
        //                    break;
        //                case PacketType.SetCoilMagnetMomentNack:
        //                    CoilMagnetMomentReceived?.Invoke(false);
        //                    break;
        //                case PacketType.SetMotorSpeedAck:
        //                    MotorSpeedReceived?.Invoke(true);
        //                    break;
        //                case PacketType.SetMotorSpeedNack:
        //                    MotorSpeedReceived?.Invoke(false);
        //                    break;
        //                //No-request/response packets
        //                case PacketType.Telemetry:
        //                    TlmPacket telemetryPacket = TlmPacket.Parse(data, OFFSET+1);
        //                    TelemetryReceived?.Invoke(telemetryPacket, packetInfo);
        //                    break;

        //                case PacketType.OrientationPacket:
        //                    ModelOrientation orientation = OrientationParser.ParseToObj(data, OFFSET + 1);
        //                    OrientationReceived?.Invoke(orientation, packetInfo);
        //                    break;
        //                case PacketType.PhotoGetAck:
        //                    PhotoResultReceived?.Invoke(true);
        //                    break;
        //                case PacketType.PhotoGetNack:
        //                    PhotoResultReceived?.Invoke(false);
        //                    break;
        //                case PacketType.PhotoGetSizeAck:
        //                    uint photoSize = SatellitePacketParser.Parse4Bytes(data, OFFSET);
        //                    PhotoSizeReceived?.Invoke(true, photoSize);
        //                    break;
        //                case PacketType.PhotoGetSizeNack:
        //                    PhotoSizeReceived?.Invoke(false, 0);
        //                    break;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        private async Task ReceiveLoop(CancellationToken token)
        {
            Exception connectionError = null;

            try
            {
                while (!token.IsCancellationRequested)
                {
                    // Ошибки здесь считаются фатальными:
                    // повреждение framing, обрыв соединения,
                    // некорректная длина сообщения и т.д.
                    byte[] data = await PacketProtocol.ReadPacketAsync(
                        _stream,
                        token);

                    if (data == null)
                    {
                        throw new InvalidDataException(
                            "PacketProtocol вернул null вместо сообщения.");
                    }

                    // Ошибка содержимого отдельного пакета
                    // не должна завершать весь ReceiveLoop.
                    try
                    {
                        ProcessIncomingPacket(data);
                    }
                    catch (Exception ex)
                    {
                        PacketProcessingError?.Invoke(ex, data);
                    }
                }
            }
            catch (Exception) when (token.IsCancellationRequested)
            {
                // Пользователь самостоятельно отключил соединение.
            }
            catch (Exception ex)
            {
                connectionError = ex;
            }
            finally
            {
                CloseTransport();
                SetConnectionState(false);

                if (connectionError != null)
                    ConnectionError?.Invoke(connectionError);
            }
        }
        private void ProcessIncomingPacket(byte[] data)
        {
            if (data.Length < OFFSET + 1)
            {
                throw new InvalidDataException(
                    $"Пакет слишком короткий. Получено {data.Length} байт, " +
                    $"минимально необходимо {OFFSET + 1}.");
            }

            byte[] packetInfoHeaderBytes = new byte[OFFSET];

            Array.Copy(
                data,
                0,
                packetInfoHeaderBytes,
                0,
                OFFSET);

            PacketType packetType =
                SatellitePacketParser.GetPacketType(data[OFFSET]);

            // Обработка смены адреса.
            if (packetType == PacketType.AddressChanging)
            {
                FileTransferPacket addrPacket = SatellitePacketParser.ParseFilePacket(data, OFFSET);

                ServerAddrChanged?.Invoke(addrPacket);
                return;
            }

            // Разбираем общую часть пакета.
            PacketInfo packetInfo = PacketInfoParser.Parse(packetInfoHeaderBytes);

            switch (packetType)
            {
                case PacketType.FileSendingAck:
                    {
                        FileTransferPacket packet =
                            SatellitePacketParser.ParseFilePacket(data, OFFSET);

                        AckReceived?.Invoke(packet, packetInfo);
                        break;
                    }

                case PacketType.FileSendingNack:
                    {
                        FileNackReceived?.Invoke();
                        break;
                    }

                case PacketType.FileRequestingAck:
                    {
                        FileTransferPacket packet =
                            SatellitePacketParser.ParseFilePacket(data, OFFSET);

                        FileReceived?.Invoke(packet);
                        break;
                    }

                case PacketType.FileRequestingLast:
                    {
                        FileTransferPacket packet =
                            SatellitePacketParser.ParseFilePacket(data, OFFSET);

                        LastFileReceived?.Invoke(packet);
                        break;
                    }

                case PacketType.VerifyCheckSumAck:
                    {
                        uint satCRC =
                            SatellitePacketParser.Parse4Bytes(data, OFFSET);

                        CRCReceived?.Invoke(satCRC);
                        break;
                    }

                case PacketType.ReprogrammingStartACK:
                    ReprogrammingResult?.Invoke(true);
                    break;

                case PacketType.ReprogrammingStartNACK:
                    ReprogrammingResult?.Invoke(false);
                    break;

                case PacketType.ModuleStatus:
                    {
                        var (moduleId, status) =
                            SatellitePacketParser.ParseModuleStatus(data, OFFSET);

                        ModuleStatusReceived?.Invoke(moduleId, status);
                        break;
                    }

                case PacketType.SetCoilMagnetMomentAck:
                    CoilMagnetMomentReceived?.Invoke(true);
                    break;

                case PacketType.SetCoilMagnetMomentNack:
                    CoilMagnetMomentReceived?.Invoke(false);
                    break;

                case PacketType.SetMotorSpeedAck:
                    MotorSpeedReceived?.Invoke(true);
                    break;

                case PacketType.SetMotorSpeedNack:
                    MotorSpeedReceived?.Invoke(false);
                    break;

                case PacketType.Telemetry:
                    {
                        TlmPacket telemetryPacket = TlmPacket.Parse(data, OFFSET + 1);
                        TelemetryReceived?.Invoke(telemetryPacket,packetInfo);

                        break;
                    }

                case PacketType.OrientationPacket:
                    {
                        ModelOrientation orientation = OrientationParser.ParseToObj(data, OFFSET + 1);
                        OrientationReceived?.Invoke( orientation,  packetInfo);
                        break;
                    }

                case PacketType.PhotoGetAck:
                    PhotoResultReceived?.Invoke(true);
                    break;

                case PacketType.PhotoGetNack:
                    PhotoResultReceived?.Invoke(false);
                    break;

                case PacketType.PhotoGetSizeAck:
                    {
                        uint photoSize = SatellitePacketParser.Parse4Bytes(data, OFFSET);
                        PhotoSizeReceived?.Invoke(true, photoSize);
                        break;
                    }

                case PacketType.PhotoGetSizeNack:
                    PhotoSizeReceived?.Invoke(false, 0);
                    break;

                default:
                    throw new NotSupportedException( $"Неизвестный или необрабатываемый тип пакета: {packetType}");
            }
        }
        public async Task DisconnectAsync()
        {
            CancellationTokenSource cts = _cts;
            Task receiveTask = _receiveTask;

            // Останавливаем ReceiveLoop.
            cts?.Cancel();

            // Закрытие потока прерывает ожидающее чтение.
            CloseTransport();

            if (receiveTask != null)
            {
                try
                {
                    await receiveTask;
                }
                catch (OperationCanceledException)
                {
                    // Штатное отключение.
                }
            }

            cts?.Dispose();

            if (ReferenceEquals(_cts, cts))
                _cts = null;

            _receiveTask = null;

            SetConnectionState(false);
        }

        private void SetConnectionState(bool connected)
        {
            if (IsConnected == connected)
                return;

            IsConnected = connected;
            ConnectionStateChanged?.Invoke(connected);
        }

        private void CloseTransport()
        {
            NetworkStream stream = _stream;
            TcpClient client = _client;

            _stream = null;
            _client = null;

            try
            {
                stream?.Close();
            }
            catch
            {
                // Игнорируем ошибку освобождения.
            }

            try
            {
                client?.Close();
            }
            catch
            {
                // Игнорируем ошибку освобождения.
            }
        }
    }
}
