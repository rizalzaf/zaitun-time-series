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

namespace zaitun.ExponentialSmoothing
{
    public partial class ESResultTabPage : FATabStripItem
    {
        private SeriesData data;
        private SeriesVariable variable;
        private ExponentialSmoothingForm.ESSpecification esProperties;
        private ExponentialSmoothingForm.ESComponent esTable;

        private double[] forecasted;

        private bool isEsModelSummaryVisible = false;
        private bool isExponentialSmoothingDataGridVisible = false;
        private bool isSmoothingVisible = false;
        private bool isTrendVisible = false;
        private bool isSeasonalVisible = false;
        private bool isForecastedDataGridVisible = false;
        private bool isActualAndPredictedGraphVisible = false;
        private bool isActualAndSmoothedGraphVisible = false;        
        private bool isActualAndForecastedGraphVisible = false;
        private bool isActualVsPredictedGraphVisible = false;
        private bool isResidualGraphVisible = false;
        private bool isResidualVsActualGraphVisible = false;
        private bool isResidualVsPredictedGraphVisible = false;

        public ESResultTabPage()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable,
            ExponentialSmoothingForm.ESSpecification esProperties,
            ExponentialSmoothingForm.ESComponent esTable, double[] forecasted)
        {
            this.data = data;
            this.variable = variable;
            this.esProperties = esProperties;
            this.esTable = esTable;
            this.forecasted = forecasted;
        }

        public void DrawControl()
        {
            if (this.isEsModelSummaryVisible)
            {
                this.esResultTabControl.Controls.Add(this.esModelSummaryTabPage);
                this.esModelSummary.SetData(this.data, this.variable, this.esProperties);
            }
            if (this.isExponentialSmoothingDataGridVisible)
            {
                if (this.esProperties.initialModel == 1)
                {
                    this.esResultTabControl.Controls.Add(this.singleExponentialSmoothingGridTabPage);
                    this.singleExponentialSmoothingDataGrid.SetData(this.data, this.variable, this.isSmoothingVisible, this.esTable.smoothed, this.esTable.predicted, this.esTable.residual);
                }

                if (this.esProperties.initialModel == 2)
                {
                    this.esResultTabControl.Controls.Add(this.doubleExponentialSmoothingBrownGridTabPage);
                    this.doubleExponentialSmoothingBrownDataGrid.SetData(this.data, this.variable, this.isSmoothingVisible, this.esTable.smoothed, this.esTable.predicted, this.esTable.residual);
                }
                if (this.esProperties.initialModel == 3)
                {
                    this.esResultTabControl.Controls.Add(this.doubleExponentialSmoothingHoltGridTabPage);
                    this.doubleExponentialSmoothingHoltDataGrid.SetData(this.data, this.variable, this.isSmoothingVisible, this.isTrendVisible, this.esTable.smoothed, this.esTable.trend, this.esTable.predicted, this.esTable.residual);
                }
                if (this.esProperties.initialModel == 4)
                {
                    this.esResultTabControl.Controls.Add(this.tripleExponentialSmoothingWinterGridTabPage);
                    this.tripleExponentialSmoothingWinterDataGrid.SetData(this.data, this.variable, this.isSmoothingVisible, this.isTrendVisible, this.isSeasonalVisible, this.esTable.smoothed, this.esTable.trend, this.esTable.seasonal, this.esTable.predicted, this.esTable.residual);
                }
            }

            if (this.isForecastedDataGridVisible)
            {
                this.esResultTabControl.Controls.Add(this.forecastedGridTabPage);
                this.forecastedDataGrid.SetData(this.data, this.variable, this.forecasted);
            }
            if (this.isActualAndPredictedGraphVisible)
            {
                this.esResultTabControl.Controls.Add(this.actualPredictedGraphTabPage);
                this.actualAndPredictedGraph.SetData(this.data, this.variable, this.esTable.predicted);
            }
            if (this.isActualAndSmoothedGraphVisible)
            {
                this.esResultTabControl.Controls.Add(this.actualSmoothedGraphTabPage);
                this.actualAndSmoothedGraph.SetData(this.data, this.variable, this.esTable.smoothed);
            }            
            if (this.isActualAndForecastedGraphVisible)
            {
                this.esResultTabControl.Controls.Add(this.ActualForecastedTabPage);
                this.actualAndForecastedGraph.SetData(this.data, this.variable, this.forecasted);
            }
            if (isActualVsPredictedGraphVisible)
            {
                this.esResultTabControl.Controls.Add(this.actualVsPredictedGraphTabPage);
                this.actualVsPredictedGraph.SetData(this.data, this.variable, this.esTable.predicted);
            }
            if (this.isResidualGraphVisible)
            {
                this.esResultTabControl.Controls.Add(this.residualGraphTabPage);
                this.residualGraph.SetData(this.data, this.variable, this.esTable.residual);
            }
            if (this.isResidualVsActualGraphVisible)
            {
                this.esResultTabControl.Controls.Add(this.residualVsActualGraphTabPage);
                this.residualVsActualGraph.SetData(this.data, this.variable, this.esTable.residual);
            }
            if (this.isResidualVsPredictedGraphVisible)
            {
                this.esResultTabControl.Controls.Add(this.residualVsPredictedGraphTabPage);
                this.residualVsPredictedGraph.SetData(this.data, this.variable, this.esTable.residual, this.esTable.predicted);
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

        public ExponentialSmoothingForm.ESSpecification EsProperties
        {
            get { return this.esProperties; }
        }

        public ExponentialSmoothingForm.ESComponent EsTable
        {
            get { return this.esTable; }
        }

        public double[] Forecasted
        {
            get { return this.forecasted; }
        }

        public bool IsEsModelSummaryVisible
        {
            get { return this.isEsModelSummaryVisible; }
            set { this.isEsModelSummaryVisible = value; }
        }

        public bool IsExponentialSmoothingDataGridVisible
        {
            get { return this.isExponentialSmoothingDataGridVisible; }
            set { this.isExponentialSmoothingDataGridVisible = value; }
        }

        public bool IsSmoothingVisible
        {
            get { return this.isSmoothingVisible; }
            set { this.isSmoothingVisible = value; }
        }

        public bool IsTrendVisible
        {
            get { return this.isTrendVisible; }
            set { this.isTrendVisible = value; }
        }

        public bool IsSeasonalVisible
        {
            get { return this.isSeasonalVisible; }
            set { this.isSeasonalVisible = value; }
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

        public bool IsActualAndSmoothedGraphVisible
        {
            get { return this.isActualAndSmoothedGraphVisible; }
            set { this.isActualAndSmoothedGraphVisible = value; }
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
