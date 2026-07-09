using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SatteliteManagment
{
    internal class TriggerGridViewManager
    {

        private DataGridView dataGridView;
        private TriggerManager triggerManager;

        public TriggerGridViewManager(DataGridView dataGridView, TriggerManager triggerManager)
        {
            this.dataGridView = dataGridView;
            
            this.triggerManager = triggerManager;
            HeaderInfo();
        }

        public void HeaderInfo()
        {

            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Width = 80;
            dataGridView.Columns[1].Width = 120;
            dataGridView.Columns[2].Width = 120;

            dataGridView.Columns[0].Name = "address";
            dataGridView.Columns[0].HeaderText = "Спутник";

            dataGridView.Columns[1].Name = "status";
            dataGridView.Columns[1].HeaderText = "Статус";    

            dataGridView.Columns[2].Name = "command";
            dataGridView.Columns[2].HeaderText = "Команда";

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Вкл/откл";
            buttonColumn.Name = "Action";
            buttonColumn.Text = "Вкл/откл";
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

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            if(row.Cells["status"].Value == "Активен")
            {
                row.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                row.Cells["status"].Value =  "Отключен";

                byte[] address = Encoding.ASCII.GetBytes(row.Cells["address"].Value.ToString());
                triggerManager.ChangeTriggerStatusByAddress(address, TriggerStatus.DisableByUser);

            }
            else if (row.Cells["status"].Value == "Отключен")
            {
                row.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                row.Cells["status"].Value = "Активен";

                byte[] address = Encoding.ASCII.GetBytes(row.Cells["address"].Value.ToString());
                triggerManager.ChangeTriggerStatusByAddress(address, TriggerStatus.Active);
            }


        }
        public void SetRowStatus(string newStatus, byte[] address)
        {
            string addr = BitConverter.ToString(address);
            foreach (DataGridViewRow row in dataGridView.Rows) {
                if (Equals(row.Cells["address"].Value, addr))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                    row.Cells["status"].Value = newStatus;

                    return;
                }
            }
        }

        public void AddRow(byte[] address,  bool status, byte[] command)
        {
            string statusString;
            if(status) {
                statusString = "Активен";
            }
            else statusString = "Неактивен";

            dataGridView.Rows.Add(
                BitConverter.ToString(address),
                statusString,
                BitConverter.ToString(command));
        }

        public void AddRow(Trigger trigger)
        {
            string statusString = trigger.StatusToString();


            dataGridView.Rows.Add(
                BitConverter.ToString(trigger.address),
                statusString,
                BitConverter.ToString(trigger.command));
        }

        public void RemoveRow(byte[] address)
        {
            string addr = BitConverter.ToString(address);
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Equals(row.Cells["address"].Value, addr))
                {
                    dataGridView.Rows.Remove(row);
                    return;
                }
            }
        }

    }
}
