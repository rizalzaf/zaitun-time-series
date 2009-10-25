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
    public partial class VariableStatistics : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        public VariableStatistics()
        {
            InitializeComponent();
            grdDescriptive.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }   

        public void SetData(SeriesVariable variable, SeriesData data)
        {
            this.variable = variable;
            this.data = data;
            this.lblVariable.Text = variable.VariableName;

            this.variable.SeriesValues.Changed += new ChangedEventHandler(SeriesValues_Changed);
            this.update();
        }

        void SeriesValues_Changed(object sender, EventArgs e)
        {
            this.update();
        }

        private void update()
        {
            this.grdDescriptive.Columns[0].HeaderCell.Value = this.variable.VariableName;

            grdDescriptive.RowCount = 18;
            grdDescriptive.Rows[0].HeaderCell.Value = "Observations";
            grdDescriptive.Rows[0].Cells[0].Value = this.variable.Observations.ToString();
            grdDescriptive.Rows[2].HeaderCell.Value = "Minimum";
            grdDescriptive.Rows[2].Cells[0].Value = this.variable.MinValue.ToString("G7");
            grdDescriptive.Rows[3].HeaderCell.Value = "Maximum";
            grdDescriptive.Rows[3].Cells[0].Value = this.variable.MaxValue.ToString("G7");
            grdDescriptive.Rows[4].HeaderCell.Value = "Range";
            grdDescriptive.Rows[4].Cells[0].Value = (this.variable.MaxValue - this.variable.MinValue).ToString("G7");

            grdDescriptive.Rows[6].HeaderCell.Value = "Sum";
            grdDescriptive.Rows[6].Cells[0].Value = this.variable.SumValue.ToString("G7");
            grdDescriptive.Rows[7].HeaderCell.Value = "Mean";
            grdDescriptive.Rows[7].Cells[0].Value = this.variable.MeanValue.ToString("G7");
            grdDescriptive.Rows[8].HeaderCell.Value = "Median";
            grdDescriptive.Rows[8].Cells[0].Value = this.variable.MedianValue.ToString("G7");
            grdDescriptive.Rows[9].HeaderCell.Value = "Quartil 1";
            grdDescriptive.Rows[9].Cells[0].Value = this.variable.Q1Value.ToString("G7");
            grdDescriptive.Rows[10].HeaderCell.Value = "Quartil 3";
            grdDescriptive.Rows[10].Cells[0].Value = this.variable.Q3Value.ToString("G7");

            grdDescriptive.Rows[12].HeaderCell.Value = "Standard Deviation";
            grdDescriptive.Rows[12].Cells[0].Value = this.variable.StDevValue.ToString("G7");
            grdDescriptive.Rows[13].HeaderCell.Value = "Variance";
            grdDescriptive.Rows[13].Cells[0].Value = this.variable.VariansValue.ToString("G7");

            grdDescriptive.Rows[15].HeaderCell.Value = "Skewness";
            grdDescriptive.Rows[15].Cells[0].Value = this.variable.SkewnessValue.ToString("G7");
            grdDescriptive.Rows[16].HeaderCell.Value = "Kurtosis";
            grdDescriptive.Rows[16].Cells[0].Value = this.variable.KurtosisValue.ToString("G7");

        }      
        
    }
}
