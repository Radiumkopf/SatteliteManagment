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
            // FormSelectPacket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewPackets);
            this.Name = "FormSelectPacket";
            this.Text = "Пакеты";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPackets;
    }
}