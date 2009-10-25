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

namespace zaitun.ExponentialSmoothing
{
    public partial class SingleExponentialSmoothingDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] smoothing;
        private double[] predicted;
        private double[] residual;

        private bool isSmoothingVisible;

        public SingleExponentialSmoothingDataGrid()
        {
            InitializeComponent();
            grdSes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

        }

        public void SetData(SeriesData data, SeriesVariable variable, bool isSmoothingVisible, double[] smoothing, double[] predicted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.isSmoothingVisible = isSmoothingVisible;
            this.smoothing = smoothing;
            this.predicted = predicted;
            this.residual = residual;

            this.update();
        }

        private void update()
        {
            int cell = 0;
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;

            this.grdSes.ColumnCount = 3;

            grdSes.RowCount = this.data.NumberObservations;
            grdSes.Columns[0].HeaderCell.Value = "Actual";
            grdSes.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdSes.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdSes.Rows[i].Cells[0].Value = this.variable[i].ToString("F4");
            }

            if (this.isSmoothingVisible)
            {
                this.grdSes.ColumnCount = this.grdSes.ColumnCount + 1;
                grdSes.Columns[cell + 1].HeaderCell.Value = "Smoothed";
                grdSes.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;
                
                double[] smoothingToView = new double[this.data.NumberObservations];

                for (int i = 0; i < notIncludedObservation; i++)
                {
                    smoothingToView[i] = double.NaN;
                }

                for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                {
                    smoothingToView[i] = this.smoothing[i - notIncludedObservation];
                }

                for (int i = 0; i < data.NumberObservations; i++)
                {
                    grdSes.Rows[i].Cells[cell + 1].Value = smoothingToView[i].ToString("F4");
                }

                cell = cell + 1;
            }

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

            grdSes.Columns[cell + 1].HeaderCell.Value = "Predicted";
            grdSes.Columns[cell + 1].SortMode = DataGridViewColumnSortMode.Programmatic;

            grdSes.Columns[cell + 2].HeaderCell.Value = "Residual";
            grdSes.Columns[cell + 2].SortMode = DataGridViewColumnSortMode.Programmatic;

            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdSes.Rows[i].Cells[cell + 1].Value = predictedToView[i].ToString("F4");
                grdSes.Rows[i].Cells[cell + 2].Value = residualToView[i].ToString("F4");
            }
        }
    }
}
