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
using zaitun.GUI;
using zaitun.Data;
using zaitun.ExponentialSmoothing;

namespace zaitun.MovingAverage
{
    public partial class MAModelSummary : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;
        private MovingAverageForm.MASpecification maProperties;
        
        public MAModelSummary()
        {
            InitializeComponent();
            grdModelSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
        }

        public void SetData(SeriesData data, SeriesVariable variable, MovingAverageForm.MASpecification maProperties)
        {
            this.data = data;
            this.variable = variable;
            this.maProperties = maProperties;
            this.lblVariable.Text = variable.VariableName;            
            this.update();
        }

        private void update()
        {
            grdModelSummary.RowCount = 10;
            grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
            grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
            grdModelSummary.Rows[1].HeaderCell.Value = "Model";
            if (this.maProperties.isSingleMA)
                grdModelSummary.Rows[1].Cells[0].Value = "MA ( " +this.maProperties.orde+ " )";
            else
                grdModelSummary.Rows[1].Cells[0].Value = "MA ( " + this.maProperties.orde + " X " + this.maProperties.orde + " )";
            
            grdModelSummary.Rows[2].HeaderCell.Value = "Included Observation";
            if (this.maProperties.isSingleMA)
                grdModelSummary.Rows[2].Cells[0].Value = this.maProperties.includedObservations - this.maProperties.orde;
            else
                grdModelSummary.Rows[2].Cells[0].Value = this.maProperties.includedObservations - (2 * this.maProperties.orde) + 1;
        
            grdModelSummary.Rows[4].HeaderCell.Value = "Accuracy Measures";
            int i = 4;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Absolute Error (MAE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.maProperties.maeMA.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Sum Square Error (SSE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.maProperties.sseMA.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Squared Error (MSE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.maProperties.mseMA.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Percentage Error (MPE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.maProperties.mpeMA.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Absolute Percentage Error (MAPE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.maProperties.mapeMA.ToString("F6");
        }     
    }
}
