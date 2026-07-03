using System.Drawing;
using System.Windows.Forms;

namespace SatteliteManagment
{
    partial class Form1
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
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSnrInfoB = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.radioButtonSeparatorNothing = new System.Windows.Forms.RadioButton();
            this.radioButtonSeparatorDollar = new System.Windows.Forms.RadioButton();
            this.buttonSendCommand = new System.Windows.Forms.Button();
            this.textBoxSendCommand = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelSnrInfoA = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOpenCloseServer = new System.Windows.Forms.Button();
            this.labelComPortConnectionInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRadioControl = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.testbutton = new System.Windows.Forms.Button();
            this.logdataGridView = new System.Windows.Forms.DataGridView();
            this.sendAllPackageButton = new System.Windows.Forms.Button();
            this.sendOnePackageButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.packetSize = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageConn = new System.Windows.Forms.TabPage();
            this.tabPageSatellite = new System.Windows.Forms.TabPage();
            this.groupBoxAskSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxRSSI = new System.Windows.Forms.CheckBox();
            this.checkBoxAskNextPhotoPacket = new System.Windows.Forms.CheckBox();
            this.checkBoxAskPhotoSize = new System.Windows.Forms.CheckBox();
            this.checkBoxAskZeroPacket = new System.Windows.Forms.CheckBox();
            this.checkBoxWriteLog = new System.Windows.Forms.CheckBox();
            this.groupBoxTriggerSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxTriggerEnable = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxDisableTriggersAfterAct = new System.Windows.Forms.CheckBox();
            this.buttonWriteNewValue = new System.Windows.Forms.Button();
            this.buttonRestartTriggers = new System.Windows.Forms.Button();
            this.groupBoxTriggerState = new System.Windows.Forms.GroupBox();
            this.dataGridViewTriggerState = new System.Windows.Forms.DataGridView();
            this.labelTriggerState = new System.Windows.Forms.Label();
            this.groupBoxTriggerPanel = new System.Windows.Forms.GroupBox();
            this.buttonCreateCommand = new System.Windows.Forms.Button();
            this.buttonWriteCommand = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxDeleteTrigger = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonDeleteTrigger = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRadioControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logdataGridView)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageConn.SuspendLayout();
            this.tabPageSatellite.SuspendLayout();
            this.groupBoxAskSettings.SuspendLayout();
            this.groupBoxTriggerSettings.SuspendLayout();
            this.groupBoxTriggerState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriggerState)).BeginInit();
            this.groupBoxTriggerPanel.SuspendLayout();
            this.groupBoxDeleteTrigger.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSnrInfoB);
            this.groupBox1.Controls.Add(this.label61);
            this.groupBox1.Controls.Add(this.radioButtonSeparatorNothing);
            this.groupBox1.Controls.Add(this.radioButtonSeparatorDollar);
            this.groupBox1.Controls.Add(this.buttonSendCommand);
            this.groupBox1.Controls.Add(this.textBoxSendCommand);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelSnrInfoA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonOpenCloseServer);
            this.groupBox1.Controls.Add(this.labelComPortConnectionInfo);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(307, 241);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение и данные";
            // 
            // labelSnrInfoB
            // 
            this.labelSnrInfoB.AutoSize = true;
            this.labelSnrInfoB.Location = new System.Drawing.Point(183, 63);
            this.labelSnrInfoB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSnrInfoB.Name = "labelSnrInfoB";
            this.labelSnrInfoB.Size = new System.Drawing.Size(14, 16);
            this.labelSnrInfoB.TabIndex = 15;
            this.labelSnrInfoB.Text = "0";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(124, 63);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(53, 16);
            this.label61.TabIndex = 14;
            this.label61.Text = "RSSI B:";
            // 
            // radioButtonSeparatorNothing
            // 
            this.radioButtonSeparatorNothing.AutoSize = true;
            this.radioButtonSeparatorNothing.Location = new System.Drawing.Point(5, 188);
            this.radioButtonSeparatorNothing.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioButtonSeparatorNothing.Name = "radioButtonSeparatorNothing";
            this.radioButtonSeparatorNothing.Size = new System.Drawing.Size(176, 20);
            this.radioButtonSeparatorNothing.TabIndex = 13;
            this.radioButtonSeparatorNothing.Text = "Без разделителя байт";
            this.radioButtonSeparatorNothing.UseVisualStyleBackColor = true;
            // 
            // radioButtonSeparatorDollar
            // 
            this.radioButtonSeparatorDollar.AutoSize = true;
            this.radioButtonSeparatorDollar.Checked = true;
            this.radioButtonSeparatorDollar.Location = new System.Drawing.Point(5, 165);
            this.radioButtonSeparatorDollar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioButtonSeparatorDollar.Name = "radioButtonSeparatorDollar";
            this.radioButtonSeparatorDollar.Size = new System.Drawing.Size(176, 20);
            this.radioButtonSeparatorDollar.TabIndex = 12;
            this.radioButtonSeparatorDollar.TabStop = true;
            this.radioButtonSeparatorDollar.Text = "Разделитель байт - \"$\"";
            this.radioButtonSeparatorDollar.UseVisualStyleBackColor = true;
            // 
            // buttonSendCommand
            // 
            this.buttonSendCommand.Location = new System.Drawing.Point(193, 165);
            this.buttonSendCommand.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonSendCommand.Name = "buttonSendCommand";
            this.buttonSendCommand.Size = new System.Drawing.Size(108, 43);
            this.buttonSendCommand.TabIndex = 11;
            this.buttonSendCommand.Text = "Отправить\r\nкоманду";
            this.buttonSendCommand.UseVisualStyleBackColor = true;
            this.buttonSendCommand.Click += new System.EventHandler(this.buttonSendCommand_Click);
            // 
            // textBoxSendCommand
            // 
            this.textBoxSendCommand.Location = new System.Drawing.Point(5, 138);
            this.textBoxSendCommand.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxSendCommand.Name = "textBoxSendCommand";
            this.textBoxSendCommand.Size = new System.Drawing.Size(295, 22);
            this.textBoxSendCommand.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Отправка команд:";
            // 
            // labelSnrInfoA
            // 
            this.labelSnrInfoA.AutoSize = true;
            this.labelSnrInfoA.Location = new System.Drawing.Point(65, 63);
            this.labelSnrInfoA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSnrInfoA.Name = "labelSnrInfoA";
            this.labelSnrInfoA.Size = new System.Drawing.Size(14, 16);
            this.labelSnrInfoA.TabIndex = 8;
            this.labelSnrInfoA.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "RSSI A:";
            // 
            // buttonOpenCloseServer
            // 
            this.buttonOpenCloseServer.Location = new System.Drawing.Point(5, 80);
            this.buttonOpenCloseServer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonOpenCloseServer.Name = "buttonOpenCloseServer";
            this.buttonOpenCloseServer.Size = new System.Drawing.Size(293, 36);
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
            this.panelRadioControl.Controls.Add(this.label3);
            this.panelRadioControl.Controls.Add(this.idTextBox);
            this.panelRadioControl.Controls.Add(this.testbutton);
            this.panelRadioControl.Controls.Add(this.logdataGridView);
            this.panelRadioControl.Controls.Add(this.sendAllPackageButton);
            this.panelRadioControl.Controls.Add(this.sendOnePackageButton);
            this.panelRadioControl.Controls.Add(this.logTextBox);
            this.panelRadioControl.Controls.Add(this.label2);
            this.panelRadioControl.Controls.Add(this.packetSize);
            this.panelRadioControl.Controls.Add(this.button1);
            this.panelRadioControl.Controls.Add(this.label1);
            this.panelRadioControl.Controls.Add(this.groupBox1);
            this.panelRadioControl.Controls.Add(this.buttonClearLogs);
            this.panelRadioControl.Location = new System.Drawing.Point(7, 5);
            this.panelRadioControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelRadioControl.Name = "panelRadioControl";
            this.panelRadioControl.Size = new System.Drawing.Size(1263, 414);
            this.panelRadioControl.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "ID назначения";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(12, 361);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 22);
            this.idTextBox.TabIndex = 17;
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            // 
            // testbutton
            // 
            this.testbutton.Location = new System.Drawing.Point(347, 371);
            this.testbutton.Name = "testbutton";
            this.testbutton.Size = new System.Drawing.Size(75, 23);
            this.testbutton.TabIndex = 16;
            this.testbutton.Text = "button2";
            this.testbutton.UseVisualStyleBackColor = true;
            this.testbutton.Click += new System.EventHandler(this.testbutton_Click);
            // 
            // logdataGridView
            // 
            this.logdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logdataGridView.Location = new System.Drawing.Point(327, 178);
            this.logdataGridView.Name = "logdataGridView";
            this.logdataGridView.ReadOnly = true;
            this.logdataGridView.RowHeadersWidth = 51;
            this.logdataGridView.RowTemplate.Height = 24;
            this.logdataGridView.Size = new System.Drawing.Size(736, 150);
            this.logdataGridView.TabIndex = 15;
            // 
            // sendAllPackageButton
            // 
            this.sendAllPackageButton.Enabled = false;
            this.sendAllPackageButton.Location = new System.Drawing.Point(157, 361);
            this.sendAllPackageButton.Name = "sendAllPackageButton";
            this.sendAllPackageButton.Size = new System.Drawing.Size(153, 48);
            this.sendAllPackageButton.TabIndex = 14;
            this.sendAllPackageButton.Text = "Отправить все оставшиеся пакеты";
            this.sendAllPackageButton.UseVisualStyleBackColor = true;
            this.sendAllPackageButton.Click += new System.EventHandler(this.sendAllPackageButton_Click);
            // 
            // sendOnePackageButton
            // 
            this.sendOnePackageButton.Enabled = false;
            this.sendOnePackageButton.Location = new System.Drawing.Point(157, 307);
            this.sendOnePackageButton.Name = "sendOnePackageButton";
            this.sendOnePackageButton.Size = new System.Drawing.Size(153, 48);
            this.sendOnePackageButton.TabIndex = 13;
            this.sendOnePackageButton.Text = "Отправить следующий пакет";
            this.sendOnePackageButton.UseVisualStyleBackColor = true;
            this.sendOnePackageButton.Click += new System.EventHandler(this.sendOnePackageButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(327, 60);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(736, 79);
            this.logTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Размер пакета";
            // 
            // packetSize
            // 
            this.packetSize.Location = new System.Drawing.Point(12, 307);
            this.packetSize.MaxLength = 32;
            this.packetSize.Name = "packetSize";
            this.packetSize.Size = new System.Drawing.Size(100, 22);
            this.packetSize.TabIndex = 10;
            this.packetSize.Text = "10";
            this.packetSize.TextChanged += new System.EventHandler(this.packetSize_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 252);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(307, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Чтение команд из файла";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageConn);
            this.tabControlMain.Controls.Add(this.tabPageSatellite);
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlMain.Location = new System.Drawing.Point(12, 2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1213, 537);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageConn
            // 
            this.tabPageConn.Controls.Add(this.panelRadioControl);
            this.tabPageConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageConn.Location = new System.Drawing.Point(4, 29);
            this.tabPageConn.Name = "tabPageConn";
            this.tabPageConn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConn.Size = new System.Drawing.Size(1205, 504);
            this.tabPageConn.TabIndex = 0;
            this.tabPageConn.Text = "Client Connection";
            this.tabPageConn.UseVisualStyleBackColor = true;
            // 
            // tabPageSatellite
            // 
            this.tabPageSatellite.Controls.Add(this.groupBoxTriggerPanel);
            this.tabPageSatellite.Controls.Add(this.groupBoxTriggerState);
            this.tabPageSatellite.Controls.Add(this.groupBoxTriggerSettings);
            this.tabPageSatellite.Controls.Add(this.groupBoxAskSettings);
            this.tabPageSatellite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageSatellite.Location = new System.Drawing.Point(4, 29);
            this.tabPageSatellite.Name = "tabPageSatellite";
            this.tabPageSatellite.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSatellite.Size = new System.Drawing.Size(1205, 504);
            this.tabPageSatellite.TabIndex = 1;
            this.tabPageSatellite.Text = "Satellite Info";
            this.tabPageSatellite.UseVisualStyleBackColor = true;
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
            this.groupBoxAskSettings.Size = new System.Drawing.Size(326, 187);
            this.groupBoxAskSettings.TabIndex = 0;
            this.groupBoxAskSettings.TabStop = false;
            this.groupBoxAskSettings.Text = "Панель настроек";
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
            // groupBoxTriggerSettings
            // 
            this.groupBoxTriggerSettings.Controls.Add(this.label12);
            this.groupBoxTriggerSettings.Controls.Add(this.buttonRestartTriggers);
            this.groupBoxTriggerSettings.Controls.Add(this.buttonWriteNewValue);
            this.groupBoxTriggerSettings.Controls.Add(this.textBox2);
            this.groupBoxTriggerSettings.Controls.Add(this.textBox1);
            this.groupBoxTriggerSettings.Controls.Add(this.label9);
            this.groupBoxTriggerSettings.Controls.Add(this.label8);
            this.groupBoxTriggerSettings.Controls.Add(this.label7);
            this.groupBoxTriggerSettings.Controls.Add(this.checkBoxDisableTriggersAfterAct);
            this.groupBoxTriggerSettings.Controls.Add(this.checkBoxTriggerEnable);
            this.groupBoxTriggerSettings.Location = new System.Drawing.Point(338, 20);
            this.groupBoxTriggerSettings.Name = "groupBoxTriggerSettings";
            this.groupBoxTriggerSettings.Size = new System.Drawing.Size(214, 265);
            this.groupBoxTriggerSettings.TabIndex = 1;
            this.groupBoxTriggerSettings.TabStop = false;
            this.groupBoxTriggerSettings.Text = "Настройка триггеров";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "На один пакет ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 24);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(5, 125);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 24);
            this.textBox2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "раз(а) с задержкой";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "сек";
            // 
            // checkBoxDisableTriggersAfterAct
            // 
            this.checkBoxDisableTriggersAfterAct.AutoSize = true;
            this.checkBoxDisableTriggersAfterAct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxDisableTriggersAfterAct.Location = new System.Drawing.Point(5, 206);
            this.checkBoxDisableTriggersAfterAct.Name = "checkBoxDisableTriggersAfterAct";
            this.checkBoxDisableTriggersAfterAct.Size = new System.Drawing.Size(323, 22);
            this.checkBoxDisableTriggersAfterAct.TabIndex = 0;
            this.checkBoxDisableTriggersAfterAct.Text = "Отключить триггеры после срабатывания";
            this.checkBoxDisableTriggersAfterAct.UseVisualStyleBackColor = true;
            // 
            // buttonWriteNewValue
            // 
            this.buttonWriteNewValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWriteNewValue.Location = new System.Drawing.Point(0, 149);
            this.buttonWriteNewValue.Name = "buttonWriteNewValue";
            this.buttonWriteNewValue.Size = new System.Drawing.Size(194, 51);
            this.buttonWriteNewValue.TabIndex = 3;
            this.buttonWriteNewValue.Text = "Записать новые значения";
            this.buttonWriteNewValue.UseVisualStyleBackColor = true;
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
            // labelTriggerState
            // 
            this.labelTriggerState.AutoSize = true;
            this.labelTriggerState.Location = new System.Drawing.Point(7, 20);
            this.labelTriggerState.Name = "labelTriggerState";
            this.labelTriggerState.Size = new System.Drawing.Size(267, 18);
            this.labelTriggerState.TabIndex = 1;
            this.labelTriggerState.Text = "Состояние: ожидание приема пакета";
            // 
            // groupBoxTriggerPanel
            // 
            this.groupBoxTriggerPanel.Controls.Add(this.groupBoxDeleteTrigger);
            this.groupBoxTriggerPanel.Controls.Add(this.label10);
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
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(459, 112);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(241, 24);
            this.textBoxCommand.TabIndex = 1;
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
            // groupBoxDeleteTrigger
            // 
            this.groupBoxDeleteTrigger.Controls.Add(this.buttonDeleteTrigger);
            this.groupBoxDeleteTrigger.Controls.Add(this.textBox3);
            this.groupBoxDeleteTrigger.Controls.Add(this.label11);
            this.groupBoxDeleteTrigger.Location = new System.Drawing.Point(716, 21);
            this.groupBoxDeleteTrigger.Name = "groupBoxDeleteTrigger";
            this.groupBoxDeleteTrigger.Size = new System.Drawing.Size(140, 190);
            this.groupBoxDeleteTrigger.TabIndex = 3;
            this.groupBoxDeleteTrigger.TabStop = false;
            this.groupBoxDeleteTrigger.Text = "Удалить триггер";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "ID триггера";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 91);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 24);
            this.textBox3.TabIndex = 1;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 551);
            this.Controls.Add(this.tabControlMain);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SatteliteManagment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRadioControl.ResumeLayout(false);
            this.panelRadioControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logdataGridView)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageConn.ResumeLayout(false);
            this.tabPageSatellite.ResumeLayout(false);
            this.groupBoxAskSettings.ResumeLayout(false);
            this.groupBoxAskSettings.PerformLayout();
            this.groupBoxTriggerSettings.ResumeLayout(false);
            this.groupBoxTriggerSettings.PerformLayout();
            this.groupBoxTriggerState.ResumeLayout(false);
            this.groupBoxTriggerState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTriggerState)).EndInit();
            this.groupBoxTriggerPanel.ResumeLayout(false);
            this.groupBoxTriggerPanel.PerformLayout();
            this.groupBoxDeleteTrigger.ResumeLayout(false);
            this.groupBoxDeleteTrigger.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CheckBox checkBoxDollar;
        private Button buttonClearLogs;
        private GroupBox groupBox1;
        public Label labelSnrInfoB;
        private Label label61;
        private RadioButton radioButtonSeparatorNothing;
        private RadioButton radioButtonSeparatorDollar;
        private Button buttonSendCommand;
        private TextBox textBoxSendCommand;
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
        private TextBox packetSize;
        private Label label2;
        private TextBox logTextBox;
        private Button sendAllPackageButton;
        private Button sendOnePackageButton;
        private DataGridView logdataGridView;
        private Button testbutton;
        private Label label3;
        private TextBox idTextBox;
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
        private Button buttonWriteNewValue;
        private TextBox textBox2;
        private TextBox textBox1;
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
        private TextBox textBox3;
        private Label label11;
        private Label label10;
        private TextBox textBoxCommand;
        private Label label12;
    }
}

