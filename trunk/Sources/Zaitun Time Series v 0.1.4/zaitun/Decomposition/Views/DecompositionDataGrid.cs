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
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.Decomposition
{
    public partial class DecompositionDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] trend;
        private double[] detrend;
        private double[] seasonal;
        private double[] deseasonal;
        private double[] predicted;
        private double[] residual;

        private bool isTrendVisible;
        private bool isDetrendVisible;
        private bool isSeasonalVisible;
        private bool isDeseasonalVisible;

        public DecompositionDataGrid()
        {
            InitializeComponent();
            grdDecomposition.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

        }

        public void SetData(SeriesData data, SeriesVariable variable, 
            bool isTrendVisible, bool isDetrendVisible, bool isSeasonalVisible, bool isDeseasonalVisible,
            double[] trend, double[] detrend, double[] seasonal, double[] deseasonal, 
            double[] predicted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.isTrendVisible = isTrendVisible;
            this.isDetrendVisible = isDetrendVisible;
            this.isSeasonalVisible = isSeasonalVisible;
            this.isDeseasonalVisible = isDeseasonalVisible;
            
            this.trend = trend;
            this.detrend = detrend;
            this.seasonal = seasonal;
            this.deseasonal = deseasonal;
            this.predicted = predicted;
            this.residual = residual;

            this.update();
        }

        private void update()
        {
            int cell = 0;
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;

            this.grdDecomposition.ColumnCount = 3;

            //Menampilkan data actual
            grdDecomposition.RowCount = this.data.NumberObservations;
            grdDecomposition.Columns[0].HeaderCell.Value = "Actual";
            grdDecomposition.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdDecomposition.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdDecomposition.Rows[i].Cells[0].Value = this.variable[i].ToString("F4");
            }

            //Menampilkan data trend
            if (this.isTrendVisible)
            {
                //Menambahkan satu kolom
                this.grdDecomposition.ColumnCount = this.grdDecomposition.ColumnCount + 1;
                grdDecomposition.Columns[cell + 1].HeaderCell.Value = "Trend";
                grdDecomposition.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

                double[] trendToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    trendToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    trendToView[i] = this.trend[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdDecomposition.Rows[i].Cells[cell + 1].Value = trendToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

            //Menampilkan dara detrend
            if (this.isDetrendVisible)
            {
                //Menambahkan satu kolom
                this.grdDecomposition.ColumnCount = this.grdDecomposition.ColumnCount + 1;
                grdDecomposition.Columns[cell + 1].HeaderCell.Value = "Detrended";
                grdDecomposition.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

                double[] detrendToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    detrendToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    detrendToView[i] = this.detrend[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdDecomposition.Rows[i].Cells[cell + 1].Value = detrendToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

            //Menampilkan data seasonal
            if (this.isSeasonalVisible)
            {
                //Menambahkan satu kolom
                this.grdDecomposition.ColumnCount = this.grdDecomposition.ColumnCount + 1;
                grdDecomposition.Columns[cell + 1].HeaderCell.Value = "Seasonal";
                grdDecomposition.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

                double[] seasonalToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    seasonalToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    seasonalToView[i] = this.seasonal[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdDecomposition.Rows[i].Cells[cell + 1].Value = seasonalToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

            //Menampilkan data deseasonal
            if (this.isDeseasonalVisible)
            {
                //Menambahkan satu kolom
                this.grdDecomposition.ColumnCount = this.grdDecomposition.ColumnCount + 1;
                grdDecomposition.Columns[cell + 1].HeaderCell.Value = "Deseasonalized";
                grdDecomposition.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

                double[] deseasonalToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    deseasonalToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    deseasonalToView[i] = this.deseasonal[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdDecomposition.Rows[i].Cells[cell + 1].Value = deseasonalToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

            //Menampilkan data prediksi dan residual
            double[] predictedToView = new double[this.data.NumberObservations];
            double[] residualToView = new double[this.data.NumberObservations];

            for (int i = 0; i < notIncludedObservation; i++)
            {
                predictedToView[i] = double.NaN;
                residualToView[i] = double.NaN;
            }

            for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
            {
                predictedToView[i] = this.predicted[i - notIncludedObservation];
                residualToView[i] = this.variable[i] - this.predicted[i - notIncludedObservation];
            }

            grdDecomposition.Columns[cell + 1].HeaderCell.Value = "Predicted";
            grdDecomposition.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

            grdDecomposition.Columns[cell + 2].HeaderCell.Value = "Residual";
            grdDecomposition.Columns[cell + 2].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdDecomposition.Rows[i].Cells[cell + 1].Value = predictedToView[i].ToString("F4");
                grdDecomposition.Rows[i].Cells[cell + 2].Value = residualToView[i].ToString("F4");
            }
        }
    }
}
