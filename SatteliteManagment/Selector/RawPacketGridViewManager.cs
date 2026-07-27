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
        short lastSentNumber;

        public RawPacketGridViewManager(DataGridView gridView)
        {
            this.dataGridView = gridView;
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
            buttonColumn.Text = "Send";
            buttonColumn.UseColumnTextForButtonValue = true;

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

            if ((string)button.Value != "Sent")
            {

                short number = Convert.ToInt16(dataGridView.Rows[e.RowIndex].Cells["number"].Value);
            }
        }

        public void AddRow(short number, byte[] data)
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
                button.Value = "Sent";


            }
        }

        public void AddAll( List<byte[]> data) 
        {
            for (short i = 0; i < data.Count; i++)
            {
                AddRow(i, data[i]);  
            }
        }
    }
}
