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

namespace zaitun.Decomposition
{
    public partial class DECModelSummary : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;
        private DecompositionForm.DECSpecification decProperties;
        
        public DECModelSummary()
        {
            InitializeComponent();
            grdModelSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
        }

        public void SetData(SeriesData data, SeriesVariable variable, DecompositionForm.DECSpecification decProperties)
        {
            this.data = data;
            this.variable = variable;
            this.decProperties = decProperties;
            this.lblVariable.Text = variable.VariableName;            
            this.update();
        }

        private void update()
        {
            grdModelSummary.RowCount = 15;
            grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
            grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
            grdModelSummary.Rows[1].HeaderCell.Value = "Model Type";
            if (this.decProperties.isMultiplikatif)
                grdModelSummary.Rows[1].Cells[0].Value = "Multiplicative";
            else
                grdModelSummary.Rows[1].Cells[0].Value = "Additive";
            grdModelSummary.Rows[2].HeaderCell.Value = "Included Observation";
            grdModelSummary.Rows[2].Cells[0].Value = this.decProperties.includedObservations;
            grdModelSummary.Rows[3].HeaderCell.Value = "Seasonal Length";
            grdModelSummary.Rows[3].Cells[0].Value = this.decProperties.seasonalLength;

            switch (this.decProperties.initialTrend)
            {
                case 1:
                    {
                        string[] parametersString = new string[this.decProperties.parameters.Length];
                        parametersString[0] = this.decProperties.parameters[0].ToString("G5");
                        for (int j = 1; j < this.decProperties.parameters.Length; j++)
                        {
                            if (this.decProperties.parameters[j] < 0)
                                parametersString[j] = " " + this.decProperties.parameters[j].ToString("G5");
                            else
                                parametersString[j] = " +" + this.decProperties.parameters[j].ToString("G5");
                        }
                        grdModelSummary.Rows[5].HeaderCell.Value = "Linear Trend Equation";
                        grdModelSummary.Rows[5].Cells[0].Value = "Yt = " + parametersString[0] + ""
                            + parametersString[1] + "*t";
                        break;
                    }
                case 2:
                    {
                        string[] parametersString = new string[this.decProperties.parameters.Length];
                        parametersString[0] = this.decProperties.parameters[0].ToString("G5");
                        for (int j = 1; j < this.decProperties.parameters.Length; j++)
                        {
                            if (this.decProperties.parameters[j] < 0)
                                parametersString[j] = " " + this.decProperties.parameters[j].ToString("G5");
                            else
                                parametersString[j] = " +" + this.decProperties.parameters[j].ToString("G5");
                        }
                        grdModelSummary.Rows[5].HeaderCell.Value = "Quadratic Trend Equation";
                        grdModelSummary.Rows[5].Cells[0].Value = "Yt = " + parametersString[0] + ""
                            + parametersString[1] + "*t" + parametersString[2] + "*t**2";
                        break;
                    }
                case 3:
                    {
                        string[] parametersString = new string[this.decProperties.parameters.Length];
                        parametersString[0] = this.decProperties.parameters[0].ToString("G5");
                        for (int j = 1; j < this.decProperties.parameters.Length; j++)
                        {
                            if (this.decProperties.parameters[j] < 0)
                                parametersString[j] = " " + this.decProperties.parameters[j].ToString("G5");
                            else
                                parametersString[j] = " +" + this.decProperties.parameters[j].ToString("G5");
                        }
                        grdModelSummary.Rows[5].HeaderCell.Value = "Cubic Trend Equation";
                        grdModelSummary.Rows[5].Cells[0].Value = "Yt = " + parametersString[0] + ""
                            + parametersString[1] + "*t" + parametersString[2] + "*t**2" + parametersString[3] + "*t**3";
                        break;
                    }
                case 4:
                    {
                        grdModelSummary.Rows[5].HeaderCell.Value = "Exponential Trend Equation";
                        grdModelSummary.Rows[5].Cells[0].Value = "Yt = " + this.decProperties.parameters[0].ToString("G5") + " * ("
                            + this.decProperties.parameters[1].ToString("G5") + "**t)";
                        break;
                    }
            }

            grdModelSummary.Rows[7].HeaderCell.Value = "Seasonal Index";
            for (int i = 0; i < this.decProperties.seasonalLength; ++i)
            {
                grdModelSummary.RowCount += 1;
                grdModelSummary.Rows[8 + i].HeaderCell.Value = "period " + (i + 1);
                grdModelSummary.Rows[8+i].Cells[0].Value = this.decProperties.seasonalIdx[i].ToString("F5");
            }

            grdModelSummary.Rows[9 + this.decProperties.seasonalLength].HeaderCell.Value = "Accuracy Measures";
            grdModelSummary.Rows[10 + this.decProperties.seasonalLength].HeaderCell.Value = "Sum Square Error (SSE)";
            grdModelSummary.Rows[10 + this.decProperties.seasonalLength].Cells[0].Value = this.decProperties.sseDEC.ToString("F6");
            grdModelSummary.Rows[11 + this.decProperties.seasonalLength].HeaderCell.Value = "Mean Absolute Error (MAE)";
            grdModelSummary.Rows[11 + this.decProperties.seasonalLength].Cells[0].Value = this.decProperties.maeDEC.ToString("F6");
            grdModelSummary.Rows[12 + this.decProperties.seasonalLength].HeaderCell.Value = "Mean Squared Error (MSE)";
            grdModelSummary.Rows[12 + this.decProperties.seasonalLength].Cells[0].Value = this.decProperties.mseDEC.ToString("F6");
            grdModelSummary.Rows[13 + this.decProperties.seasonalLength].HeaderCell.Value = "Mean Percentage Error (MPE)";
            grdModelSummary.Rows[13 + this.decProperties.seasonalLength].Cells[0].Value = this.decProperties.mpeDEC.ToString("F6");
            grdModelSummary.Rows[14 + this.decProperties.seasonalLength].HeaderCell.Value = "Mean Absolute Percentage Error (MAPE)";
            grdModelSummary.Rows[14 + this.decProperties.seasonalLength].Cells[0].Value = this.decProperties.mapeDEC.ToString("F6");
        }     
    }
}
