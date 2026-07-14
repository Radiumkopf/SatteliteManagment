using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatteliteManagment
{
    internal class GridViewLogManager
    {
        private DataGridView dataGridView;

        public GridViewLogManager(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            this.rows = new Dictionary<(byte id, short number), DataGridViewRow> ();

            HeaderInfo();
        }

        public DataGridView DataGridView { get => dataGridView; set => dataGridView = value; }
        public Dictionary<(byte id, short number), DataGridViewRow> rows ;
        public void HeaderInfo()
        {
            dataGridView.ColumnCount = 5;
            dataGridView.Columns[0].HeaderText = "Дата и время";
            dataGridView.Columns[1].HeaderText = "ID";
            dataGridView.Columns[2].HeaderText = "Номер пакета";

            dataGridView.Columns[3].HeaderText = "Байтовый текст";
            dataGridView.Columns[4].HeaderText = "Info";
        }

        public void AddRow(byte[] bytes, byte id,  short number, String text)
        {
            //dataGridView.Rows.Add(
            //    DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"),
            //    id.ToString(),
            //    number.ToString(),
            //    BitConverter.ToString(bytes),
            //    text
            //);
            //вариант без создания объекта строки

            int index = dataGridView.Rows.Add();

            DataGridViewRow row = dataGridView.Rows[index];
            row.Cells[0].Value = DateTime.Now.ToString();
            row.Cells[1].Value = id.ToString();
            row.Cells[2].Value = number.ToString();
            row.Cells[3].Value = BitConverter.ToString(bytes);
            row.Cells[4].Value = text;

            rows[(id, number)] = row; //add to dict
        }
        public void MarkPacketAsReceived(byte id, short number)
        {
            dataGridView.BeginInvoke(new Action(() =>
            {
                if (rows.TryGetValue((id, number), out DataGridViewRow row))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    //row.Cells["Status"].Value = "ACK";
                }
            }));
        }

        public void ClearGrid()
        {
            this.dataGridView.Rows.Clear();
        }
    }
}
