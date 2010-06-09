using zaitun.GUI;
namespace zaitun.ExponentialSmoothing
{
    partial class TripleExponentialSmoothingWinterDataGrid
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdWinter = new System.Windows.Forms.DataGridView();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdWinter)).BeginInit();
            this.SuspendLayout();
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
            // grdWinter
            // 
            this.grdWinter.AllowUserToAddRows = false;
            this.grdWinter.AllowUserToDeleteRows = false;
            this.grdWinter.AllowUserToResizeRows = false;
            this.grdWinter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWinter.ContextMenuStrip = this.gridMenuStrip;
            this.grdWinter.Location = new System.Drawing.Point(0, 0);
            this.grdWinter.Margin = new System.Windows.Forms.Padding(10);
            this.grdWinter.Name = "grdWinter";
            this.grdWinter.ReadOnly = true;
            this.grdWinter.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grdWinter.RowTemplate.Height = 25;
            this.grdWinter.Size = new System.Drawing.Size(512, 353);
            this.grdWinter.TabIndex = 4;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 142);
            // 
            // TripleExponentialSmoothingWinterDataGrid
            // 
            this.Controls.Add(this.grdWinter);
            this.Name = "TripleExponentialSmoothingWinterDataGrid";
            this.Size = new System.Drawing.Size(512, 353);
            ((System.ComponentModel.ISupportInitialize)(this.grdWinter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView grdWinter;
        private GridMenuStrip gridMenuStrip;
    }
}
