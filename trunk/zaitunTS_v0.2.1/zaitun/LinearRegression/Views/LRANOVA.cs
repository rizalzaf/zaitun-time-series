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
    public partial class LRANOVA : UserControl
    {
        #region Fields
        private LinearRegressionAnalysisForm.LRSpecification lrProperties;
        #endregion

        #region Constructor
        public LRANOVA()
        {
            InitializeComponent();
            grdANOVA.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        #endregion

        #region Procedure Members
        public void SetData(LinearRegressionAnalysisForm.LRSpecification lrProperties)
        {
            this.lrProperties = lrProperties;            
            this.update();
        }

        private void update()
        {
            this.grdANOVA.Rows.Add(3);
            this.grdANOVA.Rows[0].HeaderCell.Value = "Regression";
            this.grdANOVA.Rows[0].Cells[0].Value = this.lrProperties.SSR.ToString("F4");
            this.grdANOVA.Rows[0].Cells[1].Value = this.lrProperties.Parameters.Length - 1;
            this.grdANOVA.Rows[0].Cells[2].Value = this.lrProperties.MSR.ToString("F4");
            this.grdANOVA.Rows[0].Cells[3].Value = this.lrProperties.F.ToString("F4");
            this.grdANOVA.Rows[0].Cells[4].Value = this.lrProperties.SigOfF.ToString("F4");
            this.grdANOVA.Rows[1].HeaderCell.Value = "Residual";
            this.grdANOVA.Rows[1].Cells[0].Value = this.lrProperties.SSE.ToString("F4");
            this.grdANOVA.Rows[1].Cells[1].Value = this.lrProperties.IncludedObservations - this.lrProperties.Parameters.Length;
            this.grdANOVA.Rows[1].Cells[2].Value = this.lrProperties.MSE.ToString("F4");
            this.grdANOVA.Rows[2].HeaderCell.Value = "Total";
            this.grdANOVA.Rows[2].Cells[0].Value = this.lrProperties.SST.ToString("F4");
            this.grdANOVA.Rows[2].Cells[1].Value = this.lrProperties.IncludedObservations - 1;
        }
        #endregion

    }
}
