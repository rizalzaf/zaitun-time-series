namespace zaitun.GUI
{
    partial class GroupDataGrid
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
            this.grdSeriesGroup = new System.Windows.Forms.DataGridView();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdSeriesGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSeriesGroup
            // 
            this.grdSeriesGroup.AllowUserToAddRows = false;
            this.grdSeriesGroup.AllowUserToDeleteRows = false;
            this.grdSeriesGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSeriesGroup.ContextMenuStrip = this.gridMenuStrip;
            this.grdSeriesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSeriesGroup.Location = new System.Drawing.Point(0, 0);
            this.grdSeriesGroup.Name = "grdSeriesGroup";
            this.grdSeriesGroup.ReadOnly = true;
            this.grdSeriesGroup.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdSeriesGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.grdSeriesGroup.Size = new System.Drawing.Size(410, 239);
            this.grdSeriesGroup.TabIndex = 0;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(207, 120);
            // 
            // GroupDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdSeriesGroup);
            this.Name = "GroupDataGrid";
            this.Size = new System.Drawing.Size(410, 239);
            ((System.ComponentModel.ISupportInitialize)(this.grdSeriesGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSeriesGroup;
        private GridMenuStrip gridMenuStrip;

    }
}
