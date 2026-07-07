using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatteliteManagment
{
    internal class TriggerGridViewManager
    {

        private DataGridView dataGridView;


        public TriggerGridViewManager(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public void HeaderInfo()
        {

            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Width = 80;
            dataGridView.Columns[1].Width = 120;
            dataGridView.Columns[2].Width = 275;

            dataGridView.Columns[0].HeaderText = "Спутник";
            dataGridView.Columns[1].HeaderText = "Статус";
            dataGridView.Columns[2].HeaderText = "Команда";
        }

        public void AddRow(byte[] address,  bool status, byte command)
        {
            string statusString;
            if(status) {
                statusString = "Активен";
            }
            else statusString = "Неактивен";

            dataGridView.Rows.Add(
                address.ToString(),
                statusString,
                command);
        }

    }
}
