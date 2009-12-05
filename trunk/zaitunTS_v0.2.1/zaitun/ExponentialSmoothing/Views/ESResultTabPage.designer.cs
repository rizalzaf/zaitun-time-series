using zaitun.GUI;
namespace zaitun.ExponentialSmoothing
{
    partial class ESResultTabPage
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
            this.esResultTabControl = new System.Windows.Forms.TabControl();
            this.esModelSummaryTabPage = new System.Windows.Forms.TabPage();
            this.esModelSummary = new ESModelSummary();
            this.forecastedGridTabPage = new System.Windows.Forms.TabPage();
            this.forecastedDataGrid = new zaitun.GUI.ForecastedDataGrid();
            this.actualPredictedGraphTabPage = new System.Windows.Forms.TabPage();
            this.actualAndPredictedGraph = new zaitun.GUI.ActualAndPredictedGraph();            
            this.ActualForecastedTabPage = new System.Windows.Forms.TabPage();
            this.actualAndForecastedGraph = new zaitun.GUI.ActualAndForecastedGraph();
            this.actualVsPredictedGraphTabPage = new System.Windows.Forms.TabPage();
            this.actualVsPredictedGraph = new zaitun.GUI.ActualVsPredictedGraph();
            this.residualGraphTabPage = new System.Windows.Forms.TabPage();
            this.residualGraph = new zaitun.GUI.ResidualGraph();
            this.residualVsActualGraphTabPage = new System.Windows.Forms.TabPage();
            this.residualVsActualGraph = new zaitun.GUI.ResidualVsActualGraph();
            this.residualVsPredictedGraphTabPage = new System.Windows.Forms.TabPage();
            this.residualVsPredictedGraph = new zaitun.GUI.ResidualVsPredictedGraph();
            this.singleExponentialSmoothingGridTabPage = new System.Windows.Forms.TabPage();
            this.singleExponentialSmoothingDataGrid = new SingleExponentialSmoothingDataGrid();
            this.doubleExponentialSmoothingHoltGridTabPage = new System.Windows.Forms.TabPage();
            this.doubleExponentialSmoothingHoltDataGrid = new DoubleExponentialSmoothingHoltDataGrid();
            this.doubleExponentialSmoothingBrownGridTabPage = new System.Windows.Forms.TabPage();
            this.doubleExponentialSmoothingBrownDataGrid = new DoubleExponentialSmoothingBrownDataGrid();
            this.tripleExponentialSmoothingWinterGridTabPage = new System.Windows.Forms.TabPage();
            this.tripleExponentialSmoothingWinterDataGrid = new TripleExponentialSmoothingWinterDataGrid();
            this.actualSmoothedGraphTabPage = new System.Windows.Forms.TabPage();
            this.actualAndSmoothedGraph = new zaitun.GUI.ActualAndSmoothedGraph();
            this.esModelSummaryTabPage.SuspendLayout();
            this.forecastedGridTabPage.SuspendLayout();
            this.actualPredictedGraphTabPage.SuspendLayout();            
            this.ActualForecastedTabPage.SuspendLayout();
            this.actualVsPredictedGraphTabPage.SuspendLayout();
            this.residualGraphTabPage.SuspendLayout();
            this.residualVsActualGraphTabPage.SuspendLayout();
            this.residualVsPredictedGraphTabPage.SuspendLayout();
            this.singleExponentialSmoothingGridTabPage.SuspendLayout();
            this.doubleExponentialSmoothingHoltGridTabPage.SuspendLayout();
            this.doubleExponentialSmoothingBrownGridTabPage.SuspendLayout();
            this.tripleExponentialSmoothingWinterGridTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // esResultTabControl
            // 
            this.esResultTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.esResultTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.esResultTabControl.Location = new System.Drawing.Point(0, 0);
            this.esResultTabControl.Multiline = true;
            this.esResultTabControl.Name = "esResultTabControl";
            this.esResultTabControl.SelectedIndex = 0;
            this.esResultTabControl.Size = new System.Drawing.Size(727, 546);
            this.esResultTabControl.TabIndex = 0;
            // 
            // esModelSummaryTabPage
            // 
            this.esModelSummaryTabPage.Controls.Add(this.esModelSummary);
            this.esModelSummaryTabPage.Location = new System.Drawing.Point(4, 40);
            this.esModelSummaryTabPage.Name = "esModelSummaryTabPage";
            this.esModelSummaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.esModelSummaryTabPage.Size = new System.Drawing.Size(719, 502);
            this.esModelSummaryTabPage.TabIndex = 0;
            this.esModelSummaryTabPage.Text = "Exponential Smoothing Model Summary";
            this.esModelSummaryTabPage.UseVisualStyleBackColor = true;
            // 
            // esModelSummary
            // 
            this.esModelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.esModelSummary.Location = new System.Drawing.Point(3, 3);
            this.esModelSummary.Name = "esModelSummary";
            this.esModelSummary.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.esModelSummary.Size = new System.Drawing.Size(713, 496);
            this.esModelSummary.TabIndex = 0;
            // 
            // forecastedGridTabPage
            // 
            this.forecastedGridTabPage.Controls.Add(this.forecastedDataGrid);
            this.forecastedGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.forecastedGridTabPage.Name = "forecastedGridTabPage";
            this.forecastedGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.forecastedGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.forecastedGridTabPage.TabIndex = 2;
            this.forecastedGridTabPage.Text = "Forecasted";
            this.forecastedGridTabPage.UseVisualStyleBackColor = true;
            // 
            // forecastedDataGrid
            // 
            this.forecastedDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forecastedDataGrid.Location = new System.Drawing.Point(3, 3);
            this.forecastedDataGrid.Name = "forecastedDataGrid";
            this.forecastedDataGrid.Size = new System.Drawing.Size(713, 496);
            this.forecastedDataGrid.TabIndex = 0;
            // 
            // actualPredictedGraphTabPage
            // 
            this.actualPredictedGraphTabPage.Controls.Add(this.actualAndPredictedGraph);
            this.actualPredictedGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.actualPredictedGraphTabPage.Name = "actualPredictedGraphTabPage";
            this.actualPredictedGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actualPredictedGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.actualPredictedGraphTabPage.TabIndex = 3;
            this.actualPredictedGraphTabPage.Text = "Actual and Predicted Graph";
            this.actualPredictedGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // actualAndPredictedGraph
            // 
            this.actualAndPredictedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualAndPredictedGraph.Location = new System.Drawing.Point(3, 3);
            this.actualAndPredictedGraph.Name = "actualAndPredictedGraph";
            this.actualAndPredictedGraph.Size = new System.Drawing.Size(713, 496);
            this.actualAndPredictedGraph.TabIndex = 0;            
            // 
            // ActualForecastedTabPage
            // 
            this.ActualForecastedTabPage.Controls.Add(this.actualAndForecastedGraph);
            this.ActualForecastedTabPage.Location = new System.Drawing.Point(4, 40);
            this.ActualForecastedTabPage.Name = "ActualForecastedTabPage";
            this.ActualForecastedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ActualForecastedTabPage.Size = new System.Drawing.Size(719, 502);
            this.ActualForecastedTabPage.TabIndex = 5;
            this.ActualForecastedTabPage.Text = "Actual and Forecasted Graph";
            this.ActualForecastedTabPage.UseVisualStyleBackColor = true;
            // 
            // actualAndForecastedGraph
            // 
            this.actualAndForecastedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualAndForecastedGraph.Location = new System.Drawing.Point(3, 3);
            this.actualAndForecastedGraph.Name = "actualAndForecastedGraph";
            this.actualAndForecastedGraph.Size = new System.Drawing.Size(713, 496);
            this.actualAndForecastedGraph.TabIndex = 0;
            // 
            // actualVsPredictedGraphTabPage
            // 
            this.actualVsPredictedGraphTabPage.Controls.Add(this.actualVsPredictedGraph);
            this.actualVsPredictedGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.actualVsPredictedGraphTabPage.Name = "actualVsPredictedGraphTabPage";
            this.actualVsPredictedGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actualVsPredictedGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.actualVsPredictedGraphTabPage.TabIndex = 6;
            this.actualVsPredictedGraphTabPage.Text = "Actual vs Predicted Graph";
            this.actualVsPredictedGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // actualVsPredictedGraph
            // 
            this.actualVsPredictedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualVsPredictedGraph.Location = new System.Drawing.Point(3, 3);
            this.actualVsPredictedGraph.Name = "actualVsPredictedGraph";
            this.actualVsPredictedGraph.Size = new System.Drawing.Size(713, 496);
            this.actualVsPredictedGraph.TabIndex = 0;
            // 
            // residualGraphTabPage
            // 
            this.residualGraphTabPage.Controls.Add(this.residualGraph);
            this.residualGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.residualGraphTabPage.Name = "residualGraphTabPage";
            this.residualGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.residualGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.residualGraphTabPage.TabIndex = 7;
            this.residualGraphTabPage.Text = "Residual Graph";
            this.residualGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // residualGraph
            // 
            this.residualGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.residualGraph.Location = new System.Drawing.Point(3, 3);
            this.residualGraph.Name = "residualGraph";
            this.residualGraph.Size = new System.Drawing.Size(713, 496);
            this.residualGraph.TabIndex = 0;
            // 
            // residualVsActualGraphTabPage
            // 
            this.residualVsActualGraphTabPage.Controls.Add(this.residualVsActualGraph);
            this.residualVsActualGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.residualVsActualGraphTabPage.Name = "residualVsActualGraphTabPage";
            this.residualVsActualGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.residualVsActualGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.residualVsActualGraphTabPage.TabIndex = 8;
            this.residualVsActualGraphTabPage.Text = "Residual vs Actual Graph";
            this.residualVsActualGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // residualVsActualGraph
            // 
            this.residualVsActualGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.residualVsActualGraph.Location = new System.Drawing.Point(3, 3);
            this.residualVsActualGraph.Name = "residualVsActualGraph";
            this.residualVsActualGraph.Size = new System.Drawing.Size(713, 496);
            this.residualVsActualGraph.TabIndex = 0;
            // 
            // residualVsPredictedGraphTabPage
            // 
            this.residualVsPredictedGraphTabPage.Controls.Add(this.residualVsPredictedGraph);
            this.residualVsPredictedGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.residualVsPredictedGraphTabPage.Name = "residualVsPredictedGraphTabPage";
            this.residualVsPredictedGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.residualVsPredictedGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.residualVsPredictedGraphTabPage.TabIndex = 9;
            this.residualVsPredictedGraphTabPage.Text = "Residual vs Predicted Graph";
            this.residualVsPredictedGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // residualVsPredictedGraph
            // 
            this.residualVsPredictedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.residualVsPredictedGraph.Location = new System.Drawing.Point(3, 3);
            this.residualVsPredictedGraph.Name = "residualVsPredictedGraph";
            this.residualVsPredictedGraph.Size = new System.Drawing.Size(713, 496);
            this.residualVsPredictedGraph.TabIndex = 0;
            // 
            // singleExponentialSmoothingGridTabPage
            // 
            this.singleExponentialSmoothingGridTabPage.Controls.Add(this.singleExponentialSmoothingDataGrid);
            this.singleExponentialSmoothingGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.singleExponentialSmoothingGridTabPage.Name = "singleExponentialSmoothingGridTabPage";
            this.singleExponentialSmoothingGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.singleExponentialSmoothingGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.singleExponentialSmoothingGridTabPage.TabIndex = 1;
            this.singleExponentialSmoothingGridTabPage.Text = "Single Exponential Smoothing Table";
            this.singleExponentialSmoothingGridTabPage.UseVisualStyleBackColor = true;
            // 
            // singleExponentialSmoothingDataGrid
            // 
            this.singleExponentialSmoothingDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singleExponentialSmoothingDataGrid.Location = new System.Drawing.Point(3, 3);
            this.singleExponentialSmoothingDataGrid.Name = "singleExponentialSmoothingDataGrid";
            this.singleExponentialSmoothingDataGrid.Size = new System.Drawing.Size(713, 496);
            this.singleExponentialSmoothingDataGrid.TabIndex = 0;
            // 
            // doubleExponentialSmoothingHoltGridTabPage
            // 
            this.doubleExponentialSmoothingHoltGridTabPage.Controls.Add(this.doubleExponentialSmoothingHoltDataGrid);
            this.doubleExponentialSmoothingHoltGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.doubleExponentialSmoothingHoltGridTabPage.Name = "doubleExponentialSmoothingHoltGridTabPage";
            this.doubleExponentialSmoothingHoltGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.doubleExponentialSmoothingHoltGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.doubleExponentialSmoothingHoltGridTabPage.TabIndex = 1;
            this.doubleExponentialSmoothingHoltGridTabPage.Text = "Double Exponential Smoothing (Holt) Table";
            this.doubleExponentialSmoothingHoltGridTabPage.UseVisualStyleBackColor = true;
            // 
            // doubleExponentialSmoothingHoltDataGrid
            // 
            this.doubleExponentialSmoothingHoltDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleExponentialSmoothingHoltDataGrid.Location = new System.Drawing.Point(3, 3);
            this.doubleExponentialSmoothingHoltDataGrid.Name = "doubleExponentialSmoothingHoltDataGrid";
            this.doubleExponentialSmoothingHoltDataGrid.Size = new System.Drawing.Size(713, 496);
            this.doubleExponentialSmoothingHoltDataGrid.TabIndex = 0;
            // 
            // doubleExponentialSmoothingBrownGridTabPage
            // 
            this.doubleExponentialSmoothingBrownGridTabPage.Controls.Add(this.doubleExponentialSmoothingBrownDataGrid);
            this.doubleExponentialSmoothingBrownGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.doubleExponentialSmoothingBrownGridTabPage.Name = "doubleExponentialSmoothingBrownGridTabPage";
            this.doubleExponentialSmoothingBrownGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.doubleExponentialSmoothingBrownGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.doubleExponentialSmoothingBrownGridTabPage.TabIndex = 1;
            this.doubleExponentialSmoothingBrownGridTabPage.Text = "Double Exponential Smoothing (Brown) Table";
            this.doubleExponentialSmoothingBrownGridTabPage.UseVisualStyleBackColor = true;
            // 
            // doubleExponentialSmoothingBrownDataGrid
            // 
            this.doubleExponentialSmoothingBrownDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleExponentialSmoothingBrownDataGrid.Location = new System.Drawing.Point(3, 3);
            this.doubleExponentialSmoothingBrownDataGrid.Name = "doubleExponentialSmoothingBrownDataGrid";
            this.doubleExponentialSmoothingBrownDataGrid.Size = new System.Drawing.Size(713, 496);
            this.doubleExponentialSmoothingBrownDataGrid.TabIndex = 0;
            // 
            // tripleExponentialSmoothingWinterGridTabPage
            // 
            this.tripleExponentialSmoothingWinterGridTabPage.Controls.Add(this.tripleExponentialSmoothingWinterDataGrid);
            this.tripleExponentialSmoothingWinterGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.tripleExponentialSmoothingWinterGridTabPage.Name = "tripleExponentialSmoothingWinterGridTabPage";
            this.tripleExponentialSmoothingWinterGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tripleExponentialSmoothingWinterGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.tripleExponentialSmoothingWinterGridTabPage.TabIndex = 1;
            this.tripleExponentialSmoothingWinterGridTabPage.Text = "Triple Exponential Smoothing (Winter) Table";
            this.tripleExponentialSmoothingWinterGridTabPage.UseVisualStyleBackColor = true;
            // 
            // tripleExponentialSmoothingWinterDataGrid
            // 
            this.tripleExponentialSmoothingWinterDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tripleExponentialSmoothingWinterDataGrid.Location = new System.Drawing.Point(3, 3);
            this.tripleExponentialSmoothingWinterDataGrid.Name = "tripleExponentialSmoothingWinterDataGrid";
            this.tripleExponentialSmoothingWinterDataGrid.Size = new System.Drawing.Size(713, 496);
            this.tripleExponentialSmoothingWinterDataGrid.TabIndex = 0;
            // 
            // actualSmoothedGraphTabPage
            // 
            this.actualSmoothedGraphTabPage.Controls.Add(this.actualAndSmoothedGraph);
            this.actualSmoothedGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.actualSmoothedGraphTabPage.Name = "actualSmoothedGraphTabPage";
            this.actualSmoothedGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actualSmoothedGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.actualSmoothedGraphTabPage.TabIndex = 3;
            this.actualSmoothedGraphTabPage.Text = "Actual and Smoothed Graph";
            this.actualSmoothedGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // actualAndSmoothedGraph
            // 
            this.actualAndSmoothedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualAndSmoothedGraph.Location = new System.Drawing.Point(0, 0);
            this.actualAndSmoothedGraph.Name = "actualAndSmoothedGraph";
            this.actualAndSmoothedGraph.Size = new System.Drawing.Size(425, 273);
            this.actualAndSmoothedGraph.TabIndex = 0;
            // 
            // ESResultTabPage
            // 
            this.Controls.Add(this.esResultTabControl);
            this.Name = "esResultControl";
            this.Size = new System.Drawing.Size(727, 546);
            this.esModelSummaryTabPage.ResumeLayout(false);
            this.forecastedGridTabPage.ResumeLayout(false);
            this.actualPredictedGraphTabPage.ResumeLayout(false);
            this.actualSmoothedGraphTabPage.ResumeLayout(false);
            this.ActualForecastedTabPage.ResumeLayout(false);
            this.actualVsPredictedGraphTabPage.ResumeLayout(false);
            this.residualGraphTabPage.ResumeLayout(false);
            this.residualVsActualGraphTabPage.ResumeLayout(false);
            this.residualVsPredictedGraphTabPage.ResumeLayout(false);
            this.singleExponentialSmoothingGridTabPage.ResumeLayout(false);
            this.doubleExponentialSmoothingHoltGridTabPage.ResumeLayout(false);
            this.doubleExponentialSmoothingBrownGridTabPage.ResumeLayout(false);
            this.tripleExponentialSmoothingWinterGridTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl esResultTabControl;
        private System.Windows.Forms.TabPage esModelSummaryTabPage;
        private System.Windows.Forms.TabPage singleExponentialSmoothingGridTabPage;
        private System.Windows.Forms.TabPage doubleExponentialSmoothingBrownGridTabPage;
        private System.Windows.Forms.TabPage doubleExponentialSmoothingHoltGridTabPage;
        private System.Windows.Forms.TabPage tripleExponentialSmoothingWinterGridTabPage;

        private System.Windows.Forms.TabPage forecastedGridTabPage;
        private ForecastedDataGrid forecastedDataGrid;
        private System.Windows.Forms.TabPage actualPredictedGraphTabPage;
        private ActualAndPredictedGraph actualAndPredictedGraph;        
        private System.Windows.Forms.TabPage ActualForecastedTabPage;
        private ActualAndForecastedGraph actualAndForecastedGraph;
        private System.Windows.Forms.TabPage actualVsPredictedGraphTabPage;
        private ActualVsPredictedGraph actualVsPredictedGraph;
        private System.Windows.Forms.TabPage residualGraphTabPage;
        private ResidualGraph residualGraph;
        private System.Windows.Forms.TabPage residualVsActualGraphTabPage;
        private ResidualVsActualGraph residualVsActualGraph;
        private System.Windows.Forms.TabPage residualVsPredictedGraphTabPage;



        private ResidualVsPredictedGraph residualVsPredictedGraph;
        private SingleExponentialSmoothingDataGrid singleExponentialSmoothingDataGrid;
        private ESModelSummary esModelSummary;
        private DoubleExponentialSmoothingBrownDataGrid doubleExponentialSmoothingBrownDataGrid;
        private DoubleExponentialSmoothingHoltDataGrid doubleExponentialSmoothingHoltDataGrid;
        private TripleExponentialSmoothingWinterDataGrid tripleExponentialSmoothingWinterDataGrid;
        private System.Windows.Forms.TabPage actualSmoothedGraphTabPage;
        private ActualAndSmoothedGraph actualAndSmoothedGraph;
    }
}
