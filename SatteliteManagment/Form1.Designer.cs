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
            this.label2 = new System.Windows.Forms.Label();
            this.packetSize = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.sendOnePackageButton = new System.Windows.Forms.Button();
            this.sendAllPackageButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRadioControl.SuspendLayout();
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
            this.panelRadioControl.Controls.Add(this.sendAllPackageButton);
            this.panelRadioControl.Controls.Add(this.sendOnePackageButton);
            this.panelRadioControl.Controls.Add(this.logTextBox);
            this.panelRadioControl.Controls.Add(this.label2);
            this.panelRadioControl.Controls.Add(this.packetSize);
            this.panelRadioControl.Controls.Add(this.button1);
            this.panelRadioControl.Controls.Add(this.label1);
            this.panelRadioControl.Controls.Add(this.groupBox1);
            this.panelRadioControl.Controls.Add(this.buttonClearLogs);
            this.panelRadioControl.Location = new System.Drawing.Point(0, 23);
            this.panelRadioControl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelRadioControl.Name = "panelRadioControl";
            this.panelRadioControl.Size = new System.Drawing.Size(1169, 418);
            this.panelRadioControl.TabIndex = 0;
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
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(327, 60);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(736, 290);
            this.logTextBox.TabIndex = 12;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 444);
            this.Controls.Add(this.panelRadioControl);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SatteliteManagment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRadioControl.ResumeLayout(false);
            this.panelRadioControl.PerformLayout();
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
    }
}

