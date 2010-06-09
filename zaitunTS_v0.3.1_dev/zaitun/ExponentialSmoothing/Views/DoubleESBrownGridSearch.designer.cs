namespace zaitun.ExponentialSmoothing
{
    partial class DoubleESBrownGridSearch
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
            this.components = new System.ComponentModel.Container();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.alphaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.solutionBox = new zaitun.GUI.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.alphaStopUpDown = new System.Windows.Forms.NumericUpDown();
            this.alphaIncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.alphaStartUpDown = new System.Windows.Forms.NumericUpDown();
            this.searchButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaStopUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaIncrementUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaStartUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alphaColumn,
            this.maeColumn,
            this.mseColumn,
            this.mpeColumn,
            this.mapeColumn});
            this.resultGrid.Location = new System.Drawing.Point(18, 140);
            this.resultGrid.MultiSelect = false;
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.ReadOnly = true;
            this.resultGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.resultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid.ShowCellToolTips = false;
            this.resultGrid.Size = new System.Drawing.Size(606, 280);
            this.resultGrid.TabIndex = 0;
            // 
            // alphaColumn
            // 
            this.alphaColumn.HeaderText = "Alpha";
            this.alphaColumn.Name = "alphaColumn";
            this.alphaColumn.ReadOnly = true;
            // 
            // maeColumn
            // 
            this.maeColumn.HeaderText = "MAE";
            this.maeColumn.Name = "maeColumn";
            this.maeColumn.ReadOnly = true;
            // 
            // mseColumn
            // 
            this.mseColumn.HeaderText = "MSE";
            this.mseColumn.Name = "mseColumn";
            this.mseColumn.ReadOnly = true;
            // 
            // mpeColumn
            // 
            this.mpeColumn.HeaderText = "MPE";
            this.mpeColumn.Name = "mpeColumn";
            this.mpeColumn.ReadOnly = true;
            // 
            // mapeColumn
            // 
            this.mapeColumn.HeaderText = "MAPE";
            this.mapeColumn.Name = "mapeColumn";
            this.mapeColumn.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.solutionBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.alphaStopUpDown);
            this.groupBox1.Controls.Add(this.alphaIncrementUpDown);
            this.groupBox1.Controls.Add(this.alphaStartUpDown);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Parameter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(445, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Solution:";
            // 
            // solutionBox
            // 
            this.solutionBox.Location = new System.Drawing.Point(439, 36);
            this.solutionBox.Name = "solutionBox";
            this.solutionBox.Size = new System.Drawing.Size(57, 20);
            this.solutionBox.TabIndex = 11;
            this.solutionBox.Text = "10";
            this.solutionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(411, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(2, 38);
            this.label6.TabIndex = 10;
            // 
            // alphaStopUpDown
            // 
            this.alphaStopUpDown.DecimalPlaces = 3;
            this.alphaStopUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.alphaStopUpDown.Location = new System.Drawing.Point(303, 37);
            this.alphaStopUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alphaStopUpDown.Name = "alphaStopUpDown";
            this.alphaStopUpDown.Size = new System.Drawing.Size(69, 20);
            this.alphaStopUpDown.TabIndex = 7;
            this.alphaStopUpDown.Value = new decimal(new int[] {
            900,
            0,
            0,
            196608});
            // 
            // alphaIncrementUpDown
            // 
            this.alphaIncrementUpDown.DecimalPlaces = 3;
            this.alphaIncrementUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.alphaIncrementUpDown.Location = new System.Drawing.Point(192, 37);
            this.alphaIncrementUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alphaIncrementUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.alphaIncrementUpDown.Name = "alphaIncrementUpDown";
            this.alphaIncrementUpDown.Size = new System.Drawing.Size(69, 20);
            this.alphaIncrementUpDown.TabIndex = 6;
            this.alphaIncrementUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            196608});
            // 
            // alphaStartUpDown
            // 
            this.alphaStartUpDown.DecimalPlaces = 3;
            this.alphaStartUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.alphaStartUpDown.Location = new System.Drawing.Point(86, 37);
            this.alphaStartUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alphaStartUpDown.Name = "alphaStartUpDown";
            this.alphaStartUpDown.Size = new System.Drawing.Size(69, 20);
            this.alphaStartUpDown.TabIndex = 5;
            this.alphaStartUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            196608});
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(525, 19);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(87, 35);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stop parameter at:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Increment by:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start parameter at:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "alpha";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 305);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Best Result";
            // 
            // selectButton
            // 
            this.selectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.selectButton.Enabled = false;
            this.selectButton.Location = new System.Drawing.Point(432, 436);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(99, 29);
            this.selectButton.TabIndex = 3;
            this.selectButton.Text = "Select This";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(537, 436);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 29);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Alpha";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "MAD";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "MAPE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "MSE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "MPE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(134, 441);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(250, 441);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(74, 13);
            this.textBox2.TabIndex = 8;
            this.textBox2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::zaitun.Properties.Resources.bottom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 48);
            this.panel1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(555, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Double Exponential Smoothing (Brown) Grid Search";
            // 
            // DoubleESBrownGridSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 476);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoubleESBrownGridSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Double ES Brown Grid Search";
            this.Load += new System.EventHandler(this.DoubleESBrownGridSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaStopUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaIncrementUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaStartUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.NumericUpDown alphaStartUpDown;
        private System.Windows.Forms.NumericUpDown alphaStopUpDown;
        private System.Windows.Forms.NumericUpDown alphaIncrementUpDown;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label6;
        private zaitun.GUI.NumericTextBox solutionBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn alphaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mpeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapeColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}