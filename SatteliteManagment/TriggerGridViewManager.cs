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
        public event Action<byte[], TriggerStatus> StatusChange;
        public event Action<byte[], byte[]> AddressChanged; // oldAddress, newAddress
        public event Action<byte[], byte[]> CommandChanged;


        public TriggerGridViewManager(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            
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
            dataGridView.Columns[1].ReadOnly = true;

            dataGridView.Columns[2].Name = "command";
            dataGridView.Columns[2].HeaderText = "Команда";

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Вкл/откл";
            buttonColumn.Name = "Action";
            buttonColumn.Text = "Вкл/откл";
            buttonColumn.UseColumnTextForButtonValue = true;

            dataGridView.Columns.Add(buttonColumn);

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;

            dataGridView.CellContentClick += DataGridView_CellContentClick;
            dataGridView.CellValidating += DataGridView_CellValidating;
            dataGridView.EditingControlShowing += DataGridView_EditingControlShowing;
            dataGridView.CellBeginEdit += DataGridView_CellBeginEdit;
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
        }
        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string columnName = dataGridView.CurrentCell?.OwningColumn?.Name;

            if (columnName != "address" && columnName != "command")
                return;

            if (e.Control is System.Windows.Forms.TextBox tb)
            {
                tb.KeyPress -= HexTextBox_KeyPress;
                tb.KeyPress += HexTextBox_KeyPress;
            }
        }
        private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dataGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "address" || columnName == "command")
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                row.Cells[columnName].Tag = Convert.ToString(row.Cells[columnName].Value) ?? string.Empty;
            }
        }
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            if (columnName == "address")
            {
                string oldHex = Convert.ToString(row.Cells["address"].Tag) ?? string.Empty;
                string newHex = Convert.ToString(row.Cells["address"].Value) ?? string.Empty;

                if (string.Equals(oldHex, newHex, StringComparison.OrdinalIgnoreCase))
                    return;

                if (!DataConverter.IsHexString(oldHex) || !DataConverter.IsHexString(newHex))
                    return;

                byte[] oldAddress = DataConverter.HexStringToBytes(oldHex);
                byte[] newAddress = DataConverter.HexStringToBytes(newHex);

                AddressChanged?.Invoke(oldAddress, newAddress);
            }
            else if (columnName == "command")
            {
                string newHex = Convert.ToString(row.Cells["command"].Value) ?? string.Empty;
                string addressHex = Convert.ToString(row.Cells["address"].Value) ?? string.Empty;

                if (!DataConverter.IsHexString(addressHex) || !DataConverter.IsHexString(newHex))
                    return;

                byte[] address = DataConverter.HexStringToBytes(addressHex);
                byte[] newCommand = DataConverter.HexStringToBytes(newHex);

                CommandChanged?.Invoke(address, newCommand);
            }
        }
        private void HexTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (Uri.IsHexDigit(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == '-')
                return;

            e.Handled = true;
        }
        private async void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView.Columns[e.ColumnIndex].Name != "Action")
                return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            string status = Convert.ToString(row.Cells["status"].Value) ?? string.Empty;

            if (status == "Активен")
            {
                SetStatusAndColor(TriggerStatus.DisableByUser, row);
                byte[] address = DataConverter.HexStringToBytes(Convert.ToString(row.Cells["address"].Value) ?? "");
                StatusChange?.Invoke(address, TriggerStatus.DisableByUser);
            }
            else if (status == "Отключен")
            {
                SetStatusAndColor(TriggerStatus.Active, row);
                byte[] address = DataConverter.HexStringToBytes(Convert.ToString(row.Cells["address"].Value) ?? "");
                StatusChange?.Invoke(address, TriggerStatus.Active);
            }


        }


        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dataGridView.Columns[e.ColumnIndex].Name;

            if (columnName != "address" && columnName != "command")
                return;

            string text = e.FormattedValue?.ToString() ?? string.Empty;

            if (!DataConverter.IsHexString(text))
            {
                e.Cancel = true;
                dataGridView.Rows[e.RowIndex].ErrorText = "Допустимы только hex-значения";
            }
            else
            {
                dataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
            }
        }


        private void SetStatusAndColor(TriggerStatus status, DataGridViewRow row)
        {
            switch (status)
            {
                case TriggerStatus.Active:
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                    row.Cells["status"].Value = "Активен";
                    break;
                case TriggerStatus.DisableByUser:
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                    row.Cells["status"].Value = "Отключен";
                    break;
                case TriggerStatus.Sent:
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.DeepSkyBlue;
                    row.Cells["status"].Value = "Сработал";
                    break;
            }
        }

        public void SetRowStatusByAddress( byte[] address, TriggerStatus status)
        {
            string addr = BitConverter.ToString(address);
            foreach (DataGridViewRow row in dataGridView.Rows) {
                if (Equals(row.Cells["address"].Value, addr))
                {
                    SetStatusAndColor(status, row);

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
            TriggerStatus triggerStatus = trigger.status;

            int index = dataGridView.Rows.Add();

            DataGridViewRow row = dataGridView.Rows[index];
            row.Cells[0].Value = BitConverter.ToString(trigger.address);
            row.Cells[2].Value = BitConverter.ToString(trigger.command);
            SetStatusAndColor(triggerStatus, row);

            //dataGridView.Rows.Add(
            //    BitConverter.ToString(trigger.address),
            //    statusString,
            //    BitConverter.ToString(trigger.command));
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
            Console.WriteLine("Указанный триггер не найден " + addr);

        }

        public void RestartTriggers()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["status"].Value.ToString() == "Сработал")
                {
                    SetStatusAndColor(TriggerStatus.Active, row);

                }
            }
        }

    }
}
