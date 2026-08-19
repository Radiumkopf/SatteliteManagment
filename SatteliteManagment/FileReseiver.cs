using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class FileReceiver : IDisposable
    {
        private FileStream _stream;
        private short _expectedPacket = 0;

        public bool IsReceiving => _stream != null;

        public void Start(string fileName)
        {
            Cancel();

            _stream = new FileStream(
                fileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None);

            _expectedPacket = 0;
        }

        public void AddPacket(FileTransferPacket packet)
        {
            if (_stream == null)
                throw new InvalidOperationException("Прием файла не начат.");

            //if (packet.number != _expectedPacket)
            //    throw new Exception($"Ожидался пакет {_expectedPacket}, получен {packet.number}");

            _stream.Write(packet.data, 0, packet.data.Length);

            _expectedPacket++;
        }

        public void Finish()
        {
            if (_stream == null)
                return;

            _stream.Flush();
            _stream.Dispose();
            _stream = null;

            _expectedPacket = 0;
        }

        public void Cancel()
        {
            if (_stream == null)
                return;

            _stream.Dispose();
            _stream = null;

            _expectedPacket = 0;
        }

        public void Dispose()
        {
            Cancel();
        }
    }
}
