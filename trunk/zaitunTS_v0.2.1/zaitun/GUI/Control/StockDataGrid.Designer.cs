namespace zaitun.GUI
{
    partial class StockDataGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdSeriesStock = new System.Windows.Forms.DataGridView();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            this.clmOpen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmClose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdSeriesStock)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSeriesStock
            // 
            this.grdSeriesStock.AllowUserToAddRows = false;
            this.grdSeriesStock.AllowUserToDeleteRows = false;
            this.grdSeriesStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSeriesStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmOpen,
            this.clmHigh,
            this.clmLow,
            this.clmClose,
            this.clmVolume});
            this.grdSeriesStock.ContextMenuStrip = this.gridMenuStrip;
            this.grdSeriesStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSeriesStock.Location = new System.Drawing.Point(0, 0);
            this.grdSeriesStock.Name = "grdSeriesStock";
            this.grdSeriesStock.ReadOnly = true;
            this.grdSeriesStock.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdSeriesStock.Size = new System.Drawing.Size(410, 239);
            this.grdSeriesStock.TabIndex = 0;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 120);
            // 
            // clmOpen
            // 
            this.clmOpen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "G7";
            dataGridViewCellStyle1.NullValue = null;
            this.clmOpen.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmOpen.HeaderText = "Open";
            this.clmOpen.Name = "clmOpen";
            this.clmOpen.ReadOnly = true;
            this.clmOpen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmOpen.Width = 58;
            // 
            // clmHigh
            // 
            this.clmHigh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "G7";
            this.clmHigh.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmHigh.HeaderText = "High";
            this.clmHigh.Name = "clmHigh";
            this.clmHigh.ReadOnly = true;
            this.clmHigh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmHigh.Width = 54;
            // 
            // clmLow
            // 
            this.clmLow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "G7";
            this.clmLow.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmLow.HeaderText = "Low";
            this.clmLow.Name = "clmLow";
            this.clmLow.ReadOnly = true;
            this.clmLow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmLow.Width = 52;
            // 
            // clmClose
            // 
            this.clmClose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "G7";
            this.clmClose.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmClose.HeaderText = "Close";
            this.clmClose.Name = "clmClose";
            this.clmClose.ReadOnly = true;
            this.clmClose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmClose.Width = 58;
            // 
            // clmVolume
            // 
            this.clmVolume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Format = "G7";
            this.clmVolume.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmVolume.HeaderText = "Volume";
            this.clmVolume.Name = "clmVolume";
            this.clmVolume.ReadOnly = true;
            this.clmVolume.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmVolume.Width = 67;
            // 
            // StockDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdSeriesStock);
            this.Name = "StockDataGrid";
            this.Size = new System.Drawing.Size(410, 239);
            ((System.ComponentModel.ISupportInitialize)(this.grdSeriesStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSeriesStock;
        private GridMenuStrip gridMenuStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVolume;

    }
}
