namespace zaitun.Correlogram
{
    partial class CorrelogramForm
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
            this.CorrelogramGroupBox1 = new System.Windows.Forms.GroupBox();
            this.seconddifference = new System.Windows.Forms.RadioButton();
            this.firstdifference = new System.Windows.Forms.RadioButton();
            this.level = new System.Windows.Forms.RadioButton();
            this.LagGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.whiteNoiseCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.numericlag = new zaitun.GUI.NumericTextBox();
            this.CorrelogramGroupBox1.SuspendLayout();
            this.LagGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CorrelogramGroupBox1
            // 
            this.CorrelogramGroupBox1.Controls.Add(this.seconddifference);
            this.CorrelogramGroupBox1.Controls.Add(this.firstdifference);
            this.CorrelogramGroupBox1.Controls.Add(this.level);
            this.CorrelogramGroupBox1.Location = new System.Drawing.Point(10, 54);
            this.CorrelogramGroupBox1.Name = "CorrelogramGroupBox1";
            this.CorrelogramGroupBox1.Size = new System.Drawing.Size(175, 99);
            this.CorrelogramGroupBox1.TabIndex = 0;
            this.CorrelogramGroupBox1.TabStop = false;
            this.CorrelogramGroupBox1.Text = "Correlogram of";
            // 
            // seconddifference
            // 
            this.seconddifference.AutoSize = true;
            this.seconddifference.Location = new System.Drawing.Point(10, 65);
            this.seconddifference.Name = "seconddifference";
            this.seconddifference.Size = new System.Drawing.Size(93, 17);
            this.seconddifference.TabIndex = 2;
            this.seconddifference.TabStop = true;
            this.seconddifference.Text = "2nd difference";
            this.seconddifference.UseVisualStyleBackColor = true;
            // 
            // firstdifference
            // 
            this.firstdifference.AutoSize = true;
            this.firstdifference.Location = new System.Drawing.Point(10, 42);
            this.firstdifference.Name = "firstdifference";
            this.firstdifference.Size = new System.Drawing.Size(89, 17);
            this.firstdifference.TabIndex = 1;
            this.firstdifference.TabStop = true;
            this.firstdifference.Text = "1st difference";
            this.firstdifference.UseVisualStyleBackColor = true;
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Location = new System.Drawing.Point(10, 19);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(51, 17);
            this.level.TabIndex = 0;
            this.level.TabStop = true;
            this.level.Text = "Level";
            this.level.UseVisualStyleBackColor = true;
            // 
            // LagGroupBox
            // 
            this.LagGroupBox.Controls.Add(this.label1);
            this.LagGroupBox.Controls.Add(this.numericlag);
            this.LagGroupBox.Location = new System.Drawing.Point(10, 159);
            this.LagGroupBox.Name = "LagGroupBox";
            this.LagGroupBox.Size = new System.Drawing.Size(175, 54);
            this.LagGroupBox.TabIndex = 1;
            this.LagGroupBox.TabStop = false;
            this.LagGroupBox.Text = "Number of Lags";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of lags:";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(220, 63);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 37);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(220, 110);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 34);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.whiteNoiseCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 54);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "White noise standard errors";
            this.groupBox1.Visible = false;
            // 
            // whiteNoiseCheckBox
            // 
            this.whiteNoiseCheckBox.AutoSize = true;
            this.whiteNoiseCheckBox.Checked = true;
            this.whiteNoiseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.whiteNoiseCheckBox.Location = new System.Drawing.Point(12, 24);
            this.whiteNoiseCheckBox.Name = "whiteNoiseCheckBox";
            this.whiteNoiseCheckBox.Size = new System.Drawing.Size(193, 17);
            this.whiteNoiseCheckBox.TabIndex = 0;
            this.whiteNoiseCheckBox.Text = "White noise standard errors on ACF";
            this.whiteNoiseCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 48);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Correlogram";
            // 
            // numericlag
            // 
            this.numericlag.Location = new System.Drawing.Point(94, 26);
            this.numericlag.Name = "numericlag";
            this.numericlag.Size = new System.Drawing.Size(62, 20);
            this.numericlag.TabIndex = 0;
            this.numericlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CorrelogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 223);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.LagGroupBox);
            this.Controls.Add(this.CorrelogramGroupBox1);
            this.Name = "CorrelogramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Correlogram";
            this.Load += new System.EventHandler(this.correlogram_Load);
            this.CorrelogramGroupBox1.ResumeLayout(false);
            this.CorrelogramGroupBox1.PerformLayout();
            this.LagGroupBox.ResumeLayout(false);
            this.LagGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CorrelogramGroupBox1;
        private System.Windows.Forms.RadioButton seconddifference;
        private System.Windows.Forms.RadioButton firstdifference;
        private System.Windows.Forms.RadioButton level;
        private System.Windows.Forms.GroupBox LagGroupBox;
        private zaitun.GUI.NumericTextBox numericlag;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox whiteNoiseCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}