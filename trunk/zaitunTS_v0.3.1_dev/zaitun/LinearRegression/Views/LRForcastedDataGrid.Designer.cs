namespace zaitun.LinearRegression
{
    partial class LRForcastedDataGrid
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
            this.grdForcasted = new System.Windows.Forms.DataGridView();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdForcasted)).BeginInit();
            this.SuspendLayout();
            // 
            // grdForcasted
            // 
            this.grdForcasted.AllowUserToAddRows = false;
            this.grdForcasted.AllowUserToDeleteRows = false;
            this.grdForcasted.AllowUserToResizeRows = false;
            this.grdForcasted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdForcasted.ContextMenuStrip = this.gridMenuStrip;
            this.grdForcasted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdForcasted.Location = new System.Drawing.Point(0, 0);
            this.grdForcasted.Margin = new System.Windows.Forms.Padding(10);
            this.grdForcasted.Name = "grdForcasted";
            this.grdForcasted.ReadOnly = true;
            this.grdForcasted.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdForcasted.RowTemplate.Height = 25;
            this.grdForcasted.Size = new System.Drawing.Size(484, 374);
            this.grdForcasted.TabIndex = 2;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 120);
            // 
            // LRForcastedDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdForcasted);
            this.Name = "LRForcastedDataGrid";
            this.Size = new System.Drawing.Size(484, 374);
            ((System.ComponentModel.ISupportInitialize)(this.grdForcasted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdForcasted;
        private zaitun.GUI.GridMenuStrip gridMenuStrip;
    }
}
