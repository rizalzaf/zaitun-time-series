namespace zaitun.GUI
{
    partial class ForecastedDataGrid
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
            this.grdForecasted = new System.Windows.Forms.DataGridView();
            this.clmForecasted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdForecasted)).BeginInit();
            this.SuspendLayout();
            // 
            // grdForecasted
            // 
            this.grdForecasted.AllowUserToAddRows = false;
            this.grdForecasted.AllowUserToDeleteRows = false;
            this.grdForecasted.AllowUserToResizeRows = false;
            this.grdForecasted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdForecasted.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmForecasted});
            this.grdForecasted.ContextMenuStrip = this.gridMenuStrip;
            this.grdForecasted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdForecasted.Location = new System.Drawing.Point(0, 0);
            this.grdForecasted.Margin = new System.Windows.Forms.Padding(10);
            this.grdForecasted.Name = "grdForecasted";
            this.grdForecasted.ReadOnly = true;
            this.grdForecasted.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdForecasted.RowTemplate.Height = 25;
            this.grdForecasted.Size = new System.Drawing.Size(512, 306);
            this.grdForecasted.TabIndex = 3;
            // 
            // clmForecasted
            // 
            this.clmForecasted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmForecasted.HeaderText = "Forecasted";
            this.clmForecasted.Name = "clmForecasted";
            this.clmForecasted.ReadOnly = true;
            this.clmForecasted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmForecasted.Width = 85;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Predicted";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Residual";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(207, 120);
            // 
            // ForecastedDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdForecasted);
            this.Name = "ForecastedDataGrid";
            this.Size = new System.Drawing.Size(512, 306);
            ((System.ComponentModel.ISupportInitialize)(this.grdForecasted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView grdForecasted;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmForecasted;
        private GridMenuStrip gridMenuStrip;
    }
}
