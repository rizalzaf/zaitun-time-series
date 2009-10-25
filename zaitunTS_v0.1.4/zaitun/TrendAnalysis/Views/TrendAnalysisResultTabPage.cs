// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Core Programmer: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Programmer: Suryono Hadi Wibowo, Khaerul Anas, Almaratul Sholihah, Muhamad Fuad Hasan
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
using zaitun.ExponentialSmoothing;
using FarsiLibrary.Win;

namespace zaitun.TrendAnalysis
{
    public partial class TrendAnalysisResultTabPage : FATabStripItem
    {
        private SeriesData data;
        private SeriesVariable variable;
        private TrendAnalysisForm.TrendSpecification trendProperties;

        private double[] predicted;
        private double[] forecasted;
        private double[] residual;

        private bool isTrendAnalysisModelSummaryVisible = false;
        private bool isActualPredictedResidualDataGridVisible = false;
        private bool isForecastedDataGridVisible = false;
        private bool isActualAndPredictedGraphVisible = false;        
        private bool isActualAndForecastedGraphVisible = false;
        private bool isActualVsPredictedGraphVisible = false;
        private bool isResidualGraphVisible = false;
        private bool isResidualVsActualGraphVisible = false;
        private bool isResidualVsPredictedGraphVisible = false;

        public TrendAnalysisResultTabPage()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable,
            TrendAnalysisForm.TrendSpecification trendProperties,  
            double[] predicted, double[] forecasted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.trendProperties = trendProperties;
            this.predicted = predicted;
            this.residual = residual;
            this.forecasted = forecasted;
            
        }

        public void DrawControl()
        {
            //int notIncludedObservation = data.NumberObservations - this.predicted.Length;

            //this.residual = new double[this.predicted.Length];
            //for (int i = 0; i < this.predicted.Length; i++)
            //    this.residual[i] = this.predicted[i] - variable.SeriesValues[i + notIncludedObservation];

            if (this.isTrendAnalysisModelSummaryVisible)
            {
                this.taResultTabControl.Controls.Add(this.trendAnalysisModelSummaryTabPage);
                this.trendAnalysisModelSummary.SetData(this.data, this.variable, this.trendProperties);
            }

            if (this.isActualPredictedResidualDataGridVisible)
            {
                this.taResultTabControl.Controls.Add(this.actualPredictedResidualGridTabPage);
                this.actualPredictedResidualDataGrid.SetData(this.data, this.variable, this.predicted, this.residual);
            }
            if (this.isForecastedDataGridVisible)
            {
                this.taResultTabControl.Controls.Add(this.forecastedGridTabPage);
                this.forecastedDataGrid.SetData(this.data, this.variable, this.forecasted);
            }
            if (this.isActualAndPredictedGraphVisible)
            {
                this.taResultTabControl.Controls.Add(this.actualPredictedGraphTabPage);
                this.actualAndPredictedGraph.SetData(this.data, this.variable, this.predicted);
            }                        
            if (this.isActualAndForecastedGraphVisible)
            {
                this.taResultTabControl.Controls.Add(this.ActualForecastedTabPage);
                this.actualAndForecastedGraph.SetData(this.data, this.variable, this.forecasted);
            }                        
            if (isActualVsPredictedGraphVisible)
            {
                this.taResultTabControl.Controls.Add(this.actualVsPredictedGraphTabPage);
                this.actualVsPredictedGraph.SetData(this.data, this.variable, this.predicted);
            }
            if (this.isResidualGraphVisible)
            {
                this.taResultTabControl.Controls.Add(this.residualGraphTabPage);
                this.residualGraph.SetData(this.data, this.variable, this.residual);
            }
            if (this.isResidualVsActualGraphVisible)
            {
                this.taResultTabControl.Controls.Add(this.residualVsActualGraphTabPage);
                this.residualVsActualGraph.SetData(this.data, this.variable, this.residual);
            }
            if (this.isResidualVsPredictedGraphVisible)
            {
                this.taResultTabControl.Controls.Add(this.residualVsPredictedGraphTabPage);
                this.residualVsPredictedGraph.SetData(this.data, this.variable, this.residual, this.predicted);
            }            

        }

        public SeriesData Data
        {
            get { return this.data; }
        }

        public SeriesVariable Variable
        {
            get { return this.variable; }
        }

        public TrendAnalysisForm.TrendSpecification TrendProperties
        {
            get { return this.trendProperties; }
        }

        public double[] Residual
        {
            get { return this.residual; }
        }

        public double[] Predicted
        {
            get { return this.predicted; }
        }

        public double[] Forecasted
        {
            get { return this.forecasted; }
        }

        public bool IsTrendAnalysisModelSummaryVisible
        {
            get { return this.isTrendAnalysisModelSummaryVisible; }
            set { this.isTrendAnalysisModelSummaryVisible = value; }
        }

        public bool IsActualPredictedResidualDataGridVisible
        {
            get { return this.isActualPredictedResidualDataGridVisible; }
            set { this.isActualPredictedResidualDataGridVisible = value; }
        }

        public bool IsForecastedDataGridVisible
        {
            get { return this.isForecastedDataGridVisible; }
            set { this.isForecastedDataGridVisible = value; }
        }

        public bool IsActualAndPredictedGraphVisible
        {
            get { return this.isActualAndPredictedGraphVisible; }
            set { this.isActualAndPredictedGraphVisible = value; }
        }

        public bool IsActualAndForecastedGraphVisible
        {
            get { return this.isActualAndForecastedGraphVisible; }
            set { this.isActualAndForecastedGraphVisible = value; }
        }

        public bool IsActualVsPredictedGraphVisible
        {
            get { return this.isActualVsPredictedGraphVisible; }
            set { this.isActualVsPredictedGraphVisible = value; }
        }

        public bool IsResidualGraphVisible
        {
            get { return this.isResidualGraphVisible; }
            set { this.isResidualGraphVisible = value; }
        }

        public bool IsResidualVsActualGraphVisible
        {
            get { return this.isResidualVsActualGraphVisible; }
            set { this.isResidualVsActualGraphVisible = value; }
        }

        public bool IsResidualVsPredictedGraphVisible
        {
            get { return this.isResidualVsPredictedGraphVisible; }
            set { this.isResidualVsPredictedGraphVisible = value; }
        }



    }
}
