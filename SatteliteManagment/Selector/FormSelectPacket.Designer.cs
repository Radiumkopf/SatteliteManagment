namespace SatteliteManagment
{
    partial class FormSelectPacket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPackets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackets)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPackets
            // 
            this.dataGridViewPackets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPackets.Location = new System.Drawing.Point(13, 92);
            this.dataGridViewPackets.Name = "dataGridViewPackets";
            this.dataGridViewPackets.RowHeadersWidth = 51;
            this.dataGridViewPackets.RowTemplate.Height = 24;
            this.dataGridViewPackets.Size = new System.Drawing.Size(775, 346);
            this.dataGridViewPackets.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текущий последний пакет: ";
            // 
            // labelCurrentNumber
            // 
            this.labelCurrentNumber.AutoSize = true;
            this.labelCurrentNumber.Location = new System.Drawing.Point(205, 42);
            this.labelCurrentNumber.Name = "labelCurrentNumber";
            this.labelCurrentNumber.Size = new System.Drawing.Size(44, 16);
            this.labelCurrentNumber.TabIndex = 2;
            this.labelCurrentNumber.Text = "label2";
            // 
            // FormSelectPacket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelCurrentNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPackets);
            this.Name = "FormSelectPacket";
            this.Text = "Пакеты";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPackets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentNumber;
    }
}