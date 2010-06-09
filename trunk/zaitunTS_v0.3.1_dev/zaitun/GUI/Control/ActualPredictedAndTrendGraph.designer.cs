namespace zaitun.GUI
{
    partial class ActualPredictedAndTrendGraph
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
            this.actualPredictedAndTrendZedGraph = new ZedGraph.ZedGraphControl();
            this.zedGraphToolstrip1 = new zaitun.GUI.ZedGraphToolstrip();
            this.SuspendLayout();
            // 
            // actualPredictedAndTrendZedGraph
            // 
            this.actualPredictedAndTrendZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualPredictedAndTrendZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualPredictedAndTrendZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualPredictedAndTrendZedGraph.IsAutoScrollRange = false;
            this.actualPredictedAndTrendZedGraph.IsEnableHEdit = false;
            this.actualPredictedAndTrendZedGraph.IsEnableHPan = true;
            this.actualPredictedAndTrendZedGraph.IsEnableHZoom = false;
            this.actualPredictedAndTrendZedGraph.IsEnableVEdit = false;
            this.actualPredictedAndTrendZedGraph.IsEnableVPan = true;
            this.actualPredictedAndTrendZedGraph.IsEnableVZoom = false;
            this.actualPredictedAndTrendZedGraph.IsPrintFillPage = true;
            this.actualPredictedAndTrendZedGraph.IsPrintKeepAspectRatio = true;
            this.actualPredictedAndTrendZedGraph.IsScrollY2 = false;
            this.actualPredictedAndTrendZedGraph.IsShowContextMenu = true;
            this.actualPredictedAndTrendZedGraph.IsShowCopyMessage = true;
            this.actualPredictedAndTrendZedGraph.IsShowCursorValues = false;
            this.actualPredictedAndTrendZedGraph.IsShowHScrollBar = false;
            this.actualPredictedAndTrendZedGraph.IsShowPointValues = false;
            this.actualPredictedAndTrendZedGraph.IsShowVScrollBar = false;
            this.actualPredictedAndTrendZedGraph.IsSynchronizeXAxes = false;
            this.actualPredictedAndTrendZedGraph.IsSynchronizeYAxes = false;
            this.actualPredictedAndTrendZedGraph.IsZoomOnMouseCenter = false;
            this.actualPredictedAndTrendZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualPredictedAndTrendZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualPredictedAndTrendZedGraph.Location = new System.Drawing.Point(23, 0);
            this.actualPredictedAndTrendZedGraph.Name = "actualPredictedAndTrendZedGraph";
            this.actualPredictedAndTrendZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualPredictedAndTrendZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.actualPredictedAndTrendZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.actualPredictedAndTrendZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualPredictedAndTrendZedGraph.PointDateFormat = "g";
            this.actualPredictedAndTrendZedGraph.PointValueFormat = "G";
            this.actualPredictedAndTrendZedGraph.ScrollMaxX = 0;
            this.actualPredictedAndTrendZedGraph.ScrollMaxY = 0;
            this.actualPredictedAndTrendZedGraph.ScrollMaxY2 = 0;
            this.actualPredictedAndTrendZedGraph.ScrollMinX = 0;
            this.actualPredictedAndTrendZedGraph.ScrollMinY = 0;
            this.actualPredictedAndTrendZedGraph.ScrollMinY2 = 0;
            this.actualPredictedAndTrendZedGraph.Size = new System.Drawing.Size(402, 273);
            this.actualPredictedAndTrendZedGraph.TabIndex = 0;
            this.actualPredictedAndTrendZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualPredictedAndTrendZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.actualPredictedAndTrendZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.actualPredictedAndTrendZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualPredictedAndTrendZedGraph.ZoomStepFraction = 0.1;
            // 
            // zedGraphToolstrip1
            // 
            this.zedGraphToolstrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.zedGraphToolstrip1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphToolstrip1.Name = "zedGraphToolstrip1";
            this.zedGraphToolstrip1.Size = new System.Drawing.Size(23, 273);
            this.zedGraphToolstrip1.TabIndex = 1;
            // 
            // ActualPredictedAndTrendGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actualPredictedAndTrendZedGraph);
            this.Controls.Add(this.zedGraphToolstrip1);
            this.Name = "ActualPredictedAndTrendGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl actualPredictedAndTrendZedGraph;
        private zaitun.GUI.ZedGraphToolstrip zedGraphToolstrip1;
    }
}
