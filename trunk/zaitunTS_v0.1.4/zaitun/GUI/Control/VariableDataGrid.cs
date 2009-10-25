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
    public partial class VariableDataGrid : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        public VariableDataGrid()
        {
            InitializeComponent();
            grdSeriesVariable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            DataGridViewCell cell = new ValidatedTextBoxCell();
            
            clmData.CellTemplate = cell;

            this.grdSeriesVariable.CellBeginEdit += new DataGridViewCellCancelEventHandler(grdSeriesVariable_CellBeginEdit);
            this.grdSeriesVariable.CellEndEdit += new DataGridViewCellEventHandler(grdSeriesVariable_CellEndEdit);
        }

        void grdSeriesVariable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.grdSeriesVariable[e.ColumnIndex, e.RowIndex].Style.Format = "G7";
        }

        void grdSeriesVariable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.grdSeriesVariable[e.ColumnIndex, e.RowIndex].Style.Format = "0.#############################";
        }

        //void SeriesValues_Changed(object sender, EventArgs e)
        //{
        //    //this.update();
        //}

        public void SetData(SeriesVariable variable, SeriesData data)
        {
            this.variable = variable;
            this.data = data;
            //this.variable.SeriesValues.Changed += new ChangedEventHandler(SeriesValues_Changed);
            this.update();
        }

        private void update()
        {            

            this.grdSeriesVariable.Columns[0].HeaderCell.Value = this.variable.VariableName;
            this.grdSeriesVariable.Columns[0].DefaultCellStyle.Format = "G7";

            grdSeriesVariable.RowCount = this.data.NumberObservations;
            for (int i = 0; i < data.NumberObservations; i++)
            {
                grdSeriesVariable.Rows[i].HeaderCell.Value = this.data.Time[i];
                grdSeriesVariable.Rows[i].Cells[0].Value = this.variable[i];
                //grdSeriesVariable.Rows[i].Cells[0].Value = Math.Round(this.variable[i], 4);
            }           
            this.grdSeriesVariable.CellValueChanged += new DataGridViewCellEventHandler(this.grdSeriesVariable_CellValueChanged);
        }

        private void grdSeriesVariable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.grdSeriesVariable.BeginEdit(false);
        }

       
        private void grdSeriesVariable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    this.variable[e.RowIndex] = Convert.ToDouble(this.grdSeriesVariable.Rows[e.RowIndex].Cells[0].Value);
                }
                catch
                {
                    this.variable[e.RowIndex] = 0.0D;
                    this.grdSeriesVariable.Rows[e.RowIndex].Cells[0].Value = 0;
                }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                if (text.EndsWith("\r\n")) text = text.Remove(text.Length - 2, 2);

                string[] rowText = text.Split('\n');
                string[][] rowColText = new string[rowText.Length][];
                for (int i = 0; i < rowText.Length; i++)
                {
                    rowColText[i] = rowText[i].Split('\t');
                }

                this.variable.SeriesValues.SuspendEvent();

                if (this.grdSeriesVariable.SelectedCells.Count > 1)
                {
                    int firstIndex = this.grdSeriesVariable.RowCount;
                    int lastIndex = 0;
                    for (int i = 0; i < this.grdSeriesVariable.SelectedCells.Count; i++)
                    {
                        if (this.grdSeriesVariable.SelectedCells[i].RowIndex < firstIndex) firstIndex = this.grdSeriesVariable.SelectedCells[i].RowIndex;
                        if (this.grdSeriesVariable.SelectedCells[i].RowIndex > lastIndex) lastIndex = this.grdSeriesVariable.SelectedCells[i].RowIndex;
                    }

                    int k = 0, j = firstIndex;
                    while (j <= lastIndex && k < rowText.Length)
                    {
                        this.grdSeriesVariable[0, j].Value = rowColText[k][0];

                        j++;
                        k++;
                    }

                }
                else
                {
                    int firstIndex = this.grdSeriesVariable.SelectedCells[0].RowIndex;
                    int i = 0;

                    while (firstIndex < this.grdSeriesVariable.RowCount && i < rowText.Length)
                    {
                        this.grdSeriesVariable[0, firstIndex].Value = rowColText[i][0];

                        firstIndex++;
                        i++;
                    }
                }

                this.variable.SeriesValues.ResumeEvent();

            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.grdSeriesVariable.RowCount; i++)
            {
                if (grdSeriesVariable[0, i].Selected)
                {
                    sb.Append(grdSeriesVariable[0, i].Value.ToString());
                    sb.Append("\r\n");
                }

            }

            Clipboard.SetDataObject(sb.ToString(), true);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.grdSeriesVariable.SelectAll();
        }





    }
}
