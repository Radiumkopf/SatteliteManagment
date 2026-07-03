using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SatteliteManagment
{
    public partial class Form1 : Form
    {

        private readonly DuplexTcpClient _client = new DuplexTcpClient();
        private byte packetSizeValue = 10;
        private short currentPackageIndex = 0;
        private List<byte[]> data;
        private byte destId;
        private GridViewLogManager logManager;

        public Form1()
        {
            InitializeComponent();

            _client.AckReceived += OnAckReceived;

            logManager = new GridViewLogManager(this.logdataGridView);
        
        }

        private void OnAckReceived(SatelliteTCPPacket packet)
        {
            BeginInvoke(new Action(() =>
            {
                byte id = packet.id;
                short number = packet.number;

                if (logManager.rows.TryGetValue((id, number), out DataGridViewRow row))
                {
                    //row.Cells["Status"].Value = "✓ Получен";
                    logTextBox.Text += "\ngot new ack " + id + number;
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }));
        }

        void changeInterfaceState(bool stateServer)
        {
            if (stateServer)
            {
                pictureBox1.BackColor = Color.Green;
                buttonOpenCloseServer.Text = "Выключить сервер";
                labelComPortConnectionInfo.Text = "Подключено";
            }
            else
            {
                pictureBox1.BackColor = Color.Red;
                buttonOpenCloseServer.Text = "Включить сервер";
                labelComPortConnectionInfo.Text = "Выключено";
            }
        }

        private async Task changeServerState(bool stateServer)
        {

            //true - включить сервер, false - выключить сервер
            if (stateServer)
                try
                {
                    buttonOpenCloseServer.Enabled = false;
                    await _client.ConnectAsync("127.0.0.1", 8924);
                    changeInterfaceState(true);
                    buttonOpenCloseServer.Enabled = true;

                }
                catch (Exception e)
                {
                        MessageBox.Show("Подключение к серверу не было выполнено. Проверьте, что сервер включен");
                    buttonOpenCloseServer.Enabled = true;
                    changeInterfaceState(false);
                }
            else
                changeInterfaceState(false);
        }

        private void SetDataGridLogHeaders()
        {

        }

        private void buttonSendCommand_Click(object sender, EventArgs e)
        {/*
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("COM порт закрыт!");
                return;
            }

            try
            {
                string commandToSendRaw = textBoxSendCommand.Text;

                string commandToSend;
                if (radioButtonSeparatorDollar.Checked)
                {
                    commandToSend = commandToSendRaw.Replace("$", String.Empty);
                }
                else
                {
                    commandToSend = commandToSendRaw;
                }

                byte[] commandToSendBytes = GetBytesFromByteString(commandToSend).ToArray();

                outputQueue.Add(commandToSendBytes);

                ColoredItem outputLog = new ColoredItem(commandToSendBytes, "Отправка команды с терминала", Color.Blue);
                WriteRadioControlLog(outputLog);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось преобразовать строку в команду, проверьте правильность ввода");
            }
            */
        }

        public void WriteRadioControlLog(/*ColoredItem item*/)
        {
            /*
            if (item.color == Color.Green && !checkBoxIsLoggingTrancieverChanges.Checked)
            {
                return;
            }

            WriteLogHex(item);*/
        }

        private IEnumerable<byte> GetBytesFromByteString(string s)
        {
            for (int index = 0; index < s.Length; index += 2)
            {
                yield return Convert.ToByte(s.Substring(index, 2), 16);
            }
        }

        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            logTextBox.Text = string.Empty;
        }
        
        private void connectToServer_Click(object sender, EventArgs e)
        {
            if (buttonOpenCloseServer.Text=="Включить сервер") 
                changeServerState(true);
            else
                changeServerState(false);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "" || Path.GetExtension(openFileDialog1.FileName).ToLower() != ".txt")
                return;
            string path = openFileDialog1.FileName;
            byte[] dataArray=File.ReadAllBytes(path);

            data = new List<byte[]>();

            byte.TryParse(packetSize.Text, out packetSizeValue);

            int countDataPacket = (int)(dataArray.Length / packetSizeValue);
            for (int index = 0; index <= countDataPacket; index++)
            {
                int subArrayLength = (index!= countDataPacket) ? packetSizeValue : dataArray.Length % packetSizeValue;
                byte[] subArray = new byte[subArrayLength];

                Array.Copy(dataArray, subArray, subArrayLength);
                data.Add(subArray);
            }

            if (buttonOpenCloseServer.Text == "Включить сервер" || labelComPortConnectionInfo.Text == "Выключено")
                connectToServer_Click(sender,e);

            

            sendOnePackageButton.Enabled = true;
            sendAllPackageButton.Enabled = true;
            currentPackageIndex = 0;

        }

        private void logSendingInfo(int i)
        {
            String logInfo = "Пакет успешно отправлен. №" + i + "\n";
            logTextBox.Text += logInfo;
            

        }



        private void sendOnePackageButton_Click(object sender, EventArgs e)
        {
            if (data.Count > 0 && idTextBox.Text!=string.Empty)     //maybe fix second check
            {
                byte.TryParse(idTextBox.Text, out destId);
                byte[] finalPack = BuildProtocolPackage(data[currentPackageIndex]);
                _client.SendTextAsync(finalPack);
                logSendingInfo(currentPackageIndex);
                logManager.AddRow(finalPack, destId, currentPackageIndex, "Пакет отправлен");
                currentPackageIndex++;

            }
            else return;
        }

        private void sendAllPackageButton_Click(object sender, EventArgs e)
        {
            if (data.Count > 0 && idTextBox.Text != string.Empty)
            {
                byte.TryParse(idTextBox.Text, out destId);


                for (int i = currentPackageIndex; i < data.Count; i++)
                {
                    byte[] finalPack = BuildProtocolPackage(data[currentPackageIndex]);
                    _client.SendTextAsync(finalPack);
                    logSendingInfo(i);
                    logManager.AddRow(finalPack, destId, currentPackageIndex, "Пакет отправлен");

                    currentPackageIndex = (short)i;
                }
            }
            else return;
        }

        private byte[] BuildProtocolPackage( byte[] value)
        {
            SatelliteTCPPacket stp = new SatelliteTCPPacket('#', destId, currentPackageIndex, packetSizeValue, value);
            return stp.ToByteArray();
        }

        private void testbutton_Click(object sender, EventArgs e)
        {
            //GridViewLogManager gridViewLogManager = new GridViewLogManager();
            //gridViewLogManager.DataGridView = this.logdataGridView;
            //gridViewLogManager.HeaderInfo();
            //byte[] datab = new byte[] { 0x01, 0x02, 0x03 };
            //gridViewLogManager.AddRow(datab, "boba");
        }
        private void packetSize_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(packetSize.Text, out int number))
            {
                if (number < 10)
                {
                    number = 10;
                    packetSize.Text = number.ToString();

                }
                else if (number > 200)
                {
                    number = 200;
                    packetSize.Text = number.ToString();
                }
            }
            else
            {
               // MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                packetSize.Text = "10";
            }
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            if (byte.TryParse(idTextBox.Text, out byte number))
            {
                if (number < 0)
                {
                    number = 0;
                    idTextBox.Text = number.ToString();
                    destId = number;

                }
                else if (number > 255)
                {
                    number = 255;
                    idTextBox.Text = number.ToString();
                }
            }
            else
            {
                idTextBox.Text = "10";
            }
        }
    }
}
