using zaitun.GUI;
namespace zaitun.NeuralNetwork
{
    partial class ANNResultTabPage
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
            this.annResultTabControl = new System.Windows.Forms.TabControl();
            this.annModelSummaryTabPage = new System.Windows.Forms.TabPage();
            this.annModelSummary = new ANNModelSummary();
            this.actualPredictedResidualGridTabPage = new System.Windows.Forms.TabPage();
            this.actualPredictedResidualDataGrid = new zaitun.GUI.ActualPredictedResidualDataGrid();
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
            this.annModelSummaryTabPage.SuspendLayout();
            this.actualPredictedResidualGridTabPage.SuspendLayout();
            this.forecastedGridTabPage.SuspendLayout();
            this.actualPredictedGraphTabPage.SuspendLayout();
            this.ActualForecastedTabPage.SuspendLayout();
            this.actualVsPredictedGraphTabPage.SuspendLayout();
            this.residualGraphTabPage.SuspendLayout();
            this.residualVsActualGraphTabPage.SuspendLayout();
            this.residualVsPredictedGraphTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // annResultTabControl
            // 
            this.annResultTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.annResultTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annResultTabControl.Location = new System.Drawing.Point(0, 0);
            this.annResultTabControl.Multiline = true;
            this.annResultTabControl.Name = "annResultTabControl";
            this.annResultTabControl.SelectedIndex = 0;
            this.annResultTabControl.Size = new System.Drawing.Size(727, 546);
            this.annResultTabControl.TabIndex = 0;
            // 
            // annModelSummaryTabPage
            // 
            this.annModelSummaryTabPage.Controls.Add(this.annModelSummary);
            this.annModelSummaryTabPage.Location = new System.Drawing.Point(4, 40);
            this.annModelSummaryTabPage.Name = "annModelSummaryTabPage";
            this.annModelSummaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annModelSummaryTabPage.Size = new System.Drawing.Size(719, 502);
            this.annModelSummaryTabPage.TabIndex = 0;
            this.annModelSummaryTabPage.Text = "Neural Network Model Summary";
            this.annModelSummaryTabPage.UseVisualStyleBackColor = true;
            // 
            // annModelSummary
            // 
            this.annModelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annModelSummary.Location = new System.Drawing.Point(3, 3);
            this.annModelSummary.Name = "annModelSummary";
            this.annModelSummary.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.annModelSummary.Size = new System.Drawing.Size(713, 496);
            this.annModelSummary.TabIndex = 0;
            // 
            // actualPredictedResidualGridTabPage
            // 
            this.actualPredictedResidualGridTabPage.Controls.Add(this.actualPredictedResidualDataGrid);
            this.actualPredictedResidualGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.actualPredictedResidualGridTabPage.Name = "actualPredictedResidualGridTabPage";
            this.actualPredictedResidualGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actualPredictedResidualGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.actualPredictedResidualGridTabPage.TabIndex = 1;
            this.actualPredictedResidualGridTabPage.Text = "Actual, Predicted and Residual";
            this.actualPredictedResidualGridTabPage.UseVisualStyleBackColor = true;
            // 
            // actualPredictedResidualDataGrid
            // 
            this.actualPredictedResidualDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualPredictedResidualDataGrid.Location = new System.Drawing.Point(3, 3);
            this.actualPredictedResidualDataGrid.Name = "actualPredictedResidualDataGrid";
            this.actualPredictedResidualDataGrid.Size = new System.Drawing.Size(713, 496);
            this.actualPredictedResidualDataGrid.TabIndex = 0;
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
            // ANNResultTabPage
            // 
            this.Controls.Add(this.annResultTabControl);
            this.Name = "ANNResultControl";
            this.Size = new System.Drawing.Size(727, 546);
            this.annModelSummaryTabPage.ResumeLayout(false);
            this.actualPredictedResidualGridTabPage.ResumeLayout(false);
            this.forecastedGridTabPage.ResumeLayout(false);
            this.actualPredictedGraphTabPage.ResumeLayout(false);            
            this.ActualForecastedTabPage.ResumeLayout(false);
            this.actualVsPredictedGraphTabPage.ResumeLayout(false);
            this.residualGraphTabPage.ResumeLayout(false);
            this.residualVsActualGraphTabPage.ResumeLayout(false);
            this.residualVsPredictedGraphTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl annResultTabControl;
        private System.Windows.Forms.TabPage annModelSummaryTabPage;
        private System.Windows.Forms.TabPage actualPredictedResidualGridTabPage;
        private ANNModelSummary annModelSummary;
        private ActualPredictedResidualDataGrid actualPredictedResidualDataGrid;
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
    }
}
