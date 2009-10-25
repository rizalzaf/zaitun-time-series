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

namespace zaitun.MovingAverage
{
    public partial class MAResultTabPage : FATabStripItem
    {
        private SeriesData data;
        private SeriesVariable variable;
        private MovingAverageForm.MASpecification maProperties;
        private MovingAverageForm.MAComponent maTable;

        private double[] forecasted;

        private bool isMaModelSummaryVisible = false;
        private bool isMovingAverageDataGridVisible = false;
        private bool isSmoothingVisible = false;
        private bool isActualPredictedAndResidualVisible = false;
        private bool isForecastedDataGridVisible = false;
        private bool isActualAndPredictedGraphVisible = false;
        private bool isActualAndSmoothedGraphVisible = false;        
        private bool isActualAndForecastedGraphVisible = false;
        private bool isActualVsPredictedGraphVisible = false;
        private bool isResidualGraphVisible = false;
        private bool isResidualVsActualGraphVisible = false;
        private bool isResidualVsPredictedGraphVisible = false;

        public MAResultTabPage()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, 
            MovingAverageForm.MASpecification maProperties, 
            MovingAverageForm.MAComponent maTable, double[] forecasted)
        {
            this.data = data;
            this.variable = variable;
            this.maProperties = maProperties;
            this.maTable = maTable;
            this.forecasted = forecasted;
        }

        public void DrawControl()
        {
            if (this.isMaModelSummaryVisible)
            {
                this.maResultTabControl.Controls.Add(this.maModelSummaryTabPage);
                this.maModelSummary.SetData(this.data, this.variable, this.maProperties);
            }

            if (this.isMovingAverageDataGridVisible)
            {
                if (this.maProperties.isSingleMA)
                {
                    this.maResultTabControl.Controls.Add(this.movingAverageGridTabPage);
                    this.movingAverageDataGrid.SetData(this.data, this.variable, this.isSmoothingVisible, this.maTable.singleSmoothed, this.maTable.predicted, this.maTable.residual);
                }
                else
                {
                    this.maResultTabControl.Controls.Add(this.movingAverage2GridTabPage);
                    this.movingAverage2DataGrid.SetData(this.data, this.variable, this.isSmoothingVisible, this.maTable.singleSmoothed, this.maTable.doubleSmoothed, this.maTable.predicted, this.maTable.residual);
                }
            }
            if (this.isForecastedDataGridVisible)
            {
                this.maResultTabControl.Controls.Add(this.forecastedGridTabPage);
                this.forecastedDataGrid.SetData(this.data, this.variable, this.forecasted);
            }
            if (this.isActualAndPredictedGraphVisible)
            {
                this.maResultTabControl.Controls.Add(this.actualPredictedGraphTabPage);
                this.actualAndPredictedGraph.SetData(this.data, this.variable, this.maTable.predicted);
            }
            if (this.isActualAndSmoothedGraphVisible)
            {
                this.maResultTabControl.Controls.Add(this.actualSmoothedGraphTabPage);
                if(this.MaProperties.isSingleMA)
                    this.actualAndSmoothedGraph.SetData(this.data, this.variable, this.maTable.singleSmoothed);
                else
                    this.actualAndSmoothedGraph.SetData(this.data, this.variable, this.maTable.doubleSmoothed);
            }            
            if (this.isActualAndForecastedGraphVisible)
            {
                this.maResultTabControl.Controls.Add(this.ActualForecastedTabPage);
                this.actualAndForecastedGraph.SetData(this.data, this.variable, this.forecasted);
            }
            if (isActualVsPredictedGraphVisible)
            {
                this.maResultTabControl.Controls.Add(this.actualVsPredictedGraphTabPage);
                this.actualVsPredictedGraph.SetData(this.data, this.variable, this.maTable.predicted);
            }
            if (this.isResidualGraphVisible)
            {
                this.maResultTabControl.Controls.Add(this.residualGraphTabPage);
                this.residualGraph.SetData(this.data, this.variable, this.maTable.residual);
            }
            if (this.isResidualVsActualGraphVisible)
            {
                this.maResultTabControl.Controls.Add(this.residualVsActualGraphTabPage);
                this.residualVsActualGraph.SetData(this.data, this.variable, this.maTable.residual);
            }
            if (this.isResidualVsPredictedGraphVisible)
            {
                this.maResultTabControl.Controls.Add(this.residualVsPredictedGraphTabPage);
                this.residualVsPredictedGraph.SetData(this.data, this.variable, this.maTable.residual, this.maTable.predicted);
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

        public MovingAverageForm.MASpecification MaProperties
        {
            get { return this.maProperties; }
        }

        public MovingAverageForm.MAComponent MaTable
        {
            get { return this.maTable; }
        }

        public double[] Forecasted
        {
            get { return this.forecasted; }
        }

        public bool IsMaModelSummaryVisible
        {
            get { return this.isMaModelSummaryVisible; }
            set { this.isMaModelSummaryVisible = value; }
        }

        public bool IsSmoothingVisible
        {
            get { return this.isSmoothingVisible; }
            set { this.isSmoothingVisible = value; }
        }

        public bool IsActualPredictedAndResidualVisible
        {
            get { return this.isActualPredictedAndResidualVisible; }
            set { this.isActualPredictedAndResidualVisible = value; }
        }

        public bool IsMovingAverageDataGridVisible
        {
            get { return this.isMovingAverageDataGridVisible; }
            set { this.isMovingAverageDataGridVisible = value; }
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
