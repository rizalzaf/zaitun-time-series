namespace zaitun.GUI
{
    partial class ImportCSVDialog
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
            this.filePathLabel = new System.Windows.Forms.Label();
            this.previewTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.variableNameGrid = new System.Windows.Forms.DataGridView();
            this.checkColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.noColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customRadio = new System.Windows.Forms.RadioButton();
            this.useFirstRowRadio = new System.Windows.Forms.RadioButton();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variableNameGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filePathLabel);
            this.groupBox1.Location = new System.Drawing.Point(10, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imported File";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(16, 21);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(72, 13);
            this.filePathLabel.TabIndex = 0;
            this.filePathLabel.Text = "FIlePathLabel";
            // 
            // previewTextBox
            // 
            this.previewTextBox.BackColor = System.Drawing.Color.White;
            this.previewTextBox.Location = new System.Drawing.Point(6, 19);
            this.previewTextBox.Name = "previewTextBox";
            this.previewTextBox.ReadOnly = true;
            this.previewTextBox.Size = new System.Drawing.Size(343, 229);
            this.previewTextBox.TabIndex = 1;
            this.previewTextBox.Text = "";
            this.previewTextBox.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.previewTextBox);
            this.groupBox2.Location = new System.Drawing.Point(191, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 254);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.variableNameGrid);
            this.groupBox3.Controls.Add(this.customRadio);
            this.groupBox3.Controls.Add(this.useFirstRowRadio);
            this.groupBox3.Location = new System.Drawing.Point(10, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 253);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // variableNameGrid
            // 
            this.variableNameGrid.AllowUserToAddRows = false;
            this.variableNameGrid.AllowUserToDeleteRows = false;
            this.variableNameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variableNameGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkColumn,
            this.noColumn,
            this.nameColumn});
            this.variableNameGrid.Location = new System.Drawing.Point(6, 76);
            this.variableNameGrid.Name = "variableNameGrid";
            this.variableNameGrid.RowHeadersVisible = false;
            this.variableNameGrid.Size = new System.Drawing.Size(164, 171);
            this.variableNameGrid.TabIndex = 2;
            // 
            // checkColumn
            // 
            this.checkColumn.HeaderText = "";
            this.checkColumn.Name = "checkColumn";
            this.checkColumn.Width = 20;
            // 
            // noColumn
            // 
            this.noColumn.HeaderText = "No";
            this.noColumn.Name = "noColumn";
            this.noColumn.ReadOnly = true;
            this.noColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.noColumn.Width = 28;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // customRadio
            // 
            this.customRadio.AutoSize = true;
            this.customRadio.Checked = true;
            this.customRadio.Location = new System.Drawing.Point(6, 53);
            this.customRadio.Name = "customRadio";
            this.customRadio.Size = new System.Drawing.Size(60, 17);
            this.customRadio.TabIndex = 1;
            this.customRadio.TabStop = true;
            this.customRadio.Text = "Custom";
            this.customRadio.UseVisualStyleBackColor = true;
            this.customRadio.CheckedChanged += new System.EventHandler(this.customRadio_CheckedChanged);
            // 
            // useFirstRowRadio
            // 
            this.useFirstRowRadio.Location = new System.Drawing.Point(6, 15);
            this.useFirstRowRadio.Name = "useFirstRowRadio";
            this.useFirstRowRadio.Size = new System.Drawing.Size(114, 32);
            this.useFirstRowRadio.TabIndex = 0;
            this.useFirstRowRadio.TabStop = true;
            this.useFirstRowRadio.Text = "Use First Rows as Variable Name";
            this.useFirstRowRadio.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(471, 66);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 35);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(374, 66);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(91, 35);
            this.cmdOK.TabIndex = 20;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 33;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 105;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 48);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Import CSV File";
            // 
            // ImportCSVDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImportCSVDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import CSV";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variableNameGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.RichTextBox previewTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.RadioButton useFirstRowRadio;
        private System.Windows.Forms.RadioButton customRadio;
        private System.Windows.Forms.DataGridView variableNameGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}