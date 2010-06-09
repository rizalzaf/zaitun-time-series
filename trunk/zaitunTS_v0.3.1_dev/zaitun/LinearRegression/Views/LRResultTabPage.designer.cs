using zaitun.GUI;
namespace zaitun.LinearRegression
{
    partial class LRResultTabPage
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
            this.lrResultTabControl = new System.Windows.Forms.TabControl();
            this.lrResidualVsPredictedGraphTabPage = new System.Windows.Forms.TabPage();
            this.lrGridTabPage = new System.Windows.Forms.TabPage();
            this.lrModelSummaryTabPage = new System.Windows.Forms.TabPage();
            this.lrResidualGraphTabPage = new System.Windows.Forms.TabPage();
            this.lrNormalProbabilityPlotTabPage = new System.Windows.Forms.TabPage();
            this.lrAnovaTabPage = new System.Windows.Forms.TabPage();
            this.lrCoefficientsTabPage = new System.Windows.Forms.TabPage();
            this.lrForcastedTabPage = new System.Windows.Forms.TabPage();
            this.lrResidualVsPredictedGraph = new zaitun.LinearRegression.LRGraph();
            this.lrActualPredictedResidualDataGrid = new zaitun.GUI.ActualPredictedResidualDataGrid();
            this.lrModelSummary = new zaitun.LinearRegression.LRModelSummary();
            this.lrResidualGraph = new zaitun.LinearRegression.LRGraph();
            this.lrNormalProbabilityPlot = new zaitun.LinearRegression.LRGraph();
            this.lranova = new zaitun.LinearRegression.LRANOVA();
            this.lrCoefficients = new zaitun.LinearRegression.LRCoefficients();
            this.lrForcastedDataGrid = new zaitun.LinearRegression.LRForcastedDataGrid();
            this.lrResidualVsPredictedGraphTabPage.SuspendLayout();
            this.lrGridTabPage.SuspendLayout();
            this.lrModelSummaryTabPage.SuspendLayout();
            this.lrResidualGraphTabPage.SuspendLayout();
            this.lrNormalProbabilityPlotTabPage.SuspendLayout();
            this.lrAnovaTabPage.SuspendLayout();
            this.lrCoefficientsTabPage.SuspendLayout();
            this.lrForcastedTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lrResultTabControl
            // 
            this.lrResultTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.lrResultTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrResultTabControl.Location = new System.Drawing.Point(0, 0);
            this.lrResultTabControl.Multiline = true;
            this.lrResultTabControl.Name = "lrResultTabControl";
            this.lrResultTabControl.SelectedIndex = 0;
            this.lrResultTabControl.Size = new System.Drawing.Size(727, 546);
            this.lrResultTabControl.TabIndex = 0;
            // 
            // lrResidualVsPredictedGraphTabPage
            // 
            this.lrResidualVsPredictedGraphTabPage.Controls.Add(this.lrResidualVsPredictedGraph);
            this.lrResidualVsPredictedGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrResidualVsPredictedGraphTabPage.Name = "lrResidualVsPredictedGraphTabPage";
            this.lrResidualVsPredictedGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrResidualVsPredictedGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrResidualVsPredictedGraphTabPage.TabIndex = 9;
            this.lrResidualVsPredictedGraphTabPage.Text = "Residual vs Predicted Graph";
            this.lrResidualVsPredictedGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // lrGridTabPage
            // 
            this.lrGridTabPage.Controls.Add(this.lrActualPredictedResidualDataGrid);
            this.lrGridTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrGridTabPage.Name = "lrGridTabPage";
            this.lrGridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrGridTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrGridTabPage.TabIndex = 0;
            this.lrGridTabPage.Text = "Actual, Predicted, and Residual";
            this.lrGridTabPage.UseVisualStyleBackColor = true;
            // 
            // lrModelSummaryTabPage
            // 
            this.lrModelSummaryTabPage.Controls.Add(this.lrModelSummary);
            this.lrModelSummaryTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrModelSummaryTabPage.Name = "lrModelSummaryTabPage";
            this.lrModelSummaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrModelSummaryTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrModelSummaryTabPage.TabIndex = 0;
            this.lrModelSummaryTabPage.Text = "Linear Regression Model Summary";
            this.lrModelSummaryTabPage.UseVisualStyleBackColor = true;
            // 
            // lrResidualGraphTabPage
            // 
            this.lrResidualGraphTabPage.Controls.Add(this.lrResidualGraph);
            this.lrResidualGraphTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrResidualGraphTabPage.Name = "lrResidualGraphTabPage";
            this.lrResidualGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrResidualGraphTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrResidualGraphTabPage.TabIndex = 0;
            this.lrResidualGraphTabPage.Text = "Residual Graph";
            this.lrResidualGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // lrNormalProbabilityPlotTabPage
            // 
            this.lrNormalProbabilityPlotTabPage.Controls.Add(this.lrNormalProbabilityPlot);
            this.lrNormalProbabilityPlotTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrNormalProbabilityPlotTabPage.Name = "lrNormalProbabilityPlotTabPage";
            this.lrNormalProbabilityPlotTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrNormalProbabilityPlotTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrNormalProbabilityPlotTabPage.TabIndex = 0;
            this.lrNormalProbabilityPlotTabPage.Text = "Normal Probability Plot";
            this.lrNormalProbabilityPlotTabPage.UseVisualStyleBackColor = true;
            // 
            // lrAnovaTabPage
            // 
            this.lrAnovaTabPage.Controls.Add(this.lranova);
            this.lrAnovaTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrAnovaTabPage.Name = "lrAnovaTabPage";
            this.lrAnovaTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrAnovaTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrAnovaTabPage.TabIndex = 0;
            this.lrAnovaTabPage.Text = "ANOVA";
            this.lrAnovaTabPage.UseVisualStyleBackColor = true;
            // 
            // lrCoefficientsTabPage
            // 
            this.lrCoefficientsTabPage.Controls.Add(this.lrCoefficients);
            this.lrCoefficientsTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrCoefficientsTabPage.Name = "lrCoefficientsTabPage";
            this.lrCoefficientsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrCoefficientsTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrCoefficientsTabPage.TabIndex = 0;
            this.lrCoefficientsTabPage.Text = "Coefficients";
            this.lrCoefficientsTabPage.UseVisualStyleBackColor = true;
            // 
            // lrForcastedTabPage
            // 
            this.lrForcastedTabPage.Controls.Add(this.lrForcastedDataGrid);
            this.lrForcastedTabPage.Location = new System.Drawing.Point(4, 40);
            this.lrForcastedTabPage.Name = "lrForcastedTabPage";
            this.lrForcastedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lrForcastedTabPage.Size = new System.Drawing.Size(719, 502);
            this.lrForcastedTabPage.TabIndex = 0;
            this.lrForcastedTabPage.Text = "Forcasted";
            this.lrForcastedTabPage.UseVisualStyleBackColor = true;
            // 
            // lrResidualVsPredictedGraph
            // 
            this.lrResidualVsPredictedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrResidualVsPredictedGraph.Location = new System.Drawing.Point(3, 3);
            this.lrResidualVsPredictedGraph.Name = "lrResidualVsPredictedGraph";
            this.lrResidualVsPredictedGraph.Size = new System.Drawing.Size(713, 496);
            this.lrResidualVsPredictedGraph.TabIndex = 0;
            // 
            // lrActualPredictedResidualDataGrid
            // 
            this.lrActualPredictedResidualDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrActualPredictedResidualDataGrid.Location = new System.Drawing.Point(3, 3);
            this.lrActualPredictedResidualDataGrid.Name = "lrActualPredictedResidualDataGrid";
            this.lrActualPredictedResidualDataGrid.Size = new System.Drawing.Size(713, 496);
            this.lrActualPredictedResidualDataGrid.TabIndex = 0;
            // 
            // lrModelSummary
            // 
            this.lrModelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrModelSummary.IsDurbinWatsonVisible = false;
            this.lrModelSummary.Location = new System.Drawing.Point(3, 3);
            this.lrModelSummary.Name = "lrModelSummary";
            this.lrModelSummary.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.lrModelSummary.Size = new System.Drawing.Size(713, 496);
            this.lrModelSummary.TabIndex = 0;
            // 
            // lrResidualGraph
            // 
            this.lrResidualGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrResidualGraph.Location = new System.Drawing.Point(3, 3);
            this.lrResidualGraph.Name = "lrResidualGraph";
            this.lrResidualGraph.Size = new System.Drawing.Size(713, 496);
            this.lrResidualGraph.TabIndex = 0;
            // 
            // lrNormalProbabilityPlot
            // 
            this.lrNormalProbabilityPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrNormalProbabilityPlot.Location = new System.Drawing.Point(3, 3);
            this.lrNormalProbabilityPlot.Name = "lrNormalProbabilityPlot";
            this.lrNormalProbabilityPlot.Size = new System.Drawing.Size(713, 496);
            this.lrNormalProbabilityPlot.TabIndex = 0;
            // 
            // lranova
            // 
            this.lranova.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lranova.Location = new System.Drawing.Point(3, 3);
            this.lranova.Name = "lranova";
            this.lranova.Size = new System.Drawing.Size(713, 496);
            this.lranova.TabIndex = 0;
            // 
            // lrCoefficients
            // 
            this.lrCoefficients.IsConfidenceIntervalForParametersVisible = false;
            this.lrCoefficients.IsVIFForPredictorsVisible = false;
            this.lrCoefficients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrCoefficients.Location = new System.Drawing.Point(0, 0);
            this.lrCoefficients.Name = "lrCoefficients";
            this.lrCoefficients.Size = new System.Drawing.Size(512, 306);
            this.lrCoefficients.TabIndex = 0;
            // 
            // lrForcastedDataGrid
            // 
            this.lrForcastedDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrForcastedDataGrid.Location = new System.Drawing.Point(0, 0);
            this.lrForcastedDataGrid.Name = "lrForcastedDataGrid";
            this.lrForcastedDataGrid.Size = new System.Drawing.Size(512, 306);
            this.lrForcastedDataGrid.TabIndex = 0;
            // 
            // LRResultTabPage
            // 
            this.Controls.Add(this.lrResultTabControl);
            this.Size = new System.Drawing.Size(727, 546);
            this.lrResidualVsPredictedGraphTabPage.ResumeLayout(false);
            this.lrGridTabPage.ResumeLayout(false);
            this.lrModelSummaryTabPage.ResumeLayout(false);
            this.lrResidualGraphTabPage.ResumeLayout(false);
            this.lrNormalProbabilityPlotTabPage.ResumeLayout(false);
            this.lrAnovaTabPage.ResumeLayout(false);
            this.lrCoefficientsTabPage.ResumeLayout(false);
            this.lrForcastedTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl lrResultTabControl;
        private System.Windows.Forms.TabPage lrModelSummaryTabPage;
        private System.Windows.Forms.TabPage lrAnovaTabPage;
        private System.Windows.Forms.TabPage lrCoefficientsTabPage;
        private System.Windows.Forms.TabPage lrGridTabPage;
        private System.Windows.Forms.TabPage lrForcastedTabPage;
        private System.Windows.Forms.TabPage lrResidualGraphTabPage;
        private System.Windows.Forms.TabPage lrResidualVsPredictedGraphTabPage;
        private System.Windows.Forms.TabPage lrNormalProbabilityPlotTabPage;
        private LRModelSummary lrModelSummary;
        private ActualPredictedResidualDataGrid lrActualPredictedResidualDataGrid;
        private LRGraph lrResidualGraph;
        private LRGraph lrResidualVsPredictedGraph;
        private LRGraph lrNormalProbabilityPlot;
        private LRANOVA lranova;
        private LRCoefficients lrCoefficients;
        private LRForcastedDataGrid lrForcastedDataGrid;
    }
}
