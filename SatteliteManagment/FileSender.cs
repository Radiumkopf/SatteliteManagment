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

        public List<byte[]> FileData { get; set; } 

        private FileReceiver fileReceiver { get; set; }

        public short CurrentPacketIndex { get;  set; }

        public short CurrentReceiveIndex { get;  set; }

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

            byte id = packet.id;
            short number = packet.number;

            logManager.MarkPacketAsReceived(packet.id, packet.number);

            if (IsSendNextIfAck)
            {
                 SendNextPacketAsync();
            }

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
            this.PacketSize = size;
            FileData = new List<byte[]>();

            int countDataPacket = (int)Math.Ceiling((double)dataArray.Length / PacketSize);

            for (int index = 0; index < countDataPacket; index++)
            {
                int offset = index * PacketSize;

                int subArrayLength = Math.Min(PacketSize, dataArray.Length - offset);

                byte[] subArray = new byte[subArrayLength];

                Array.Copy(dataArray, offset, subArray, 0, subArrayLength);

                FileData.Add(subArray);
            }
        }
        public async Task SendNextPacketAsync()
        {
            if (CurrentPacketIndex >= FileData.Count)
                return;

            byte[] packet =
                BuildProtocolPackage(
                    PacketType.FileSending,
                    FileData[CurrentPacketIndex]);

            CurrentPacketIndex++;

            await SendPackageAsync(packet);

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
            byte[] packet = BuildProtocolPackage(PacketType.FileRequesting, Array.Empty<byte>());

            await SendPackageAsync(packet);

            CurrentReceiveIndex++;

            if (!fileReceiver.IsReceiving)
            {
                throw new Exception("Firtsly set the path");
            }
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

        private byte[] BuildProtocolPackage(PacketType type, byte[] value)
        {
            FileTransferPacket packet =
                new FileTransferPacket(
                    type,
                    DestinationId,
                    CurrentPacketIndex,
                    PacketSize,
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
