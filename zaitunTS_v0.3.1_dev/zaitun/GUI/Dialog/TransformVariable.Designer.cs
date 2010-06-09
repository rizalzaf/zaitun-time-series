namespace zaitun.GUI
{
    partial class TransformVariable
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstVariables = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericLogarithmBase = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericSeasonalLag = new System.Windows.Forms.NumericUpDown();
            this.radioSquareRoot = new System.Windows.Forms.RadioButton();
            this.radioSeasonalDifferencing = new System.Windows.Forms.RadioButton();
            this.radioNaturalLogarithm = new System.Windows.Forms.RadioButton();
            this.radioLogarithm = new System.Windows.Forms.RadioButton();
            this.radioDifferencing = new System.Windows.Forms.RadioButton();
            this.txtName = new zaitun.GUI.NameTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLogarithmBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeasonalLag)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Transformed Variable:";
            // 
            // lstVariables
            // 
            this.lstVariables.FormattingEnabled = true;
            this.lstVariables.Location = new System.Drawing.Point(11, 83);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.Size = new System.Drawing.Size(175, 173);
            this.lstVariables.Sorted = true;
            this.lstVariables.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "New variable name:";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(432, 114);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(84, 25);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(432, 83);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(84, 25);
            this.cmdOK.TabIndex = 24;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericLogarithmBase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericSeasonalLag);
            this.groupBox1.Controls.Add(this.radioSquareRoot);
            this.groupBox1.Controls.Add(this.radioSeasonalDifferencing);
            this.groupBox1.Controls.Add(this.radioNaturalLogarithm);
            this.groupBox1.Controls.Add(this.radioLogarithm);
            this.groupBox1.Controls.Add(this.radioDifferencing);
            this.groupBox1.Location = new System.Drawing.Point(202, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 145);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transformation Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "base";
            // 
            // numericLogarithmBase
            // 
            this.numericLogarithmBase.Location = new System.Drawing.Point(129, 91);
            this.numericLogarithmBase.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericLogarithmBase.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericLogarithmBase.Name = "numericLogarithmBase";
            this.numericLogarithmBase.Size = new System.Drawing.Size(38, 20);
            this.numericLogarithmBase.TabIndex = 7;
            this.numericLogarithmBase.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "lag";
            // 
            // numericSeasonalLag
            // 
            this.numericSeasonalLag.Location = new System.Drawing.Point(173, 45);
            this.numericSeasonalLag.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericSeasonalLag.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericSeasonalLag.Name = "numericSeasonalLag";
            this.numericSeasonalLag.Size = new System.Drawing.Size(38, 20);
            this.numericSeasonalLag.TabIndex = 5;
            this.numericSeasonalLag.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // radioSquareRoot
            // 
            this.radioSquareRoot.AutoSize = true;
            this.radioSquareRoot.Location = new System.Drawing.Point(16, 114);
            this.radioSquareRoot.Name = "radioSquareRoot";
            this.radioSquareRoot.Size = new System.Drawing.Size(80, 17);
            this.radioSquareRoot.TabIndex = 4;
            this.radioSquareRoot.Text = "Square root";
            this.radioSquareRoot.UseVisualStyleBackColor = true;
            // 
            // radioSeasonalDifferencing
            // 
            this.radioSeasonalDifferencing.AutoSize = true;
            this.radioSeasonalDifferencing.Location = new System.Drawing.Point(16, 45);
            this.radioSeasonalDifferencing.Name = "radioSeasonalDifferencing";
            this.radioSeasonalDifferencing.Size = new System.Drawing.Size(127, 17);
            this.radioSeasonalDifferencing.TabIndex = 3;
            this.radioSeasonalDifferencing.Text = "Seasonal differencing";
            this.radioSeasonalDifferencing.UseVisualStyleBackColor = true;
            this.radioSeasonalDifferencing.CheckedChanged += new System.EventHandler(this.radioSeasonalDifferencing_CheckedChanged);
            // 
            // radioNaturalLogarithm
            // 
            this.radioNaturalLogarithm.AutoSize = true;
            this.radioNaturalLogarithm.Location = new System.Drawing.Point(16, 68);
            this.radioNaturalLogarithm.Name = "radioNaturalLogarithm";
            this.radioNaturalLogarithm.Size = new System.Drawing.Size(104, 17);
            this.radioNaturalLogarithm.TabIndex = 2;
            this.radioNaturalLogarithm.Text = "Natural logarithm";
            this.radioNaturalLogarithm.UseVisualStyleBackColor = true;
            // 
            // radioLogarithm
            // 
            this.radioLogarithm.AutoSize = true;
            this.radioLogarithm.Location = new System.Drawing.Point(16, 91);
            this.radioLogarithm.Name = "radioLogarithm";
            this.radioLogarithm.Size = new System.Drawing.Size(71, 17);
            this.radioLogarithm.TabIndex = 1;
            this.radioLogarithm.Text = "Logarithm";
            this.radioLogarithm.UseVisualStyleBackColor = true;
            this.radioLogarithm.CheckedChanged += new System.EventHandler(this.radioLogarithm_CheckedChanged);
            // 
            // radioDifferencing
            // 
            this.radioDifferencing.AutoSize = true;
            this.radioDifferencing.Checked = true;
            this.radioDifferencing.Location = new System.Drawing.Point(16, 22);
            this.radioDifferencing.Name = "radioDifferencing";
            this.radioDifferencing.Size = new System.Drawing.Size(82, 17);
            this.radioDifferencing.TabIndex = 0;
            this.radioDifferencing.TabStop = true;
            this.radioDifferencing.Text = "Differencing";
            this.radioDifferencing.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(202, 233);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(217, 20);
            this.txtName.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 48);
            this.panel1.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Transform Variable";
            // 
            // TransformVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 270);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstVariables);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "TransformVariable";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transform Variable";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLogarithmBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeasonalLag)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstVariables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioLogarithm;
        private System.Windows.Forms.RadioButton radioDifferencing;
        private NameTextBox txtName;
        private System.Windows.Forms.RadioButton radioSquareRoot;
        private System.Windows.Forms.RadioButton radioSeasonalDifferencing;
        private System.Windows.Forms.RadioButton radioNaturalLogarithm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericLogarithmBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericSeasonalLag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}