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

namespace zaitun.Decomposition
{
    public partial class DECResultTabPage : FATabStripItem
    {
        private SeriesData data;
        private SeriesVariable variable;
        private DecompositionForm.DECSpecification decProperties;
        private DecompositionForm.DECComponent decTable;

        private double[] forecasted;

        private bool isDecModelSummaryVisible = false;
        private bool isDecompositionDataGridVisible = false;
        private bool isTrendVisible = false;
        private bool isDetrendVisible = false;
        private bool isSeasonalVisible = false;
        private bool isDeseasonalVisible = false;
        private bool isForecastedDataGridVisible = false;
        private bool isActualPredictedAndTrendGraphVisible = false;        
        private bool isActualAndForecastedGraphVisible = false;
        private bool isActualVsPredictedGraphVisible = false;
        private bool isResidualGraphVisible = false;
        private bool isResidualVsActualGraphVisible = false;
        private bool isResidualVsPredictedGraphVisible = false;
        private bool isDetrendGraphVisible = false;
        private bool isDeseasonalGraphVisible = false;

        public DECResultTabPage()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, 
            DecompositionForm.DECSpecification decProperties, 
            DecompositionForm.DECComponent decTable, double[] forecasted)
        {
            this.data = data;
            this.variable = variable;
            this.decProperties = decProperties;
            this.decTable = decTable;
            this.forecasted = forecasted;
            
        }

        public void DrawControl()
        {
            if (this.isDecModelSummaryVisible)
            {
                this.decResultTabControl.Controls.Add(this.decModelSummaryTabPage);
                this.decModelSummary.SetData(this.data, this.variable, this.decProperties);
            }
            if (this.isDecompositionDataGridVisible)
            {
                this.decResultTabControl.Controls.Add(this.decompositionGridTabPage);
                this.decompositionDataGrid.SetData(this.data, this.variable, this.isTrendVisible, this.isDetrendVisible,
                    this.isSeasonalVisible, this.isDeseasonalVisible,
                    this.decTable.trend, this.decTable.detrend, this.decTable.seasonal, this.decTable.deseasonal, 
                    this.decTable.predicted, this.decTable.residual);
            }
            if (this.isForecastedDataGridVisible)
            {
                this.decResultTabControl.Controls.Add(this.forecastedGridTabPage);
                this.forecastedDataGrid.SetData(this.data, this.variable, this.forecasted);
            }
            if (this.isActualPredictedAndTrendGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.actualPredictedTrendGraphTabPage);
                this.actualPredictedAndTrendGraph.SetData(this.data, this.variable, this.decTable.predicted, this.decTable.trend);
            }            
            if (this.isActualAndForecastedGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.ActualForecastedTabPage);
                this.actualAndForecastedGraph.SetData(this.data, this.variable, this.forecasted);
            }
            if (isActualVsPredictedGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.actualVsPredictedGraphTabPage);
                this.actualVsPredictedGraph.SetData(this.data, this.variable, this.decTable.predicted);
            }
            if (this.isResidualGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.residualGraphTabPage);
                this.residualGraph.SetData(this.data, this.variable, this.decTable.residual);
            }
            if (this.isResidualVsActualGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.residualVsActualGraphTabPage);
                this.residualVsActualGraph.SetData(this.data, this.variable, this.decTable.residual);
            }
            if (this.isResidualVsPredictedGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.residualVsPredictedGraphTabPage);
                this.residualVsPredictedGraph.SetData(this.data, this.variable, this.decTable.residual, this.decTable.predicted);
            }
            if (this.isDetrendGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.detrendGraphTabPage);
                this.detrendGraph.SetData(this.data, this.variable, this.decTable.detrend);
            }
            if (this.isDeseasonalGraphVisible)
            {
                this.decResultTabControl.Controls.Add(this.deseasonalGraphTabPage);
                this.deseasonalGraph.SetData(this.data, this.variable, this.decTable.deseasonal);
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

        public DecompositionForm.DECSpecification DecProperties
        {
            get { return this.decProperties; }
        }

        public DecompositionForm.DECComponent DecTable
        {
            get { return this.decTable; }
        }

        public double[] Forecasted
        {
            get { return this.forecasted; }
        }

        public bool IsDecModelSummaryVisible
        {
            get { return this.isDecModelSummaryVisible; }
            set { this.isDecModelSummaryVisible = value; }
        }

        public bool IsDecompositionDataGridVisible
        {
            get { return this.isDecompositionDataGridVisible; }
            set { this.isDecompositionDataGridVisible = value; }
        }

        public bool IsTrendVisible
        {
            get { return this.isTrendVisible; }
            set { this.isTrendVisible = value; }
        }

        public bool IsDetrendVisible
        {
            get { return this.isDetrendVisible; }
            set { this.isDetrendVisible = value; }
        }

        public bool IsSeasonalVisible
        {
            get { return this.isSeasonalVisible; }
            set { this.isSeasonalVisible = value; }
        }

        public bool IsDeseasonalVisible
        {
            get { return this.isDeseasonalVisible; }
            set { this.isDeseasonalVisible = value; }
        }

        public bool IsForecastedDataGridVisible
        {
            get { return this.isForecastedDataGridVisible; }
            set { this.isForecastedDataGridVisible = value; }
        }

        public bool IsActualPredictedAndTrendGraphVisible
        {
            get { return this.isActualPredictedAndTrendGraphVisible; }
            set { this.isActualPredictedAndTrendGraphVisible = value; }
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

        public bool IsDetrendGraphVisible
        {
            get { return this.isDetrendGraphVisible; }
            set { this.isDetrendGraphVisible = value; }
        }

        public bool IsDeseasonalGraphVisible
        {
            get { return this.isDeseasonalGraphVisible; }
            set { this.isDeseasonalGraphVisible = value; }
        }
    }
}
