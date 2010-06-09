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
using zaitun.Data;

namespace zaitun.LinearRegression
{
    public partial class LRForcastedDataGrid : UserControl
    {
        #region Constructor
        public LRForcastedDataGrid()
        {
            InitializeComponent();
        }
        #endregion

        #region Procedure Members
        public void SetData(SeriesVariables independentVariables, 
            SeriesVariable dependentVariable, 
            double[,] testValues, 
            string[] forcastedTime,
            double[] forcastedData)
        {
            foreach (SeriesVariable var in independentVariables)
            {
                DataGridViewTextBoxColumn clm = new DataGridViewTextBoxColumn();
                clm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                clm.HeaderText = var.VariableName;
                clm.Name = "clm" + var.VariableName;
                clm.ReadOnly = true;
                clm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
                this.grdForcasted.Columns.Add(clm);
            }
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            c.HeaderText = dependentVariable.VariableName;
            c.Name = "clm" + dependentVariable.VariableName;
            c.ReadOnly = true;
            c.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grdForcasted.Columns.Add(c);

            this.grdForcasted.RowCount = forcastedTime.Length;
            for (int i = 0; i < this.grdForcasted.Rows.Count; i++)
            {
                this.grdForcasted.Rows[i].HeaderCell.Value = forcastedTime[i];
                for (int j = 0; j < independentVariables.Count; j++)
                {
                    this.grdForcasted.Rows[i].Cells[j].Value = testValues[j, i].ToString("F4");
                }
                this.grdForcasted.Rows[i].Cells[independentVariables.Count].Value = forcastedData[i].ToString("F4");
            }
            this.grdForcasted.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        #endregion
    }
}
