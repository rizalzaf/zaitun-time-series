namespace zaitun.GUI
{
    partial class ActualVsPredictedGraph
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
            this.actualVsPredictedZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // actualVsPredictedZedGraph
            // 
            this.actualVsPredictedZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualVsPredictedZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualVsPredictedZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualVsPredictedZedGraph.IsAutoScrollRange = false;
            this.actualVsPredictedZedGraph.IsEnableHEdit = false;
            this.actualVsPredictedZedGraph.IsEnableHPan = true;
            this.actualVsPredictedZedGraph.IsEnableHZoom = true;
            this.actualVsPredictedZedGraph.IsEnableVEdit = false;
            this.actualVsPredictedZedGraph.IsEnableVPan = true;
            this.actualVsPredictedZedGraph.IsEnableVZoom = true;
            this.actualVsPredictedZedGraph.IsPrintFillPage = true;
            this.actualVsPredictedZedGraph.IsPrintKeepAspectRatio = true;
            this.actualVsPredictedZedGraph.IsScrollY2 = false;
            this.actualVsPredictedZedGraph.IsShowContextMenu = true;
            this.actualVsPredictedZedGraph.IsShowCopyMessage = true;
            this.actualVsPredictedZedGraph.IsShowCursorValues = false;
            this.actualVsPredictedZedGraph.IsShowHScrollBar = false;
            this.actualVsPredictedZedGraph.IsShowPointValues = false;
            this.actualVsPredictedZedGraph.IsShowVScrollBar = false;
            this.actualVsPredictedZedGraph.IsSynchronizeXAxes = false;
            this.actualVsPredictedZedGraph.IsSynchronizeYAxes = false;
            this.actualVsPredictedZedGraph.IsZoomOnMouseCenter = false;
            this.actualVsPredictedZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualVsPredictedZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualVsPredictedZedGraph.Location = new System.Drawing.Point(0, 0);
            this.actualVsPredictedZedGraph.Name = "actualVsPredictedZedGraph";
            this.actualVsPredictedZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualVsPredictedZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.actualVsPredictedZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.actualVsPredictedZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualVsPredictedZedGraph.PointDateFormat = "g";
            this.actualVsPredictedZedGraph.PointValueFormat = "G";
            this.actualVsPredictedZedGraph.ScrollMaxX = 0;
            this.actualVsPredictedZedGraph.ScrollMaxY = 0;
            this.actualVsPredictedZedGraph.ScrollMaxY2 = 0;
            this.actualVsPredictedZedGraph.ScrollMinX = 0;
            this.actualVsPredictedZedGraph.ScrollMinY = 0;
            this.actualVsPredictedZedGraph.ScrollMinY2 = 0;
            this.actualVsPredictedZedGraph.Size = new System.Drawing.Size(425, 273);
            this.actualVsPredictedZedGraph.TabIndex = 0;
            this.actualVsPredictedZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualVsPredictedZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.actualVsPredictedZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.actualVsPredictedZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualVsPredictedZedGraph.ZoomStepFraction = 0.1;
            // 
            // ActualVsPredictedGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actualVsPredictedZedGraph);
            this.Name = "ActualVsPredictedGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl actualVsPredictedZedGraph;
    }
}
