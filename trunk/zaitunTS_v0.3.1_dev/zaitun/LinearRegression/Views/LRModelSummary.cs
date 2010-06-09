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

namespace zaitun.LinearRegression
{
    public partial class LRModelSummary : UserControl
    {
        #region Fields
        private SeriesVariable dependentVariable;
        private SeriesVariables independentVariables;
        private LinearRegressionAnalysisForm.LRSpecification lrProperties;

        private bool isDurbinWatsonVisible = false;
        #endregion

        #region Constructor
        public LRModelSummary()
        {
            InitializeComponent();
            grdModelSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        #endregion

        #region Procedure Members
        public void SetData(SeriesVariable dependentVariable, SeriesVariables independentVariables, LinearRegressionAnalysisForm.LRSpecification lrProperties)
        {
            this.dependentVariable = dependentVariable;
            this.independentVariables = independentVariables;
            this.lrProperties = lrProperties;            
            this.update();
        }

        private void update()
        {
            grdModelSummary.RowCount = 11;

            grdModelSummary.Rows[0].HeaderCell.Value = "Variable Dependent";
            grdModelSummary.Rows[0].Cells[0].Value = this.dependentVariable.VariableName;
            grdModelSummary.Rows[1].HeaderCell.Value = "Predictors";
            grdModelSummary.Rows[1].Cells[0].Value = "(Costant)";
            for (int i = 0; i < this.independentVariables.Count; i++)
            {
                grdModelSummary.Rows[1].Cells[0].Value = grdModelSummary.Rows[1].Cells[0].Value +
                    ", " + this.independentVariables[i].VariableName;
            }
            grdModelSummary.Rows[2].HeaderCell.Value = "Model Type";
            if (this.lrProperties.IsMultiple)
                grdModelSummary.Rows[2].Cells[0].Value = "Multiple Linear Regression";
            else
                grdModelSummary.Rows[2].Cells[0].Value = "Simple Linear Regression";
            grdModelSummary.Rows[3].HeaderCell.Value = "Included Observation";
            grdModelSummary.Rows[3].Cells[0].Value = this.lrProperties.IncludedObservations;

            grdModelSummary.Rows[5].HeaderCell.Value = "Regression Equation";
            grdModelSummary.Rows[5].Cells[0].Value = this.dependentVariable.VariableName +
                " = " + this.lrProperties.Parameters[0].ToString("F4");
            for (int i = 1; i < this.lrProperties.Parameters.Length; i++)
            {
                if(this.lrProperties.Parameters[i] > 0)
                    grdModelSummary.Rows[5].Cells[0].Value = grdModelSummary.Rows[5].Cells[0].Value + " + " +
                        this.lrProperties.Parameters[i].ToString("F4") + "*" + this.independentVariables[i-1].VariableName;
                else
                    grdModelSummary.Rows[5].Cells[0].Value = grdModelSummary.Rows[5].Cells[0].Value + " " +
                        this.lrProperties.Parameters[i].ToString("F4") + "*" + this.independentVariables[i - 1].VariableName;
            }
            grdModelSummary.Rows[6].HeaderCell.Value = "R";
            grdModelSummary.Rows[6].Cells[0].Value = this.lrProperties.R.ToString("F4");
            grdModelSummary.Rows[7].HeaderCell.Value = "R-Square";
            grdModelSummary.Rows[7].Cells[0].Value = this.lrProperties.RSquare.ToString("F4");
            grdModelSummary.Rows[8].HeaderCell.Value = "R-Square (Adjusted)";
            grdModelSummary.Rows[8].Cells[0].Value = this.lrProperties.AdjRSquare.ToString("F4");
            grdModelSummary.Rows[9].HeaderCell.Value = "Standard Error of Estimates";
            grdModelSummary.Rows[9].Cells[0].Value = this.lrProperties.StandardError.ToString("F4");
            grdModelSummary.Rows[10].HeaderCell.Value = "Durbin-Watson";
            grdModelSummary.Rows[10].Cells[0].Value = this.lrProperties.DurbinWatson.ToString("F4");
            grdModelSummary.Rows[10].Visible = isDurbinWatsonVisible;
        }
        #endregion

        #region Properties
        public bool IsDurbinWatsonVisible
        {
            set { this.isDurbinWatsonVisible = value; }
        }
        #endregion
    }
}
