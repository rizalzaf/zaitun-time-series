namespace zaitun.GUI
{
    partial class CreateNewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewProject));
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipe = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpUndated = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpYear = new System.Windows.Forms.GroupBox();
            this.numMonthEnd = new System.Windows.Forms.NumericUpDown();
            this.numMonthStart = new System.Windows.Forms.NumericUpDown();
            this.txtMinor = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.Label();
            this.numYearEnd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numYearStart = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblObservations = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.grpDate = new System.Windows.Forms.GroupBox();
            this.txtObsDisplay = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new zaitun.GUI.NameTextBox();
            this.txtObservation = new zaitun.GUI.NumericTextBox();
            this.groupBox1.SuspendLayout();
            this.grpUndated.SuspendLayout();
            this.grpYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearStart)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.grpDate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Frequency:";
            // 
            // cmbTipe
            // 
            this.cmbTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipe.FormattingEnabled = true;
            this.cmbTipe.Items.AddRange(new object[] {
            "Annual",
            "Semi Annual",
            "Quarterly",
            "Monthly",
            "Weekly",
            "Daily (7 days a week)",
            "Daily6 (6 days a week)",
            "Daily5 (5 days a week)",
            "Undated"});
            this.cmbTipe.Location = new System.Drawing.Point(72, 19);
            this.cmbTipe.Name = "cmbTipe";
            this.cmbTipe.Size = new System.Drawing.Size(128, 21);
            this.cmbTipe.TabIndex = 8;
            this.cmbTipe.SelectedIndexChanged += new System.EventHandler(this.cmbTipe_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbTipe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 54);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frequency";
            // 
            // grpUndated
            // 
            this.grpUndated.Controls.Add(this.txtObservation);
            this.grpUndated.Controls.Add(this.label8);
            this.grpUndated.Location = new System.Drawing.Point(230, 51);
            this.grpUndated.Name = "grpUndated";
            this.grpUndated.Size = new System.Drawing.Size(264, 104);
            this.grpUndated.TabIndex = 13;
            this.grpUndated.TabStop = false;
            this.grpUndated.Text = "Data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Observations:";
            // 
            // grpYear
            // 
            this.grpYear.BackColor = System.Drawing.Color.Transparent;
            this.grpYear.Controls.Add(this.numMonthEnd);
            this.grpYear.Controls.Add(this.numMonthStart);
            this.grpYear.Controls.Add(this.txtMinor);
            this.grpYear.Controls.Add(this.txtMajor);
            this.grpYear.Controls.Add(this.numYearEnd);
            this.grpYear.Controls.Add(this.label5);
            this.grpYear.Controls.Add(this.label4);
            this.grpYear.Controls.Add(this.numYearStart);
            this.grpYear.Location = new System.Drawing.Point(231, 51);
            this.grpYear.Name = "grpYear";
            this.grpYear.Size = new System.Drawing.Size(263, 104);
            this.grpYear.TabIndex = 12;
            this.grpYear.TabStop = false;
            this.grpYear.Text = "Data";
            // 
            // numMonthEnd
            // 
            this.numMonthEnd.Location = new System.Drawing.Point(173, 66);
            this.numMonthEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonthEnd.Name = "numMonthEnd";
            this.numMonthEnd.Size = new System.Drawing.Size(47, 20);
            this.numMonthEnd.TabIndex = 7;
            this.numMonthEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonthEnd.ValueChanged += new System.EventHandler(this.numMonthEnd_ValueChanged);
            // 
            // numMonthStart
            // 
            this.numMonthStart.Location = new System.Drawing.Point(173, 40);
            this.numMonthStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonthStart.Name = "numMonthStart";
            this.numMonthStart.Size = new System.Drawing.Size(47, 20);
            this.numMonthStart.TabIndex = 6;
            this.numMonthStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonthStart.ValueChanged += new System.EventHandler(this.numMonthStart_ValueChanged);
            // 
            // txtMinor
            // 
            this.txtMinor.AutoSize = true;
            this.txtMinor.Location = new System.Drawing.Point(170, 24);
            this.txtMinor.Name = "txtMinor";
            this.txtMinor.Size = new System.Drawing.Size(45, 13);
            this.txtMinor.TabIndex = 5;
            this.txtMinor.Text = "Quarter:";
            this.txtMinor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMajor
            // 
            this.txtMajor.AutoSize = true;
            this.txtMajor.Location = new System.Drawing.Point(70, 24);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(32, 13);
            this.txtMajor.TabIndex = 4;
            this.txtMajor.Text = "Year:";
            // 
            // numYearEnd
            // 
            this.numYearEnd.Location = new System.Drawing.Point(61, 66);
            this.numYearEnd.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numYearEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYearEnd.Name = "numYearEnd";
            this.numYearEnd.Size = new System.Drawing.Size(73, 20);
            this.numYearEnd.TabIndex = 3;
            this.numYearEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYearEnd.ValueChanged += new System.EventHandler(this.numYearEnd_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "End:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Start:";
            // 
            // numYearStart
            // 
            this.numYearStart.Location = new System.Drawing.Point(61, 40);
            this.numYearStart.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numYearStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYearStart.Name = "numYearStart";
            this.numYearStart.Size = new System.Drawing.Size(73, 20);
            this.numYearStart.TabIndex = 0;
            this.numYearStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYearStart.ValueChanged += new System.EventHandler(this.numYearStart_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Name:";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.txtName);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(231, 186);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(263, 56);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Project Name";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(118, 217);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 25);
            this.cmdCancel.TabIndex = 18;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(12, 217);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(94, 25);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblObservations
            // 
            this.lblObservations.AutoSize = true;
            this.lblObservations.BackColor = System.Drawing.Color.Transparent;
            this.lblObservations.Location = new System.Drawing.Point(340, 161);
            this.lblObservations.Name = "lblObservations";
            this.lblObservations.Size = new System.Drawing.Size(72, 13);
            this.lblObservations.TabIndex = 19;
            this.lblObservations.Text = "Observations:";
            this.lblObservations.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Date:";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd MMMM yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(89, 25);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(154, 20);
            this.dtpStart.TabIndex = 7;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "End Date:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd MMMM yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(89, 54);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(154, 20);
            this.dtpEnd.TabIndex = 9;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // grpDate
            // 
            this.grpDate.Controls.Add(this.dtpEnd);
            this.grpDate.Controls.Add(this.label2);
            this.grpDate.Controls.Add(this.dtpStart);
            this.grpDate.Controls.Add(this.label1);
            this.grpDate.Location = new System.Drawing.Point(231, 51);
            this.grpDate.Name = "grpDate";
            this.grpDate.Size = new System.Drawing.Size(263, 104);
            this.grpDate.TabIndex = 11;
            this.grpDate.TabStop = false;
            this.grpDate.Text = "Data";
            // 
            // txtObsDisplay
            // 
            this.txtObsDisplay.Location = new System.Drawing.Point(418, 158);
            this.txtObsDisplay.Name = "txtObsDisplay";
            this.txtObsDisplay.ReadOnly = true;
            this.txtObsDisplay.Size = new System.Drawing.Size(76, 20);
            this.txtObsDisplay.TabIndex = 20;
            this.txtObsDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 48);
            this.panel1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Create New Project";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(51, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(199, 20);
            this.txtName.TabIndex = 15;
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(168, 18);
            this.txtObservation.MaxLength = 7;
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(76, 20);
            this.txtObservation.TabIndex = 2;
            this.txtObservation.Text = "0";
            this.txtObservation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtObservation.TextChanged += new System.EventHandler(this.txtObservation_TextChanged);
            // 
            // CreateNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(506, 254);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtObsDisplay);
            this.Controls.Add(this.lblObservations);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpYear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDate);
            this.Controls.Add(this.grpUndated);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateNewProject";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Project";
            this.Load += new System.EventHandler(this.CreateNewProject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpUndated.ResumeLayout(false);
            this.grpUndated.PerformLayout();
            this.grpYear.ResumeLayout(false);
            this.grpYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearStart)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpDate.ResumeLayout(false);
            this.grpDate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpYear;
        private System.Windows.Forms.NumericUpDown numYearEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numYearStart;
        private System.Windows.Forms.Label txtMajor;
        private System.Windows.Forms.NumericUpDown numMonthEnd;
        private System.Windows.Forms.NumericUpDown numMonthStart;
        private System.Windows.Forms.Label txtMinor;
        private System.Windows.Forms.GroupBox grpUndated;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private NameTextBox txtName;
        private System.Windows.Forms.Label lblObservations;
        private NumericTextBox txtObservation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.GroupBox grpDate;
        private System.Windows.Forms.TextBox txtObsDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}