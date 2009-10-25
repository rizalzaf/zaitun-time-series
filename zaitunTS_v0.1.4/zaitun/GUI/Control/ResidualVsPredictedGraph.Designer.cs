namespace zaitun.GUI
{
    partial class ResidualVsPredictedGraph
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
            this.residualVsActualZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // residualVsActualZedGraph
            // 
            this.residualVsActualZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.residualVsActualZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualVsActualZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.residualVsActualZedGraph.IsAutoScrollRange = false;
            this.residualVsActualZedGraph.IsEnableHEdit = false;
            this.residualVsActualZedGraph.IsEnableHPan = true;
            this.residualVsActualZedGraph.IsEnableHZoom = true;
            this.residualVsActualZedGraph.IsEnableVEdit = false;
            this.residualVsActualZedGraph.IsEnableVPan = true;
            this.residualVsActualZedGraph.IsEnableVZoom = true;
            this.residualVsActualZedGraph.IsPrintFillPage = true;
            this.residualVsActualZedGraph.IsPrintKeepAspectRatio = true;
            this.residualVsActualZedGraph.IsScrollY2 = false;
            this.residualVsActualZedGraph.IsShowContextMenu = true;
            this.residualVsActualZedGraph.IsShowCopyMessage = true;
            this.residualVsActualZedGraph.IsShowCursorValues = false;
            this.residualVsActualZedGraph.IsShowHScrollBar = false;
            this.residualVsActualZedGraph.IsShowPointValues = false;
            this.residualVsActualZedGraph.IsShowVScrollBar = false;
            this.residualVsActualZedGraph.IsSynchronizeXAxes = false;
            this.residualVsActualZedGraph.IsSynchronizeYAxes = false;
            this.residualVsActualZedGraph.IsZoomOnMouseCenter = false;
            this.residualVsActualZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualVsActualZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.residualVsActualZedGraph.Location = new System.Drawing.Point(0, 0);
            this.residualVsActualZedGraph.Name = "residualVsActualZedGraph";
            this.residualVsActualZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualVsActualZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.residualVsActualZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.residualVsActualZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.residualVsActualZedGraph.PointDateFormat = "g";
            this.residualVsActualZedGraph.PointValueFormat = "G";
            this.residualVsActualZedGraph.ScrollMaxX = 0;
            this.residualVsActualZedGraph.ScrollMaxY = 0;
            this.residualVsActualZedGraph.ScrollMaxY2 = 0;
            this.residualVsActualZedGraph.ScrollMinX = 0;
            this.residualVsActualZedGraph.ScrollMinY = 0;
            this.residualVsActualZedGraph.ScrollMinY2 = 0;
            this.residualVsActualZedGraph.Size = new System.Drawing.Size(425, 273);
            this.residualVsActualZedGraph.TabIndex = 0;
            this.residualVsActualZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualVsActualZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.residualVsActualZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.residualVsActualZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.residualVsActualZedGraph.ZoomStepFraction = 0.1;
            // 
            // ResidualVsActualGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.residualVsActualZedGraph);
            this.Name = "ResidualVsActualGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl residualVsActualZedGraph;
    }
}
