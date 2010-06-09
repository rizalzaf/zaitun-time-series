using zaitun.GUI;
namespace zaitun.LinearRegression
{
    partial class LRANOVA
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
            this.grdANOVA = new System.Windows.Forms.DataGridView();
            this.clmSumOfSquares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDegreeOfFreedom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMeanSquare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdANOVA)).BeginInit();
            this.SuspendLayout();
            // 
            // grdANOVA
            // 
            this.grdANOVA.AllowUserToAddRows = false;
            this.grdANOVA.AllowUserToDeleteRows = false;
            this.grdANOVA.AllowUserToResizeRows = false;
            this.grdANOVA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdANOVA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSumOfSquares,
            this.clmDegreeOfFreedom,
            this.clmMeanSquare,
            this.clmF,
            this.clmPValue});
            this.grdANOVA.ContextMenuStrip = this.gridMenuStrip;
            this.grdANOVA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdANOVA.Location = new System.Drawing.Point(0, 46);
            this.grdANOVA.Margin = new System.Windows.Forms.Padding(10);
            this.grdANOVA.Name = "grdANOVA";
            this.grdANOVA.ReadOnly = true;
            this.grdANOVA.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdANOVA.RowTemplate.Height = 25;
            this.grdANOVA.Size = new System.Drawing.Size(512, 307);
            this.grdANOVA.TabIndex = 1;
            // 
            // clmSumOfSquares
            // 
            this.clmSumOfSquares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSumOfSquares.HeaderText = "Sum of Squares";
            this.clmSumOfSquares.Name = "clmSumOfSquares";
            this.clmSumOfSquares.ReadOnly = true;
            this.clmSumOfSquares.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmSumOfSquares.Width = 98;
            // 
            // clmDegreeOfFreedom
            // 
            this.clmDegreeOfFreedom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDegreeOfFreedom.HeaderText = "df";
            this.clmDegreeOfFreedom.Name = "clmDegreeOfFreedom";
            this.clmDegreeOfFreedom.ReadOnly = true;
            this.clmDegreeOfFreedom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmDegreeOfFreedom.Width = 41;
            // 
            // clmMeanSquare
            // 
            this.clmMeanSquare.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmMeanSquare.HeaderText = "Mean Square";
            this.clmMeanSquare.Name = "clmMeanSquare";
            this.clmMeanSquare.ReadOnly = true;
            this.clmMeanSquare.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmMeanSquare.Width = 88;
            // 
            // clmF
            // 
            this.clmF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmF.HeaderText = "F";
            this.clmF.Name = "clmF";
            this.clmF.ReadOnly = true;
            this.clmF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmF.Width = 38;
            // 
            // clmPValue
            // 
            this.clmPValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmPValue.HeaderText = "Sig.";
            this.clmPValue.Name = "clmPValue";
            this.clmPValue.ReadOnly = true;
            this.clmPValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clmPValue.Width = 50;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 120);
            // 
            // LRANOVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdANOVA);
            this.Name = "LRANOVA";
            this.Size = new System.Drawing.Size(512, 306);
            ((System.ComponentModel.ISupportInitialize)(this.grdANOVA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdANOVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSumOfSquares;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDegreeOfFreedom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMeanSquare;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPValue;
        private GridMenuStrip gridMenuStrip;
    }
}
