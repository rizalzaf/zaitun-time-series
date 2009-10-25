namespace zaitun.MovingAverage
{
    partial class MovingAverageForm
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
            this.gbxMetode = new System.Windows.Forms.GroupBox();
            this.dmaRadio = new System.Windows.Forms.RadioButton();
            this.smaRadio = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OrdeBox = new zaitun.GUI.NumericTextBox();
            this.lblOrde = new System.Windows.Forms.Label();
            this.storageButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.gbxMetode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMetode
            // 
            this.gbxMetode.Controls.Add(this.dmaRadio);
            this.gbxMetode.Controls.Add(this.smaRadio);
            this.gbxMetode.Location = new System.Drawing.Point(12, 59);
            this.gbxMetode.Name = "gbxMetode";
            this.gbxMetode.Size = new System.Drawing.Size(200, 71);
            this.gbxMetode.TabIndex = 7;
            this.gbxMetode.TabStop = false;
            this.gbxMetode.Text = "Method:";
            // 
            // dmaRadio
            // 
            this.dmaRadio.AutoSize = true;
            this.dmaRadio.Location = new System.Drawing.Point(19, 43);
            this.dmaRadio.Name = "dmaRadio";
            this.dmaRadio.Size = new System.Drawing.Size(140, 17);
            this.dmaRadio.TabIndex = 1;
            this.dmaRadio.Text = "Double Moving Average";
            this.dmaRadio.UseVisualStyleBackColor = true;
            // 
            // smaRadio
            // 
            this.smaRadio.AutoSize = true;
            this.smaRadio.Checked = true;
            this.smaRadio.Location = new System.Drawing.Point(19, 20);
            this.smaRadio.Name = "smaRadio";
            this.smaRadio.Size = new System.Drawing.Size(135, 17);
            this.smaRadio.TabIndex = 0;
            this.smaRadio.TabStop = true;
            this.smaRadio.Text = "Single Moving Average";
            this.smaRadio.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(228, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 32);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.okButton.Location = new System.Drawing.Point(228, 64);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(76, 32);
            this.okButton.TabIndex = 19;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OrdeBox);
            this.groupBox1.Controls.Add(this.lblOrde);
            this.groupBox1.Location = new System.Drawing.Point(12, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 47);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Moving Average Length";
            // 
            // OrdeBox
            // 
            this.OrdeBox.Location = new System.Drawing.Point(120, 17);
            this.OrdeBox.Name = "OrdeBox";
            this.OrdeBox.Size = new System.Drawing.Size(61, 20);
            this.OrdeBox.TabIndex = 19;
            this.OrdeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOrde
            // 
            this.lblOrde.AutoSize = true;
            this.lblOrde.Location = new System.Drawing.Point(16, 20);
            this.lblOrde.Name = "lblOrde";
            this.lblOrde.Size = new System.Drawing.Size(97, 13);
            this.lblOrde.TabIndex = 18;
            this.lblOrde.Text = "MA Length (Orde) :";
            // 
            // storageButton
            // 
            this.storageButton.Location = new System.Drawing.Point(92, 197);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(81, 31);
            this.storageButton.TabIndex = 41;
            this.storageButton.Text = "&Storage...";
            this.storageButton.UseVisualStyleBackColor = true;
            this.storageButton.Click += new System.EventHandler(this.storageButton_Click);
            // 
            // resultButton
            // 
            this.resultButton.Location = new System.Drawing.Point(12, 197);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(74, 31);
            this.resultButton.TabIndex = 40;
            this.resultButton.Text = "&Results...";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 48);
            this.panel1.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Moving Average Analysis";
            // 
            // MovingAverageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 239);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.storageButton);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.gbxMetode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovingAverageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moving Average";
            this.Load += new System.EventHandler(this.MovingAverageForm_Load);
            this.gbxMetode.ResumeLayout(false);
            this.gbxMetode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMetode;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOrde;
        private System.Windows.Forms.RadioButton smaRadio;
        private System.Windows.Forms.RadioButton dmaRadio;
        private zaitun.GUI.NumericTextBox OrdeBox;
        private System.Windows.Forms.Button storageButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}

