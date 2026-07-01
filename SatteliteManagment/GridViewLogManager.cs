using System;
using System.Collections.Generic;
using System.Linq;
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
            HeaderInfo();
        }

        public DataGridView DataGridView { get => dataGridView; set => dataGridView = value; }

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
            dataGridView.Rows.Add(
                DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"),
                id.ToString(),
                number.ToString(),
                BitConverter.ToString(bytes),
                text
            );
        }

        public void ClearGrid()
        {
            this.dataGridView.Rows.Clear();
        }
    }
}
