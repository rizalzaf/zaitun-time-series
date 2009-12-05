namespace zaitun.ExponentialSmoothing
{
    partial class ExponentialSmoothingForm
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
            this.winterRdb = new System.Windows.Forms.RadioButton();
            this.holtRdb = new System.Windows.Forms.RadioButton();
            this.brownRdb = new System.Windows.Forms.RadioButton();
            this.sesRdb = new System.Windows.Forms.RadioButton();
            this.slengthLbl = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.beta = new zaitun.GUI.DecimalTextBox();
            this.gridSearchButton = new System.Windows.Forms.Button();
            this.gamma = new zaitun.GUI.DecimalTextBox();
            this.alpha = new zaitun.GUI.DecimalTextBox();
            this.seasonalLbl = new System.Windows.Forms.Label();
            this.trendLbl = new System.Windows.Forms.Label();
            this.levelLbl = new System.Windows.Forms.Label();
            this.betaLbl = new System.Windows.Forms.Label();
            this.gammaLbl = new System.Windows.Forms.Label();
            this.alphaLbl = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.seasonalBox = new zaitun.GUI.NumericTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.adtRdb = new System.Windows.Forms.RadioButton();
            this.mtpRdb = new System.Windows.Forms.RadioButton();
            this.storageButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.winterRdb);
            this.groupBox1.Controls.Add(this.holtRdb);
            this.groupBox1.Controls.Add(this.brownRdb);
            this.groupBox1.Controls.Add(this.sesRdb);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Method";
            // 
            // winterRdb
            // 
            this.winterRdb.AutoSize = true;
            this.winterRdb.Location = new System.Drawing.Point(24, 91);
            this.winterRdb.Name = "winterRdb";
            this.winterRdb.Size = new System.Drawing.Size(202, 17);
            this.winterRdb.TabIndex = 3;
            this.winterRdb.Text = "Triple Exponential Smoothing (Winter)";
            this.winterRdb.UseVisualStyleBackColor = true;
            this.winterRdb.CheckedChanged += new System.EventHandler(this.winterRdb_CheckedChanged);
            // 
            // holtRdb
            // 
            this.holtRdb.AutoSize = true;
            this.holtRdb.Location = new System.Drawing.Point(24, 67);
            this.holtRdb.Name = "holtRdb";
            this.holtRdb.Size = new System.Drawing.Size(198, 17);
            this.holtRdb.TabIndex = 2;
            this.holtRdb.Text = "Double Exponential Smoothing (Holt)";
            this.holtRdb.UseVisualStyleBackColor = true;
            this.holtRdb.CheckedChanged += new System.EventHandler(this.holtRdb_CheckedChanged);
            // 
            // brownRdb
            // 
            this.brownRdb.AutoSize = true;
            this.brownRdb.Location = new System.Drawing.Point(24, 43);
            this.brownRdb.Name = "brownRdb";
            this.brownRdb.Size = new System.Drawing.Size(209, 17);
            this.brownRdb.TabIndex = 1;
            this.brownRdb.Text = "Double Exponential Smoothing (Brown)";
            this.brownRdb.UseVisualStyleBackColor = true;
            this.brownRdb.CheckedChanged += new System.EventHandler(this.brownRdb_CheckedChanged);
            // 
            // sesRdb
            // 
            this.sesRdb.AutoSize = true;
            this.sesRdb.Checked = true;
            this.sesRdb.Location = new System.Drawing.Point(24, 19);
            this.sesRdb.Name = "sesRdb";
            this.sesRdb.Size = new System.Drawing.Size(165, 17);
            this.sesRdb.TabIndex = 0;
            this.sesRdb.TabStop = true;
            this.sesRdb.Text = "Single Exponential Smoothing";
            this.sesRdb.UseVisualStyleBackColor = true;
            this.sesRdb.CheckedChanged += new System.EventHandler(this.sesRdb_CheckedChanged);
            // 
            // slengthLbl
            // 
            this.slengthLbl.AutoSize = true;
            this.slengthLbl.Enabled = false;
            this.slengthLbl.Location = new System.Drawing.Point(6, 22);
            this.slengthLbl.Name = "slengthLbl";
            this.slengthLbl.Size = new System.Drawing.Size(93, 13);
            this.slengthLbl.TabIndex = 1;
            this.slengthLbl.Text = "Seasonal Length :";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.okButton.Location = new System.Drawing.Point(306, 343);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(76, 32);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(388, 343);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 32);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.beta);
            this.groupBox2.Controls.Add(this.gridSearchButton);
            this.groupBox2.Controls.Add(this.gamma);
            this.groupBox2.Controls.Add(this.alpha);
            this.groupBox2.Controls.Add(this.seasonalLbl);
            this.groupBox2.Controls.Add(this.trendLbl);
            this.groupBox2.Controls.Add(this.levelLbl);
            this.groupBox2.Controls.Add(this.betaLbl);
            this.groupBox2.Controls.Add(this.gammaLbl);
            this.groupBox2.Controls.Add(this.alphaLbl);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 151);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Smoothing Constant";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(83, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 28);
            this.label2.TabIndex = 28;
            this.label2.Text = "You can click \'Grid Search\' button to identifying the optimum smoothing parameter" +
                "s ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Note";
            // 
            // beta
            // 
            this.beta.Enabled = false;
            this.beta.Location = new System.Drawing.Point(86, 81);
            this.beta.Name = "beta";
            this.beta.Size = new System.Drawing.Size(73, 20);
            this.beta.TabIndex = 9;
            this.beta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gridSearchButton
            // 
            this.gridSearchButton.Location = new System.Drawing.Point(261, 40);
            this.gridSearchButton.Name = "gridSearchButton";
            this.gridSearchButton.Size = new System.Drawing.Size(109, 45);
            this.gridSearchButton.TabIndex = 6;
            this.gridSearchButton.Text = "==> Grid Search";
            this.gridSearchButton.UseVisualStyleBackColor = true;
            this.gridSearchButton.Click += new System.EventHandler(this.gridSearchButton_Click);
            // 
            // gamma
            // 
            this.gamma.Enabled = false;
            this.gamma.Location = new System.Drawing.Point(86, 53);
            this.gamma.Name = "gamma";
            this.gamma.Size = new System.Drawing.Size(73, 20);
            this.gamma.TabIndex = 8;
            this.gamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // alpha
            // 
            this.alpha.Location = new System.Drawing.Point(86, 24);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(73, 20);
            this.alpha.TabIndex = 7;
            this.alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seasonalLbl
            // 
            this.seasonalLbl.AutoSize = true;
            this.seasonalLbl.Enabled = false;
            this.seasonalLbl.Location = new System.Drawing.Point(176, 84);
            this.seasonalLbl.Name = "seasonalLbl";
            this.seasonalLbl.Size = new System.Drawing.Size(51, 13);
            this.seasonalLbl.TabIndex = 8;
            this.seasonalLbl.Text = "Seasonal";
            // 
            // trendLbl
            // 
            this.trendLbl.AutoSize = true;
            this.trendLbl.Enabled = false;
            this.trendLbl.Location = new System.Drawing.Point(176, 56);
            this.trendLbl.Name = "trendLbl";
            this.trendLbl.Size = new System.Drawing.Size(35, 13);
            this.trendLbl.TabIndex = 7;
            this.trendLbl.Text = "Trend";
            // 
            // levelLbl
            // 
            this.levelLbl.AutoSize = true;
            this.levelLbl.Location = new System.Drawing.Point(176, 27);
            this.levelLbl.Name = "levelLbl";
            this.levelLbl.Size = new System.Drawing.Size(33, 13);
            this.levelLbl.TabIndex = 6;
            this.levelLbl.Text = "Level";
            // 
            // betaLbl
            // 
            this.betaLbl.AutoSize = true;
            this.betaLbl.Enabled = false;
            this.betaLbl.Location = new System.Drawing.Point(21, 84);
            this.betaLbl.Name = "betaLbl";
            this.betaLbl.Size = new System.Drawing.Size(35, 13);
            this.betaLbl.TabIndex = 2;
            this.betaLbl.Text = "Beta :";
            // 
            // gammaLbl
            // 
            this.gammaLbl.AutoSize = true;
            this.gammaLbl.Enabled = false;
            this.gammaLbl.Location = new System.Drawing.Point(21, 56);
            this.gammaLbl.Name = "gammaLbl";
            this.gammaLbl.Size = new System.Drawing.Size(49, 13);
            this.gammaLbl.TabIndex = 1;
            this.gammaLbl.Text = "Gamma :";
            // 
            // alphaLbl
            // 
            this.alphaLbl.AutoSize = true;
            this.alphaLbl.Location = new System.Drawing.Point(21, 27);
            this.alphaLbl.Name = "alphaLbl";
            this.alphaLbl.Size = new System.Drawing.Size(40, 13);
            this.alphaLbl.TabIndex = 0;
            this.alphaLbl.Text = "Alpha :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.slengthLbl);
            this.groupBox4.Controls.Add(this.seasonalBox);
            this.groupBox4.Location = new System.Drawing.Point(285, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 52);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Seasonal Length";
            // 
            // seasonalBox
            // 
            this.seasonalBox.Enabled = false;
            this.seasonalBox.Location = new System.Drawing.Point(105, 19);
            this.seasonalBox.Name = "seasonalBox";
            this.seasonalBox.Size = new System.Drawing.Size(45, 20);
            this.seasonalBox.TabIndex = 6;
            this.seasonalBox.Text = "12";
            this.seasonalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.adtRdb);
            this.groupBox5.Controls.Add(this.mtpRdb);
            this.groupBox5.Location = new System.Drawing.Point(285, 52);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(174, 50);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Model Type";
            // 
            // adtRdb
            // 
            this.adtRdb.AutoSize = true;
            this.adtRdb.Enabled = false;
            this.adtRdb.Location = new System.Drawing.Point(101, 19);
            this.adtRdb.Name = "adtRdb";
            this.adtRdb.Size = new System.Drawing.Size(63, 17);
            this.adtRdb.TabIndex = 5;
            this.adtRdb.Text = "Additive";
            this.adtRdb.UseVisualStyleBackColor = true;
            this.adtRdb.CheckedChanged += new System.EventHandler(this.adtRdb_CheckedChanged);
            // 
            // mtpRdb
            // 
            this.mtpRdb.AutoSize = true;
            this.mtpRdb.Checked = true;
            this.mtpRdb.Enabled = false;
            this.mtpRdb.Location = new System.Drawing.Point(9, 19);
            this.mtpRdb.Name = "mtpRdb";
            this.mtpRdb.Size = new System.Drawing.Size(86, 17);
            this.mtpRdb.TabIndex = 4;
            this.mtpRdb.TabStop = true;
            this.mtpRdb.Text = "Multiplicative";
            this.mtpRdb.UseVisualStyleBackColor = true;
            this.mtpRdb.CheckedChanged += new System.EventHandler(this.mtpRdb_CheckedChanged);
            // 
            // storageButton
            // 
            this.storageButton.Location = new System.Drawing.Point(90, 343);
            this.storageButton.Name = "storageButton";
            this.storageButton.Size = new System.Drawing.Size(81, 31);
            this.storageButton.TabIndex = 43;
            this.storageButton.Text = "&Storage...";
            this.storageButton.UseVisualStyleBackColor = true;
            this.storageButton.Click += new System.EventHandler(this.storageButton_Click);
            // 
            // resultButton
            // 
            this.resultButton.Location = new System.Drawing.Point(10, 343);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(74, 31);
            this.resultButton.TabIndex = 42;
            this.resultButton.Text = "&Results...";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(177, 343);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(81, 31);
            this.optionsButton.TabIndex = 44;
            this.optionsButton.Text = "&Options...";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 48);
            this.panel1.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(350, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Exponential Smoothing Analysis";
            // 
            // ExponentialSmoothingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 385);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.storageButton);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExponentialSmoothingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exponential Smoothing Analysis";
            this.Load += new System.EventHandler(this.ExponentialSmoothingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton winterRdb;
        private System.Windows.Forms.RadioButton holtRdb;
        private System.Windows.Forms.RadioButton brownRdb;
        private System.Windows.Forms.RadioButton sesRdb;
        private System.Windows.Forms.Label slengthLbl;
        private zaitun.GUI.NumericTextBox seasonalBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label betaLbl;
        private System.Windows.Forms.Label gammaLbl;
        private System.Windows.Forms.Label alphaLbl;
        private System.Windows.Forms.Label seasonalLbl;
        private System.Windows.Forms.Label trendLbl;
        private System.Windows.Forms.Label levelLbl;
        private System.Windows.Forms.Button gridSearchButton;
        private zaitun.GUI.DecimalTextBox beta;
        private zaitun.GUI.DecimalTextBox gamma;
        private zaitun.GUI.DecimalTextBox alpha;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton adtRdb;
        private System.Windows.Forms.RadioButton mtpRdb;
        private System.Windows.Forms.Button storageButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}