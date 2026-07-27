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

        public FormSelectPacket(FileSender sender)
        {
            InitializeComponent();

            packetGridViewManager = new RawPacketGridViewManager(dataGridViewPackets);
            this.fileSender = sender;
            packetGridViewManager.AddAll(fileSender.FileData);
        }


    }
}
