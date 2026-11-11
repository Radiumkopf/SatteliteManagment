using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatteliteManagment.Selector
{
    internal class RawPacketGridViewManager
    {

        DataGridView dataGridView;
        ushort lastSentNumber;
        public event Action<ushort> PacketSendRequested;
        public event Action<ushort> PacketRequestRequested;
        private bool Mode; // true = send, false = receive


        public RawPacketGridViewManager(DataGridView gridView, ushort last, bool mode)
        {
            this.dataGridView = gridView;
            lastSentNumber = last;
            Mode = mode;
            HeaderInfo();
        }

        public void HeaderInfo()
        {
            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Width = 80;
            dataGridView.Columns[1].Width = 200;
            dataGridView.Columns[2].Width = 80;

            dataGridView.Columns[0].HeaderText = "№";
            dataGridView.Columns[0].Name = "Number";
            dataGridView.Columns[1].HeaderText = "RawData";
            dataGridView.Columns[1].Name = "RawData";
            dataGridView.Columns[2].HeaderText = "Size";
            dataGridView.Columns[2].Name = "Size";

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Send";
            buttonColumn.Name = "Action";
            //buttonColumn.Text = "---";
            buttonColumn.UseColumnTextForButtonValue = false;

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;

            dataGridView.ReadOnly = true;

            dataGridView.Columns.Add(buttonColumn);
            dataGridView.CellContentClick += DataGridView_CellContentClick;
        
        }

        private async void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView.Columns[e.ColumnIndex].Name != "Action")
                return;

            DataGridViewButtonCell button =
                (DataGridViewButtonCell)dataGridView.Rows[e.RowIndex].Cells["Action"];

            if (button.Value?.ToString() == "ACK получен")
                return;

            ushort number = Convert.ToUInt16(dataGridView.Rows[e.RowIndex].Cells["Number"].Value);

            if (!Mode)
                PacketRequestRequested?.Invoke(number);
            else
                PacketSendRequested?.Invoke(number);
        }

        public void AddRow(ushort number, byte[] data)
        {
            int index = dataGridView.Rows.Add();

            DataGridViewRow row = dataGridView.Rows[index];

            row.Cells[0].Value = number.ToString();
            row.Cells[1].Value = BitConverter.ToString(data);
            row.Cells[2].Value = data.Length.ToString();
            if (lastSentNumber >= number)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                DataGridViewButtonCell button = (DataGridViewButtonCell)row.Cells["Action"];
                button.Value = "Уже отправлен";
                

            }
        }
        public void AddRow(RawPacket packet)
        {
            int index = dataGridView.Rows.Add();

            DataGridViewRow row = dataGridView.Rows[index];

            row.Cells["Number"].Value = packet.Number;
            row.Cells["RawData"].Value = BitConverter.ToString(packet.Data);
            row.Cells["Size"].Value = packet.Data.Length;

            DataGridViewButtonCell button =
                (DataGridViewButtonCell)row.Cells["Action"];

            if (packet.IsAckReceived)
            {
                row.DefaultCellStyle.BackColor = Color.Green;
                button.Value = "ACK получен";
                return;
            }
            else if (packet.IsSent)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                button.Value = "Пакет отправлен";
            }
            else
            {
                button.Value = "Отправить";
            }
        }

        public void AddAll(Dictionary<ushort, RawPacket> data) 
        {
            dataGridView.Rows.Clear();

            foreach (RawPacket packet in data.Values.OrderBy(p => p.Number))
            {
                AddRow(packet);
            }
        }
        public void AddRequests(IEnumerable<FileRequestState> requests, bool onlySent)
        {
            dataGridView.Rows.Clear();

            foreach (FileRequestState request in
                     requests.OrderBy(x => x.Number))
            {
                if (onlySent && !request.IsSent)
                    continue;

                AddRequestRow(request);
            }
        }
        private void AddRequestRow(FileRequestState request)
        {
            int index = dataGridView.Rows.Add();

            DataGridViewRow row = dataGridView.Rows[index];

            row.Cells["Number"].Value = request.Number;
            row.Cells["RawData"].Value = "---";
            row.Cells["Size"].Value = request.Size;

            DataGridViewButtonCell button = (DataGridViewButtonCell)row.Cells["Action"];

            if (request.IsAckReceived)
            {
                row.DefaultCellStyle.BackColor = Color.Green;
                button.Value = "ACK получен";
            }
            else if (request.IsSent)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                button.Value = "Переотправить";
            }
            else
            {
                button.Value = "Запросить";
            }
        }
    }
}
