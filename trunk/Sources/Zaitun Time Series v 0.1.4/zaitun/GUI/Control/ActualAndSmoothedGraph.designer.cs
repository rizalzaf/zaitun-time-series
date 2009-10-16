namespace zaitun.GUI
{
    partial class ActualAndSmoothedGraph
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
            this.actualAndSmoothedZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // actualAndSmoothedZedGraph
            // 
            this.actualAndSmoothedZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualAndSmoothedZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndSmoothedZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualAndSmoothedZedGraph.IsAutoScrollRange = false;
            this.actualAndSmoothedZedGraph.IsEnableHEdit = false;
            this.actualAndSmoothedZedGraph.IsEnableHPan = true;
            this.actualAndSmoothedZedGraph.IsEnableHZoom = true;
            this.actualAndSmoothedZedGraph.IsEnableVEdit = false;
            this.actualAndSmoothedZedGraph.IsEnableVPan = true;
            this.actualAndSmoothedZedGraph.IsEnableVZoom = true;
            this.actualAndSmoothedZedGraph.IsPrintFillPage = true;
            this.actualAndSmoothedZedGraph.IsPrintKeepAspectRatio = true;
            this.actualAndSmoothedZedGraph.IsScrollY2 = false;
            this.actualAndSmoothedZedGraph.IsShowContextMenu = true;
            this.actualAndSmoothedZedGraph.IsShowCopyMessage = true;
            this.actualAndSmoothedZedGraph.IsShowCursorValues = false;
            this.actualAndSmoothedZedGraph.IsShowHScrollBar = false;
            this.actualAndSmoothedZedGraph.IsShowPointValues = false;
            this.actualAndSmoothedZedGraph.IsShowVScrollBar = false;
            this.actualAndSmoothedZedGraph.IsSynchronizeXAxes = false;
            this.actualAndSmoothedZedGraph.IsSynchronizeYAxes = false;
            this.actualAndSmoothedZedGraph.IsZoomOnMouseCenter = false;
            this.actualAndSmoothedZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndSmoothedZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualAndSmoothedZedGraph.Location = new System.Drawing.Point(0, 0);
            this.actualAndSmoothedZedGraph.Name = "actualAndSmoothedZedGraph";
            this.actualAndSmoothedZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndSmoothedZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.actualAndSmoothedZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.actualAndSmoothedZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualAndSmoothedZedGraph.PointDateFormat = "g";
            this.actualAndSmoothedZedGraph.PointValueFormat = "G";
            this.actualAndSmoothedZedGraph.ScrollMaxX = 0;
            this.actualAndSmoothedZedGraph.ScrollMaxY = 0;
            this.actualAndSmoothedZedGraph.ScrollMaxY2 = 0;
            this.actualAndSmoothedZedGraph.ScrollMinX = 0;
            this.actualAndSmoothedZedGraph.ScrollMinY = 0;
            this.actualAndSmoothedZedGraph.ScrollMinY2 = 0;
            this.actualAndSmoothedZedGraph.Size = new System.Drawing.Size(425, 273);
            this.actualAndSmoothedZedGraph.TabIndex = 0;
            this.actualAndSmoothedZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndSmoothedZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.actualAndSmoothedZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.actualAndSmoothedZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualAndSmoothedZedGraph.ZoomStepFraction = 0.1;
            // 
            // ActualAndSmoothedGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actualAndSmoothedZedGraph);
            this.Name = "ActualAndSmoothedGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl actualAndSmoothedZedGraph;
    }
}
