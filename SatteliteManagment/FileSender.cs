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

        public short CurrentPacketIndex { get; private set; }

        public short CurrentReceiveIndex { get; private set; }

        public byte DestinationId { get; set; }

        public byte PacketSize { get; set; }
        public bool IsSendNextIfAck { get; set; }
        public bool IsSendRequestIfGetPacket { get; set; }

        public FileSender(DuplexTcpClient client,
                          GridViewLogManager logManager)
        {
            this.client = client;
            this.logManager = logManager;
            client.AckReceived += OnAckReceived;
            client.FileReceived += OnFileReceived;
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
                    //sendPackage(); //данные уже загружены + айди уже записан + хз какой то кринж
            }

        }

        private void OnFileReceived(FileTransferPacket packet)
        {
            //обработка полученных данных!!!!!


            if (IsSendRequestIfGetPacket)
            {
                SendFileRequestAsync();
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

            await SendPackageAsync(packet);

            CurrentPacketIndex++;
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
    }
}
