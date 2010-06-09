using zaitun.GUI;
namespace zaitun.MovingAverage
{
    partial class MAResultTabPage
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
            this.maResultTabControl = new System.Windows.Forms.TabControl();
            this.maModelSummaryTabPage = new System.Windows.Forms.TabPage();
            this.maModelSummary = new MAModelSummary();
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
            this.movingAverage2GridTabPage = new System.Windows.Forms.TabPage();
            this.movingAverage2DataGrid = new MovingAverage2DataGrid();
            this.movingAverageGridTabPage = new System.Windows.Forms.TabPage();
            this.movingAverageDataGrid = new MovingAverageDataGrid();
            this.actualSmoothedGraphTabPage = new System.Windows.Forms.TabPage();
            this.actualAndSmoothedGraph = new zaitun.GUI.ActualAndSmoothedGraph();
            this.maModelSummaryTabPage.SuspendLayout();
            this.forecastedGridTabPage.SuspendLayout();
            this.actualPredictedGraphTabPage.SuspendLayout();           
            this.ActualForecastedTabPage.SuspendLayout();
            this.actualVsPredictedGraphTabPage.SuspendLayout();
            this.residualGraphTabPage.SuspendLayout();
            this.residualVsActualGraphTabPage.SuspendLayout();
            this.residualVsPredictedGraphTabPage.SuspendLayout();
            this.movingAverage2GridTabPage.SuspendLayout();
            this.movingAverageGridTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // maResultTabControl
            // 
            this.maResultTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.maResultTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maResultTabControl.Location = new System.Drawing.Point(0, 0);
            this.maResultTabControl.Multiline = true;
            this.maResultTabControl.Name = "maResultTabControl";
            this.maResultTabControl.SelectedIndex = 0;
            this.maResultTabControl.Size = new System.Drawing.Size(727, 546);
            this.maResultTabControl.TabIndex = 0;
            // 
            // maModelSummaryTabPage
            // 
            this.maModelSummaryTabPage.Controls.Add(this.maModelSummary);
            this.maModelSummaryTabPage.Location = new System.Drawing.Point(4, 40);
            this.maModelSummaryTabPage.Name = "maModelSummaryTabPage";
            this.maModelSummaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.maModelSummaryTabPage.Size = new System.Drawing.Size(719, 502);
            this.maModelSummaryTabPage.TabIndex = 0;
            this.maModelSummaryTabPage.Text = "Moving Average Model Summary";
            this.maModelSummaryTabPage.UseVisualStyleBackColor = true;
            // 
            // maModelSummary
            // 
            this.maModelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maModelSummary.Location = new System.Drawing.Point(3, 3);
            this.maModelSummary.Name = "maModelSummary";
            this.maModelSummary.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.maModelSummary.Size = new System.Drawing.Size(713, 496);
            this.maModelSummary.TabIndex = 0;
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
            // movingAverage2GridTabPage
            // 
            this.movingAverage2GridTabPage.Controls.Add(this.movingAverage2DataGrid);
            this.movingAverage2GridTabPage.Location = new System.Drawing.Point(4, 40);
            this.movingAverage2GridTabPage.Name = "movingAverage2GridTabPage";
            this.movingAverage2GridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.movingAverage2GridTabPage.Size = new System.Drawing.Size(719, 502);
            this.movingAverage2GridTabPage.TabIndex = 1;
            this.movingAverage2GridTabPage.Text = "Double Moving Average Table";
            this.movingAverage2GridTabPage.UseVisualStyleBackColor = true;
            // 
            // movingAverage2DataGrid
            // 
            this.movingAverage2DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movingAverage2DataGrid.Location = new System.Drawing.Point(3, 3);
            this.movingAverage2DataGrid.Name = "movingAverage2DataGrid";
            this.movingAverage2DataGrid.Size = new System.Drawing.Size(713, 496);
            this.movingAverage2DataGrid.TabIndex = 0;
            // 
            // movingAverageGridTabPage
            // 
            this.movingAverageGridTabPage.Controls.Add(this.movingAverageDataGrid);
            this.movingAverageGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.movingAverageGridTabPage.Name = "movingAverageGridTabPage";
            this.movingAverageGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.movingAverageGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.movingAverageGridTabPage.TabIndex = 1;
            this.movingAverageGridTabPage.Text = "Single Moving Average Table";
            this.movingAverageGridTabPage.UseVisualStyleBackColor = true;
            // 
            // movingAverageDataGrid
            // 
            this.movingAverageDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movingAverageDataGrid.Location = new System.Drawing.Point(3, 3);
            this.movingAverageDataGrid.Name = "movingAverageDataGrid";
            this.movingAverageDataGrid.Size = new System.Drawing.Size(713, 496);
            this.movingAverageDataGrid.TabIndex = 0;
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
            // MAResultTabPage
            // 
            this.Controls.Add(this.maResultTabControl);
            this.Name = "maResultControl";
            this.Size = new System.Drawing.Size(727, 546);
            this.maModelSummaryTabPage.ResumeLayout(false);
            this.forecastedGridTabPage.ResumeLayout(false);
            this.actualPredictedGraphTabPage.ResumeLayout(false);
            this.actualSmoothedGraphTabPage.ResumeLayout(false);
            this.ActualForecastedTabPage.ResumeLayout(false);
            this.actualVsPredictedGraphTabPage.ResumeLayout(false);
            this.residualGraphTabPage.ResumeLayout(false);
            this.residualVsActualGraphTabPage.ResumeLayout(false);
            this.residualVsPredictedGraphTabPage.ResumeLayout(false);
            this.movingAverage2GridTabPage.ResumeLayout(false);
            this.movingAverageGridTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl maResultTabControl;
        private System.Windows.Forms.TabPage maModelSummaryTabPage;
        private System.Windows.Forms.TabPage movingAverageGridTabPage;
        private MovingAverageDataGrid movingAverageDataGrid;
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
        private MAModelSummary maModelSummary;
        private System.Windows.Forms.TabPage movingAverage2GridTabPage;
        private MovingAverage2DataGrid movingAverage2DataGrid;
        private System.Windows.Forms.TabPage actualSmoothedGraphTabPage;
        private ActualAndSmoothedGraph actualAndSmoothedGraph;
    }
}
