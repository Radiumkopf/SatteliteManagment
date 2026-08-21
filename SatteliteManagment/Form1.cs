using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SatteliteManagment.Entities;
using SatteliteManagment.Services;
using SatteliteManagment.Telemetry;
using ScottPlot.MultiplotLayouts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatteliteManagment
{
    public partial class Form1 : Form
    {

        private readonly DuplexTcpClient _client = new DuplexTcpClient();


        private byte[] currentServerTxAddress = new byte[] {0xAA, 0xAA, 0xAA, 0xAA, 0xAA};
        private GridViewLogManager logSendingManager;
        private GridViewLogManager logRequestingManager;

        private CommandSender commandSender;        
        private TriggerGridViewManager triggerGridManager;
        private TriggerManager triggerManager;
        private FileSender fileSender;
        private PlotManager plotManager;
        private DeviceStatusManager deviceStatusManager;
        private DbServices dbSevrices;
        private string currentFilePath;
        private uint crc;

        public Form1()
        {
            InitializeComponent();

            _client.PacketReceived += OnAddressReceived;
            _client.ServerAddrChanged += OnServerAddrChanged;
            _client.CRCReceived += OnCRCReceived;
            _client.ReprogrammingResult += OnReprogResult;



            logSendingManager = new GridViewLogManager(this.logSendingGridView);
            logRequestingManager = new GridViewLogManager(this.logRequestingGridView);

            commandSender = new CommandSender(_client);

            triggerGridManager = new TriggerGridViewManager(dataGridViewTriggerState);

            triggerManager = new TriggerManager(triggerGridManager);

            fileSender = new FileSender(_client, logSendingManager, logRequestingManager);

            fileSender.SenderLastFileReceived += OnFullFileReceived;
            fileSender.SenderLastACKReceived += EnableCrcButton;

            InizializeDB();
            InizializeGraphs();
            InitializeDeviceStatusManager();


            maskedTextBoxIP.ValidatingType = typeof(System.Net.IPAddress);


        }

        private void InizializeDB()
        {
            var db = new AppDbContext();
            db.Database.Migrate();

            dbSevrices = new DbServices(db);




            var dbCreator = new DatabaseCreator();

            if (!dbCreator.TryInitialize())
            {
                MessageBox.Show(
                    "Подключение к базе данных недоступно.\n" +
                    "Функции работы с базой данных отключены.",
                    "Предупреждение");

                dbSevrices = null;
                checkBoxWriteTLMToDB.Enabled = false;
                TabPage dbPage =  tabControlMain.TabPages[4];
                dbPage.Enabled = false;
            }
            else
            {
                dbSevrices = new DbServices(dbCreator.Context);
                comboBoxEntityType.DataSource = Enum.GetValues(typeof(DbEntityType));
                dataGridViewEntities.AutoGenerateColumns = true;
                dataGridViewEntities.ReadOnly = true;
                dataGridViewEntities.AllowUserToAddRows = false;
                dataGridViewEntities.AllowUserToDeleteRows = false;

            }
        }

        private void InizializeGraphs()
        {
            //System.Windows.Forms.TextBox[] logTextBoxes = groupBoxTelemetryLog.Controls
            //    .OfType<System.Windows.Forms.TextBox>()
            //    .OrderBy(tb =>
            //    {
            //        Match match = Regex.Match(tb.Name, @"\d+$");
            //        return match.Success ? int.Parse(match.Value) : int.MaxValue;
            //    })
            //    .ToArray();

            System.Windows.Forms.TextBox[] logTextBoxes = new System.Windows.Forms.TextBox[]
            {
                textBoxTelemetry0, textBoxTelemetry1, textBoxTelemetry2, textBoxTelemetry3, textBoxTelemetry4,
                textBoxTelemetry5, textBoxTelemetry6, textBoxTelemetry7, textBoxTelemetry8, textBoxTelemetry9
            };

            if (dbSevrices != null)
            {
                plotManager = new PlotManager(_client, logTextBoxes, dbSevrices);
               
            }
            else
            {
                plotManager = new PlotManager(_client, logTextBoxes, null);
            }

            plotManager.EnableWriteToDB = false;

            comboBoxTelemetryType.DataSource = plotManager.sensors;
            comboBoxTelemetryType.DisplayMember = "Name";

            plotManager.GraphRefresh += RefreshGraph;

            formsPlotTelemetry.MouseMove += formsPlotTelemetry_MouseMove;
            formsPlotTelemetry.MouseLeave += formsPlotTelemetry_MouseLeave;
        }

        private void OnAddressReceived(PacketInfo packet)
        {
            BeginInvoke(new Action(() =>
            {
                byte[] satelliteAddress = BitConverter.GetBytes(packet.SourceAddr);

                if(!(satelliteAddress).SequenceEqual(currentServerTxAddress))
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
                            //triggerGridManager.SetRowStatusSent(trigger.address);
                            triggerManager.ChangeTriggerStatus(trigger, TriggerStatus.Sent);
                        }

                        Console.WriteLine("Команда отправлена, триггер сработал " + trigger.command);
                    }
                }
                else Console.WriteLine("Нужный триггер/адрес не найден!");

            }));
        }
        private void OnReprogResult(bool result)
        {
            BeginInvoke(new Action(() =>
            {
                if (result) {
                    MessageBox.Show("Перепрошивка прошла успешно! Ура!");
                }
                else
                {
                    MessageBox.Show("Сбой при перепрошивке.");      //FIXME дать возможность 
                                                                    //отправить запрос повторно 
                }
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

        private void OnCRCReceived(uint satCrc)
        {
            if (satCrc == crc)      //FIXME нормальную обработку и/или отправку уведа на сат
            {
                DialogResult result = MessageBox.Show(
                    "Контрольная сумма верная! Начать перепрошивку?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    fileSender.StartReprogramming();
                }
                else return;
            }
            else
            {
                MessageBox.Show("CRC не сходится :(\n" + satCrc.ToString());
            }
        }
        private void LogTextBoxWriteNewAddr(string who, byte[] addr) {

            logTextBox.AppendText(who);
            logTextBox.AppendText( " изменил TX-адрес: ");
            logTextBox.AppendText(DataConverter.ByteArrayToStringHEX(addr));
            logTextBox.AppendText(  Environment.NewLine );
        }

        //Обработчик успешно принятого файла
        private void OnFullFileReceived()
        {
            buttonSendFileRequest.Enabled = false;
            logTextBox.AppendText("Файл сохранен: " + currentFilePath);
            IsFilePathSet = false;
            dbSevrices.StoredFileService.SaveFileAsync(currentFilePath, currentServerTxAddress);
        }

        /// <summary>
        /// Server connection part
        /// </summary>
        /// <param name="stateServer"></param>
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
                    int port = (int)numericUpDownPort.Value;
                    string rawText = maskedTextBoxIP.Text.Replace(" ", "");
                    rawText = rawText.Replace(",", ".");

                    if (IPAddress.TryParse(rawText, out IPAddress ip))
                    {
                        await _client.ConnectAsync(ip.ToString(), port);
                        changeInterfaceState(true);
                        buttonOpenCloseServer.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Подключение к серверу не было выполнено. Проверьте, что сервер включен");
                    buttonOpenCloseServer.Enabled = true;
                    changeInterfaceState(false);
                }
            else
                changeInterfaceState(false);
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
            if (openFileDialog1.FileName == "")
                return;
            string path = openFileDialog1.FileName;

            byte[] dataArray = File.ReadAllBytes(path);

            crc = Crc32.CalculateFileVer2(path);
            labelCrc.Text = crc.ToString();
            labelCrcHex.Text = crc.ToString("X8");
            logTextBox.AppendText("FileCrc: " + crc.ToString());


            fileSender.SetAndSplitFile(dataArray, (byte)numericUpDownPacketSize.Value);

            if (buttonOpenCloseServer.Text == "Включить сервер" || labelComPortConnectionInfo.Text == "Выключено")
                connectToServer_Click(sender,e);


            sendOnePackageButton.Enabled = true;
            sendAllPackageButton.Enabled = true;

            numericUpDownPacketSize.Enabled = false;
            button1.Enabled = false;
            buttonDeleteCurrentFile.Enabled = true;
            buttonShowRawPackets.Enabled = true;
            //buttonVerifyCheckSum.Enabled = false;

        }


        private async void sendOnePackageButton_Click(object sender, EventArgs e)
        {

            fileSender.DestinationId = (byte)numericUpDownId.Value;
            fileSender.PacketSize = (byte)numericUpDownPacketSize.Value;

            await fileSender.SendNextPacketAsync();
        }

        private async void sendAllPackageButton_Click(object sender, EventArgs e)
        {

            fileSender.DestinationId = (byte)numericUpDownId.Value;
            fileSender.PacketSize = (byte)numericUpDownPacketSize.Value;

            await fileSender.SendAllAsync();
        } 
        private async void buttonSendFileRequest_Click(object sender, EventArgs e)
        {

            fileSender.DestinationId = (byte)numericUpDownId.Value;
            fileSender.PacketSize = (byte)numericUpDownPacketSize.Value;

            await fileSender.SendFileRequestAsync();
        }

        private bool IsFilePathSet = false;
        private void buttonSelectPathFile_Click(object sender, EventArgs e)
        {
            if (IsFilePathSet) {

                DialogResult result = MessageBox.Show(
                    "Запись уже началась.\nПри продолжении возможна потеря\nнекоторых полученных данных!",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
                //fileSender.RestartReceive();

            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Куда сохранить файл?";
                saveDialog.Filter = "Все файлы (*.*)|*.*";
                saveDialog.FileName = "received_file";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveDialog.FileName;  
                    IsFilePathSet = true;
                    fileSender.CurrentReceiveIndex = 0;
                    fileSender.SetPathToSave(path);
                    buttonSendFileRequest.Enabled = true;
                    this.currentFilePath = path;
                }
            }
        }

        private void buttonDeleteCurrentFile_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Удалить текущий файл?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                fileSender.ClearFileData();

                numericUpDownPacketSize.Enabled = true;
                button1.Enabled = true;
                sendOnePackageButton.Enabled = false;
                sendAllPackageButton.Enabled = false;
                buttonShowRawPackets.Enabled = false;
                labelCrc.Text = "-";
                labelCrcHex.Text = "-";
            }

        }
        private void buttonVerifyCheckSum_Click(object sender, EventArgs e)
        {
            fileSender.CheckSumVerify();

        }
        private void EnableCrcButton()
        {
            buttonVerifyCheckSum.Enabled = true;
        }

        private void checkBoxAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            logSendingManager.IsAutoScrollEnable = checkBoxAutoScroll.Checked;
            logRequestingManager.IsAutoScrollEnable = checkBoxAutoScroll.Checked;
        }

        private void comboBoxInOut_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxInOut.SelectedIndex == 0)
            {
                logSendingGridView.Visible = false;
                logRequestingGridView.Visible = true;
            }
            else
            {
                logSendingGridView.Visible = true;
                logRequestingGridView.Visible = false;
            }
        }
        private void checkBoxSendNextIfGetAck_CheckedChanged(object sender, EventArgs e)
        {
            fileSender.IsSendNextIfAck = checkBoxSendNextIfGetAck.Checked;
        }

        private void checkBoxSendRequestIfGetPacket_CheckedChanged(object sender, EventArgs e)
        {
            fileSender.IsSendRequestIfGetPacket = checkBoxSendRequestIfGetPacket.Checked;

        }

        private void testbutton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///  2. Triggers
        /// </summary>

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
                Trigger trigger = new Trigger(
                    DataConverter.HexStringToBytes(textBoxSatAddress.Text), 
                    DataConverter.HexStringToBytes(commandToSend));
                triggerManager.AddTrigger(trigger);
            }
            else Console.WriteLine("No command/addres in textbox!!!");
        }


        private void buttonDeleteTrigger_Click(object sender, EventArgs e)
        {
            if(textBoxDeleteTrigger.Text != "")
            {
                byte[] address = DataConverter.HexStringToBytes(textBoxDeleteTrigger.Text);
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
            triggerManager.RestartTriggers();
        }

        private void buttonbuttonteststatus_Click(object sender, EventArgs e)
        {
            byte[] addr = DataConverter.HexStringToBytes(textBoxSatAddress.Text);
            Trigger trigger = triggerManager.GetTriggerByAddress(addr);
            triggerManager.ChangeTriggerStatus(trigger, TriggerStatus.Sent);
        }



        /// <summary>
        /// 3. Telemetry Graph and Log
        /// </summary>

        private void comboBoxTelemetryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTelemetryType.SelectedItem is SensorGraph graph)
            {
                ShowGraph(graph);
            }
        }

        private const int VisiblePoints = 100;
        private SensorGraph _currentGraph;

        private readonly ToolTip _graphToolTip = new ToolTip
        {
            AutoPopDelay = 2000,
            InitialDelay = 0,
            ReshowDelay = 0,
            ShowAlways = true
        };

        private void RefreshGraph()
        {
            if (_currentGraph == null)
                return;

            DrawGraph(_currentGraph, autoscale: true);
        }

        private void ShowGraph(SensorGraph graph)
        {
            _currentGraph = graph;
            DrawGraph(graph, autoscale: true);
        }

        private void DrawGraph(SensorGraph graph, bool autoscale)
        {
            formsPlotTelemetry.Plot.Clear();

            foreach (var series in graph.Series)
            {
                float[] values = series.Values
                    .Skip(Math.Max(0, series.Values.Count - VisiblePoints))
                    .ToArray();

                formsPlotTelemetry.Plot.Add.Signal(values);
            }

            formsPlotTelemetry.Plot.ShowLegend();
            labelTelType.Text = graph.Name;

            if (autoscale)
                formsPlotTelemetry.Plot.Axes.AutoScale();

            formsPlotTelemetry.Refresh();
        }
        private void formsPlotTelemetry_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinates = formsPlotTelemetry.Plot.GetCoordinates(new ScottPlot.Pixel(e.X, e.Y));

            string text = $"X = {coordinates.X:0.###}\nY = {coordinates.Y:0.###}";

            _graphToolTip.Show(
                text,
                formsPlotTelemetry,
                e.Location.X + 15,
                e.Location.Y + 15,
                500);
        }
        private void formsPlotTelemetry_MouseLeave(object sender, EventArgs e)
        {
            _graphToolTip.Hide(formsPlotTelemetry);
        }
        private void buttonClearPlot_Click(object sender, EventArgs e)
        {
            formsPlotTelemetry.Plot.Clear();
        }
        private void checkBoxWriteTLMToDB_CheckedChanged(object sender, EventArgs e)
        {
            plotManager.EnableWriteToDB = checkBoxWriteTLMToDB.Checked;
        }


        private void InitializeDeviceStatusManager()
        {
            deviceStatusManager = new DeviceStatusManager(treeViewDevices, labelDeviceName, labelDeviceType, labelDeviceId, labelDeviceStatus, textBoxDeviceMetadata);
        }

        private void buttonLoadDeviceXml_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog xmlDialog = new OpenFileDialog())
            {
                xmlDialog.Filter = "XML files (*.xml)|*.xml";
                xmlDialog.Title = "Выберите XML конфигурации устройств";
                if (xmlDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    deviceStatusManager.LoadFromFile(xmlDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить XML: " + ex.Message);
                }
            }
        }

        private void buttonShowRawPackets_Click(object sender, EventArgs e)
        {
            FormSelectPacket dialogForm = new FormSelectPacket(fileSender);
            dialogForm.ShowDialog();
        }



        /// <summary>
        /// 5. DB View
        /// </summary>
        
        public enum DbEntityType
        {
            PacketInfo,
            TlmPacket,
            FileTransferPacket
        }

        private async Task<IReadOnlyList<IDataConvertable>> LoadLastEntitiesAsync(int count)
        {
            DbEntityType selectedType = (DbEntityType)comboBoxEntityType.SelectedItem;

            switch (selectedType)
            {
                case DbEntityType.PacketInfo:
                    return (await dbSevrices.PacketInfoService.GetLastAsync(count))
                        .Cast<IDataConvertable>()
                        .ToList();

                case DbEntityType.TlmPacket:
                    return (await dbSevrices.TlmPacketService.GetLastAsync(count))
                        .Cast<IDataConvertable>()
                        .ToList();

                case DbEntityType.FileTransferPacket:
                    return (await dbSevrices.FileTransferPacketService.GetLastAsync(count))
                        .Cast<IDataConvertable>().ToList();
                default:
                    return Array.Empty<IDataConvertable>();
            }
        }
        private async void buttonGetLast_Click(object sender, EventArgs e)
        {
            dataGridViewEntities.Columns.Clear();
            textBoxHexView.Clear();
            var entity =  await LoadLastEntitiesAsync(1);
            dataGridViewEntities.DataSource = EntityTableConverter.ToDataTable(entity);
            textBoxHexView.AppendText(DataConverter.ByteArrayToStringHEX(entity.First().ToByteArray()));
        }

        private async void buttonGetLastX_Click(object sender, EventArgs e)
        {
            dataGridViewEntities.Columns.Clear();
            textBoxHexView.Clear();
            var entity = await LoadLastEntitiesAsync((int)numericUpDownGetCount.Value);
            dataGridViewEntities.DataSource = EntityTableConverter.ToDataTable(entity);
        }


    }
}
