// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Leader: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Members: Suryono Hadi Wibowo (ryonoha@gmail.com), Khaerul Anas (anasikova@gmail.com), 
//          Lia Amelia (afifahlia@gmail.com), Almaratul Sholihah, Muhamad Fuad Hasan
//
// This is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as
// published by the Free Software Foundation; either version 3 of
// the License, or (at your option) any later version.
//
// This software is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public
// License along with this software; if not, write to the Free
// Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301 USA, or see the FSF site: http://www.fsf.org.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using zaitun.Data;
using FarsiLibrary.Win;

namespace zaitun.LinearRegression
{
    public partial class LRResultTabPage : FATabStripItem
    {
        #region Fields
        private SeriesData data;
        private SeriesVariables independentVariables;
        private SeriesVariable dependentVariable;
        private double[,] testValues;
        private double[] forcasted;
        private string[] time;
        private LinearRegressionAnalysisForm.LRSpecification lrProperties;
        private LinearRegressionAnalysisForm.LRComponent lrTable;

        private bool isAnovaTableVisible = true;
        private bool isPartialCorrelationVisible = false;
        private bool isCoefficientTableVisible = true;
        private bool isConfidenceIntervalForParametersVisible = false;
        private bool isVIFForPredictorsVisible = false;
        private bool isDurbinWatsonVisible = false;
        private bool isDataGridVisible = true;
        private bool isForcastedGridVisible = false;
        private bool isResidualVsPredictedGraphVisible = true;
        private bool isResidualGraphVisible = true;
        private bool isNormalProbabilityPlotVisible = true;
        #endregion

        #region Constructor
        public LRResultTabPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Procedure Members
        public void SetData(SeriesData data,
            SeriesVariable dependentVariable, 
            SeriesVariables independentVariables, 
            LinearRegressionAnalysisForm.LRSpecification lrProperties,
            LinearRegressionAnalysisForm.LRComponent lrTable,
            double[,] testValues, 
            string[] forcastedTime,
            double[] forcastedData)
        {
            this.data = data;
            this.dependentVariable = dependentVariable;
            this.independentVariables = independentVariables;
            this.lrProperties = lrProperties;
            this.lrTable = lrTable;
            this.testValues = testValues;
            this.time = forcastedTime;
            this.forcasted = forcastedData;
        }

        public void DrawControl()
        {
            this.lrResultTabControl.Controls.Add(this.lrModelSummaryTabPage);
            this.lrModelSummary.IsDurbinWatsonVisible = isDurbinWatsonVisible;
            this.lrModelSummary.SetData(this.dependentVariable, this.independentVariables, this.lrProperties);
            if (this.isAnovaTableVisible)
            {
                this.lrResultTabControl.Controls.Add(this.lrAnovaTabPage);
                this.lranova.SetData(this.lrProperties);
            }
            if (this.isCoefficientTableVisible)
            {
                this.lrResultTabControl.Controls.Add(this.lrCoefficientsTabPage);
                this.lrCoefficients.IsConfidenceIntervalForParametersVisible = isConfidenceIntervalForParametersVisible;
                this.lrCoefficients.IsVIFForPredictorsVisible = isVIFForPredictorsVisible;
                this.lrCoefficients.IsPartialCorrelationVisible = isPartialCorrelationVisible;
                this.lrCoefficients.SetData(this.independentVariables, this.lrProperties);
            }
            if (this.isDataGridVisible)
            {
                this.lrResultTabControl.Controls.Add(this.lrGridTabPage);
                this.lrActualPredictedResidualDataGrid.SetData(this.data, this.dependentVariable, 
                    this.lrTable.Predicted, this.lrTable.Residual);
            }
            if (this.isForcastedGridVisible)
            {
                this.lrResultTabControl.Controls.Add(this.lrForcastedTabPage);
                this.lrForcastedDataGrid.SetData(this.independentVariables, 
                    this.dependentVariable, this.testValues, this.time,this.forcasted);
            }
            if (this.isResidualGraphVisible)
            {
                this.lrResultTabControl.Controls.Add(this.lrResidualGraphTabPage);
                this.lrResidualGraph.SetData(this.data, "Residual Graph", "Residual", "Time");
                this.lrResidualGraph.AddCurve("Residual", null, this.lrTable.Residual, 
                    Color.Blue, ZedGraph.SymbolType.Circle, false);
                this.lrResidualGraph.UpdateGraph();
            }
            if (this.isResidualVsPredictedGraphVisible)
            {
                this.lrResultTabControl.Controls.Add(this.lrResidualVsPredictedGraphTabPage);
                this.lrResidualVsPredictedGraph.SetData(this.data, "Residual Vs Predicted Graph", "Residual", "Predicted");
                this.lrResidualVsPredictedGraph.AddCurve("Residual Vs Predicted", this.lrTable.Predicted, this.lrTable.Residual,
                    Color.Blue, ZedGraph.SymbolType.Circle, false);
                this.lrResidualVsPredictedGraph.UpdateGraph();
            }
            if (this.isNormalProbabilityPlotVisible)
            {
                this.lrResultTabControl.Controls.Add(this.lrNormalProbabilityPlotTabPage);
                this.lrNormalProbabilityPlot.SetData(this.data, "Normal Probability Plot", "Residual", "Expected Residual");
                List<double> sortedResidual = new List<double>();
                sortedResidual.AddRange(this.lrTable.Residual);
                sortedResidual.Sort();
                this.lrNormalProbabilityPlot.AddCurve("Residual Vs Expected Residual", this.lrTable.ExpectedResidual,
                    sortedResidual.ToArray(), Color.Blue, ZedGraph.SymbolType.Circle, false);
                this.lrNormalProbabilityPlot.AddCurve(null, lrTable.ExpectedResidual, lrTable.ExpectedResidual,
                    Color.Black, ZedGraph.SymbolType.None, true);
                this.lrNormalProbabilityPlot.UpdateGraph();
            }
        }
        #endregion

        #region Properties

        public bool IsAnovaTableVisible
        {
            set { this.isAnovaTableVisible = value; }
            get { return this.isAnovaTableVisible; }
        }
        public bool IsCoefficientTableVisible
        {
            set { this.isCoefficientTableVisible = value; }
            get { return this.isCoefficientTableVisible; }
        }
        public bool IsConfidenceIntervalForParametersVisible
        {
            set { this.isConfidenceIntervalForParametersVisible = value; }
            get { return this.isConfidenceIntervalForParametersVisible; }
        }
        public bool IsVIFForPredictorsVisible
        {
            set { this.isVIFForPredictorsVisible = value; }
            get { return this.isVIFForPredictorsVisible; }
        }
        public bool IsPartialCorrelationVisible
        {
            set { this.isPartialCorrelationVisible = value; }
            get { return this.isPartialCorrelationVisible; }
        }
        public bool IsDurbinWatsonVisible
        {
            set { this.isDurbinWatsonVisible = value; }
            get { return this.isDurbinWatsonVisible; }
        }
        public bool IsDataTableVisible
        {
            set { this.isDataGridVisible = value; }
            get { return this.isDataGridVisible; }
        }

        public bool IsForcastedTableVisible
        {
            set { this.isForcastedGridVisible = value; }
            get { return this.isForcastedGridVisible; }
        }

        public bool IsResidualVsPredictedGraphVisible
        {
            set { this.isResidualVsPredictedGraphVisible = value; }
            get { return this.isResidualVsPredictedGraphVisible; }
        }
        public bool IsResidualGraphVisible
        {
            set { this.isResidualGraphVisible = value; }
            get { return this.isResidualGraphVisible; }
        }
        public bool IsNormalProbabilityPlotVisible
        {
            set { this.isNormalProbabilityPlotVisible = value; }
            get { return this.isNormalProbabilityPlotVisible; }
        }
        public SeriesVariable DependentVariable
        {
            get { return this.dependentVariable; }
        }
        public SeriesVariables IndependentVariables
        {
            get { return this.independentVariables; }
        }
        public zaitun.LinearRegression.LinearRegressionAnalysisForm.LRSpecification LRProperties
        {
            get { return this.lrProperties; }
        }
        public zaitun.LinearRegression.LinearRegressionAnalysisForm.LRComponent LRTable
        {
            get { return this.lrTable; }
        }
        public double[,] TestValues
        {
            get { return this.testValues; }
        }
        public double[] ForcastedData
        {
            get { return this.forcasted; }
        }
        public string[] ForcastedTime
        {
            get { return this.time; }
        }
        #endregion
    }
}
