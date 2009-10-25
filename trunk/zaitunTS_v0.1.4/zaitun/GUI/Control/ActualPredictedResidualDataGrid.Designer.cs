namespace zaitun.GUI
{
    partial class ActualPredictedResidualDataGrid
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
            this.grdActualPredictedResidual = new System.Windows.Forms.DataGridView();
            this.clmActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPredicted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmResidual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdActualPredictedResidual)).BeginInit();
            this.SuspendLayout();
            // 
            // grdActualPredictedResidual
            // 
            this.grdActualPredictedResidual.AllowUserToAddRows = false;
            this.grdActualPredictedResidual.AllowUserToDeleteRows = false;
            this.grdActualPredictedResidual.AllowUserToResizeRows = false;
            this.grdActualPredictedResidual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdActualPredictedResidual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmActual,
            this.clmPredicted,
            this.clmResidual});
            this.grdActualPredictedResidual.ContextMenuStrip = this.gridMenuStrip;
            this.grdActualPredictedResidual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdActualPredictedResidual.Location = new System.Drawing.Point(0, 0);
            this.grdActualPredictedResidual.Margin = new System.Windows.Forms.Padding(10);
            this.grdActualPredictedResidual.Name = "grdActualPredictedResidual";
            this.grdActualPredictedResidual.ReadOnly = true;
            this.grdActualPredictedResidual.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdActualPredictedResidual.RowTemplate.Height = 25;
            this.grdActualPredictedResidual.Size = new System.Drawing.Size(512, 306);
            this.grdActualPredictedResidual.TabIndex = 3;
            // 
            // clmActual
            // 
            this.clmActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmActual.HeaderText = "Actual";
            this.clmActual.Name = "clmActual";
            this.clmActual.ReadOnly = true;
            this.clmActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmActual.Width = 62;
            // 
            // clmPredicted
            // 
            this.clmPredicted.HeaderText = "Predicted";
            this.clmPredicted.Name = "clmPredicted";
            this.clmPredicted.ReadOnly = true;
            this.clmPredicted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // clmResidual
            // 
            this.clmResidual.HeaderText = "Residual";
            this.clmResidual.Name = "clmResidual";
            this.clmResidual.ReadOnly = true;
            this.clmResidual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(207, 142);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Predicted";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Residual";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ActualPredictedResidualDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdActualPredictedResidual);
            this.Name = "ActualPredictedResidualDataGrid";
            this.Size = new System.Drawing.Size(512, 306);
            ((System.ComponentModel.ISupportInitialize)(this.grdActualPredictedResidual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView grdActualPredictedResidual;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPredicted;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmResidual;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private GridMenuStrip gridMenuStrip;
    }
}
