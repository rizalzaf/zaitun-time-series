using zaitun.GUI;
namespace zaitun.TrendAnalysis
{
    partial class TrendAnalysisForm
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
            this.cubicRdb = new System.Windows.Forms.RadioButton();
            this.expGrowthRdb = new System.Windows.Forms.RadioButton();
            this.quadraticRdb = new System.Windows.Forms.RadioButton();
            this.linearRdb = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.storageButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cubicRdb);
            this.groupBox1.Controls.Add(this.expGrowthRdb);
            this.groupBox1.Controls.Add(this.quadraticRdb);
            this.groupBox1.Controls.Add(this.linearRdb);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 113);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model Type";
            // 
            // cubicRdb
            // 
            this.cubicRdb.AutoSize = true;
            this.cubicRdb.Location = new System.Drawing.Point(17, 64);
            this.cubicRdb.Name = "cubicRdb";
            this.cubicRdb.Size = new System.Drawing.Size(52, 17);
            this.cubicRdb.TabIndex = 2;
            this.cubicRdb.TabStop = true;
            this.cubicRdb.Text = "Cubic";
            this.cubicRdb.UseVisualStyleBackColor = true;
            // 
            // expGrowthRdb
            // 
            this.expGrowthRdb.AutoSize = true;
            this.expGrowthRdb.Location = new System.Drawing.Point(17, 87);
            this.expGrowthRdb.Name = "expGrowthRdb";
            this.expGrowthRdb.Size = new System.Drawing.Size(80, 17);
            this.expGrowthRdb.TabIndex = 3;
            this.expGrowthRdb.Text = "Exponential";
            this.expGrowthRdb.UseVisualStyleBackColor = true;
            // 
            // quadraticRdb
            // 
            this.quadraticRdb.AutoSize = true;
            this.quadraticRdb.Location = new System.Drawing.Point(17, 42);
            this.quadraticRdb.Name = "quadraticRdb";
            this.quadraticRdb.Size = new System.Drawing.Size(71, 17);
            this.quadraticRdb.TabIndex = 1;
            this.quadraticRdb.Text = "Quadratic";
            this.quadraticRdb.UseVisualStyleBackColor = true;
            // 
            // linearRdb
            // 
            this.linearRdb.AutoSize = true;
            this.linearRdb.Checked = true;
            this.linearRdb.Location = new System.Drawing.Point(17, 19);
            this.linearRdb.Name = "linearRdb";
            this.linearRdb.Size = new System.Drawing.Size(54, 17);
            this.linearRdb.TabIndex = 0;
            this.linearRdb.TabStop = true;
            this.linearRdb.Text = "Linear";
            this.linearRdb.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(233, 64);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(76, 32);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(233, 114);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 32);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // resultButton
            // 
            this.resultButton.Location = new System.Drawing.Point(9, 179);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(74, 31);
            this.resultButton.TabIndex = 36;
            this.resultButton.Text = "&Results...";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // storageButton
            // 
            this.storageButton.Location = new System.Drawing.Point(89, 179);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(81, 31);
            this.storageButton.TabIndex = 37;
            this.storageButton.Text = "&Storage...";
            this.storageButton.UseVisualStyleBackColor = true;
            this.storageButton.Click += new System.EventHandler(this.storageButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 48);
            this.panel1.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trend Analysis";
            // 
            // TrendAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 222);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.storageButton);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrendAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trend Analysis";
            this.Load += new System.EventHandler(this.TrendAnalysisForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton quadraticRdb;
        private System.Windows.Forms.RadioButton linearRdb;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton expGrowthRdb;
        private System.Windows.Forms.RadioButton cubicRdb;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Button storageButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}