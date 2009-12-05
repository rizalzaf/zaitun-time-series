namespace zaitun.GUI
{
    partial class CreateSeriesStock
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
            this.Nama = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lstVariables = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdVolume = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdLow = new System.Windows.Forms.Button();
            this.cmdHigh = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtVolume = new zaitun.GUI.NameTextBox();
            this.txtClose = new zaitun.GUI.NameTextBox();
            this.txtLow = new zaitun.GUI.NameTextBox();
            this.txtHigh = new zaitun.GUI.NameTextBox();
            this.txtOpen = new zaitun.GUI.NameTextBox();
            this.txtName = new zaitun.GUI.NameTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nama
            // 
            this.Nama.AutoSize = true;
            this.Nama.Location = new System.Drawing.Point(12, 56);
            this.Nama.Name = "Nama";
            this.Nama.Size = new System.Drawing.Size(35, 13);
            this.Nama.TabIndex = 20;
            this.Nama.Text = "Name";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(365, 88);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 25);
            this.cmdCancel.TabIndex = 19;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(365, 56);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(94, 25);
            this.cmdOK.TabIndex = 18;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lstVariables
            // 
            this.lstVariables.FormattingEnabled = true;
            this.lstVariables.Location = new System.Drawing.Point(6, 19);
            this.lstVariables.Name = "lstVariables";
            this.lstVariables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstVariables.Size = new System.Drawing.Size(189, 199);
            this.lstVariables.Sorted = true;
            this.lstVariables.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 48);
            this.panel1.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Create New Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Open";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "High";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Close";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Low";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Volume";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstVariables);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 229);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Variables";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdVolume);
            this.groupBox2.Controls.Add(this.cmdClose);
            this.groupBox2.Controls.Add(this.cmdLow);
            this.groupBox2.Controls.Add(this.cmdHigh);
            this.groupBox2.Controls.Add(this.cmdOpen);
            this.groupBox2.Controls.Add(this.txtVolume);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtClose);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLow);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtHigh);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtOpen);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(219, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 229);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock\'s Variables";
            // 
            // cmdVolume
            // 
            this.cmdVolume.Location = new System.Drawing.Point(4, 191);
            this.cmdVolume.Name = "cmdVolume";
            this.cmdVolume.Size = new System.Drawing.Size(30, 20);
            this.cmdVolume.TabIndex = 44;
            this.cmdVolume.Text = ">";
            this.cmdVolume.UseVisualStyleBackColor = true;
            this.cmdVolume.Click += new System.EventHandler(this.cmdVolume_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(4, 152);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(30, 20);
            this.cmdClose.TabIndex = 43;
            this.cmdClose.Text = ">";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdLow
            // 
            this.cmdLow.Location = new System.Drawing.Point(4, 112);
            this.cmdLow.Name = "cmdLow";
            this.cmdLow.Size = new System.Drawing.Size(30, 20);
            this.cmdLow.TabIndex = 42;
            this.cmdLow.Text = ">";
            this.cmdLow.UseVisualStyleBackColor = true;
            this.cmdLow.Click += new System.EventHandler(this.cmdLow_Click);
            // 
            // cmdHigh
            // 
            this.cmdHigh.Location = new System.Drawing.Point(4, 74);
            this.cmdHigh.Name = "cmdHigh";
            this.cmdHigh.Size = new System.Drawing.Size(30, 20);
            this.cmdHigh.TabIndex = 41;
            this.cmdHigh.Text = ">";
            this.cmdHigh.UseVisualStyleBackColor = true;
            this.cmdHigh.Click += new System.EventHandler(this.cmdHigh_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(4, 35);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(30, 20);
            this.cmdOpen.TabIndex = 40;
            this.cmdOpen.Text = ">";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(88, 82);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(271, 47);
            this.txtDescription.TabIndex = 40;
            // 
            // txtVolume
            // 
            this.txtVolume.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtVolume.Location = new System.Drawing.Point(40, 191);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(187, 20);
            this.txtVolume.TabIndex = 39;
            // 
            // txtClose
            // 
            this.txtClose.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtClose.Location = new System.Drawing.Point(40, 153);
            this.txtClose.Name = "txtClose";
            this.txtClose.ReadOnly = true;
            this.txtClose.Size = new System.Drawing.Size(187, 20);
            this.txtClose.TabIndex = 37;
            // 
            // txtLow
            // 
            this.txtLow.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLow.Location = new System.Drawing.Point(40, 113);
            this.txtLow.Name = "txtLow";
            this.txtLow.ReadOnly = true;
            this.txtLow.Size = new System.Drawing.Size(187, 20);
            this.txtLow.TabIndex = 35;
            // 
            // txtHigh
            // 
            this.txtHigh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtHigh.Location = new System.Drawing.Point(40, 75);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.ReadOnly = true;
            this.txtHigh.Size = new System.Drawing.Size(187, 20);
            this.txtHigh.TabIndex = 33;
            // 
            // txtOpen
            // 
            this.txtOpen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtOpen.Location = new System.Drawing.Point(40, 35);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.ReadOnly = true;
            this.txtOpen.Size = new System.Drawing.Size(187, 20);
            this.txtOpen.TabIndex = 31;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(271, 20);
            this.txtName.TabIndex = 24;
            // 
            // CreateSeriesStock
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(471, 376);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Nama);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "CreateSeriesStock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Stock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nama;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ListBox lstVariables;
        private NameTextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private NameTextBox txtOpen;
        private System.Windows.Forms.Label label3;
        private NameTextBox txtHigh;
        private System.Windows.Forms.Label label4;
        private NameTextBox txtClose;
        private System.Windows.Forms.Label label5;
        private NameTextBox txtLow;
        private System.Windows.Forms.Label label7;
        private NameTextBox txtVolume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdVolume;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdLow;
        private System.Windows.Forms.Button cmdHigh;
        private System.Windows.Forms.Button cmdOpen;
    }
}