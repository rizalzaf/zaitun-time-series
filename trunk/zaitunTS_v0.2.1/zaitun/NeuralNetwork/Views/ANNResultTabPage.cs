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

namespace zaitun.NeuralNetwork
{
    public partial class ANNResultTabPage : FATabStripItem
    {
        private SeriesData data;
        private SeriesVariable variable;
        private NeuralNetworkAnalysisForm.NetworkSpecification networkProperties;

        private double[] predicted;
        private double[] forecasted;
        private double[] residual;

        private bool isAnnModelSummaryVisible = false;
        private bool isActualPredictedResidualDataGridVisible = false;
        private bool isForecastedDataGridVisible = false;
        private bool isActualAndPredictedGraphVisible = false;        
        private bool isActualAndForecastedGraphVisible = false;
        private bool isActualVsPredictedGraphVisible = false;
        private bool isResidualGraphVisible = false;
        private bool isResidualVsActualGraphVisible = false;
        private bool isResidualVsPredictedGraphVisible = false;

        public ANNResultTabPage()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, NeuralNetworkAnalysisForm.NetworkSpecification networkProperties,
            double[] predicted, double[] forecasted)
        {
            this.data = data;
            this.variable = variable;
            this.predicted = predicted;
            this.forecasted = forecasted;
            this.networkProperties = networkProperties;

            
        }

        public void DrawControl()
        {
            int notIncludedObservation = data.NumberObservations - this.predicted.Length;

            this.residual = new double[this.predicted.Length];
            for (int i = 0; i < this.predicted.Length; i++)
                this.residual[i] = variable.SeriesValues[i + notIncludedObservation] - this.predicted[i];

            if (this.isAnnModelSummaryVisible)
            {
                this.annResultTabControl.Controls.Add(this.annModelSummaryTabPage);
                this.annModelSummary.SetData(this.data, this.variable, this.networkProperties);
            }
            if (this.isActualPredictedResidualDataGridVisible)
            {
                this.annResultTabControl.Controls.Add(this.actualPredictedResidualGridTabPage);
                this.actualPredictedResidualDataGrid.SetData(this.data, this.variable, this.predicted, this.residual);
            }
            if (this.isForecastedDataGridVisible)
            {
                this.annResultTabControl.Controls.Add(this.forecastedGridTabPage);
                this.forecastedDataGrid.SetData(this.data, this.variable, this.forecasted);
            }
            if (this.isActualAndPredictedGraphVisible)
            {
                this.annResultTabControl.Controls.Add(this.actualPredictedGraphTabPage);
                this.actualAndPredictedGraph.SetData(this.data, this.variable, this.predicted);
            }
            if (this.isActualAndForecastedGraphVisible)
            {
                this.annResultTabControl.Controls.Add(this.ActualForecastedTabPage);
                this.actualAndForecastedGraph.SetData(this.data, this.variable, this.forecasted);
            }
            if (isActualVsPredictedGraphVisible)
            {
                this.annResultTabControl.Controls.Add(this.actualVsPredictedGraphTabPage);
                this.actualVsPredictedGraph.SetData(this.data, this.variable, this.predicted);
            }
            if (this.isResidualGraphVisible)
            {
                this.annResultTabControl.Controls.Add(this.residualGraphTabPage);
                this.residualGraph.SetData(this.data, this.variable, this.residual);
            }
            if (this.isResidualVsActualGraphVisible)
            {
                this.annResultTabControl.Controls.Add(this.residualVsActualGraphTabPage);
                this.residualVsActualGraph.SetData(this.data, this.variable, this.residual);
            }
            if (this.isResidualVsPredictedGraphVisible)
            {
                this.annResultTabControl.Controls.Add(this.residualVsPredictedGraphTabPage);
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

        public NeuralNetworkAnalysisForm.NetworkSpecification NetworkProperties
        {
            get { return this.networkProperties; }
        }

        public double[] Predicted
        {
            get { return this.predicted; }
        }

        public double[] Forecasted
        {
            get { return this.forecasted; }
        }

        public double[] Residual
        {
            get { return this.residual; }
        }

        public bool IsAnnModelSummaryVisible
        {
            get { return this.isAnnModelSummaryVisible; }
            set { this.isAnnModelSummaryVisible = value; }
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
