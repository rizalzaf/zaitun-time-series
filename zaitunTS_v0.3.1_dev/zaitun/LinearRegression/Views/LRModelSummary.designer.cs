using zaitun.GUI;
namespace zaitun.LinearRegression
{
    partial class LRModelSummary
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
            this.groupBoxModelSummary = new System.Windows.Forms.GroupBox();
            this.grdModelSummary = new System.Windows.Forms.DataGridView();
            this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            this.groupBoxModelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModelSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linear Regression Model Summary ";
            // 
            // groupBoxModelSummary
            // 
            this.groupBoxModelSummary.Controls.Add(this.grdModelSummary);
            this.groupBoxModelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxModelSummary.Location = new System.Drawing.Point(0, 46);
            this.groupBoxModelSummary.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.groupBoxModelSummary.Name = "groupBoxModelSummary";
            this.groupBoxModelSummary.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.groupBoxModelSummary.Size = new System.Drawing.Size(512, 307);
            this.groupBoxModelSummary.TabIndex = 2;
            this.groupBoxModelSummary.TabStop = false;
            this.groupBoxModelSummary.Text = "Model Summary";
            // 
            // grdModelSummary
            // 
            this.grdModelSummary.AllowUserToAddRows = false;
            this.grdModelSummary.AllowUserToDeleteRows = false;
            this.grdModelSummary.AllowUserToResizeRows = false;
            this.grdModelSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdModelSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmValue});
            this.grdModelSummary.ContextMenuStrip = this.gridMenuStrip;
            this.grdModelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdModelSummary.Location = new System.Drawing.Point(9, 23);
            this.grdModelSummary.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.grdModelSummary.Name = "grdModelSummary";
            this.grdModelSummary.ReadOnly = true;
            this.grdModelSummary.RowTemplate.Height = 25;
            this.grdModelSummary.Size = new System.Drawing.Size(494, 274);
            this.grdModelSummary.TabIndex = 1;
            // 
            // clmValue
            // 
            this.clmValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmValue.HeaderText = "Value";
            this.clmValue.Name = "clmValue";
            this.clmValue.ReadOnly = true;
            this.clmValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmValue.Width = 59;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 120);
            // 
            // LRModelSummary
            // 
            this.Controls.Add(this.groupBoxModelSummary);
            this.Controls.Add(this.label1);
            this.Name = "LRModelSummary";
            this.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.Size = new System.Drawing.Size(512, 353);
            this.groupBoxModelSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModelSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxModelSummary;
        private System.Windows.Forms.DataGridView grdModelSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
        private GridMenuStrip gridMenuStrip;
    }
}
