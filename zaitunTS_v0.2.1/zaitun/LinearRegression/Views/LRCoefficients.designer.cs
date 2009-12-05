using zaitun.GUI;
namespace zaitun.LinearRegression
{
    partial class LRCoefficients
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
            this.grdCoefficients = new System.Windows.Forms.DataGridView();
            this.clmB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStdError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCorr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPartCorr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdCoefficients)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCoefficients
            // 
            this.grdCoefficients.AllowUserToAddRows = false;
            this.grdCoefficients.AllowUserToDeleteRows = false;
            this.grdCoefficients.AllowUserToResizeRows = false;
            this.grdCoefficients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCoefficients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmB,
            this.clmStdError,
            this.clmT,
            this.clmPValue,
            this.clmLB,
            this.clmUB,
            this.clmVIF,
            this.clmCorr,
            this.clmPartCorr});
            this.grdCoefficients.ContextMenuStrip = this.gridMenuStrip;
            this.grdCoefficients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCoefficients.Location = new System.Drawing.Point(0, 46);
            this.grdCoefficients.Margin = new System.Windows.Forms.Padding(10);
            this.grdCoefficients.Name = "grdCoefficients";
            this.grdCoefficients.ReadOnly = true;
            this.grdCoefficients.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdCoefficients.RowTemplate.Height = 25;
            this.grdCoefficients.Size = new System.Drawing.Size(512, 307);
            this.grdCoefficients.TabIndex = 1;
            // 
            // clmB
            // 
            this.clmB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmB.HeaderText = "B";
            this.clmB.Name = "clmB";
            this.clmB.ReadOnly = true;
            this.clmB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmB.Width = 98;
            // 
            // clmStdError
            // 
            this.clmStdError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmStdError.HeaderText = "Std. Error";
            this.clmStdError.Name = "clmStdError";
            this.clmStdError.ReadOnly = true;
            this.clmStdError.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmStdError.Width = 41;
            // 
            // clmT
            // 
            this.clmT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmT.HeaderText = "t";
            this.clmT.Name = "clmT";
            this.clmT.ReadOnly = true;
            this.clmT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmT.Width = 88;
            // 
            // clmPValue
            // 
            this.clmPValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmPValue.HeaderText = "Sig.";
            this.clmPValue.Name = "clmPValue";
            this.clmPValue.ReadOnly = true;
            this.clmPValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmPValue.Width = 38;
            // 
            // clmLB
            // 
            this.clmLB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmLB.HeaderText = "Lower Bound of 95% CI for B";
            this.clmLB.Name = "clmLB";
            this.clmLB.ReadOnly = true;
            this.clmLB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmLB.Width = 50;
            // 
            // clmUB
            // 
            this.clmUB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmUB.HeaderText = "Upper Bound of 95% CI for B";
            this.clmUB.Name = "clmUB";
            this.clmUB.ReadOnly = true;
            this.clmUB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmUB.Width = 50;
            // 
            // clmVIF
            // 
            this.clmVIF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmVIF.HeaderText = "VIF";
            this.clmVIF.Name = "clmVIF";
            this.clmVIF.ReadOnly = true;
            this.clmVIF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmVIF.Width = 50;
            // 
            // clmCorr
            // 
            this.clmCorr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmCorr.HeaderText = "Z-Order Correlation";
            this.clmCorr.Name = "clmCorr";
            this.clmCorr.ReadOnly = true;
            this.clmCorr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmCorr.Width = 50;
            // 
            // clmPartCorr
            // 
            this.clmPartCorr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmPartCorr.HeaderText = "Partial Correlation";
            this.clmPartCorr.Name = "clmPartCorr";
            this.clmPartCorr.ReadOnly = true;
            this.clmPartCorr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmPartCorr.Width = 50;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 120);
            // 
            // LRCoefficients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdCoefficients);
            this.Name = "LRCoefficients";
            this.Size = new System.Drawing.Size(512, 306);
            ((System.ComponentModel.ISupportInitialize)(this.grdCoefficients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCoefficients;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStdError;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCorr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPartCorr;
        private GridMenuStrip gridMenuStrip;
    }
}
