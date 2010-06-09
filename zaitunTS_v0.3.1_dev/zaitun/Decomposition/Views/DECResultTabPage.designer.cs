using zaitun.GUI;
namespace zaitun.Decomposition
{
    partial class DECResultTabPage
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
            this.decResultTabControl = new System.Windows.Forms.TabControl();
            this.forecastedGridTabPage = new System.Windows.Forms.TabPage();
            this.forecastedDataGrid = new zaitun.GUI.ForecastedDataGrid();
            this.actualPredictedTrendGraphTabPage = new System.Windows.Forms.TabPage();
            this.actualPredictedAndTrendGraph = new zaitun.GUI.ActualPredictedAndTrendGraph();            
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
            this.decompositionGridTabPage = new System.Windows.Forms.TabPage();
            this.decompositionDataGrid = new DecompositionDataGrid();
            this.decModelSummary = new DECModelSummary();
            this.decModelSummaryTabPage = new System.Windows.Forms.TabPage();
            this.deseasonalGraph = new DeseasonalGraph();
            this.deseasonalGraphTabPage = new System.Windows.Forms.TabPage();
            this.detrendGraph = new DetrendGraph();
            this.detrendGraphTabPage = new System.Windows.Forms.TabPage();
            this.forecastedGridTabPage.SuspendLayout();
            this.actualPredictedTrendGraphTabPage.SuspendLayout();            
            this.ActualForecastedTabPage.SuspendLayout();
            this.actualVsPredictedGraphTabPage.SuspendLayout();
            this.residualGraphTabPage.SuspendLayout();
            this.deseasonalGraphTabPage.SuspendLayout();
            this.detrendGraphTabPage.SuspendLayout();
            this.residualVsActualGraphTabPage.SuspendLayout();
            this.residualVsPredictedGraphTabPage.SuspendLayout();
            this.decompositionGridTabPage.SuspendLayout();
            this.decModelSummaryTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // decResultTabControl
            // 
            this.decResultTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.decResultTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decResultTabControl.Location = new System.Drawing.Point(0, 0);
            this.decResultTabControl.Multiline = true;
            this.decResultTabControl.Name = "decResultTabControl";
            this.decResultTabControl.SelectedIndex = 0;
            this.decResultTabControl.Size = new System.Drawing.Size(727, 546);
            this.decResultTabControl.TabIndex = 0;
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
            // actualPredictedTrendGraphTabPage
            // 
            this.actualPredictedTrendGraphTabPage.Controls.Add(this.actualPredictedAndTrendGraph);
            this.actualPredictedTrendGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.actualPredictedTrendGraphTabPage.Name = "actualPredictedTrendGraphTabPage";
            this.actualPredictedTrendGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actualPredictedTrendGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.actualPredictedTrendGraphTabPage.TabIndex = 3;
            this.actualPredictedTrendGraphTabPage.Text = "Actual Predicted and Trend Graph";
            this.actualPredictedTrendGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // actualPredictedAndTrendGraph
            // 
            this.actualPredictedAndTrendGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualPredictedAndTrendGraph.Location = new System.Drawing.Point(3, 3);
            this.actualPredictedAndTrendGraph.Name = "actualPredictedTrendGraph";
            this.actualPredictedAndTrendGraph.Size = new System.Drawing.Size(713, 496);
            this.actualPredictedAndTrendGraph.TabIndex = 0;                        
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
            // decompositionGridTabPage
            // 
            this.decompositionGridTabPage.Controls.Add(this.decompositionDataGrid);
            this.decompositionGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.decompositionGridTabPage.Name = "decompositionGridTabPage";
            this.decompositionGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.decompositionGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.decompositionGridTabPage.TabIndex = 1;
            this.decompositionGridTabPage.Text = "Decomposition Table";
            this.decompositionGridTabPage.UseVisualStyleBackColor = true;
            // 
            // decompositionDataGrid
            // 
            this.decompositionDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decompositionDataGrid.Location = new System.Drawing.Point(3, 3);
            this.decompositionDataGrid.Name = "decompositionDataGrid";
            this.decompositionDataGrid.Size = new System.Drawing.Size(713, 496);
            this.decompositionDataGrid.TabIndex = 0;
            // 
            // decModelSummary
            // 
            this.decModelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decModelSummary.Location = new System.Drawing.Point(3, 3);
            this.decModelSummary.Name = "decModelSummary";
            this.decModelSummary.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.decModelSummary.Size = new System.Drawing.Size(713, 496);
            this.decModelSummary.TabIndex = 0;
            // 
            // decModelSummaryTabPage
            // 
            this.decModelSummaryTabPage.Controls.Add(this.decModelSummary);
            this.decModelSummaryTabPage.Location = new System.Drawing.Point(4, 40);
            this.decModelSummaryTabPage.Name = "decModelSummaryTabPage";
            this.decModelSummaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.decModelSummaryTabPage.Size = new System.Drawing.Size(719, 502);
            this.decModelSummaryTabPage.TabIndex = 0;
            this.decModelSummaryTabPage.Text = "Decomposition Model Summary";
            this.decModelSummaryTabPage.UseVisualStyleBackColor = true;
            // 
            // deseasonalGraphTabPage
            // 
            this.deseasonalGraphTabPage.Controls.Add(this.deseasonalGraph);
            this.deseasonalGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.deseasonalGraphTabPage.Name = "deseasonalGraphTabPage";
            this.deseasonalGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.deseasonalGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.deseasonalGraphTabPage.TabIndex = 7;
            this.deseasonalGraphTabPage.Text = "Deseasonal Graph";
            this.deseasonalGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // deseasonalGraph
            // 
            this.deseasonalGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deseasonalGraph.Location = new System.Drawing.Point(0, 0);
            this.deseasonalGraph.Name = "deseasonalGraph";
            this.deseasonalGraph.Size = new System.Drawing.Size(425, 273);
            this.deseasonalGraph.TabIndex = 0;
            // 
            // detrendGraphTabPage
            // 
            this.detrendGraphTabPage.Controls.Add(this.detrendGraph);
            this.detrendGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.detrendGraphTabPage.Name = "detrendGraphTabPage";
            this.detrendGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.detrendGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.detrendGraphTabPage.TabIndex = 7;
            this.detrendGraphTabPage.Text = "Detrend Graph";
            this.detrendGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // detrendGraph
            // 
            this.detrendGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detrendGraph.Location = new System.Drawing.Point(0, 0);
            this.detrendGraph.Name = "detrendGraph";
            this.detrendGraph.Size = new System.Drawing.Size(425, 273);
            this.detrendGraph.TabIndex = 0;
            // 
            // DECResultTabPage
            // 
            this.Controls.Add(this.decResultTabControl);
            this.Name = "decResultControl";
            this.Size = new System.Drawing.Size(727, 546);
            this.forecastedGridTabPage.ResumeLayout(false);
            this.actualPredictedTrendGraphTabPage.ResumeLayout(false);            
            this.ActualForecastedTabPage.ResumeLayout(false);
            this.actualVsPredictedGraphTabPage.ResumeLayout(false);
            this.residualGraphTabPage.ResumeLayout(false);
            this.detrendGraphTabPage.ResumeLayout(false);
            this.deseasonalGraphTabPage.ResumeLayout(false);
            this.residualVsActualGraphTabPage.ResumeLayout(false);
            this.residualVsPredictedGraphTabPage.ResumeLayout(false);
            this.decompositionGridTabPage.ResumeLayout(false);
            this.decModelSummaryTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl decResultTabControl;
        private System.Windows.Forms.TabPage decModelSummaryTabPage;
        private System.Windows.Forms.TabPage decompositionGridTabPage;
        private System.Windows.Forms.TabPage forecastedGridTabPage;
        private ForecastedDataGrid forecastedDataGrid;
        private System.Windows.Forms.TabPage actualPredictedTrendGraphTabPage;
        private ActualPredictedAndTrendGraph actualPredictedAndTrendGraph;
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
        private DecompositionDataGrid decompositionDataGrid;
        private DECModelSummary decModelSummary;
        private System.Windows.Forms.TabPage detrendGraphTabPage;
        private System.Windows.Forms.TabPage deseasonalGraphTabPage;
        private DeseasonalGraph deseasonalGraph;
        private DetrendGraph detrendGraph;
    }
}
