namespace zaitun.Correlogram
{
    partial class CorrelogramResult
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.gridMenuStrip = new zaitun.GUI.GridMenuStrip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acfColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pacfColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qStatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.probColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 424);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ACF / PACF";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zedGraphControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ACF Graph";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zedGraphControl1.IsAutoScrollRange = false;
            this.zedGraphControl1.IsEnableHEdit = false;
            this.zedGraphControl1.IsEnableHPan = true;
            this.zedGraphControl1.IsEnableHZoom = true;
            this.zedGraphControl1.IsEnableVEdit = false;
            this.zedGraphControl1.IsEnableVPan = true;
            this.zedGraphControl1.IsEnableVZoom = true;
            this.zedGraphControl1.IsPrintFillPage = true;
            this.zedGraphControl1.IsPrintKeepAspectRatio = true;
            this.zedGraphControl1.IsScrollY2 = false;
            this.zedGraphControl1.IsShowContextMenu = true;
            this.zedGraphControl1.IsShowCopyMessage = true;
            this.zedGraphControl1.IsShowCursorValues = false;
            this.zedGraphControl1.IsShowHScrollBar = false;
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.IsShowVScrollBar = false;
            this.zedGraphControl1.IsSynchronizeXAxes = false;
            this.zedGraphControl1.IsSynchronizeYAxes = false;
            this.zedGraphControl1.IsZoomOnMouseCenter = false;
            this.zedGraphControl1.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zedGraphControl1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.PointDateFormat = "g";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(541, 389);
            this.zedGraphControl1.TabIndex = 1;
            this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zedGraphControl1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomStepFraction = 0.1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.zedGraphControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(547, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PACF Graph";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl2.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl2.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zedGraphControl2.IsAutoScrollRange = false;
            this.zedGraphControl2.IsEnableHEdit = false;
            this.zedGraphControl2.IsEnableHPan = true;
            this.zedGraphControl2.IsEnableHZoom = true;
            this.zedGraphControl2.IsEnableVEdit = false;
            this.zedGraphControl2.IsEnableVPan = true;
            this.zedGraphControl2.IsEnableVZoom = true;
            this.zedGraphControl2.IsPrintFillPage = true;
            this.zedGraphControl2.IsPrintKeepAspectRatio = true;
            this.zedGraphControl2.IsScrollY2 = false;
            this.zedGraphControl2.IsShowContextMenu = true;
            this.zedGraphControl2.IsShowCopyMessage = true;
            this.zedGraphControl2.IsShowCursorValues = false;
            this.zedGraphControl2.IsShowHScrollBar = false;
            this.zedGraphControl2.IsShowPointValues = false;
            this.zedGraphControl2.IsShowVScrollBar = false;
            this.zedGraphControl2.IsSynchronizeXAxes = false;
            this.zedGraphControl2.IsSynchronizeYAxes = false;
            this.zedGraphControl2.IsZoomOnMouseCenter = false;
            this.zedGraphControl2.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl2.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zedGraphControl2.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl2.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zedGraphControl2.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl2.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl2.PointDateFormat = "g";
            this.zedGraphControl2.PointValueFormat = "G";
            this.zedGraphControl2.ScrollMaxX = 0;
            this.zedGraphControl2.ScrollMaxY = 0;
            this.zedGraphControl2.ScrollMaxY2 = 0;
            this.zedGraphControl2.ScrollMinX = 0;
            this.zedGraphControl2.ScrollMinY = 0;
            this.zedGraphControl2.ScrollMinY2 = 0;
            this.zedGraphControl2.Size = new System.Drawing.Size(541, 389);
            this.zedGraphControl2.TabIndex = 2;
            this.zedGraphControl2.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl2.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zedGraphControl2.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl2.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl2.ZoomStepFraction = 0.1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acfColumn,
            this.pacfColumn,
            this.qStatColumn,
            this.probColumn});
            this.dataGridView2.ContextMenuStrip = this.gridMenuStrip;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Size = new System.Drawing.Size(541, 389);
            this.dataGridView2.TabIndex = 3;
            // 
            // gridMenuStrip
            // 
            this.gridMenuStrip.Name = "mnuGrid";
            this.gridMenuStrip.Size = new System.Drawing.Size(168, 120);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ACF";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "PACF";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "STATISTIK Q";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "PROB";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // acfColumn
            // 
            this.acfColumn.HeaderText = "ACF";
            this.acfColumn.Name = "acfColumn";
            this.acfColumn.ReadOnly = true;
            this.acfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // pacfColumn
            // 
            this.pacfColumn.HeaderText = "PACF";
            this.pacfColumn.Name = "pacfColumn";
            this.pacfColumn.ReadOnly = true;
            this.pacfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // qStatColumn
            // 
            this.qStatColumn.HeaderText = "Q-Stat";
            this.qStatColumn.Name = "qStatColumn";
            this.qStatColumn.ReadOnly = true;
            this.qStatColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // probColumn
            // 
            this.probColumn.HeaderText = "Prob";
            this.probColumn.Name = "probColumn";
            this.probColumn.ReadOnly = true;
            this.probColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CorrelogramResult
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "CorellogramResult";
            this.Size = new System.Drawing.Size(555, 424);
            this.Text = "CorellogramResult";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private zaitun.GUI.GridMenuStrip gridMenuStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn acfColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pacfColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qStatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn probColumn;

    }
}