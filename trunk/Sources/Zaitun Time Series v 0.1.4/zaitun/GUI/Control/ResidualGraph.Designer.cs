namespace zaitun.GUI
{
    partial class ResidualGraph
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
            this.residualZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // residualZedGraph
            // 
            this.residualZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.residualZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.residualZedGraph.IsAutoScrollRange = false;
            this.residualZedGraph.IsEnableHEdit = false;
            this.residualZedGraph.IsEnableHPan = true;
            this.residualZedGraph.IsEnableHZoom = true;
            this.residualZedGraph.IsEnableVEdit = false;
            this.residualZedGraph.IsEnableVPan = true;
            this.residualZedGraph.IsEnableVZoom = true;
            this.residualZedGraph.IsPrintFillPage = true;
            this.residualZedGraph.IsPrintKeepAspectRatio = true;
            this.residualZedGraph.IsScrollY2 = false;
            this.residualZedGraph.IsShowContextMenu = true;
            this.residualZedGraph.IsShowCopyMessage = true;
            this.residualZedGraph.IsShowCursorValues = false;
            this.residualZedGraph.IsShowHScrollBar = false;
            this.residualZedGraph.IsShowPointValues = false;
            this.residualZedGraph.IsShowVScrollBar = false;
            this.residualZedGraph.IsSynchronizeXAxes = false;
            this.residualZedGraph.IsSynchronizeYAxes = false;
            this.residualZedGraph.IsZoomOnMouseCenter = false;
            this.residualZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.residualZedGraph.Location = new System.Drawing.Point(0, 0);
            this.residualZedGraph.Name = "residualZedGraph";
            this.residualZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.residualZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.residualZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.residualZedGraph.PointDateFormat = "g";
            this.residualZedGraph.PointValueFormat = "G";
            this.residualZedGraph.ScrollMaxX = 0;
            this.residualZedGraph.ScrollMaxY = 0;
            this.residualZedGraph.ScrollMaxY2 = 0;
            this.residualZedGraph.ScrollMinX = 0;
            this.residualZedGraph.ScrollMinY = 0;
            this.residualZedGraph.ScrollMinY2 = 0;
            this.residualZedGraph.Size = new System.Drawing.Size(425, 273);
            this.residualZedGraph.TabIndex = 0;
            this.residualZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.residualZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.residualZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.residualZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.residualZedGraph.ZoomStepFraction = 0.1;
            // 
            // ResidualGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.residualZedGraph);
            this.Name = "ResidualGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl residualZedGraph;
    }
}
