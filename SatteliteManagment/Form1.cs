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
        private short currentReceiveIndex = 0;

        private byte[] currentServerTxAddress;
        private List<byte[]> fileSendingData;
        private byte destId;
        private GridViewLogManager logManager;
        private CommandSender commandSender;        
        private TriggerGridViewManager triggerGridManager;
        private TriggerManager triggerManager;
        private FileSender fileSender;

        public Form1()
        {
            InitializeComponent();

            _client.PacketReceived += OnAddressReceived;
            _client.ServerAddrChanged += OnServerAddrChanged;


            logManager = new GridViewLogManager(this.logdataGridView);
            commandSender = new CommandSender(_client);
            triggerManager = new TriggerManager();
            triggerGridManager = new TriggerGridViewManager(dataGridViewTriggerState, triggerManager);
            fileSender = new FileSender(_client, logManager);

            fileSender.LastFileReceived += OnFullFileReceived;
        
        }

        //private void OnAckReceived(FileTransferPacket packet)
        //{
        //    BeginInvoke(new Action(() =>
        //    {
        //        byte id = packet.id;
        //        short number = packet.number;

        //        if (logManager.rows.TryGetValue((id, number), out DataGridViewRow row))
        //        {
        //            //fix and move to sender or gridmanager
        //            logTextBox.Text += "\ngot new ack " + id + number;
        //            row.DefaultCellStyle.BackColor = Color.Green;
        //        }

        //        if (checkBoxSendNextIfGetAck.Checked)
        //        {
        //            //sendPackage(); //данные уже загружены + айди уже записан + хз какой то кринж
        //        }
        //    }));
        //}
        private void OnAddressReceived(PacketInfo packet)
        {
            BeginInvoke(new Action(() =>
            {
                byte[] satelliteAddress = BitConverter.GetBytes(packet.SourceAddr);

                if(!Equals(satelliteAddress, currentServerTxAddress))
                {
                    fileSender.SetTxRegister(satelliteAddress);
                    LogTextBoxWriteNewAddr("Спутник", satelliteAddress);
                }

                Trigger trigger = triggerManager.GetTriggerByAddress(BitConverter.GetBytes( packet.SourceAddr));
                if (trigger != null)
                {
                    if (trigger.status == TriggerStatus.Active)
                    {
                        commandSender.SendCommandAsync(trigger.command);
                        if (checkBoxDisableTriggersAfterAct.Checked)
                        {
                            triggerGridManager.SetRowStatusSent(trigger.address);
                            triggerManager.ChangeTriggerStatusByAddress(trigger.address, TriggerStatus.Sent);
                        }

                        Console.WriteLine("Команда отправлена, триггер сработал " + trigger.command);
                    }
                }
                else Console.WriteLine("Нужный триггер/адрес не найден!");

            }));
        }

        private void OnServerAddrChanged(FileTransferPacket packet)
        {
            BeginInvoke(new Action(() => {
                byte[] newAddr = new byte[packet.data.Length];
                Array.Copy(packet.data, newAddr, packet.data.Length);
                currentServerTxAddress = newAddr;

                LogTextBoxWriteNewAddr( "Сервер", newAddr);
            }));
            
         }

        private void LogTextBoxWriteNewAddr(string who, byte[] addr) {

            logTextBox.AppendText(who);
            logTextBox.AppendText( " изменил TX-адрес: ");
            logTextBox.AppendText(ByteArrayToStringHEX(addr));
            logTextBox.AppendText(  Environment.NewLine );
        }

        //Обработчик успешно принятого файла
        private void OnFullFileReceived()
        {
            buttonSendFileRequest.Enabled = false;
            logTextBox.AppendText("Файл получен");
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

            byte[] dataArray = File.ReadAllBytes(path);

            fileSendingData = new List<byte[]>();

            packetSizeValue = (byte)numericUpDownPacketSize.Value;

            int countDataPacket = (int)Math.Ceiling((double)dataArray.Length / packetSizeValue);

            for (int index = 0; index < countDataPacket; index++)
            {
                int offset = index * packetSizeValue;

                int subArrayLength = Math.Min(packetSizeValue, dataArray.Length - offset);

                byte[] subArray = new byte[subArrayLength];

                Array.Copy(dataArray, offset, subArray, 0, subArrayLength);

                fileSendingData.Add(subArray);
            }

            if (buttonOpenCloseServer.Text == "Включить сервер" || labelComPortConnectionInfo.Text == "Выключено")
                connectToServer_Click(sender,e);

            

            sendOnePackageButton.Enabled = true;
            sendAllPackageButton.Enabled = true;
            currentPackageIndex = 0;
            fileSender.FileData = fileSendingData;
            fileSender.PacketSize = (byte) numericUpDownPacketSize.Value;

        }


        private async void sendOnePackageButton_Click(object sender, EventArgs e)
        {

            fileSender.DestinationId = (byte)numericUpDownId.Value;

            await fileSender.SendNextPacketAsync();
        }

        private async void sendAllPackageButton_Click(object sender, EventArgs e)
        {

            fileSender.DestinationId = (byte)numericUpDownId.Value;

            await fileSender.SendAllAsync();
        } 
        private async void buttonSendFileRequest_Click(object sender, EventArgs e)
        {

            fileSender.DestinationId = (byte)numericUpDownId.Value;

            await fileSender.SendFileRequestAsync();
        }


        private void testbutton_Click(object sender, EventArgs e)
        {
            //GridViewLogManager gridViewLogManager = new GridViewLogManager();
            //gridViewLogManager.DataGridView = this.logdataGridView;
            //gridViewLogManager.HeaderInfo();
            //byte[] datab = new byte[] { 0x01, 0x02, 0x03 };
            //gridViewLogManager.AddRow(datab, "boba");
        }


        private void buttonWriteCommand_Click(object sender, EventArgs e)
        {
            if (textBoxCommand.Text.Length > 0 && textBoxSatAddress.Text.Length > 0)
            {
                
                string commandToSendRaw = textBoxCommand.Text;

                string commandToSend;
                if (radioButtonSeparatorDollar1.Checked)
                {
                    commandToSend = commandToSendRaw.Replace("$", String.Empty);
                }
                else
                {
                    commandToSend = commandToSendRaw;
                }
                Trigger trigger = new Trigger(HexStringToBytes(textBoxSatAddress.Text), HexStringToBytes(commandToSend));
                triggerManager.AddTrigger(trigger);
                triggerGridManager.AddRow(trigger);
                //commandSender.SendComandAsync(commandToSend);
            }
            else Console.WriteLine("No command/addres in textbox!!!");
        }

        public static byte[] HexStringToBytes(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return Array.Empty<byte>();

            // Убираем пробелы, тире и двоеточия
            hex = hex.Replace(" ", "")
                     .Replace("-", "")
                     .Replace(":", "");

            if (hex.Length % 2 != 0)
                throw new FormatException("Количество HEX-символов должно быть четным.");

            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        public static string ByteArrayToStringHEX(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "");
        }
        public static string ByteToStringHEX(byte data)
        {
            return BitConverter.ToString(new byte[] { data }).Replace("-", "");
        }


        private void buttonDeleteTrigger_Click(object sender, EventArgs e)
        {
            if(textBoxDeleteTrigger.Text != "")
            {
                byte[] address = HexStringToBytes(textBoxDeleteTrigger.Text);
                triggerGridManager.RemoveRow(address);
                triggerManager.DeleteTrigger(address);

            }
        }

        private void buttonWriteNewCountAndDelay_Click(object sender, EventArgs e)
        {
            if(textBoxCountSend.Text != "" && textBoxDelaySend.Text != "")
            {
                int.TryParse(textBoxCountSend.Text, out int countSend);
                commandSender.repeatCount = countSend;

                TimeSpan.TryParse(textBoxDelaySend.Text, out var delay);
                commandSender.delay = delay;
            }
        }

        private void buttonRestartTriggers_Click(object sender, EventArgs e)
        {
            triggerGridManager.RestartTriggers();
            triggerManager.RestartTriggers();
        }

        private void buttonbuttonteststatus_Click(object sender, EventArgs e)
        {
            byte[] addr = HexStringToBytes(textBoxSatAddress.Text);
            triggerGridManager.SetRowStatusSent(addr);
            triggerManager.ChangeTriggerStatusByAddress(addr, TriggerStatus.Sent);
        }

        private void checkBoxSendNextIfGetAck_CheckedChanged(object sender, EventArgs e)
        {
            fileSender.IsSendNextIfAck = checkBoxSendNextIfGetAck.Checked;
        }

        private void checkBoxSendRequestIfGetPacket_CheckedChanged(object sender, EventArgs e)
        {
            fileSender.IsSendRequestIfGetPacket = checkBoxSendRequestIfGetPacket.Checked;

        }

        private void buttonSelectPathFile_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку для сохранения";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.Combine(folderDialog.SelectedPath, "image.png");

                    fileSender.SetPathToSave(path);
                    buttonSendFileRequest.Enabled = true;
                }
            }
        }


    }
}
