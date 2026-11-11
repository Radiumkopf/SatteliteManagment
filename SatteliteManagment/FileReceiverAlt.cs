using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class FileReceiverAlt
    {
        private FileStream _stream;

        private byte _packetSize;

        private int? _expectedFileSize;

        private int? _expectedPacketCount;

        private ushort? _lastPacketNumber;

        private int _lastPacketLength;

        private readonly HashSet<ushort> _receivedPackets = new HashSet<ushort>();

        public bool IsReceiving => _stream != null;

        public bool IsComplete
        {
            get
            {
                if (_expectedPacketCount.HasValue)
                {
                    return _receivedPackets.Count ==
                           _expectedPacketCount.Value;
                }

                if (_lastPacketNumber.HasValue)
                {
                    return _receivedPackets.Count ==
                           _lastPacketNumber.Value + 1;
                }

                return false;
            }
        }

        public void Start(string fileName, byte packetSize, int? fileSize = null)
        {
            if (packetSize == 0)
                throw new ArgumentOutOfRangeException(nameof(packetSize));

            Cancel();

            _packetSize = packetSize;
            _expectedFileSize = fileSize;

            if (fileSize.HasValue)
            {
                _expectedPacketCount =
                    (int)Math.Ceiling(
                        (double)fileSize.Value / packetSize);
            }
            else
            {
                _expectedPacketCount = null;
            }

            _lastPacketNumber = null;
            _lastPacketLength = 0;

            _receivedPackets.Clear();

            _stream = new FileStream(
                fileName,
                FileMode.Create,
                FileAccess.ReadWrite,
                FileShare.None);

            // Если полный размер известен,
            // сразу резервируем нужный размер.
            if (fileSize.HasValue)
                _stream.SetLength(fileSize.Value);
        }

        public bool AddPacket(
            FileTransferPacket packet,
            bool isLast = false)
        {
            if (_stream == null)
                throw new InvalidOperationException(
                    "Прием файла не начат.");

            long offset =
                (long)packet.number * _packetSize;

            if (_expectedFileSize.HasValue &&
                offset + packet.data.Length >
                _expectedFileSize.Value)
            {
                throw new InvalidOperationException(
                    $"Пакет №{packet.number} выходит за размер файла.");
            }

            _stream.Seek(
                offset,
                SeekOrigin.Begin);

            _stream.Write(
                packet.data,
                0,
                packet.data.Length);

            _receivedPackets.Add(packet.number);

            if (isLast)
            {
                _lastPacketNumber = packet.number;
                _lastPacketLength = packet.data.Length;
            }

            // Если размер файла неизвестен,
            // после получения последнего пакета
            // можем вычислить фактический размер.
            if (IsComplete &&
                !_expectedFileSize.HasValue &&
                _lastPacketNumber.HasValue)
            {
                long fileLength =
                    (long)_lastPacketNumber.Value * _packetSize
                    + _lastPacketLength;

                _stream.SetLength(fileLength);
            }

            return IsComplete;
        }

        public ushort? GetNextMissingPacket()
        {
            int limit;

            if (_expectedPacketCount.HasValue)
            {
                limit = _expectedPacketCount.Value;
            }
            else if (_lastPacketNumber.HasValue)
            {
                limit = _lastPacketNumber.Value + 1;
            }
            else
            {
                // Всего файла пока не знаем.
                return 0;
            }

            for (ushort i = 0; i < limit; i++)
            {
                if (!_receivedPackets.Contains(i))
                    return i;
            }

            return null;
        }

        public bool HasPacket(ushort number)
        {
            return _receivedPackets.Contains(number);
        }

        public void Finish()
        {
            if (_stream == null)
                return;

            if (!IsComplete)
                throw new InvalidOperationException("Нельзя завершить прием: не все пакеты получены.");

            _stream.Flush();
            _stream.Dispose();
            _stream = null;
        }

        public void Cancel()
        {
            if (_stream == null)
                return;

            _stream.Dispose();
            _stream = null;

            _receivedPackets.Clear();
            _lastPacketNumber = null;
            _expectedPacketCount = null;
            _expectedFileSize = null;
        }

        public void Dispose()
        {
            Cancel();
        }
    }
}
