using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SatteliteManagment
{
    internal enum TableType : byte
    {
        SendingTable = 0x00,
        RequestingTable = 0x01
    }

    internal class FileSender
    {

        private readonly DuplexTcpClient client;
        private readonly GridViewLogManager logRequestingManager;
        private readonly GridViewLogManager logSendingManager;


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

        public event Action SenderLastFileReceived;
        public event Action SenderLastACKReceived;


        private System.Timers.Timer ackTimer;


        public FileSender(DuplexTcpClient client,
                          GridViewLogManager logManager,
                          GridViewLogManager logRequestingManager)
        {
            this.client = client;
            this.logSendingManager = logManager;
            this.logRequestingManager = logRequestingManager;

            this.fileReceiver = new FileReceiver();
            client.AckReceived += OnAckReceived;
            client.FileReceived += OnFileReceived;
            client.LastFileReceived += OnLastFileReceived;
            client.FileNackReceived += OnNackReceived;

            ackTimer = new System.Timers.Timer(3000);
            //ackTimer.Elapsed += OnTimedEvent;
            ackTimer.AutoReset = true;
            //ackTimer.Enabled = true;


        }

        public FileSender()
        {
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (FileData.TryGetValue(CurrentPacketIndex, out RawPacket rawPacket))
            {
                if (rawPacket.IsAckReceived == false)
                {
                    SendPacketAsyncByNumber(CurrentPacketIndex);
                }
                else
                {
                    ackTimer.Stop();
                }


            }
        }

        private async void OnAckReceived(FileTransferPacket packet)     //async annotation add
        {

            if (FileData.TryGetValue(packet.number, out RawPacket filePacket))
            {
                filePacket.IsAckReceived = true;
                logSendingManager.MarkPacketAsReceived(packet.id, packet.number);

                CurrentPacketIndex++;

                if(packet.number == FileData.Count - 1)
                {
                    SenderLastACKReceived?.Invoke();
                }

            }


            if (IsSendNextIfAck)
                await SendNextPacketAsync();

        }

        private async void OnNackReceived()
        {
            await SendNextPacketAsync();
        }

        private void OnFileReceived(FileTransferPacket packet)
        {
            //обработка полученных данных!!!!!

            if (fileReceiver.IsReceiving)
            {
                fileReceiver.AddPacket(packet);

                if (IsSendRequestIfGetPacket)
                {
                    SendFileRequestAsync();
                }
            }

        }


        private void OnLastFileReceived(FileTransferPacket packet)
        {
            if (fileReceiver.IsReceiving)
            {
                fileReceiver.AddPacket(packet);
                fileReceiver.Dispose();
                //еще какой то увед что файл готов

                SenderLastFileReceived?.Invoke();
            }
        }

        public async void SetTxRegister(byte[] address)
        {

            //await client.SendTextAsync(TxOperator.RegisterWrite(address));
            //FIXME addr sending    
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

            //ackTimer.Start();

            //CurrentPacketIndex++;

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
            await SendPackageAsync(packet, rawPacket.Number, TableType.SendingTable);

            
        }

        public async Task SendAllAsync()
        {
            while (CurrentPacketIndex < FileData.Count)
            {
                await SendNextPacketAsync();
                await Task.Delay(700);
            }
        }

        public async Task SendFileRequestAsync()
        {
            byte[] packet = BuildProtocolPackage(PacketType.FileRequesting, CurrentReceiveIndex, Array.Empty<byte>());
            
            if (!fileReceiver.IsReceiving)
            {
                throw new Exception("Firtsly set the path");
            }

            await SendPackageAsync(packet, CurrentReceiveIndex, TableType.RequestingTable);

            CurrentReceiveIndex++;
        }

        private async Task SendPackageAsync(byte[] packet, ushort number, TableType tableType)
        {
            await client.SendTextAsync(packet);

            if (tableType == TableType.SendingTable)
            {
                logSendingManager.AddRow(
                    packet,
                    DestinationId,
                    number,
                    "Пакет отправлен");
            }
            else
            {
                logRequestingManager.AddRow(
                    packet,
                    DestinationId,
                    number,
                    "Запрос отправлен");
            }

        }

        private byte[] BuildProtocolPackage(PacketType type, ushort number, byte[] value)
        {
            FileTransferPacket packet =
                new FileTransferPacket(
                    type,
                    DestinationId,
                    number,
                    (byte)value.Length, 
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

        public async void SendCheckSum()    //FIXME 
        {
            byte[] packet = BuildProtocolPackage(PacketType.VerifyCheckSum, 0, Array.Empty<byte>());
            await client.SendTextAsync(packet);
        }

        public async Task RestartReceive()
        {
            fileReceiver.Finish();
            byte[] packet = BuildProtocolPackage( PacketType.RestartFileReceiving, 0, Array.Empty<byte>());    
            //Увед что нужно рестартнуть передачу
            await client.SendTextAsync(packet);
        }

        public void RequestCurrentServerTxAddress()
        {

        }

    }
}
