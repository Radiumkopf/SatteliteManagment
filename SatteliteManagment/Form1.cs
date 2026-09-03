using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SatteliteManagment.Entities;
using SatteliteManagment.Entities.LeafEntities;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
        private DatabaseCreator dbCreator;

        private DbServices dbServices;
        private string currentFilePath;
        private uint crc;
        private bool IsDbWritingEnable;

        private  Dictionary<DbEntityType, Func<int, Task<IReadOnlyList<IDbEntity>>>> _entityLoaders;
        public Form1()
        {
            InitializeComponent();

            InizializeDB();

            _client.PacketReceived += OnAddressReceived;
            _client.ServerAddrChanged += OnServerAddrChanged;
            _client.CRCReceived += OnCRCReceived;
            _client.ReprogrammingResult += OnReprogResult;

            logSendingManager = new GridViewLogManager(this.logSendingGridView);
            logRequestingManager = new GridViewLogManager(this.logRequestingGridView);

            commandSender = new CommandSender(_client);

            triggerGridManager = new TriggerGridViewManager(dataGridViewTriggerState);

            triggerManager = new TriggerManager(triggerGridManager);

            fileSender = new FileSender(_client, logSendingManager, logRequestingManager, dbServices);

            fileSender.SenderLastFileReceived += OnFullFileReceived;
            fileSender.SenderLastACKReceived += EnableCrcButton;

            maskedTextBoxIP.ValidatingType = typeof(System.Net.IPAddress);

            InizializeGraphs();
            InitializeDeviceStatusManager();

            LoadListEntityToDict();
            Image originalImage = Properties.Resources.save_data; 

            Bitmap zoomedImage = new Bitmap(originalImage, new Size(30, 30));

            checkBoxSaveToDb.Image = zoomedImage;
            checkBoxWriteTLMToDB.Image = zoomedImage;
            //checkBox1.TextImageRelation = TextImageRelation.ImageBeforeText;

        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            dbCreator?.Dispose();

            base.OnFormClosed(e);
        }
        public void LoadListEntityToDict()
        {
            _entityLoaders = new Dictionary<DbEntityType, Func<int, Task<IReadOnlyList<IDbEntity>>>>
            {
                {
                    DbEntityType.PacketInfo,
                    async count => (await dbServices.PacketInfoService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.TlmPacket,
                    async count => (await dbServices.TlmPacketService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.FileTransferPacket,
                    async count => (await dbServices.FileTransferPacketService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.FileRequest,
                    async count => (await dbServices.FileRequestService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.ModuleStatus,
                    async count => (await dbServices.ModuleStatusService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.MotorSpeed,
                    async count => (await dbServices.MotorSpeedService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.Reprogramming,
                    async count => (await dbServices.ReprogrammingService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.TimeSet,
                    async count => (await dbServices.TimeSetService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.VerifyCheckSum,
                    async count => (await dbServices.VerifyCheckSumService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.CoilMagnetMoment,
                    async count => (await dbServices.CoilMagnetMomentService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                }
            };
        }
        private void InizializeDB()
        {
            dbCreator = new DatabaseCreator();

            if (!dbCreator.TryInitialize())
            {
                MessageBox.Show(
                    "Подключение к базе данных недоступно.\n" +
                    "Функции работы с базой данных отключены.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dbServices = null;

                checkBoxWriteTLMToDB.Enabled = false;
                checkBoxSaveToDb.Enabled = false;

                tabControlMain.TabPages[4].Enabled = false;

                return;
            }

            // База успешно доступна и миграции применены
            dbServices = new DbServices(dbCreator.Context);

            comboBoxEntityType.DataSource =
                Enum.GetValues(typeof(DbEntityType));

            dataGridViewEntities.AutoGenerateColumns = true;
            dataGridViewEntities.ReadOnly = true;
            dataGridViewEntities.AllowUserToAddRows = false;
            dataGridViewEntities.AllowUserToDeleteRows = false;
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

            if (dbServices != null)
            {
                plotManager = new PlotManager(_client, logTextBoxes, dbServices);
               
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
                    DialogResult dialogResult = MessageBox.Show(
                        "Ошибки при перепрошивке. Отправить запрос повторно?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                         fileSender.StartReprogramming();
                    }
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

        private async void OnCRCReceived(uint satCrc)
        {
            if (satCrc == crc)      
            {
                DialogResult result = MessageBox.Show(
                    "Контрольная сумма верная! Начать перепрошивку?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await fileSender.StartReprogramming();
                }
                else return;
            }
            else
            {
                MessageBox.Show("CRC не сходится :(\n" + satCrc.ToString());
            }
            if (IsDbWritingEnable)
            {
                var vcse = await dbServices.VerifyCheckSumService.GetLastAsync();
                if (satCrc == crc)
                { 
                    vcse.Result = CommandResult.ACK;
                }
                else
                {
                    vcse.Result = CommandResult.NACK;
                }
                vcse.Crc = satCrc;
                await dbServices.VerifyCheckSumService.UpdateAsync(vcse);

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
            dbServices.StoredFileService.SaveFileAsync(currentFilePath, currentServerTxAddress);
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
            logSendingManager.ClearGrid();
            logRequestingManager.ClearGrid();
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
        private void checkBoxSaveToDb_CheckedChanged(object sender, EventArgs e)
        {
            fileSender.IsDbWritingEnable = checkBoxSaveToDb.Checked;
            this.IsDbWritingEnable = checkBoxSaveToDb.Checked;
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
            fileSender.IsSendRequestIfGetPacket = checkBoxSendNextIfGetAck.Checked;
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
              

        private async Task<IReadOnlyList<IDbEntity>> LoadLastEntitiesAsync(int count)
        {
            DbEntityType selectedType = (DbEntityType)comboBoxEntityType.SelectedItem;

            if (_entityLoaders.TryGetValue(selectedType, out var loader))
                return await loader(count);

            return Array.Empty<IDbEntity>();
        }
        private async void buttonGetLast_Click(object sender, EventArgs e)
        {
            dataGridViewEntities.Columns.Clear();
            textBoxHexView.Clear();
            var entity =  await LoadLastEntitiesAsync(1);
            dataGridViewEntities.DataSource = EntityTableConverter.ToDataTable(entity);
            //textBoxHexView.AppendText(DataConverter.ByteArrayToStringHEX(entity.First().ToByteArray()));
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
