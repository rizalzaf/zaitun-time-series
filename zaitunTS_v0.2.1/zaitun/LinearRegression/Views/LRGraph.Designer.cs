namespace zaitun.LinearRegression
{
    partial class LRGraph
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
            this.lrZedGraph = new ZedGraph.ZedGraphControl();
            this.zedGraphToolstrip1 = new zaitun.GUI.ZedGraphToolstrip();
            this.SuspendLayout();
            // 
            // lrZedGraph
            // 
            this.lrZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrZedGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.lrZedGraph.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.lrZedGraph.IsAutoScrollRange = false;
            this.lrZedGraph.IsEnableHEdit = false;
            this.lrZedGraph.IsEnableHPan = true;
            this.lrZedGraph.IsEnableHZoom = true;
            this.lrZedGraph.IsEnableVEdit = false;
            this.lrZedGraph.IsEnableVPan = true;
            this.lrZedGraph.IsEnableVZoom = true;
            this.lrZedGraph.IsPrintFillPage = true;
            this.lrZedGraph.IsPrintKeepAspectRatio = true;
            this.lrZedGraph.IsScrollY2 = false;
            this.lrZedGraph.IsShowContextMenu = true;
            this.lrZedGraph.IsShowCopyMessage = true;
            this.lrZedGraph.IsShowCursorValues = false;
            this.lrZedGraph.IsShowHScrollBar = false;
            this.lrZedGraph.IsShowPointValues = false;
            this.lrZedGraph.IsShowVScrollBar = false;
            this.lrZedGraph.IsSynchronizeXAxes = false;
            this.lrZedGraph.IsSynchronizeYAxes = false;
            this.lrZedGraph.IsZoomOnMouseCenter = false;
            this.lrZedGraph.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.lrZedGraph.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.lrZedGraph.Location = new System.Drawing.Point(30, 0);
            this.lrZedGraph.Name = "lrZedGraph";
            this.lrZedGraph.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.lrZedGraph.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.lrZedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.lrZedGraph.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.lrZedGraph.PointDateFormat = "g";
            this.lrZedGraph.PointValueFormat = "G";
            this.lrZedGraph.ScrollMaxX = 0;
            this.lrZedGraph.ScrollMaxY = 0;
            this.lrZedGraph.ScrollMaxY2 = 0;
            this.lrZedGraph.ScrollMinX = 0;
            this.lrZedGraph.ScrollMinY = 0;
            this.lrZedGraph.ScrollMinY2 = 0;
            this.lrZedGraph.Size = new System.Drawing.Size(395, 273);
            this.lrZedGraph.TabIndex = 0;
            this.lrZedGraph.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.lrZedGraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.lrZedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.lrZedGraph.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.lrZedGraph.ZoomStepFraction = 0.1;
            // 
            // zedGraphToolstrip1
            // 
            this.zedGraphToolstrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.zedGraphToolstrip1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphToolstrip1.Name = "zedGraphToolstrip1";
            this.zedGraphToolstrip1.Size = new System.Drawing.Size(23, 273);
            this.zedGraphToolstrip1.TabIndex = 1;
            // 
            // LRGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;            
            this.Controls.Add(this.lrZedGraph);
            this.Controls.Add(this.zedGraphToolstrip1);
            this.Name = "LRGraph";
            this.Size = new System.Drawing.Size(425, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl lrZedGraph;
        private zaitun.GUI.ZedGraphToolstrip zedGraphToolstrip1;
    }
}
