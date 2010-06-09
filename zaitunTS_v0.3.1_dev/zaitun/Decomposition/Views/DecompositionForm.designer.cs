namespace zaitun.Decomposition
{
    partial class DecompositionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SeasonalLengthBox = new zaitun.GUI.NumericTextBox();
            this.lblOrde = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.additiveRdb = new System.Windows.Forms.RadioButton();
            this.multiplikativeRdb = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.trendComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.storageButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SeasonalLengthBox);
            this.groupBox1.Controls.Add(this.lblOrde);
            this.groupBox1.Location = new System.Drawing.Point(9, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 47);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seasonal Length";
            // 
            // SeasonalLengthBox
            // 
            this.SeasonalLengthBox.Location = new System.Drawing.Point(112, 17);
            this.SeasonalLengthBox.Name = "SeasonalLengthBox";
            this.SeasonalLengthBox.Size = new System.Drawing.Size(69, 20);
            this.SeasonalLengthBox.TabIndex = 0;
            this.SeasonalLengthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOrde
            // 
            this.lblOrde.AutoSize = true;
            this.lblOrde.Location = new System.Drawing.Point(16, 20);
            this.lblOrde.Name = "lblOrde";
            this.lblOrde.Size = new System.Drawing.Size(90, 13);
            this.lblOrde.TabIndex = 18;
            this.lblOrde.Text = "Seasonal Length:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.okButton.Location = new System.Drawing.Point(251, 63);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(76, 32);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(251, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 32);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.additiveRdb);
            this.groupBox2.Controls.Add(this.multiplikativeRdb);
            this.groupBox2.Location = new System.Drawing.Point(9, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 67);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model Type";
            // 
            // additiveRdb
            // 
            this.additiveRdb.AutoSize = true;
            this.additiveRdb.Location = new System.Drawing.Point(19, 42);
            this.additiveRdb.Name = "additiveRdb";
            this.additiveRdb.Size = new System.Drawing.Size(63, 17);
            this.additiveRdb.TabIndex = 2;
            this.additiveRdb.TabStop = true;
            this.additiveRdb.Text = "Additive";
            this.additiveRdb.UseVisualStyleBackColor = true;
            // 
            // multiplikativeRdb
            // 
            this.multiplikativeRdb.AutoSize = true;
            this.multiplikativeRdb.Checked = true;
            this.multiplikativeRdb.Location = new System.Drawing.Point(19, 19);
            this.multiplikativeRdb.Name = "multiplikativeRdb";
            this.multiplikativeRdb.Size = new System.Drawing.Size(86, 17);
            this.multiplikativeRdb.TabIndex = 1;
            this.multiplikativeRdb.TabStop = true;
            this.multiplikativeRdb.Text = "Multiplicative";
            this.multiplikativeRdb.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trendComboBox);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(9, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 52);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trend";
            // 
            // trendComboBox
            // 
            this.trendComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trendComboBox.FormattingEnabled = true;
            this.trendComboBox.Items.AddRange(new object[] {
            "Linear",
            "Quadratic",
            "Cubic",
            "Exponential"});
            this.trendComboBox.Location = new System.Drawing.Point(99, 19);
            this.trendComboBox.Name = "trendComboBox";
            this.trendComboBox.Size = new System.Drawing.Size(105, 21);
            this.trendComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trend Model :";
            // 
            // storageButton
            // 
            this.storageButton.Location = new System.Drawing.Point(89, 242);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(81, 31);
            this.storageButton.TabIndex = 39;
            this.storageButton.Text = "&Storage...";
            this.storageButton.UseVisualStyleBackColor = true;
            this.storageButton.Click += new System.EventHandler(this.storageButton_Click);
            // 
            // resultButton
            // 
            this.resultButton.Location = new System.Drawing.Point(9, 242);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(74, 31);
            this.resultButton.TabIndex = 38;
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
            this.panel1.Size = new System.Drawing.Size(353, 48);
            this.panel1.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Decomposition Analysis";
            // 
            // DecompositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 287);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.storageButton);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DecompositionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Decomposition Analysis";
            this.Load += new System.EventHandler(this.DecompositionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private zaitun.GUI.NumericTextBox SeasonalLengthBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOrde;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton multiplikativeRdb;
        private System.Windows.Forms.RadioButton additiveRdb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox trendComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button storageButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;

    }
}