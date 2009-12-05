using zaitun.GUI;
namespace zaitun.Decomposition
{
    partial class DecompositionDataGrid
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
            this.grdDecomposition = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdDecomposition)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDecomposition
            // 
            this.grdDecomposition.AllowUserToAddRows = false;
            this.grdDecomposition.AllowUserToDeleteRows = false;
            this.grdDecomposition.AllowUserToResizeRows = false;
            this.grdDecomposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDecomposition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDecomposition.ContextMenuStrip = this.gridMenuStrip;
            this.grdDecomposition.Location = new System.Drawing.Point(0, 0);
            this.grdDecomposition.Margin = new System.Windows.Forms.Padding(10);
            this.grdDecomposition.Name = "grdDecomposition";
            this.grdDecomposition.ReadOnly = true;
            this.grdDecomposition.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdDecomposition.RowTemplate.Height = 25;
            this.grdDecomposition.Size = new System.Drawing.Size(512, 306);
            this.grdDecomposition.TabIndex = 3;
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
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 142);
            // 
            // DecompositionDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdDecomposition);
            this.Name = "DecompositionDataGrid";
            this.Size = new System.Drawing.Size(512, 306);
            ((System.ComponentModel.ISupportInitialize)(this.grdDecomposition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView grdDecomposition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private GridMenuStrip gridMenuStrip;
    }
}
