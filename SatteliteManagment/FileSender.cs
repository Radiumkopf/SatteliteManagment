using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatteliteManagment
{
    internal class FileSender
    {

        private readonly DuplexTcpClient client;
        private readonly GridViewLogManager logManager;

        //public List<byte[]> FileData { get; set; }
        public Dictionary<ushort, RawPacket> FileData;

        private FileReceiver fileReceiver { get; set; }

        public ushort CurrentPacketIndex { get;  set; }

        public ushort CurrentReceiveIndex { get;  set; }

        public byte DestinationId { get; set; }

        public byte PacketSize { get; set; }
        public bool IsSendNextIfAck { get; set; }
        public bool IsSendRequestIfGetPacket { get; set; }
        public bool IsTxSet {  get; set; }

        public event Action LastFileReceived;


        public FileSender(DuplexTcpClient client,
                          GridViewLogManager logManager)
        {
            this.client = client;
            this.logManager = logManager;
            this.fileReceiver = new FileReceiver();
            client.AckReceived += OnAckReceived;
            client.FileReceived += OnFileReceived;
            client.LastFileReceived += OnLastFileReceived;

        }

        public FileSender()
        {
        }
        private void OnAckReceived(FileTransferPacket packet)
        {

            if (FileData.TryGetValue(packet.number, out RawPacket filePacket))
            {
                filePacket.IsAckReceived = true;
            }

            logManager.MarkPacketAsReceived(packet.id, packet.number);

            if (IsSendNextIfAck)
                SendNextPacketAsync();

        }

        private void OnFileReceived(FileTransferPacket packet)
        {
            //обработка полученных данных!!!!!

            if (fileReceiver.IsReceiving)
            {
                fileReceiver.AddPacket(packet);
            }
            if (IsSendRequestIfGetPacket)
            {
                SendFileRequestAsync();
            }
        }

        private void OnLastFileReceived(FileTransferPacket packet)
        {
            if (fileReceiver.IsReceiving)
            {
                fileReceiver.AddPacket(packet);
                fileReceiver.Finish();
                //еще какой то увед что файл готов
            }
        }

        public async void SetTxRegister(byte[] address)
        {

                await client.SendTextAsync(TxOperator.RegisterWrite(address));
            
        }

        public void SetAndSplitFile(byte[] dataArray, byte size)
        {
            PacketSize = size;
            FileData = new Dictionary<ushort, RawPacket>();

            int count = (int)Math.Ceiling((double)dataArray.Length / PacketSize);

            for (ushort i = 0; i < count; i++)
            {
                int offset = i * PacketSize;

                int length = Math.Min(PacketSize, dataArray.Length - offset);

                byte[] packet = new byte[length];

                Array.Copy(dataArray, offset, packet, 0, length);

                FileData.Add(i, new RawPacket(i, packet));
            }
        }
        public async Task SendNextPacketAsync()
        {
            if (!FileData.ContainsKey(CurrentPacketIndex))
                return;

            await SendPacketAsyncByNumber(CurrentPacketIndex);

            CurrentPacketIndex++;

        }
        public async Task SendPacketAsyncByNumber(ushort number)
        {
            if (!FileData.TryGetValue(number, out RawPacket rawPacket))
                throw new ArgumentException($"Пакет №{number} не найден.");

            byte[] packet = BuildProtocolPackage(
                PacketType.FileSending,
                rawPacket.Number,
                rawPacket.Data);

            rawPacket.IsSent = true;
            await SendPackageAsync(packet, rawPacket.Number);

            
        }

        public async Task SendAllAsync()
        {
            while (CurrentPacketIndex < FileData.Count)
            {
                await SendNextPacketAsync();
            }
        }

        public async Task SendFileRequestAsync()
        {
            byte[] packet = BuildProtocolPackage(PacketType.FileRequesting, CurrentReceiveIndex, Array.Empty<byte>());
            
            if (!fileReceiver.IsReceiving)
            {
                throw new Exception("Firtsly set the path");
            }

            await SendPackageAsync(packet);

            CurrentReceiveIndex++;
        }

        private async Task SendPackageAsync(byte[] packet)
        {
            await client.SendTextAsync(packet);

            logManager.AddRow(
                packet,
                DestinationId,
                CurrentPacketIndex,
                "Пакет отправлен");
        }
        private async Task SendPackageAsync(byte[] packet, ushort number)
        {
            await client.SendTextAsync(packet);

            logManager.AddRow(
                packet,
                DestinationId,
                number,
                "Пакет отправлен");
        }

        private byte[] BuildProtocolPackage(PacketType type, ushort number, byte[] value)
        {
            FileTransferPacket packet =
                new FileTransferPacket(
                    type,
                    DestinationId,
                    number,
                    (byte)value.Length, // FIXME fix for last one
                    value);

            return packet.ToByteArray();
        }

        public void SetPathToSave(string path)
        {
            if (!fileReceiver.IsReceiving)
            {
                fileReceiver.Start(path);
            }
            else throw new Exception("Already writing in this path");
        }

        public void ClearFileData()
        {
            FileData.Clear();
            CurrentPacketIndex = 0;
            DestinationId = 0;
            PacketSize = 0;
        }

        public void RequestCurrentServerTxAddress()
        {

        }

    }
}
