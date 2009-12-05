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
    public partial class LRCoefficients : UserControl
    {
        #region Fields
        private SeriesVariables independentVariables;
        private LinearRegressionAnalysisForm.LRSpecification lrProperties;

        private bool isConfidenceIntervalForParametersVisible = false;
        private bool isVIFForPredictorsVisible = false;
        private bool isPartialCorrelationVisible = false;
        #endregion

        #region Constructor
        public LRCoefficients()
        {
            InitializeComponent();
            grdCoefficients.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        #endregion

        #region Procedure Members
        public void SetData(SeriesVariables independentVariables, LinearRegressionAnalysisForm.LRSpecification lrProperties)
        {
            this.independentVariables = independentVariables;
            this.lrProperties = lrProperties;            
            this.update();
        }

        private void update()
        {
            this.grdCoefficients.Rows.Add(this.lrProperties.Parameters.Length);
            this.grdCoefficients.Rows[0].HeaderCell.Value = "(Constant)";
            this.grdCoefficients.Rows[0].Cells[0].Value = this.lrProperties.Parameters[0].ToString("F4");
            this.grdCoefficients.Rows[0].Cells[1].Value = this.lrProperties.StandardErrorOfParameters[0].ToString("F4");
            this.grdCoefficients.Rows[0].Cells[2].Value = this.lrProperties.t[0].ToString("F4");
            this.grdCoefficients.Rows[0].Cells[3].Value = this.lrProperties.SigOfT[0].ToString("F4");
            this.grdCoefficients.Rows[0].Cells[4].Value = this.lrProperties.LowerBoundForParameters[0].ToString("F4");
            this.grdCoefficients.Rows[0].Cells[5].Value = this.lrProperties.UpperBoundForParameters[0].ToString("F4");
            for (int i = 1; i < this.lrProperties.Parameters.Length; i++)
            {
                this.grdCoefficients.Rows[i].HeaderCell.Value = this.independentVariables[i-1].VariableName;
                this.grdCoefficients.Rows[i].Cells[0].Value = this.lrProperties.Parameters[i].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[1].Value = this.lrProperties.StandardErrorOfParameters[i].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[2].Value = this.lrProperties.t[i].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[3].Value = this.lrProperties.SigOfT[i].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[4].Value = this.lrProperties.LowerBoundForParameters[i].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[5].Value = this.lrProperties.UpperBoundForParameters[i].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[6].Value = this.lrProperties.VIFForpredictors[i - 1].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[7].Value = this.lrProperties.Correlations[i - 1].ToString("F4");
                this.grdCoefficients.Rows[i].Cells[8].Value = this.lrProperties.PartialCorrelations[i - 1].ToString("F4");
            }
            this.grdCoefficients.Columns[4].Visible = isConfidenceIntervalForParametersVisible;
            this.grdCoefficients.Columns[5].Visible = isConfidenceIntervalForParametersVisible;
            this.grdCoefficients.Columns[6].Visible = isVIFForPredictorsVisible;
            this.grdCoefficients.Columns[7].Visible = isPartialCorrelationVisible;
            this.grdCoefficients.Columns[8].Visible = isPartialCorrelationVisible;
        }
        #endregion

        #region Properties
        public bool IsConfidenceIntervalForParametersVisible
        {
            set { this.isConfidenceIntervalForParametersVisible = value; }
        }
        public bool IsVIFForPredictorsVisible
        {
            set { this.isVIFForPredictorsVisible = value; }
        }
        public bool IsPartialCorrelationVisible
        {
            set { this.isPartialCorrelationVisible = value; }
        }
        #endregion
    }
}
