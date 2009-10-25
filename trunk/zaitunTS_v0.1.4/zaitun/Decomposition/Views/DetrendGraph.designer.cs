namespace zaitun.Decomposition
{
    partial class DetrendGraph
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
            this.detrendZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // detrendZedGraph
            // 
            this.detrendZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detrendZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.detrendZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.detrendZedGraph.IsAutoScrollRange = false;
            this.detrendZedGraph.IsEnableHEdit = false;
            this.detrendZedGraph.IsEnableHPan = true;
            this.detrendZedGraph.IsEnableHZoom = true;
            this.detrendZedGraph.IsEnableVEdit = false;
            this.detrendZedGraph.IsEnableVPan = true;
            this.detrendZedGraph.IsEnableVZoom = true;
            this.detrendZedGraph.IsPrintFillPage = true;
            this.detrendZedGraph.IsPrintKeepAspectRatio = true;
            this.detrendZedGraph.IsScrollY2 = false;
            this.detrendZedGraph.IsShowContextMenu = true;
            this.detrendZedGraph.IsShowCopyMessage = true;
            this.detrendZedGraph.IsShowCursorValues = false;
            this.detrendZedGraph.IsShowHScrollBar = false;
            this.detrendZedGraph.IsShowPointValues = false;
            this.detrendZedGraph.IsShowVScrollBar = false;
            this.detrendZedGraph.IsSynchronizeXAxes = false;
            this.detrendZedGraph.IsSynchronizeYAxes = false;
            this.detrendZedGraph.IsZoomOnMouseCenter = false;
            this.detrendZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.detrendZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.detrendZedGraph.Location = new System.Drawing.Point(0, 0);
            this.detrendZedGraph.Name = "detrendZedGraph";
            this.detrendZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.detrendZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.detrendZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.detrendZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.detrendZedGraph.PointDateFormat = "g";
            this.detrendZedGraph.PointValueFormat = "G";
            this.detrendZedGraph.ScrollMaxX = 0;
            this.detrendZedGraph.ScrollMaxY = 0;
            this.detrendZedGraph.ScrollMaxY2 = 0;
            this.detrendZedGraph.ScrollMinX = 0;
            this.detrendZedGraph.ScrollMinY = 0;
            this.detrendZedGraph.ScrollMinY2 = 0;
            this.detrendZedGraph.Size = new System.Drawing.Size(425, 273);
            this.detrendZedGraph.TabIndex = 0;
            this.detrendZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.detrendZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.detrendZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.detrendZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.detrendZedGraph.ZoomStepFraction = 0.1;
            // 
            // DetrendGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detrendZedGraph);
            this.Name = "DetrendGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl detrendZedGraph;
    }
}
