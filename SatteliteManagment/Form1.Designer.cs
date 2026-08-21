using System.Drawing;
using System.Windows.Forms;

namespace SatteliteManagment
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxIP = new System.Windows.Forms.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.labelSnrInfoB = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelSnrInfoA = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOpenCloseServer = new System.Windows.Forms.Button();
            this.labelComPortConnectionInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRadioControl = new System.Windows.Forms.Panel();
            this.groupBoxLogTables = new System.Windows.Forms.GroupBox();
            this.logRequestingGridView = new System.Windows.Forms.DataGridView();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.comboBoxInOut = new System.Windows.Forms.ComboBox();
            this.logSendingGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxFileSending = new System.Windows.Forms.GroupBox();
            this.checkBoxSendRequestIfGetPacket = new System.Windows.Forms.CheckBox();
            this.labelCrcHex = new System.Windows.Forms.Label();
            this.checkBoxSendNextIfGetAck = new System.Windows.Forms.CheckBox();
            this.buttonSelectPathFile = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonVerifyCheckSum = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCrc = new System.Windows.Forms.Label();
            this.sendOnePackageButton = new System.Windows.Forms.Button();
            this.buttonShowRawPackets = new System.Windows.Forms.Button();
            this.sendAllPackageButton = new System.Windows.Forms.Button();
            this.buttonDeleteCurrentFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownPacketSize = new System.Windows.Forms.NumericUpDown();
            this.buttonSendFileRequest = new System.Windows.Forms.Button();
            this.numericUpDownId = new System.Windows.Forms.NumericUpDown();
            this.testbutton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageConn = new System.Windows.Forms.TabPage();
            this.tabPageSatellite = new System.Windows.Forms.TabPage();
            this.buttonbuttonteststatus = new System.Windows.Forms.Button();
            this.groupBoxTriggerPanel = new System.Windows.Forms.GroupBox();
            this.radioButtonSeparatorNothing1 = new System.Windows.Forms.RadioButton();
            this.radioButtonSeparatorDollar1 = new System.Windows.Forms.RadioButton();
            this.groupBoxDeleteTrigger = new System.Windows.Forms.GroupBox();
            this.buttonDeleteTrigger = new System.Windows.Forms.Button();
            this.textBoxDeleteTrigger = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSatAddress = new System.Windows.Forms.TextBox();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.buttonWriteCommand = new System.Windows.Forms.Button();
            this.buttonCreateCommand = new System.Windows.Forms.Button();
            this.groupBoxTriggerState = new System.Windows.Forms.GroupBox();
            this.labelTriggerState = new System.Windows.Forms.Label();
            this.dataGridViewTriggerState = new System.Windows.Forms.DataGridView();
            this.groupBoxTriggerSettings = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonRestartTriggers = new System.Windows.Forms.Button();
            this.buttonWriteNewCountAndDelay = new System.Windows.Forms.Button();
            this.textBoxDelaySend = new System.Windows.Forms.TextBox();
            this.textBoxCountSend = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxDisableTriggersAfterAct = new System.Windows.Forms.CheckBox();
            this.checkBoxTriggerEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxAskSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxWriteLog = new System.Windows.Forms.CheckBox();
            this.checkBoxAskZeroPacket = new System.Windows.Forms.CheckBox();
            this.checkBoxAskPhotoSize = new System.Windows.Forms.CheckBox();
            this.checkBoxAskNextPhotoPacket = new System.Windows.Forms.CheckBox();
            this.checkBoxRSSI = new System.Windows.Forms.CheckBox();
            this.tabPageTelemetry = new System.Windows.Forms.TabPage();
            this.groupBoxTelemetryPlots = new System.Windows.Forms.GroupBox();
            this.checkBoxWriteTLMToDB = new System.Windows.Forms.CheckBox();
            this.buttonClearPlot = new System.Windows.Forms.Button();
            this.labelTelType = new System.Windows.Forms.Label();
            this.formsPlotTelemetry = new ScottPlot.WinForms.FormsPlot();
            this.comboBoxTelemetryType = new System.Windows.Forms.ComboBox();
            this.groupBoxTelemetryLog = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxTelemetry0 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxTelemetry1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxTelemetry8 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxTelemetry7 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxTelemetry6 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxTelemetry5 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxTelemetry4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxTelemetry3 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxTelemetry2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxTelemetry9 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPageDeviceStatus = new System.Windows.Forms.TabPage();
            this.splitContainerDeviceStatus = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelDeviceTree = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLoadDeviceXml = new System.Windows.Forms.Button();
            this.treeViewDevices = new System.Windows.Forms.TreeView();
            this.groupBoxDeviceDetails = new System.Windows.Forms.GroupBox();
            this.textBoxDeviceMetadata = new System.Windows.Forms.TextBox();
            this.labelDeviceMetadataTitle = new System.Windows.Forms.Label();
            this.labelDeviceStatus = new System.Windows.Forms.Label();
            this.labelDeviceId = new System.Windows.Forms.Label();
            this.labelDeviceType = new System.Windows.Forms.Label();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.tabPageDBView = new System.Windows.Forms.TabPage();
            this.numericUpDownGetCount = new System.Windows.Forms.NumericUpDown();
            this.buttonGetLastX = new System.Windows.Forms.Button();
            this.buttonGetLast = new System.Windows.Forms.Button();
            this.comboBoxEntityType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewEntities = new System.Windows.Forms.DataGridView();
            this.textBoxHexView = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolTipAutoSendNextInfo = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRadioControl.SuspendLayout();
            this.groupBoxLogTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logRequestingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logSendingGridView)).BeginInit();
            this.groupBoxFileSending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownId)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageConn.SuspendLayout();
            this.tabPageSatellite.SuspendLayout();
            this.groupBoxTriggerPanel.SuspendLayout();
            this.groupBoxDeleteTrigger.SuspendLayout();
            this.groupBoxTriggerState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriggerState)).BeginInit();
            this.groupBoxTriggerSettings.SuspendLayout();
            this.groupBoxAskSettings.SuspendLayout();
            this.tabPageTelemetry.SuspendLayout();
            this.groupBoxTelemetryPlots.SuspendLayout();
            this.groupBoxTelemetryLog.SuspendLayout();
            this.tabPageDeviceStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDeviceStatus)).BeginInit();
            this.splitContainerDeviceStatus.Panel1.SuspendLayout();
            this.splitContainerDeviceStatus.Panel2.SuspendLayout();
            this.splitContainerDeviceStatus.SuspendLayout();
            this.tableLayoutPanelDeviceTree.SuspendLayout();
            this.groupBoxDeviceDetails.SuspendLayout();
            this.tabPageDBView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGetCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Location = new System.Drawing.Point(952, 2);
            this.buttonClearLogs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(111, 28);
            this.buttonClearLogs.TabIndex = 4;
            this.buttonClearLogs.Text = "Очистить";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.buttonClearLogs_Click);
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.maskedTextBoxIP);
            this.groupBoxConnection.Controls.Add(this.label38);
            this.groupBoxConnection.Controls.Add(this.label37);
            this.groupBoxConnection.Controls.Add(this.numericUpDownPort);
            this.groupBoxConnection.Controls.Add(this.labelSnrInfoB);
            this.groupBoxConnection.Controls.Add(this.label61);
            this.groupBoxConnection.Controls.Add(this.label6);
            this.groupBoxConnection.Controls.Add(this.labelSnrInfoA);
            this.groupBoxConnection.Controls.Add(this.label5);
            this.groupBoxConnection.Controls.Add(this.buttonOpenCloseServer);
            this.groupBoxConnection.Controls.Add(this.labelComPortConnectionInfo);
            this.groupBoxConnection.Controls.Add(this.pictureBox1);
            this.groupBoxConnection.Controls.Add(this.label4);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 4);
            this.groupBoxConnection.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxConnection.Size = new System.Drawing.Size(307, 135);
            this.groupBoxConnection.TabIndex = 6;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Подключение ";
            // 
            // maskedTextBoxIP
            // 
            this.maskedTextBoxIP.Location = new System.Drawing.Point(37, 56);
            this.maskedTextBoxIP.Mask = "000.000.000.000";
            this.maskedTextBoxIP.Name = "maskedTextBoxIP";
            this.maskedTextBoxIP.PromptChar = ' ';
            this.maskedTextBoxIP.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBoxIP.TabIndex = 20;
            this.maskedTextBoxIP.Text = "1270  0  1";
            this.maskedTextBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 56);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(22, 16);
            this.label38.TabIndex = 19;
            this.label38.Text = "IP:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(5, 92);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(43, 16);
            this.label37.TabIndex = 18;
            this.label37.Text = "Порт:";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(62, 90);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(75, 22);
            this.numericUpDownPort.TabIndex = 17;
            this.numericUpDownPort.Value = new decimal(new int[] {
            8924,
            0,
            0,
            0});
            // 
            // labelSnrInfoB
            // 
            this.labelSnrInfoB.AutoSize = true;
            this.labelSnrInfoB.Location = new System.Drawing.Point(284, 56);
            this.labelSnrInfoB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSnrInfoB.Name = "labelSnrInfoB";
            this.labelSnrInfoB.Size = new System.Drawing.Size(14, 16);
            this.labelSnrInfoB.TabIndex = 15;
            this.labelSnrInfoB.Text = "0";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(223, 56);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(53, 16);
            this.label61.TabIndex = 14;
            this.label61.Text = "RSSI B:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 16;
            // 
            // labelSnrInfoA
            // 
            this.labelSnrInfoA.AutoSize = true;
            this.labelSnrInfoA.Location = new System.Drawing.Point(284, 32);
            this.labelSnrInfoA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSnrInfoA.Name = "labelSnrInfoA";
            this.labelSnrInfoA.Size = new System.Drawing.Size(14, 16);
            this.labelSnrInfoA.TabIndex = 8;
            this.labelSnrInfoA.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "RSSI A:";
            // 
            // buttonOpenCloseServer
            // 
            this.buttonOpenCloseServer.Location = new System.Drawing.Point(145, 80);
            this.buttonOpenCloseServer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonOpenCloseServer.Name = "buttonOpenCloseServer";
            this.buttonOpenCloseServer.Size = new System.Drawing.Size(153, 36);
            this.buttonOpenCloseServer.TabIndex = 6;
            this.buttonOpenCloseServer.Text = "Включить сервер";
            this.buttonOpenCloseServer.UseVisualStyleBackColor = true;
            this.buttonOpenCloseServer.Click += new System.EventHandler(this.connectToServer_Click);
            // 
            // labelComPortConnectionInfo
            // 
            this.labelComPortConnectionInfo.AutoSize = true;
            this.labelComPortConnectionInfo.Location = new System.Drawing.Point(100, 28);
            this.labelComPortConnectionInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComPortConnectionInfo.Name = "labelComPortConnectionInfo";
            this.labelComPortConnectionInfo.Size = new System.Drawing.Size(109, 16);
            this.labelComPortConnectionInfo.TabIndex = 5;
            this.labelComPortConnectionInfo.Text = "Не подключено";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(65, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 22);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Статус:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Лог:";
            // 
            // panelRadioControl
            // 
            this.panelRadioControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRadioControl.Controls.Add(this.groupBoxLogTables);
            this.panelRadioControl.Controls.Add(this.groupBoxFileSending);
            this.panelRadioControl.Controls.Add(this.testbutton);
            this.panelRadioControl.Controls.Add(this.logTextBox);
            this.panelRadioControl.Controls.Add(this.label1);
            this.panelRadioControl.Controls.Add(this.groupBoxConnection);
            this.panelRadioControl.Controls.Add(this.buttonClearLogs);
            this.panelRadioControl.Location = new System.Drawing.Point(7, 5);
            this.panelRadioControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelRadioControl.Name = "panelRadioControl";
            this.panelRadioControl.Size = new System.Drawing.Size(1191, 544);
            this.panelRadioControl.TabIndex = 0;
            // 
            // groupBoxLogTables
            // 
            this.groupBoxLogTables.Controls.Add(this.logRequestingGridView);
            this.groupBoxLogTables.Controls.Add(this.checkBoxAutoScroll);
            this.groupBoxLogTables.Controls.Add(this.comboBoxInOut);
            this.groupBoxLogTables.Controls.Add(this.logSendingGridView);
            this.groupBoxLogTables.Location = new System.Drawing.Point(327, 148);
            this.groupBoxLogTables.Name = "groupBoxLogTables";
            this.groupBoxLogTables.Size = new System.Drawing.Size(861, 377);
            this.groupBoxLogTables.TabIndex = 28;
            this.groupBoxLogTables.TabStop = false;
            this.groupBoxLogTables.Text = "Пришло/Ушло";
            // 
            // logRequestingGridView
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.logRequestingGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.logRequestingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.logRequestingGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.logRequestingGridView.Location = new System.Drawing.Point(6, 64);
            this.logRequestingGridView.Name = "logRequestingGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.logRequestingGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.logRequestingGridView.RowHeadersWidth = 51;
            this.logRequestingGridView.RowTemplate.Height = 24;
            this.logRequestingGridView.Size = new System.Drawing.Size(740, 307);
            this.logRequestingGridView.TabIndex = 18;
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.BackgroundImage = global::SatteliteManagment.Properties.Resources._243_downarrow;
            this.checkBoxAutoScroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxAutoScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(169, 18);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(69, 29);
            this.checkBoxAutoScroll.TabIndex = 17;
            this.checkBoxAutoScroll.Text = "       ";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            this.checkBoxAutoScroll.CheckedChanged += new System.EventHandler(this.checkBoxAutoScroll_CheckedChanged);
            // 
            // comboBoxInOut
            // 
            this.comboBoxInOut.FormattingEnabled = true;
            this.comboBoxInOut.Items.AddRange(new object[] {
            "Пришло",
            "Ушло"});
            this.comboBoxInOut.Location = new System.Drawing.Point(6, 25);
            this.comboBoxInOut.Name = "comboBoxInOut";
            this.comboBoxInOut.Size = new System.Drawing.Size(121, 24);
            this.comboBoxInOut.TabIndex = 16;
            this.comboBoxInOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxInOut_SelectedIndexChanged_1);
            // 
            // logSendingGridView
            // 
            this.logSendingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logSendingGridView.Location = new System.Drawing.Point(6, 55);
            this.logSendingGridView.Name = "logSendingGridView";
            this.logSendingGridView.ReadOnly = true;
            this.logSendingGridView.RowHeadersWidth = 51;
            this.logSendingGridView.RowTemplate.Height = 24;
            this.logSendingGridView.Size = new System.Drawing.Size(740, 316);
            this.logSendingGridView.TabIndex = 15;
            // 
            // groupBoxFileSending
            // 
            this.groupBoxFileSending.Controls.Add(this.checkBoxSendRequestIfGetPacket);
            this.groupBoxFileSending.Controls.Add(this.labelCrcHex);
            this.groupBoxFileSending.Controls.Add(this.checkBoxSendNextIfGetAck);
            this.groupBoxFileSending.Controls.Add(this.buttonSelectPathFile);
            this.groupBoxFileSending.Controls.Add(this.label36);
            this.groupBoxFileSending.Controls.Add(this.label35);
            this.groupBoxFileSending.Controls.Add(this.button1);
            this.groupBoxFileSending.Controls.Add(this.buttonVerifyCheckSum);
            this.groupBoxFileSending.Controls.Add(this.label2);
            this.groupBoxFileSending.Controls.Add(this.labelCrc);
            this.groupBoxFileSending.Controls.Add(this.sendOnePackageButton);
            this.groupBoxFileSending.Controls.Add(this.buttonShowRawPackets);
            this.groupBoxFileSending.Controls.Add(this.sendAllPackageButton);
            this.groupBoxFileSending.Controls.Add(this.buttonDeleteCurrentFile);
            this.groupBoxFileSending.Controls.Add(this.label3);
            this.groupBoxFileSending.Controls.Add(this.numericUpDownPacketSize);
            this.groupBoxFileSending.Controls.Add(this.buttonSendFileRequest);
            this.groupBoxFileSending.Controls.Add(this.numericUpDownId);
            this.groupBoxFileSending.Location = new System.Drawing.Point(12, 145);
            this.groupBoxFileSending.Name = "groupBoxFileSending";
            this.groupBoxFileSending.Size = new System.Drawing.Size(307, 380);
            this.groupBoxFileSending.TabIndex = 27;
            this.groupBoxFileSending.TabStop = false;
            this.groupBoxFileSending.Text = "Чтение/запись";
            // 
            // checkBoxSendRequestIfGetPacket
            // 
            this.checkBoxSendRequestIfGetPacket.AutoSize = true;
            this.checkBoxSendRequestIfGetPacket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSendRequestIfGetPacket.Location = new System.Drawing.Point(6, 349);
            this.checkBoxSendRequestIfGetPacket.Name = "checkBoxSendRequestIfGetPacket";
            this.checkBoxSendRequestIfGetPacket.Size = new System.Drawing.Size(412, 20);
            this.checkBoxSendRequestIfGetPacket.TabIndex = 0;
            this.checkBoxSendRequestIfGetPacket.Text = "Отправлять запрос автоматически при получении пакета";
            this.checkBoxSendRequestIfGetPacket.UseVisualStyleBackColor = true;
            this.checkBoxSendRequestIfGetPacket.CheckedChanged += new System.EventHandler(this.checkBoxSendRequestIfGetPacket_CheckedChanged);
            // 
            // labelCrcHex
            // 
            this.labelCrcHex.AutoSize = true;
            this.labelCrcHex.Location = new System.Drawing.Point(186, 78);
            this.labelCrcHex.Name = "labelCrcHex";
            this.labelCrcHex.Size = new System.Drawing.Size(11, 16);
            this.labelCrcHex.TabIndex = 28;
            this.labelCrcHex.Text = "-";
            // 
            // checkBoxSendNextIfGetAck
            // 
            this.checkBoxSendNextIfGetAck.AutoSize = true;
            this.checkBoxSendNextIfGetAck.BackgroundImage = global::SatteliteManagment.Properties.Resources.cyclearrow;
            this.checkBoxSendNextIfGetAck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxSendNextIfGetAck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSendNextIfGetAck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSendNextIfGetAck.Location = new System.Drawing.Point(5, 268);
            this.checkBoxSendNextIfGetAck.Name = "checkBoxSendNextIfGetAck";
            this.checkBoxSendNextIfGetAck.Size = new System.Drawing.Size(74, 29);
            this.checkBoxSendNextIfGetAck.TabIndex = 0;
            this.checkBoxSendNextIfGetAck.Text = "        ";
            this.checkBoxSendNextIfGetAck.UseVisualStyleBackColor = true;
            this.checkBoxSendNextIfGetAck.CheckedChanged += new System.EventHandler(this.checkBoxSendNextIfGetAck_CheckedChanged);
            // 
            // buttonSelectPathFile
            // 
            this.buttonSelectPathFile.BackColor = System.Drawing.Color.LightBlue;
            this.buttonSelectPathFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSelectPathFile.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.buttonSelectPathFile.FlatAppearance.BorderSize = 2;
            this.buttonSelectPathFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectPathFile.Location = new System.Drawing.Point(145, 294);
            this.buttonSelectPathFile.Name = "buttonSelectPathFile";
            this.buttonSelectPathFile.Size = new System.Drawing.Size(153, 49);
            this.buttonSelectPathFile.TabIndex = 20;
            this.buttonSelectPathFile.Text = "Указать путь для сохранения";
            this.buttonSelectPathFile.UseVisualStyleBackColor = false;
            this.buttonSelectPathFile.Click += new System.EventHandler(this.buttonSelectPathFile_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(124, 78);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(37, 16);
            this.label36.TabIndex = 27;
            this.label36.Text = "HEX:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(124, 58);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(38, 16);
            this.label35.TabIndex = 27;
            this.label35.Text = "CRC:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Чтение данных из файла";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonVerifyCheckSum
            // 
            this.buttonVerifyCheckSum.Location = new System.Drawing.Point(3, 198);
            this.buttonVerifyCheckSum.Name = "buttonVerifyCheckSum";
            this.buttonVerifyCheckSum.Size = new System.Drawing.Size(134, 32);
            this.buttonVerifyCheckSum.TabIndex = 26;
            this.buttonVerifyCheckSum.Text = "Проверить CRC";
            this.buttonVerifyCheckSum.UseVisualStyleBackColor = true;
            this.buttonVerifyCheckSum.Click += new System.EventHandler(this.buttonVerifyCheckSum_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Размер пакета";
            // 
            // labelCrc
            // 
            this.labelCrc.AutoSize = true;
            this.labelCrc.Location = new System.Drawing.Point(186, 58);
            this.labelCrc.Name = "labelCrc";
            this.labelCrc.Size = new System.Drawing.Size(11, 16);
            this.labelCrc.TabIndex = 25;
            this.labelCrc.Text = "-";
            // 
            // sendOnePackageButton
            // 
            this.sendOnePackageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendOnePackageButton.Enabled = false;
            this.sendOnePackageButton.Location = new System.Drawing.Point(145, 131);
            this.sendOnePackageButton.Name = "sendOnePackageButton";
            this.sendOnePackageButton.Size = new System.Drawing.Size(153, 48);
            this.sendOnePackageButton.TabIndex = 13;
            this.sendOnePackageButton.Text = "Отправить следующий пакет";
            this.sendOnePackageButton.UseVisualStyleBackColor = true;
            this.sendOnePackageButton.Click += new System.EventHandler(this.sendOnePackageButton_Click);
            // 
            // buttonShowRawPackets
            // 
            this.buttonShowRawPackets.Location = new System.Drawing.Point(3, 160);
            this.buttonShowRawPackets.Name = "buttonShowRawPackets";
            this.buttonShowRawPackets.Size = new System.Drawing.Size(107, 31);
            this.buttonShowRawPackets.TabIndex = 24;
            this.buttonShowRawPackets.Text = "Выбор пакета";
            this.buttonShowRawPackets.UseVisualStyleBackColor = true;
            this.buttonShowRawPackets.Click += new System.EventHandler(this.buttonShowRawPackets_Click);
            // 
            // sendAllPackageButton
            // 
            this.sendAllPackageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendAllPackageButton.Enabled = false;
            this.sendAllPackageButton.Location = new System.Drawing.Point(145, 185);
            this.sendAllPackageButton.Name = "sendAllPackageButton";
            this.sendAllPackageButton.Size = new System.Drawing.Size(153, 48);
            this.sendAllPackageButton.TabIndex = 14;
            this.sendAllPackageButton.Text = "Отправить все оставшиеся пакеты";
            this.sendAllPackageButton.UseVisualStyleBackColor = true;
            this.sendAllPackageButton.Click += new System.EventHandler(this.sendAllPackageButton_Click);
            // 
            // buttonDeleteCurrentFile
            // 
            this.buttonDeleteCurrentFile.BackColor = System.Drawing.Color.LightCoral;
            this.buttonDeleteCurrentFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDeleteCurrentFile.BackgroundImage")));
            this.buttonDeleteCurrentFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDeleteCurrentFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteCurrentFile.Enabled = false;
            this.buttonDeleteCurrentFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonDeleteCurrentFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.buttonDeleteCurrentFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteCurrentFile.Location = new System.Drawing.Point(274, 22);
            this.buttonDeleteCurrentFile.Name = "buttonDeleteCurrentFile";
            this.buttonDeleteCurrentFile.Size = new System.Drawing.Size(27, 28);
            this.buttonDeleteCurrentFile.TabIndex = 23;
            this.buttonDeleteCurrentFile.UseVisualStyleBackColor = false;
            this.buttonDeleteCurrentFile.Click += new System.EventHandler(this.buttonDeleteCurrentFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "ID назначения";
            // 
            // numericUpDownPacketSize
            // 
            this.numericUpDownPacketSize.Location = new System.Drawing.Point(5, 81);
            this.numericUpDownPacketSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownPacketSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPacketSize.Name = "numericUpDownPacketSize";
            this.numericUpDownPacketSize.Size = new System.Drawing.Size(102, 22);
            this.numericUpDownPacketSize.TabIndex = 22;
            this.numericUpDownPacketSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonSendFileRequest
            // 
            this.buttonSendFileRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendFileRequest.Enabled = false;
            this.buttonSendFileRequest.Location = new System.Drawing.Point(145, 239);
            this.buttonSendFileRequest.Name = "buttonSendFileRequest";
            this.buttonSendFileRequest.Size = new System.Drawing.Size(153, 49);
            this.buttonSendFileRequest.TabIndex = 19;
            this.buttonSendFileRequest.Text = "Отправить запрос на получение файла";
            this.buttonSendFileRequest.UseVisualStyleBackColor = true;
            this.buttonSendFileRequest.Click += new System.EventHandler(this.buttonSendFileRequest_Click);
            // 
            // numericUpDownId
            // 
            this.numericUpDownId.Location = new System.Drawing.Point(5, 131);
            this.numericUpDownId.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownId.Name = "numericUpDownId";
            this.numericUpDownId.Size = new System.Drawing.Size(102, 22);
            this.numericUpDownId.TabIndex = 21;
            // 
            // testbutton
            // 
            this.testbutton.Location = new System.Drawing.Point(820, 10);
            this.testbutton.Name = "testbutton";
            this.testbutton.Size = new System.Drawing.Size(75, 23);
            this.testbutton.TabIndex = 16;
            this.testbutton.Text = "buttontest";
            this.testbutton.UseVisualStyleBackColor = true;
            this.testbutton.Visible = false;
            this.testbutton.Click += new System.EventHandler(this.testbutton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(327, 60);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(736, 79);
            this.logTextBox.TabIndex = 12;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageConn);
            this.tabControlMain.Controls.Add(this.tabPageSatellite);
            this.tabControlMain.Controls.Add(this.tabPageTelemetry);
            this.tabControlMain.Controls.Add(this.tabPageDeviceStatus);
            this.tabControlMain.Controls.Add(this.tabPageDBView);
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlMain.Location = new System.Drawing.Point(12, 2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1213, 597);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageConn
            // 
            this.tabPageConn.Controls.Add(this.panelRadioControl);
            this.tabPageConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageConn.Location = new System.Drawing.Point(4, 29);
            this.tabPageConn.Name = "tabPageConn";
            this.tabPageConn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConn.Size = new System.Drawing.Size(1205, 564);
            this.tabPageConn.TabIndex = 0;
            this.tabPageConn.Text = "Client Connection";
            this.tabPageConn.UseVisualStyleBackColor = true;
            // 
            // tabPageSatellite
            // 
            this.tabPageSatellite.Controls.Add(this.buttonbuttonteststatus);
            this.tabPageSatellite.Controls.Add(this.groupBoxTriggerPanel);
            this.tabPageSatellite.Controls.Add(this.groupBoxTriggerState);
            this.tabPageSatellite.Controls.Add(this.groupBoxTriggerSettings);
            this.tabPageSatellite.Controls.Add(this.groupBoxAskSettings);
            this.tabPageSatellite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageSatellite.Location = new System.Drawing.Point(4, 29);
            this.tabPageSatellite.Name = "tabPageSatellite";
            this.tabPageSatellite.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSatellite.Size = new System.Drawing.Size(1205, 564);
            this.tabPageSatellite.TabIndex = 1;
            this.tabPageSatellite.Text = "Triggers Info";
            this.tabPageSatellite.UseVisualStyleBackColor = true;
            // 
            // buttonbuttonteststatus
            // 
            this.buttonbuttonteststatus.BackColor = System.Drawing.Color.Silver;
            this.buttonbuttonteststatus.Location = new System.Drawing.Point(568, 255);
            this.buttonbuttonteststatus.Name = "buttonbuttonteststatus";
            this.buttonbuttonteststatus.Size = new System.Drawing.Size(143, 23);
            this.buttonbuttonteststatus.TabIndex = 4;
            this.buttonbuttonteststatus.Text = "buttonteststatus";
            this.buttonbuttonteststatus.UseVisualStyleBackColor = false;
            this.buttonbuttonteststatus.Click += new System.EventHandler(this.buttonbuttonteststatus_Click);
            // 
            // groupBoxTriggerPanel
            // 
            this.groupBoxTriggerPanel.Controls.Add(this.radioButtonSeparatorNothing1);
            this.groupBoxTriggerPanel.Controls.Add(this.radioButtonSeparatorDollar1);
            this.groupBoxTriggerPanel.Controls.Add(this.groupBoxDeleteTrigger);
            this.groupBoxTriggerPanel.Controls.Add(this.label13);
            this.groupBoxTriggerPanel.Controls.Add(this.label10);
            this.groupBoxTriggerPanel.Controls.Add(this.textBoxSatAddress);
            this.groupBoxTriggerPanel.Controls.Add(this.textBoxCommand);
            this.groupBoxTriggerPanel.Controls.Add(this.buttonWriteCommand);
            this.groupBoxTriggerPanel.Controls.Add(this.buttonCreateCommand);
            this.groupBoxTriggerPanel.Location = new System.Drawing.Point(337, 297);
            this.groupBoxTriggerPanel.Name = "groupBoxTriggerPanel";
            this.groupBoxTriggerPanel.Size = new System.Drawing.Size(862, 211);
            this.groupBoxTriggerPanel.TabIndex = 3;
            this.groupBoxTriggerPanel.TabStop = false;
            this.groupBoxTriggerPanel.Text = "Панель триггеров";
            // 
            // radioButtonSeparatorNothing1
            // 
            this.radioButtonSeparatorNothing1.AutoSize = true;
            this.radioButtonSeparatorNothing1.Location = new System.Drawing.Point(291, 179);
            this.radioButtonSeparatorNothing1.Name = "radioButtonSeparatorNothing1";
            this.radioButtonSeparatorNothing1.Size = new System.Drawing.Size(149, 22);
            this.radioButtonSeparatorNothing1.TabIndex = 5;
            this.radioButtonSeparatorNothing1.Text = "Без разделителя";
            this.radioButtonSeparatorNothing1.UseVisualStyleBackColor = true;
            // 
            // radioButtonSeparatorDollar1
            // 
            this.radioButtonSeparatorDollar1.AutoSize = true;
            this.radioButtonSeparatorDollar1.Checked = true;
            this.radioButtonSeparatorDollar1.Location = new System.Drawing.Point(291, 150);
            this.radioButtonSeparatorDollar1.Name = "radioButtonSeparatorDollar1";
            this.radioButtonSeparatorDollar1.Size = new System.Drawing.Size(133, 22);
            this.radioButtonSeparatorDollar1.TabIndex = 4;
            this.radioButtonSeparatorDollar1.TabStop = true;
            this.radioButtonSeparatorDollar1.Text = "Разделитель $";
            this.radioButtonSeparatorDollar1.UseVisualStyleBackColor = true;
            // 
            // groupBoxDeleteTrigger
            // 
            this.groupBoxDeleteTrigger.Controls.Add(this.buttonDeleteTrigger);
            this.groupBoxDeleteTrigger.Controls.Add(this.textBoxDeleteTrigger);
            this.groupBoxDeleteTrigger.Controls.Add(this.label11);
            this.groupBoxDeleteTrigger.Location = new System.Drawing.Point(716, 21);
            this.groupBoxDeleteTrigger.Name = "groupBoxDeleteTrigger";
            this.groupBoxDeleteTrigger.Size = new System.Drawing.Size(140, 190);
            this.groupBoxDeleteTrigger.TabIndex = 3;
            this.groupBoxDeleteTrigger.TabStop = false;
            this.groupBoxDeleteTrigger.Text = "Удалить триггер";
            // 
            // buttonDeleteTrigger
            // 
            this.buttonDeleteTrigger.BackColor = System.Drawing.Color.LightCoral;
            this.buttonDeleteTrigger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteTrigger.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonDeleteTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteTrigger.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteTrigger.Location = new System.Drawing.Point(10, 134);
            this.buttonDeleteTrigger.Name = "buttonDeleteTrigger";
            this.buttonDeleteTrigger.Size = new System.Drawing.Size(124, 41);
            this.buttonDeleteTrigger.TabIndex = 2;
            this.buttonDeleteTrigger.Text = "Удалить";
            this.buttonDeleteTrigger.UseVisualStyleBackColor = false;
            this.buttonDeleteTrigger.Click += new System.EventHandler(this.buttonDeleteTrigger_Click);
            // 
            // textBoxDeleteTrigger
            // 
            this.textBoxDeleteTrigger.Location = new System.Drawing.Point(6, 91);
            this.textBoxDeleteTrigger.Name = "textBoxDeleteTrigger";
            this.textBoxDeleteTrigger.Size = new System.Drawing.Size(100, 24);
            this.textBoxDeleteTrigger.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "ID триггера";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(288, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 18);
            this.label13.TabIndex = 2;
            this.label13.Text = "Адрес спутника:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(456, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "Команда для записи:";
            // 
            // textBoxSatAddress
            // 
            this.textBoxSatAddress.Location = new System.Drawing.Point(291, 112);
            this.textBoxSatAddress.Name = "textBoxSatAddress";
            this.textBoxSatAddress.Size = new System.Drawing.Size(149, 24);
            this.textBoxSatAddress.TabIndex = 1;
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(459, 112);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(241, 24);
            this.textBoxCommand.TabIndex = 1;
            // 
            // buttonWriteCommand
            // 
            this.buttonWriteCommand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWriteCommand.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonWriteCommand.FlatAppearance.BorderSize = 3;
            this.buttonWriteCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWriteCommand.Location = new System.Drawing.Point(459, 155);
            this.buttonWriteCommand.Name = "buttonWriteCommand";
            this.buttonWriteCommand.Size = new System.Drawing.Size(241, 41);
            this.buttonWriteCommand.TabIndex = 0;
            this.buttonWriteCommand.Text = "Записать команду";
            this.buttonWriteCommand.UseVisualStyleBackColor = true;
            this.buttonWriteCommand.Click += new System.EventHandler(this.buttonWriteCommand_Click);
            // 
            // buttonCreateCommand
            // 
            this.buttonCreateCommand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateCommand.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonCreateCommand.FlatAppearance.BorderSize = 3;
            this.buttonCreateCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateCommand.Location = new System.Drawing.Point(459, 21);
            this.buttonCreateCommand.Name = "buttonCreateCommand";
            this.buttonCreateCommand.Size = new System.Drawing.Size(241, 41);
            this.buttonCreateCommand.TabIndex = 0;
            this.buttonCreateCommand.Text = "Создать команду";
            this.buttonCreateCommand.UseVisualStyleBackColor = true;
            // 
            // groupBoxTriggerState
            // 
            this.groupBoxTriggerState.Controls.Add(this.labelTriggerState);
            this.groupBoxTriggerState.Controls.Add(this.dataGridViewTriggerState);
            this.groupBoxTriggerState.Location = new System.Drawing.Point(558, 20);
            this.groupBoxTriggerState.Name = "groupBoxTriggerState";
            this.groupBoxTriggerState.Size = new System.Drawing.Size(641, 210);
            this.groupBoxTriggerState.TabIndex = 2;
            this.groupBoxTriggerState.TabStop = false;
            this.groupBoxTriggerState.Text = "Состояние триггеров";
            // 
            // labelTriggerState
            // 
            this.labelTriggerState.AutoSize = true;
            this.labelTriggerState.Location = new System.Drawing.Point(7, 20);
            this.labelTriggerState.Name = "labelTriggerState";
            this.labelTriggerState.Size = new System.Drawing.Size(267, 18);
            this.labelTriggerState.TabIndex = 1;
            this.labelTriggerState.Text = "Состояние: ожидание приема пакета";
            // 
            // dataGridViewTriggerState
            // 
            this.dataGridViewTriggerState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTriggerState.Location = new System.Drawing.Point(7, 42);
            this.dataGridViewTriggerState.Name = "dataGridViewTriggerState";
            this.dataGridViewTriggerState.RowHeadersWidth = 51;
            this.dataGridViewTriggerState.RowTemplate.Height = 24;
            this.dataGridViewTriggerState.Size = new System.Drawing.Size(628, 162);
            this.dataGridViewTriggerState.TabIndex = 0;
            // 
            // groupBoxTriggerSettings
            // 
            this.groupBoxTriggerSettings.Controls.Add(this.label12);
            this.groupBoxTriggerSettings.Controls.Add(this.buttonRestartTriggers);
            this.groupBoxTriggerSettings.Controls.Add(this.buttonWriteNewCountAndDelay);
            this.groupBoxTriggerSettings.Controls.Add(this.textBoxDelaySend);
            this.groupBoxTriggerSettings.Controls.Add(this.textBoxCountSend);
            this.groupBoxTriggerSettings.Controls.Add(this.label9);
            this.groupBoxTriggerSettings.Controls.Add(this.label8);
            this.groupBoxTriggerSettings.Controls.Add(this.label7);
            this.groupBoxTriggerSettings.Controls.Add(this.checkBoxDisableTriggersAfterAct);
            this.groupBoxTriggerSettings.Controls.Add(this.checkBoxTriggerEnable);
            this.groupBoxTriggerSettings.Location = new System.Drawing.Point(8, 236);
            this.groupBoxTriggerSettings.Name = "groupBoxTriggerSettings";
            this.groupBoxTriggerSettings.Size = new System.Drawing.Size(323, 265);
            this.groupBoxTriggerSettings.TabIndex = 1;
            this.groupBoxTriggerSettings.TabStop = false;
            this.groupBoxTriggerSettings.Text = "Настройка триггеров";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 18);
            this.label12.TabIndex = 4;
            this.label12.Text = "триггеры ответят:";
            // 
            // buttonRestartTriggers
            // 
            this.buttonRestartTriggers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRestartTriggers.Location = new System.Drawing.Point(0, 226);
            this.buttonRestartTriggers.Name = "buttonRestartTriggers";
            this.buttonRestartTriggers.Size = new System.Drawing.Size(194, 33);
            this.buttonRestartTriggers.TabIndex = 3;
            this.buttonRestartTriggers.Text = "Перезапустить триггеры";
            this.buttonRestartTriggers.UseVisualStyleBackColor = true;
            this.buttonRestartTriggers.Click += new System.EventHandler(this.buttonRestartTriggers_Click);
            // 
            // buttonWriteNewCountAndDelay
            // 
            this.buttonWriteNewCountAndDelay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWriteNewCountAndDelay.Location = new System.Drawing.Point(0, 149);
            this.buttonWriteNewCountAndDelay.Name = "buttonWriteNewCountAndDelay";
            this.buttonWriteNewCountAndDelay.Size = new System.Drawing.Size(194, 51);
            this.buttonWriteNewCountAndDelay.TabIndex = 3;
            this.buttonWriteNewCountAndDelay.Text = "Записать новые значения";
            this.buttonWriteNewCountAndDelay.UseVisualStyleBackColor = true;
            this.buttonWriteNewCountAndDelay.Click += new System.EventHandler(this.buttonWriteNewCountAndDelay_Click);
            // 
            // textBoxDelaySend
            // 
            this.textBoxDelaySend.Location = new System.Drawing.Point(5, 125);
            this.textBoxDelaySend.Name = "textBoxDelaySend";
            this.textBoxDelaySend.Size = new System.Drawing.Size(76, 24);
            this.textBoxDelaySend.TabIndex = 2;
            this.textBoxDelaySend.Text = "00:00:00";
            // 
            // textBoxCountSend
            // 
            this.textBoxCountSend.Location = new System.Drawing.Point(5, 97);
            this.textBoxCountSend.Name = "textBoxCountSend";
            this.textBoxCountSend.Size = new System.Drawing.Size(76, 24);
            this.textBoxCountSend.TabIndex = 2;
            this.textBoxCountSend.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "сек";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "раз(а) с задержкой";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "На один пакет ";
            // 
            // checkBoxDisableTriggersAfterAct
            // 
            this.checkBoxDisableTriggersAfterAct.AutoSize = true;
            this.checkBoxDisableTriggersAfterAct.Checked = true;
            this.checkBoxDisableTriggersAfterAct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisableTriggersAfterAct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxDisableTriggersAfterAct.Location = new System.Drawing.Point(5, 206);
            this.checkBoxDisableTriggersAfterAct.Name = "checkBoxDisableTriggersAfterAct";
            this.checkBoxDisableTriggersAfterAct.Size = new System.Drawing.Size(323, 22);
            this.checkBoxDisableTriggersAfterAct.TabIndex = 0;
            this.checkBoxDisableTriggersAfterAct.Text = "Отключить триггеры после срабатывания";
            this.checkBoxDisableTriggersAfterAct.UseVisualStyleBackColor = true;
            // 
            // checkBoxTriggerEnable
            // 
            this.checkBoxTriggerEnable.AutoSize = true;
            this.checkBoxTriggerEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxTriggerEnable.Location = new System.Drawing.Point(5, 23);
            this.checkBoxTriggerEnable.Name = "checkBoxTriggerEnable";
            this.checkBoxTriggerEnable.Size = new System.Drawing.Size(169, 22);
            this.checkBoxTriggerEnable.TabIndex = 0;
            this.checkBoxTriggerEnable.Text = "Триггеры включены";
            this.checkBoxTriggerEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxAskSettings
            // 
            this.groupBoxAskSettings.Controls.Add(this.checkBoxWriteLog);
            this.groupBoxAskSettings.Controls.Add(this.checkBoxAskZeroPacket);
            this.groupBoxAskSettings.Controls.Add(this.checkBoxAskPhotoSize);
            this.groupBoxAskSettings.Controls.Add(this.checkBoxAskNextPhotoPacket);
            this.groupBoxAskSettings.Controls.Add(this.checkBoxRSSI);
            this.groupBoxAskSettings.Location = new System.Drawing.Point(6, 20);
            this.groupBoxAskSettings.Name = "groupBoxAskSettings";
            this.groupBoxAskSettings.Size = new System.Drawing.Size(489, 210);
            this.groupBoxAskSettings.TabIndex = 0;
            this.groupBoxAskSettings.TabStop = false;
            this.groupBoxAskSettings.Text = "Панель настроек";
            // 
            // checkBoxWriteLog
            // 
            this.checkBoxWriteLog.AutoSize = true;
            this.checkBoxWriteLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxWriteLog.Location = new System.Drawing.Point(6, 126);
            this.checkBoxWriteLog.Name = "checkBoxWriteLog";
            this.checkBoxWriteLog.Size = new System.Drawing.Size(238, 22);
            this.checkBoxWriteLog.TabIndex = 0;
            this.checkBoxWriteLog.Text = "Писать лог общения с платой";
            this.checkBoxWriteLog.UseVisualStyleBackColor = true;
            // 
            // checkBoxAskZeroPacket
            // 
            this.checkBoxAskZeroPacket.AutoSize = true;
            this.checkBoxAskZeroPacket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAskZeroPacket.Location = new System.Drawing.Point(6, 100);
            this.checkBoxAskZeroPacket.Name = "checkBoxAskZeroPacket";
            this.checkBoxAskZeroPacket.Size = new System.Drawing.Size(324, 22);
            this.checkBoxAskZeroPacket.TabIndex = 0;
            this.checkBoxAskZeroPacket.Text = "Запрашивать нулевой пакет при создании";
            this.checkBoxAskZeroPacket.UseVisualStyleBackColor = true;
            // 
            // checkBoxAskPhotoSize
            // 
            this.checkBoxAskPhotoSize.AutoSize = true;
            this.checkBoxAskPhotoSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAskPhotoSize.Location = new System.Drawing.Point(6, 74);
            this.checkBoxAskPhotoSize.Name = "checkBoxAskPhotoSize";
            this.checkBoxAskPhotoSize.Size = new System.Drawing.Size(307, 22);
            this.checkBoxAskPhotoSize.TabIndex = 0;
            this.checkBoxAskPhotoSize.Text = "Запрашивать длину фото при создании";
            this.checkBoxAskPhotoSize.UseVisualStyleBackColor = true;
            // 
            // checkBoxAskNextPhotoPacket
            // 
            this.checkBoxAskNextPhotoPacket.AutoSize = true;
            this.checkBoxAskNextPhotoPacket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAskNextPhotoPacket.Location = new System.Drawing.Point(6, 48);
            this.checkBoxAskNextPhotoPacket.Name = "checkBoxAskNextPhotoPacket";
            this.checkBoxAskNextPhotoPacket.Size = new System.Drawing.Size(294, 22);
            this.checkBoxAskNextPhotoPacket.TabIndex = 0;
            this.checkBoxAskNextPhotoPacket.Text = "Запрашивать следющие пакеты фото";
            this.checkBoxAskNextPhotoPacket.UseVisualStyleBackColor = true;
            // 
            // checkBoxRSSI
            // 
            this.checkBoxRSSI.AutoSize = true;
            this.checkBoxRSSI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxRSSI.Location = new System.Drawing.Point(7, 22);
            this.checkBoxRSSI.Name = "checkBoxRSSI";
            this.checkBoxRSSI.Size = new System.Drawing.Size(203, 22);
            this.checkBoxRSSI.TabIndex = 0;
            this.checkBoxRSSI.Text = "Получать значения RSSI";
            this.checkBoxRSSI.UseVisualStyleBackColor = true;
            // 
            // tabPageTelemetry
            // 
            this.tabPageTelemetry.Controls.Add(this.groupBoxTelemetryPlots);
            this.tabPageTelemetry.Controls.Add(this.groupBoxTelemetryLog);
            this.tabPageTelemetry.Location = new System.Drawing.Point(4, 29);
            this.tabPageTelemetry.Name = "tabPageTelemetry";
            this.tabPageTelemetry.Size = new System.Drawing.Size(1205, 564);
            this.tabPageTelemetry.TabIndex = 2;
            this.tabPageTelemetry.Text = "Telemetry";
            this.tabPageTelemetry.UseVisualStyleBackColor = true;
            // 
            // groupBoxTelemetryPlots
            // 
            this.groupBoxTelemetryPlots.Controls.Add(this.checkBoxWriteTLMToDB);
            this.groupBoxTelemetryPlots.Controls.Add(this.buttonClearPlot);
            this.groupBoxTelemetryPlots.Controls.Add(this.labelTelType);
            this.groupBoxTelemetryPlots.Controls.Add(this.formsPlotTelemetry);
            this.groupBoxTelemetryPlots.Controls.Add(this.comboBoxTelemetryType);
            this.groupBoxTelemetryPlots.Location = new System.Drawing.Point(355, 18);
            this.groupBoxTelemetryPlots.Name = "groupBoxTelemetryPlots";
            this.groupBoxTelemetryPlots.Size = new System.Drawing.Size(827, 466);
            this.groupBoxTelemetryPlots.TabIndex = 1;
            this.groupBoxTelemetryPlots.TabStop = false;
            this.groupBoxTelemetryPlots.Text = "Telemetry Graph";
            // 
            // checkBoxWriteTLMToDB
            // 
            this.checkBoxWriteTLMToDB.AutoSize = true;
            this.checkBoxWriteTLMToDB.Location = new System.Drawing.Point(355, 26);
            this.checkBoxWriteTLMToDB.Name = "checkBoxWriteTLMToDB";
            this.checkBoxWriteTLMToDB.Size = new System.Drawing.Size(260, 24);
            this.checkBoxWriteTLMToDB.TabIndex = 4;
            this.checkBoxWriteTLMToDB.Text = "Записывать данные в базу";
            this.checkBoxWriteTLMToDB.UseVisualStyleBackColor = true;
            this.checkBoxWriteTLMToDB.CheckedChanged += new System.EventHandler(this.checkBoxWriteTLMToDB_CheckedChanged);
            // 
            // buttonClearPlot
            // 
            this.buttonClearPlot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearPlot.Location = new System.Drawing.Point(7, 433);
            this.buttonClearPlot.Name = "buttonClearPlot";
            this.buttonClearPlot.Size = new System.Drawing.Size(172, 27);
            this.buttonClearPlot.TabIndex = 3;
            this.buttonClearPlot.Text = "Очистить график";
            this.buttonClearPlot.UseVisualStyleBackColor = true;
            this.buttonClearPlot.Click += new System.EventHandler(this.buttonClearPlot_Click);
            // 
            // labelTelType
            // 
            this.labelTelType.AutoSize = true;
            this.labelTelType.Location = new System.Drawing.Point(183, 27);
            this.labelTelType.Name = "labelTelType";
            this.labelTelType.Size = new System.Drawing.Size(62, 20);
            this.labelTelType.TabIndex = 2;
            this.labelTelType.Text = "label14";
            // 
            // formsPlotTelemetry
            // 
            this.formsPlotTelemetry.Location = new System.Drawing.Point(7, 62);
            this.formsPlotTelemetry.Name = "formsPlotTelemetry";
            this.formsPlotTelemetry.Size = new System.Drawing.Size(827, 368);
            this.formsPlotTelemetry.TabIndex = 1;
            // 
            // comboBoxTelemetryType
            // 
            this.comboBoxTelemetryType.FormattingEnabled = true;
            this.comboBoxTelemetryType.Location = new System.Drawing.Point(7, 27);
            this.comboBoxTelemetryType.Name = "comboBoxTelemetryType";
            this.comboBoxTelemetryType.Size = new System.Drawing.Size(153, 28);
            this.comboBoxTelemetryType.TabIndex = 0;
            this.comboBoxTelemetryType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTelemetryType_SelectedIndexChanged);
            // 
            // groupBoxTelemetryLog
            // 
            this.groupBoxTelemetryLog.Controls.Add(this.label34);
            this.groupBoxTelemetryLog.Controls.Add(this.label33);
            this.groupBoxTelemetryLog.Controls.Add(this.label32);
            this.groupBoxTelemetryLog.Controls.Add(this.label31);
            this.groupBoxTelemetryLog.Controls.Add(this.label30);
            this.groupBoxTelemetryLog.Controls.Add(this.label29);
            this.groupBoxTelemetryLog.Controls.Add(this.label28);
            this.groupBoxTelemetryLog.Controls.Add(this.label27);
            this.groupBoxTelemetryLog.Controls.Add(this.label26);
            this.groupBoxTelemetryLog.Controls.Add(this.label25);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry0);
            this.groupBoxTelemetryLog.Controls.Add(this.label23);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry1);
            this.groupBoxTelemetryLog.Controls.Add(this.label24);
            this.groupBoxTelemetryLog.Controls.Add(this.label22);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry8);
            this.groupBoxTelemetryLog.Controls.Add(this.label21);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry7);
            this.groupBoxTelemetryLog.Controls.Add(this.label20);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry6);
            this.groupBoxTelemetryLog.Controls.Add(this.label19);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry5);
            this.groupBoxTelemetryLog.Controls.Add(this.label18);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry4);
            this.groupBoxTelemetryLog.Controls.Add(this.label17);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry3);
            this.groupBoxTelemetryLog.Controls.Add(this.label16);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry2);
            this.groupBoxTelemetryLog.Controls.Add(this.label15);
            this.groupBoxTelemetryLog.Controls.Add(this.textBoxTelemetry9);
            this.groupBoxTelemetryLog.Controls.Add(this.label14);
            this.groupBoxTelemetryLog.Location = new System.Drawing.Point(16, 18);
            this.groupBoxTelemetryLog.Name = "groupBoxTelemetryLog";
            this.groupBoxTelemetryLog.Size = new System.Drawing.Size(333, 466);
            this.groupBoxTelemetryLog.TabIndex = 0;
            this.groupBoxTelemetryLog.TabStop = false;
            this.groupBoxTelemetryLog.Text = "Telemetry Log";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(280, 358);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(28, 20);
            this.label34.TabIndex = 2;
            this.label34.Text = "C°";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(280, 305);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(28, 20);
            this.label33.TabIndex = 2;
            this.label33.Text = "C°";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(280, 272);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(34, 20);
            this.label32.TabIndex = 2;
            this.label32.Text = "mV";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(280, 236);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 20);
            this.label31.TabIndex = 2;
            this.label31.Text = "mV";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(280, 206);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(28, 20);
            this.label30.TabIndex = 2;
            this.label30.Text = "C°";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(280, 170);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(28, 20);
            this.label29.TabIndex = 2;
            this.label29.Text = "C°";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(280, 140);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(28, 20);
            this.label28.TabIndex = 2;
            this.label28.Text = "C°";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(280, 111);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 20);
            this.label27.TabIndex = 2;
            this.label27.Text = "C°";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(280, 74);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(28, 20);
            this.label26.TabIndex = 2;
            this.label26.Text = "C°";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(280, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(28, 20);
            this.label25.TabIndex = 2;
            this.label25.Text = "C°";
            // 
            // textBoxTelemetry0
            // 
            this.textBoxTelemetry0.Location = new System.Drawing.Point(188, 38);
            this.textBoxTelemetry0.Name = "textBoxTelemetry0";
            this.textBoxTelemetry0.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry0.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 358);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(118, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "Статус-флаг";
            // 
            // textBoxTelemetry1
            // 
            this.textBoxTelemetry1.Location = new System.Drawing.Point(188, 75);
            this.textBoxTelemetry1.Name = "textBoxTelemetry1";
            this.textBoxTelemetry1.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry1.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 325);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(124, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "перезапусков";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 305);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "Количество ";
            // 
            // textBoxTelemetry8
            // 
            this.textBoxTelemetry8.Location = new System.Drawing.Point(188, 318);
            this.textBoxTelemetry8.Name = "textBoxTelemetry8";
            this.textBoxTelemetry8.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry8.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 272);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(181, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "Мощность разрядки";
            // 
            // textBoxTelemetry7
            // 
            this.textBoxTelemetry7.Location = new System.Drawing.Point(188, 272);
            this.textBoxTelemetry7.Name = "textBoxTelemetry7";
            this.textBoxTelemetry7.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry7.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 239);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(171, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "Мощность зарядки";
            // 
            // textBoxTelemetry6
            // 
            this.textBoxTelemetry6.Location = new System.Drawing.Point(188, 239);
            this.textBoxTelemetry6.Name = "textBoxTelemetry6";
            this.textBoxTelemetry6.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry6.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 206);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(146, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "Магнитное поле";
            // 
            // textBoxTelemetry5
            // 
            this.textBoxTelemetry5.Location = new System.Drawing.Point(188, 203);
            this.textBoxTelemetry5.Name = "textBoxTelemetry5";
            this.textBoxTelemetry5.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry5.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 173);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Ангуляр";
            // 
            // textBoxTelemetry4
            // 
            this.textBoxTelemetry4.Location = new System.Drawing.Point(188, 170);
            this.textBoxTelemetry4.Name = "textBoxTelemetry4";
            this.textBoxTelemetry4.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry4.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 140);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "PV мощность";
            // 
            // textBoxTelemetry3
            // 
            this.textBoxTelemetry3.Location = new System.Drawing.Point(188, 137);
            this.textBoxTelemetry3.Name = "textBoxTelemetry3";
            this.textBoxTelemetry3.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry3.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Напряжение";
            // 
            // textBoxTelemetry2
            // 
            this.textBoxTelemetry2.Location = new System.Drawing.Point(188, 108);
            this.textBoxTelemetry2.Name = "textBoxTelemetry2";
            this.textBoxTelemetry2.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry2.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Температура 2";
            // 
            // textBoxTelemetry9
            // 
            this.textBoxTelemetry9.Location = new System.Drawing.Point(188, 355);
            this.textBoxTelemetry9.Name = "textBoxTelemetry9";
            this.textBoxTelemetry9.Size = new System.Drawing.Size(86, 27);
            this.textBoxTelemetry9.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Температура 1";
            // 
            // tabPageDeviceStatus
            // 
            this.tabPageDeviceStatus.Controls.Add(this.splitContainerDeviceStatus);
            this.tabPageDeviceStatus.Location = new System.Drawing.Point(4, 29);
            this.tabPageDeviceStatus.Name = "tabPageDeviceStatus";
            this.tabPageDeviceStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeviceStatus.Size = new System.Drawing.Size(1205, 564);
            this.tabPageDeviceStatus.TabIndex = 3;
            this.tabPageDeviceStatus.Text = "Device Status";
            this.tabPageDeviceStatus.UseVisualStyleBackColor = true;
            // 
            // splitContainerDeviceStatus
            // 
            this.splitContainerDeviceStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDeviceStatus.Location = new System.Drawing.Point(3, 3);
            this.splitContainerDeviceStatus.Name = "splitContainerDeviceStatus";
            // 
            // splitContainerDeviceStatus.Panel1
            // 
            this.splitContainerDeviceStatus.Panel1.Controls.Add(this.tableLayoutPanelDeviceTree);
            // 
            // splitContainerDeviceStatus.Panel2
            // 
            this.splitContainerDeviceStatus.Panel2.Controls.Add(this.groupBoxDeviceDetails);
            this.splitContainerDeviceStatus.Size = new System.Drawing.Size(1199, 558);
            this.splitContainerDeviceStatus.SplitterDistance = 420;
            this.splitContainerDeviceStatus.TabIndex = 0;
            // 
            // tableLayoutPanelDeviceTree
            // 
            this.tableLayoutPanelDeviceTree.ColumnCount = 1;
            this.tableLayoutPanelDeviceTree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDeviceTree.Controls.Add(this.buttonLoadDeviceXml, 0, 0);
            this.tableLayoutPanelDeviceTree.Controls.Add(this.treeViewDevices, 0, 1);
            this.tableLayoutPanelDeviceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDeviceTree.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDeviceTree.Name = "tableLayoutPanelDeviceTree";
            this.tableLayoutPanelDeviceTree.RowCount = 2;
            this.tableLayoutPanelDeviceTree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelDeviceTree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDeviceTree.Size = new System.Drawing.Size(420, 558);
            this.tableLayoutPanelDeviceTree.TabIndex = 0;
            // 
            // buttonLoadDeviceXml
            // 
            this.buttonLoadDeviceXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoadDeviceXml.Location = new System.Drawing.Point(3, 3);
            this.buttonLoadDeviceXml.Name = "buttonLoadDeviceXml";
            this.buttonLoadDeviceXml.Size = new System.Drawing.Size(414, 34);
            this.buttonLoadDeviceXml.TabIndex = 0;
            this.buttonLoadDeviceXml.Text = "Load XML";
            this.buttonLoadDeviceXml.UseVisualStyleBackColor = true;
            this.buttonLoadDeviceXml.Click += new System.EventHandler(this.buttonLoadDeviceXml_Click);
            // 
            // treeViewDevices
            // 
            this.treeViewDevices.CheckBoxes = true;
            this.treeViewDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDevices.Location = new System.Drawing.Point(3, 43);
            this.treeViewDevices.Name = "treeViewDevices";
            this.treeViewDevices.Size = new System.Drawing.Size(414, 512);
            this.treeViewDevices.TabIndex = 1;
            // 
            // groupBoxDeviceDetails
            // 
            this.groupBoxDeviceDetails.Controls.Add(this.textBoxDeviceMetadata);
            this.groupBoxDeviceDetails.Controls.Add(this.labelDeviceMetadataTitle);
            this.groupBoxDeviceDetails.Controls.Add(this.labelDeviceStatus);
            this.groupBoxDeviceDetails.Controls.Add(this.labelDeviceId);
            this.groupBoxDeviceDetails.Controls.Add(this.labelDeviceType);
            this.groupBoxDeviceDetails.Controls.Add(this.labelDeviceName);
            this.groupBoxDeviceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDeviceDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDeviceDetails.Name = "groupBoxDeviceDetails";
            this.groupBoxDeviceDetails.Size = new System.Drawing.Size(775, 558);
            this.groupBoxDeviceDetails.TabIndex = 0;
            this.groupBoxDeviceDetails.TabStop = false;
            this.groupBoxDeviceDetails.Text = "Selected device";
            // 
            // textBoxDeviceMetadata
            // 
            this.textBoxDeviceMetadata.Location = new System.Drawing.Point(16, 179);
            this.textBoxDeviceMetadata.Multiline = true;
            this.textBoxDeviceMetadata.Name = "textBoxDeviceMetadata";
            this.textBoxDeviceMetadata.ReadOnly = true;
            this.textBoxDeviceMetadata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDeviceMetadata.Size = new System.Drawing.Size(743, 301);
            this.textBoxDeviceMetadata.TabIndex = 5;
            // 
            // labelDeviceMetadataTitle
            // 
            this.labelDeviceMetadataTitle.AutoSize = true;
            this.labelDeviceMetadataTitle.Location = new System.Drawing.Point(12, 234);
            this.labelDeviceMetadataTitle.Name = "labelDeviceMetadataTitle";
            this.labelDeviceMetadataTitle.Size = new System.Drawing.Size(78, 20);
            this.labelDeviceMetadataTitle.TabIndex = 4;
            this.labelDeviceMetadataTitle.Text = "Metadata";
            // 
            // labelDeviceStatus
            // 
            this.labelDeviceStatus.AutoSize = true;
            this.labelDeviceStatus.Location = new System.Drawing.Point(12, 200);
            this.labelDeviceStatus.Name = "labelDeviceStatus";
            this.labelDeviceStatus.Size = new System.Drawing.Size(73, 20);
            this.labelDeviceStatus.TabIndex = 3;
            this.labelDeviceStatus.Text = "Status: -";
            // 
            // labelDeviceId
            // 
            this.labelDeviceId.AutoSize = true;
            this.labelDeviceId.Location = new System.Drawing.Point(12, 170);
            this.labelDeviceId.Name = "labelDeviceId";
            this.labelDeviceId.Size = new System.Drawing.Size(38, 20);
            this.labelDeviceId.TabIndex = 2;
            this.labelDeviceId.Text = "Id: -";
            // 
            // labelDeviceType
            // 
            this.labelDeviceType.AutoSize = true;
            this.labelDeviceType.Location = new System.Drawing.Point(12, 140);
            this.labelDeviceType.Name = "labelDeviceType";
            this.labelDeviceType.Size = new System.Drawing.Size(61, 20);
            this.labelDeviceType.TabIndex = 1;
            this.labelDeviceType.Text = "Type: -";
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Location = new System.Drawing.Point(12, 110);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(69, 20);
            this.labelDeviceName.TabIndex = 0;
            this.labelDeviceName.Text = "Name: -";
            // 
            // tabPageDBView
            // 
            this.tabPageDBView.Controls.Add(this.numericUpDownGetCount);
            this.tabPageDBView.Controls.Add(this.buttonGetLastX);
            this.tabPageDBView.Controls.Add(this.buttonGetLast);
            this.tabPageDBView.Controls.Add(this.comboBoxEntityType);
            this.tabPageDBView.Controls.Add(this.groupBox3);
            this.tabPageDBView.Controls.Add(this.groupBox2);
            this.tabPageDBView.Location = new System.Drawing.Point(4, 29);
            this.tabPageDBView.Name = "tabPageDBView";
            this.tabPageDBView.Size = new System.Drawing.Size(1205, 564);
            this.tabPageDBView.TabIndex = 4;
            this.tabPageDBView.Text = "DB View";
            this.tabPageDBView.UseVisualStyleBackColor = true;
            // 
            // numericUpDownGetCount
            // 
            this.numericUpDownGetCount.Location = new System.Drawing.Point(521, 17);
            this.numericUpDownGetCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGetCount.Name = "numericUpDownGetCount";
            this.numericUpDownGetCount.Size = new System.Drawing.Size(75, 27);
            this.numericUpDownGetCount.TabIndex = 5;
            this.numericUpDownGetCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonGetLastX
            // 
            this.buttonGetLastX.Location = new System.Drawing.Point(404, 7);
            this.buttonGetLastX.Name = "buttonGetLastX";
            this.buttonGetLastX.Size = new System.Drawing.Size(111, 48);
            this.buttonGetLastX.TabIndex = 4;
            this.buttonGetLastX.Text = "Последние n пакетов";
            this.buttonGetLastX.UseVisualStyleBackColor = true;
            this.buttonGetLastX.Click += new System.EventHandler(this.buttonGetLastX_Click);
            // 
            // buttonGetLast
            // 
            this.buttonGetLast.Location = new System.Drawing.Point(167, 7);
            this.buttonGetLast.Name = "buttonGetLast";
            this.buttonGetLast.Size = new System.Drawing.Size(121, 48);
            this.buttonGetLast.TabIndex = 3;
            this.buttonGetLast.Text = "Последний пакет";
            this.buttonGetLast.UseVisualStyleBackColor = true;
            this.buttonGetLast.Click += new System.EventHandler(this.buttonGetLast_Click);
            // 
            // comboBoxEntityType
            // 
            this.comboBoxEntityType.FormattingEnabled = true;
            this.comboBoxEntityType.Items.AddRange(new object[] {
            "Телеметрия",
            "Файловые пакеты"});
            this.comboBoxEntityType.Location = new System.Drawing.Point(4, 17);
            this.comboBoxEntityType.Name = "comboBoxEntityType";
            this.comboBoxEntityType.Size = new System.Drawing.Size(139, 28);
            this.comboBoxEntityType.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewEntities);
            this.groupBox3.Controls.Add(this.textBoxHexView);
            this.groupBox3.Location = new System.Drawing.Point(417, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(778, 399);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // dataGridViewEntities
            // 
            this.dataGridViewEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntities.Location = new System.Drawing.Point(7, 168);
            this.dataGridViewEntities.Name = "dataGridViewEntities";
            this.dataGridViewEntities.RowHeadersWidth = 51;
            this.dataGridViewEntities.RowTemplate.Height = 24;
            this.dataGridViewEntities.Size = new System.Drawing.Size(765, 225);
            this.dataGridViewEntities.TabIndex = 1;
            // 
            // textBoxHexView
            // 
            this.textBoxHexView.Location = new System.Drawing.Point(6, 37);
            this.textBoxHexView.Multiline = true;
            this.textBoxHexView.Name = "textBoxHexView";
            this.textBoxHexView.ReadOnly = true;
            this.textBoxHexView.Size = new System.Drawing.Size(646, 124);
            this.textBoxHexView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 399);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 620);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SatteliteManagment";
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRadioControl.ResumeLayout(false);
            this.panelRadioControl.PerformLayout();
            this.groupBoxLogTables.ResumeLayout(false);
            this.groupBoxLogTables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logRequestingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logSendingGridView)).EndInit();
            this.groupBoxFileSending.ResumeLayout(false);
            this.groupBoxFileSending.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownId)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageConn.ResumeLayout(false);
            this.tabPageSatellite.ResumeLayout(false);
            this.groupBoxTriggerPanel.ResumeLayout(false);
            this.groupBoxTriggerPanel.PerformLayout();
            this.groupBoxDeleteTrigger.ResumeLayout(false);
            this.groupBoxDeleteTrigger.PerformLayout();
            this.groupBoxTriggerState.ResumeLayout(false);
            this.groupBoxTriggerState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriggerState)).EndInit();
            this.groupBoxTriggerSettings.ResumeLayout(false);
            this.groupBoxTriggerSettings.PerformLayout();
            this.groupBoxAskSettings.ResumeLayout(false);
            this.groupBoxAskSettings.PerformLayout();
            this.tabPageTelemetry.ResumeLayout(false);
            this.groupBoxTelemetryPlots.ResumeLayout(false);
            this.groupBoxTelemetryPlots.PerformLayout();
            this.groupBoxTelemetryLog.ResumeLayout(false);
            this.groupBoxTelemetryLog.PerformLayout();
            this.tabPageDeviceStatus.ResumeLayout(false);
            this.splitContainerDeviceStatus.Panel1.ResumeLayout(false);
            this.splitContainerDeviceStatus.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDeviceStatus)).EndInit();
            this.splitContainerDeviceStatus.ResumeLayout(false);
            this.tableLayoutPanelDeviceTree.ResumeLayout(false);
            this.groupBoxDeviceDetails.ResumeLayout(false);
            this.groupBoxDeviceDetails.PerformLayout();
            this.tabPageDBView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGetCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CheckBox checkBoxDollar;
        private Button buttonClearLogs;
        private GroupBox groupBoxConnection;
        public Label labelSnrInfoB;
        private Label label61;
        private Label label6;
        public Label labelSnrInfoA;
        private Label label5;
        public Button buttonOpenCloseServer;
        public Label labelComPortConnectionInfo;
        public PictureBox pictureBox1;
        private Label label4;
        private Label label1;
        private Panel panelRadioControl;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Label label2;
        private TextBox logTextBox;
        private Button sendAllPackageButton;
        private Button sendOnePackageButton;
        private DataGridView logSendingGridView;
        private Button testbutton;
        private Label label3;
        private TabControl tabControlMain;
        private TabPage tabPageConn;
        private TabPage tabPageSatellite;
        private GroupBox groupBoxAskSettings;
        private GroupBox groupBoxTriggerSettings;
        private CheckBox checkBoxWriteLog;
        private CheckBox checkBoxAskZeroPacket;
        private CheckBox checkBoxAskPhotoSize;
        private CheckBox checkBoxAskNextPhotoPacket;
        private CheckBox checkBoxRSSI;
        private CheckBox checkBoxTriggerEnable;
        private GroupBox groupBoxTriggerState;
        private DataGridView dataGridViewTriggerState;
        private Button buttonRestartTriggers;
        private Button buttonWriteNewCountAndDelay;
        private TextBox textBoxDelaySend;
        private TextBox textBoxCountSend;
        private Label label9;
        private Label label8;
        private Label label7;
        private CheckBox checkBoxDisableTriggersAfterAct;
        private Label labelTriggerState;
        private GroupBox groupBoxTriggerPanel;
        private Button buttonWriteCommand;
        private Button buttonCreateCommand;
        private GroupBox groupBoxDeleteTrigger;
        private Button buttonDeleteTrigger;
        private TextBox textBoxDeleteTrigger;
        private Label label11;
        private Label label10;
        private TextBox textBoxCommand;
        private Label label12;
        private RadioButton radioButtonSeparatorNothing1;
        private RadioButton radioButtonSeparatorDollar1;
        private TextBox textBoxSatAddress;
        private Label label13;
        private Button buttonbuttonteststatus;
        private CheckBox checkBoxSendNextIfGetAck;
        private CheckBox checkBoxSendRequestIfGetPacket;
        private Button buttonSendFileRequest;
        private Button buttonSelectPathFile;
        private NumericUpDown numericUpDownId;
        private NumericUpDown numericUpDownPacketSize;
        private TabPage tabPageTelemetry;
        private TabPage tabPageDeviceStatus;
        private SplitContainer splitContainerDeviceStatus;
        private TableLayoutPanel tableLayoutPanelDeviceTree;
        private Button buttonLoadDeviceXml;
        private TreeView treeViewDevices;
        private GroupBox groupBoxDeviceDetails;
        private TextBox textBoxDeviceMetadata;
        private Label labelDeviceMetadataTitle;
        private Label labelDeviceStatus;
        private Label labelDeviceId;
        private Label labelDeviceType;
        private Label labelDeviceName;
        private GroupBox groupBoxTelemetryLog;
        private GroupBox groupBoxTelemetryPlots;
        private ComboBox comboBoxTelemetryType;
        private ScottPlot.WinForms.FormsPlot formsPlotTelemetry;
        private Label labelTelType;
        private TextBox textBoxTelemetry0;
        private Label label23;
        private TextBox textBoxTelemetry1;
        private Label label22;
        private TextBox textBoxTelemetry8;
        private Label label21;
        private TextBox textBoxTelemetry7;
        private Label label20;
        private TextBox textBoxTelemetry6;
        private Label label19;
        private TextBox textBoxTelemetry5;
        private Label label18;
        private TextBox textBoxTelemetry4;
        private Label label17;
        private TextBox textBoxTelemetry3;
        private Label label16;
        private TextBox textBoxTelemetry2;
        private Label label15;
        private TextBox textBoxTelemetry9;
        private Label label14;
        private Label label24;
        private Button buttonDeleteCurrentFile;
        private Label label25;
        private Label label34;
        private Label label33;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private Button buttonShowRawPackets;
        private Button buttonClearPlot;
        private TabPage tabPageDBView;
        private ComboBox comboBoxEntityType;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Button buttonGetLastX;
        private Button buttonGetLast;
        private NumericUpDown numericUpDownGetCount;
        private TextBox textBoxHexView;
        private DataGridView dataGridViewEntities;
        private CheckBox checkBoxWriteTLMToDB;
        private Label labelCrc;
        private Button buttonVerifyCheckSum;
        private GroupBox groupBoxFileSending;
        private Label labelCrcHex;
        private Label label35;
        private Label label36;
        private ToolTip toolTipAutoSendNextInfo;
        private GroupBox groupBoxLogTables;
        private CheckBox checkBoxAutoScroll;
        private ComboBox comboBoxInOut;
        private DataGridView logRequestingGridView;
        private NumericUpDown numericUpDownPort;
        private MaskedTextBox maskedTextBoxIP;
        private Label label38;
        private Label label37;
    }
}

