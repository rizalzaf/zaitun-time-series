namespace zaitun.GUI
{
    partial class StockGraph
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
            this.grpGraph = new ZedGraph.ZedGraphControl();
            this.zedGraphToolstrip1 = new zaitun.GUI.ZedGraphToolstrip();
            this.SuspendLayout();
            // 
            // grpGraph
            // 
            this.grpGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.grpGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.grpGraph.IsAutoScrollRange = false;
            this.grpGraph.IsEnableHEdit = false;
            this.grpGraph.IsEnableHPan = true;
            this.grpGraph.IsEnableHZoom = true;
            this.grpGraph.IsEnableVEdit = false;
            this.grpGraph.IsEnableVPan = true;
            this.grpGraph.IsEnableVZoom = true;
            this.grpGraph.IsPrintFillPage = true;
            this.grpGraph.IsPrintKeepAspectRatio = true;
            this.grpGraph.IsScrollY2 = false;
            this.grpGraph.IsShowContextMenu = true;
            this.grpGraph.IsShowCopyMessage = true;
            this.grpGraph.IsShowCursorValues = false;
            this.grpGraph.IsShowHScrollBar = false;
            this.grpGraph.IsShowPointValues = false;
            this.grpGraph.IsShowVScrollBar = false;
            this.grpGraph.IsSynchronizeXAxes = false;
            this.grpGraph.IsSynchronizeYAxes = false;
            this.grpGraph.IsZoomOnMouseCenter = false;
            this.grpGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.grpGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.grpGraph.Location = new System.Drawing.Point(23, 0);
            this.grpGraph.Name = "grpGraph";
            this.grpGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.grpGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.grpGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.grpGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.grpGraph.PointDateFormat = "g";
            this.grpGraph.PointValueFormat = "G";
            this.grpGraph.ScrollMaxX = 0;
            this.grpGraph.ScrollMaxY = 0;
            this.grpGraph.ScrollMaxY2 = 0;
            this.grpGraph.ScrollMinX = 0;
            this.grpGraph.ScrollMinY = 0;
            this.grpGraph.ScrollMinY2 = 0;
            this.grpGraph.Size = new System.Drawing.Size(441, 295);
            this.grpGraph.TabIndex = 0;
            this.grpGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.grpGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.grpGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.grpGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.grpGraph.ZoomStepFraction = 0.1;
            // 
            // zedGraphToolstrip1
            // 
            this.zedGraphToolstrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.zedGraphToolstrip1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphToolstrip1.Name = "zedGraphToolstrip1";
            this.zedGraphToolstrip1.Size = new System.Drawing.Size(23, 295);
            this.zedGraphToolstrip1.TabIndex = 1;
            // 
            // StockGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpGraph);
            this.Controls.Add(this.zedGraphToolstrip1);
            this.Name = "StockGraph";
            this.Size = new System.Drawing.Size(464, 295);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl grpGraph;
        private ZedGraphToolstrip zedGraphToolstrip1;
    }
}
