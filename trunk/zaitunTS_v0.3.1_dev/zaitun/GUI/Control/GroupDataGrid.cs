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

namespace zaitun.GUI
{
    public partial class GroupDataGrid : UserControl
    {
        private SeriesGroup group;
        private SeriesData data;

        public GroupDataGrid()
        {
            InitializeComponent();
            grdSeriesGroup.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        public void SetData(SeriesGroup group, SeriesData data)
        {
            this.group = group;
            this.data = data;
            this.group.Changed += new ChangedEventHandler(group_Changed);
            foreach (SeriesVariable var in this.group.GroupList)
            {
                var.SeriesValues.Changed += new ChangedEventHandler(SeriesValues_Changed);
            }            
            this.update();
        }

        void group_Changed(object sender, EventArgs e)
        {
            this.update();
        }

        void SeriesValues_Changed(object sender, EventArgs e)
        {
            this.update();
        }

        private void update()
        {
            grdSeriesGroup.Columns.Clear();
            foreach (SeriesVariable item in this.group.GroupList)
            {
                DataGridViewTextBoxColumn variableColumn = new DataGridViewTextBoxColumn();
                variableColumn.DefaultCellStyle.Format = "G7";
                variableColumn.Name = item.VariableName;
                variableColumn.HeaderText = item.VariableName;
                variableColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                this.grdSeriesGroup.Columns.Add(variableColumn);                
            }

            grdSeriesGroup.RowCount = this.data.NumberObservations;
            for (int i = 0; i < this.data.NumberObservations; i++)
                grdSeriesGroup.Rows[i].HeaderCell.Value = this.data.Time[i];

            for (int i = 0; i < grdSeriesGroup.Columns.Count; i++)
                for (int j = 0; j < grdSeriesGroup.Rows.Count; j++)
                    grdSeriesGroup.Rows[j].Cells[i].Value = this.group.GroupList[i].SeriesValues[j];

            //grdSeriesGroup.Rows[j].Cells[i].Value = Math.Round(this.group.GroupList[i].SeriesValues[j], 4);
            
        }

        private void grdSeriesVariable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // this.grdSeriesGroup.BeginEdit(false);
        }

        private void grdSeriesVariable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //this.group[e.RowIndex] = Convert.ToDouble(this.grdSeriesVariable.Rows[e.RowIndex].Cells[0].Value);
        }

        private void grdSeriesVariable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >=0 && e.ColumnIndex>=0)
            //    this.group[e.RowIndex] = Convert.ToDouble(this.grdSeriesGroup.Rows[e.RowIndex].Cells[0].Value);
        }     

        
    }
}
