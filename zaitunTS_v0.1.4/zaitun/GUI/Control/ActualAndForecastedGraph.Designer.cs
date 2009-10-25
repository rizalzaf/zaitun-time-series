namespace zaitun.GUI
{
    partial class ActualAndForecastedGraph
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
            this.actualAndForecastedZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // actualAndForecastedZedGraph
            // 
            this.actualAndForecastedZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualAndForecastedZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndForecastedZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualAndForecastedZedGraph.IsAutoScrollRange = false;
            this.actualAndForecastedZedGraph.IsEnableHEdit = false;
            this.actualAndForecastedZedGraph.IsEnableHPan = true;
            this.actualAndForecastedZedGraph.IsEnableHZoom = true;
            this.actualAndForecastedZedGraph.IsEnableVEdit = false;
            this.actualAndForecastedZedGraph.IsEnableVPan = true;
            this.actualAndForecastedZedGraph.IsEnableVZoom = true;
            this.actualAndForecastedZedGraph.IsPrintFillPage = true;
            this.actualAndForecastedZedGraph.IsPrintKeepAspectRatio = true;
            this.actualAndForecastedZedGraph.IsScrollY2 = false;
            this.actualAndForecastedZedGraph.IsShowContextMenu = true;
            this.actualAndForecastedZedGraph.IsShowCopyMessage = true;
            this.actualAndForecastedZedGraph.IsShowCursorValues = false;
            this.actualAndForecastedZedGraph.IsShowHScrollBar = false;
            this.actualAndForecastedZedGraph.IsShowPointValues = false;
            this.actualAndForecastedZedGraph.IsShowVScrollBar = false;
            this.actualAndForecastedZedGraph.IsSynchronizeXAxes = false;
            this.actualAndForecastedZedGraph.IsSynchronizeYAxes = false;
            this.actualAndForecastedZedGraph.IsZoomOnMouseCenter = false;
            this.actualAndForecastedZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndForecastedZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.actualAndForecastedZedGraph.Location = new System.Drawing.Point(0, 0);
            this.actualAndForecastedZedGraph.Name = "actualAndForecastedZedGraph";
            this.actualAndForecastedZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndForecastedZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.actualAndForecastedZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.actualAndForecastedZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualAndForecastedZedGraph.PointDateFormat = "g";
            this.actualAndForecastedZedGraph.PointValueFormat = "G";
            this.actualAndForecastedZedGraph.ScrollMaxX = 0;
            this.actualAndForecastedZedGraph.ScrollMaxY = 0;
            this.actualAndForecastedZedGraph.ScrollMaxY2 = 0;
            this.actualAndForecastedZedGraph.ScrollMinX = 0;
            this.actualAndForecastedZedGraph.ScrollMinY = 0;
            this.actualAndForecastedZedGraph.ScrollMinY2 = 0;
            this.actualAndForecastedZedGraph.Size = new System.Drawing.Size(425, 273);
            this.actualAndForecastedZedGraph.TabIndex = 0;
            this.actualAndForecastedZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.actualAndForecastedZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.actualAndForecastedZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.actualAndForecastedZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.actualAndForecastedZedGraph.ZoomStepFraction = 0.1;
            // 
            // ActualAndForecasted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actualAndForecastedZedGraph);
            this.Name = "ActualAndForecasted";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl actualAndForecastedZedGraph;
    }
}
