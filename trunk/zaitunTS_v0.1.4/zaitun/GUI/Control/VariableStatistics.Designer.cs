namespace zaitun.GUI
{
    partial class VariableStatistics
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVariable = new System.Windows.Forms.Label();
            this.groupBoxStat = new System.Windows.Forms.GroupBox();
            this.grdDescriptive = new System.Windows.Forms.DataGridView();
            this.clmData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            this.groupBoxStat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDescriptive)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descriptive Statistics for Variable:";
            // 
            // lblVariable
            // 
            this.lblVariable.AutoSize = true;
            this.lblVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariable.Location = new System.Drawing.Point(254, 15);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(84, 16);
            this.lblVariable.TabIndex = 1;
            this.lblVariable.Text = "lblVariable";
            // 
            // groupBoxStat
            // 
            this.groupBoxStat.Controls.Add(this.grdDescriptive);
            this.groupBoxStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStat.Location = new System.Drawing.Point(0, 40);
            this.groupBoxStat.Margin = new System.Windows.Forms.Padding(9);
            this.groupBoxStat.Name = "groupBoxStat";
            this.groupBoxStat.Padding = new System.Windows.Forms.Padding(9);
            this.groupBoxStat.Size = new System.Drawing.Size(512, 266);
            this.groupBoxStat.TabIndex = 2;
            this.groupBoxStat.TabStop = false;
            this.groupBoxStat.Text = "Descriptive Statistics";
            // 
            // grdDescriptive
            // 
            this.grdDescriptive.AllowUserToAddRows = false;
            this.grdDescriptive.AllowUserToDeleteRows = false;
            this.grdDescriptive.AllowUserToResizeRows = false;
            this.grdDescriptive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDescriptive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmData});
            this.grdDescriptive.ContextMenuStrip = this.gridMenuStrip;
            this.grdDescriptive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDescriptive.Location = new System.Drawing.Point(9, 22);
            this.grdDescriptive.Margin = new System.Windows.Forms.Padding(10);
            this.grdDescriptive.Name = "grdDescriptive";
            this.grdDescriptive.ReadOnly = true;
            this.grdDescriptive.Size = new System.Drawing.Size(494, 235);
            this.grdDescriptive.TabIndex = 1;
            // 
            // clmData
            // 
            this.clmData.HeaderText = "Data";
            this.clmData.Name = "clmData";
            this.clmData.ReadOnly = true;
            this.clmData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 120);
            // 
            // VariableStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxStat);
            this.Controls.Add(this.lblVariable);
            this.Controls.Add(this.label1);
            this.Name = "VariableStatistics";
            this.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.Size = new System.Drawing.Size(512, 306);
            this.groupBoxStat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDescriptive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.GroupBox groupBoxStat;
        private System.Windows.Forms.DataGridView grdDescriptive;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmData;
        private GridMenuStrip gridMenuStrip;
    }
}
