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

namespace zaitun.GUI
{
    public partial class ActualPredictedResidualDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] predicted;
        private double[] residual;
        
        public ActualPredictedResidualDataGrid()
        {
            InitializeComponent();
            grdActualPredictedResidual.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
            
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] predicted, double[] residual)
        {
            this.data = data;
            this.variable = variable;
            this.predicted = predicted;
            this.residual = residual;
          
            this.update();
        }

        private void update()
        {
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;
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
                residualToView[i] = this.residual[i - notIncludedObservation];             
            }


            grdActualPredictedResidual.RowCount = this.data.NumberObservations;
            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdActualPredictedResidual.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdActualPredictedResidual.Rows[i].Cells[0].Value = this.variable[i].ToString("F4");
                grdActualPredictedResidual.Rows[i].Cells[1].Value = predictedToView[i].ToString("F4");
                grdActualPredictedResidual.Rows[i].Cells[2].Value = residualToView[i].ToString("F4");

            }


        }      
        
    }
}
