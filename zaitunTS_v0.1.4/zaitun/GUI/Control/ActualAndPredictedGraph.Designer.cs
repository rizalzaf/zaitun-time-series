namespace zaitun.GUI
{
    partial class ActualAndPredictedGraph
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
            this.actualAndPredictedZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // actualAndPredictedZedGraph
            // 
            this.actualAndPredictedZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualAndPredictedZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndPredictedZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualAndPredictedZedGraph.IsAutoScrollRange = false;
            this.actualAndPredictedZedGraph.IsEnableHEdit = false;
            this.actualAndPredictedZedGraph.IsEnableHPan = true;
            this.actualAndPredictedZedGraph.IsEnableHZoom = true;
            this.actualAndPredictedZedGraph.IsEnableVEdit = false;
            this.actualAndPredictedZedGraph.IsEnableVPan = true;
            this.actualAndPredictedZedGraph.IsEnableVZoom = true;
            this.actualAndPredictedZedGraph.IsPrintFillPage = true;
            this.actualAndPredictedZedGraph.IsPrintKeepAspectRatio = true;
            this.actualAndPredictedZedGraph.IsScrollY2 = false;
            this.actualAndPredictedZedGraph.IsShowContextMenu = true;
            this.actualAndPredictedZedGraph.IsShowCopyMessage = true;
            this.actualAndPredictedZedGraph.IsShowCursorValues = false;
            this.actualAndPredictedZedGraph.IsShowHScrollBar = false;
            this.actualAndPredictedZedGraph.IsShowPointValues = false;
            this.actualAndPredictedZedGraph.IsShowVScrollBar = false;
            this.actualAndPredictedZedGraph.IsSynchronizeXAxes = false;
            this.actualAndPredictedZedGraph.IsSynchronizeYAxes = false;
            this.actualAndPredictedZedGraph.IsZoomOnMouseCenter = false;
            this.actualAndPredictedZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndPredictedZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualAndPredictedZedGraph.Location = new System.Drawing.Point(0, 0);
            this.actualAndPredictedZedGraph.Name = "actualAndPredictedZedGraph";
            this.actualAndPredictedZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndPredictedZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.actualAndPredictedZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.actualAndPredictedZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualAndPredictedZedGraph.PointDateFormat = "g";
            this.actualAndPredictedZedGraph.PointValueFormat = "G";
            this.actualAndPredictedZedGraph.ScrollMaxX = 0;
            this.actualAndPredictedZedGraph.ScrollMaxY = 0;
            this.actualAndPredictedZedGraph.ScrollMaxY2 = 0;
            this.actualAndPredictedZedGraph.ScrollMinX = 0;
            this.actualAndPredictedZedGraph.ScrollMinY = 0;
            this.actualAndPredictedZedGraph.ScrollMinY2 = 0;
            this.actualAndPredictedZedGraph.Size = new System.Drawing.Size(425, 273);
            this.actualAndPredictedZedGraph.TabIndex = 0;
            this.actualAndPredictedZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndPredictedZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.actualAndPredictedZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.actualAndPredictedZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualAndPredictedZedGraph.ZoomStepFraction = 0.1;
            // 
            // ActualAndPredictedGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actualAndPredictedZedGraph);
            this.Name = "ActualAndPredictedGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl actualAndPredictedZedGraph;
    }
}
