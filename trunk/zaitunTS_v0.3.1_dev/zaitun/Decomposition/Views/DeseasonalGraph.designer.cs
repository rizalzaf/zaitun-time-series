namespace zaitun.Decomposition
{
    partial class DeseasonalGraph
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
            this.deseasonalZedGraph = new ZedGraph.ZedGraphControl();
            this.zedGraphToolstrip1 = new zaitun.GUI.ZedGraphToolstrip();
            this.SuspendLayout();
            // 
            // deseasonalZedGraph
            // 
            this.deseasonalZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deseasonalZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.deseasonalZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.deseasonalZedGraph.IsAutoScrollRange = false;
            this.deseasonalZedGraph.IsEnableHEdit = false;
            this.deseasonalZedGraph.IsEnableHPan = true;
            this.deseasonalZedGraph.IsEnableHZoom = false;
            this.deseasonalZedGraph.IsEnableVEdit = false;
            this.deseasonalZedGraph.IsEnableVPan = true;
            this.deseasonalZedGraph.IsEnableVZoom = false;
            this.deseasonalZedGraph.IsPrintFillPage = true;
            this.deseasonalZedGraph.IsPrintKeepAspectRatio = true;
            this.deseasonalZedGraph.IsScrollY2 = false;
            this.deseasonalZedGraph.IsShowContextMenu = true;
            this.deseasonalZedGraph.IsShowCopyMessage = true;
            this.deseasonalZedGraph.IsShowCursorValues = false;
            this.deseasonalZedGraph.IsShowHScrollBar = false;
            this.deseasonalZedGraph.IsShowPointValues = false;
            this.deseasonalZedGraph.IsShowVScrollBar = false;
            this.deseasonalZedGraph.IsSynchronizeXAxes = false;
            this.deseasonalZedGraph.IsSynchronizeYAxes = false;
            this.deseasonalZedGraph.IsZoomOnMouseCenter = false;
            this.deseasonalZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.deseasonalZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.deseasonalZedGraph.Location = new System.Drawing.Point(23, 0);
            this.deseasonalZedGraph.Name = "deseasonalZedGraph";
            this.deseasonalZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.deseasonalZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.deseasonalZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.deseasonalZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.deseasonalZedGraph.PointDateFormat = "g";
            this.deseasonalZedGraph.PointValueFormat = "G";
            this.deseasonalZedGraph.ScrollMaxX = 0;
            this.deseasonalZedGraph.ScrollMaxY = 0;
            this.deseasonalZedGraph.ScrollMaxY2 = 0;
            this.deseasonalZedGraph.ScrollMinX = 0;
            this.deseasonalZedGraph.ScrollMinY = 0;
            this.deseasonalZedGraph.ScrollMinY2 = 0;
            this.deseasonalZedGraph.Size = new System.Drawing.Size(402, 273);
            this.deseasonalZedGraph.TabIndex = 0;
            this.deseasonalZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.deseasonalZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.deseasonalZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.deseasonalZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.deseasonalZedGraph.ZoomStepFraction = 0.1;
            // 
            // zedGraphToolstrip1
            // 
            this.zedGraphToolstrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.zedGraphToolstrip1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphToolstrip1.Name = "zedGraphToolstrip1";
            this.zedGraphToolstrip1.Size = new System.Drawing.Size(23, 273);
            this.zedGraphToolstrip1.TabIndex = 1;
            // 
            // DeseasonalGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deseasonalZedGraph);
            this.Controls.Add(this.zedGraphToolstrip1);
            this.Name = "DeseasonalGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl deseasonalZedGraph;
        private zaitun.GUI.ZedGraphToolstrip zedGraphToolstrip1;
    }
}
