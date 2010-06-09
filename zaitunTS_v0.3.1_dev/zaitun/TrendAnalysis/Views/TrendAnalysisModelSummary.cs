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

namespace zaitun.TrendAnalysis
{
    public partial class TrendAnalysisModelSummary : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;
        private TrendAnalysisForm.TrendSpecification trendProperties;

        public TrendAnalysisModelSummary()
        {
            InitializeComponent();
            grdModelSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
        }

        public void SetData(SeriesData data, SeriesVariable variable, TrendAnalysisForm.TrendSpecification trendProperties)
        {
            this.data = data;
            this.variable = variable;
            this.trendProperties = trendProperties;
            this.lblVariable.Text = variable.VariableName;            
            this.update();
        }

        private void update()
        {
            grdModelSummary.RowCount = 11;
            grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
            grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
            grdModelSummary.Rows[2].HeaderCell.Value = "Included Observation";
            grdModelSummary.Rows[2].Cells[0].Value = this.trendProperties.includedObservations;

            switch (this.trendProperties.initialModel)
            {
                case 1:
                    {
                        string[] parametersString = new string[this.trendProperties.parameters.Length];
                        parametersString[0] = this.trendProperties.parameters[0].ToString("G5");
                        for (int j = 1; j < this.trendProperties.parameters.Length; j++)
                        {
                            if (this.trendProperties.parameters[j] < 0)
                                parametersString[j] = " " + this.trendProperties.parameters[j].ToString("G5");
                            else
                                parametersString[j] = " +" + this.trendProperties.parameters[j].ToString("G5");
                        }
                        grdModelSummary.Rows[4].HeaderCell.Value = "Linear Trend Equation";
                        grdModelSummary.Rows[4].Cells[0].Value = "Yt = " + parametersString[0] + ""
                            + parametersString[1] + "*t";
                        break;
                    }
                case 2:
                    {
                        string[] parametersString = new string[this.trendProperties.parameters.Length];
                        parametersString[0] = this.trendProperties.parameters[0].ToString("G5");
                        for (int j = 1; j < this.trendProperties.parameters.Length; j++)
                        {
                            if (this.trendProperties.parameters[j] < 0)
                                parametersString[j] = " " + this.trendProperties.parameters[j].ToString("G5");
                            else
                                parametersString[j] = " +" + this.trendProperties.parameters[j].ToString("G5");
                        }
                        grdModelSummary.Rows[4].HeaderCell.Value = "Quadratic Trend Equation";
                        grdModelSummary.Rows[4].Cells[0].Value = "Yt = " + parametersString[0] + ""
                            + parametersString[1] + "*t" + parametersString[2] + "*t**2";
                        break;
                    }
                case 3:
                    {
                        string[] parametersString = new string[this.trendProperties.parameters.Length];
                        parametersString[0] = this.trendProperties.parameters[0].ToString("G5");
                        for (int j = 1; j < this.trendProperties.parameters.Length; j++)
                        {
                            if (this.trendProperties.parameters[j] < 0)
                                parametersString[j] = " " + this.trendProperties.parameters[j].ToString("G5");
                            else
                                parametersString[j] = " +" + this.trendProperties.parameters[j].ToString("G5");
                        }
                        grdModelSummary.Rows[4].HeaderCell.Value = "Cubic Trend Equation";
                        grdModelSummary.Rows[4].Cells[0].Value = "Yt = " + parametersString[0] + ""
                            + parametersString[1] + "*t" + parametersString[2] + "*t**2" + parametersString[3] + "*t**3";
                        break;
                    }
                case 4:
                    {
                        grdModelSummary.Rows[4].HeaderCell.Value = "Exponential Trend Equation";
                        grdModelSummary.Rows[4].Cells[0].Value = "Yt = " + this.trendProperties.parameters[0].ToString("G5") + " * ("
                            + this.trendProperties.parameters[1].ToString("G5") + "**t)"; break;
                    }
            }

            int i = 5;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "R";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.trendProperties.r.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "R-Squared";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.trendProperties.rSquare.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "R-Square Adjusted";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.trendProperties.rSquareAdjusted.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Sum Square Error (SSE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.trendProperties.sse.ToString("F6");
            i++;
            grdModelSummary.Rows[i + 1].HeaderCell.Value = "Mean Squared Error (MSE)";
            grdModelSummary.Rows[i + 1].Cells[0].Value = this.trendProperties.mse.ToString("F6");
        }     
    }
}
