using SatteliteManagment.Selector;
using SatteliteManagment.Telemetry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatteliteManagment
{
    internal partial class FormSelectPacket : Form
    {
        //public event Action<TlmPacket> Telemetryeived;

        private FileSender fileSender { get; set; }
        private RawPacketGridViewManager packetGridViewManager;
        private bool Mode; // true = send, false = receive

        public FormSelectPacket(FileSender sender)
        {
            InitializeComponent();
            ushort currentN = sender.CurrentPacketIndex;
            labelCurrentNumber.Text = currentN.ToString();
            packetGridViewManager = new RawPacketGridViewManager(dataGridViewPackets, currentN, true);
            this.fileSender = sender;
            packetGridViewManager.AddAll(fileSender.FileData);

            packetGridViewManager.PacketSendRequested += PacketGridViewManager_PacketSend;

        }
        public FormSelectPacket(FileSender sender, bool mode)
        {
            InitializeComponent();
            ushort currentN = mode ? sender.CurrentPacketIndex : sender.CurrentReceiveIndex;
            labelCurrentNumber.Text = currentN.ToString();
            packetGridViewManager = new RawPacketGridViewManager(dataGridViewPackets, currentN, mode);
            this.fileSender = sender;
            //packetGridViewManager.AddAll(fileSender.FileData);

            packetGridViewManager.PacketSendRequested += PacketGridViewManager_PacketSend;
            packetGridViewManager.PacketRequestRequested += PacketGridViewManager_PacketRequest;

            this.Mode = mode;
            if (mode)
            {
                packetGridViewManager.AddAll(fileSender.FileData);
            }
            else
            {
                packetGridViewManager.AddRequests(
                    fileSender.RequestData.Values,
                    onlySent: !fileSender.ReceiveFileSize.HasValue);
            }

        }
        private async void PacketGridViewManager_PacketSend(ushort number)
        {
            await fileSender.SendPacketAsyncByNumber(number);

            DialogResult = DialogResult.OK;
            Close();
        }
        private async void PacketGridViewManager_PacketRequest(ushort number)
        {
            await fileSender.SendFileRequestAsync(number);

            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
