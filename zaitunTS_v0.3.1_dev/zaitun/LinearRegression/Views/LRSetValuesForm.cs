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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.LinearRegression
{
    public partial class LRSetValuesForm : Form
    {
        #region Fields
        private int forcastingStep;
        private double[,] testValues;
        private string[] time;
        #endregion

        #region Constructor
        public LRSetValuesForm()
        {
            InitializeComponent();
            grdValues.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            this.grdValues.CellBeginEdit += new DataGridViewCellCancelEventHandler(grdValues_CellBeginEdit);
            this.grdValues.CellEndEdit += new DataGridViewCellEventHandler(grdValues_CellEndEdit);
        }
        #endregion

        #region grdValues
        private void grdValues_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.grdValues[e.ColumnIndex, e.RowIndex].Style.Format = "G7";
        }

        private void grdValues_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.grdValues[e.ColumnIndex, e.RowIndex].Style.Format = "0.#############################";
        }
        private void grdValues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.grdValues.BeginEdit(false);
        }
        #endregion

        #region Procedure Members
        public void SetData(zaitun.Data.SeriesData data,
            zaitun.Data.SeriesVariables independentVariables)
        {
            foreach (zaitun.Data.SeriesVariable var in independentVariables)
            {
                DataGridViewTextBoxColumn clm = new DataGridViewTextBoxColumn();
                DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                DataGridViewCell cell = new zaitun.GUI.ValidatedTextBoxCell();
                dataGridViewCellStyle1.NullValue = null;
                clm.DefaultCellStyle = dataGridViewCellStyle1;
                clm.CellTemplate = cell;
                clm.HeaderText = var.VariableName;
                clm.Name = "clm" + var.VariableName;
                clm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                this.grdValues.Columns.Add(clm);
            }
            this.time = getForecastedTime(data);
            this.grdValues.RowCount = this.forcastingStep;
            for (int i = 0; i < this.forcastingStep; i++)
            {
                this.grdValues.Rows[i].HeaderCell.Value = time[i];
            }
            this.testValues = new double[independentVariables.Count, this.forcastingStep];
            
        }
        private string[] getForecastedTime(zaitun.Data.SeriesData data)
        {
            string[] result = new string[this.forcastingStep];

            DateTime currentDate = new DateTime();

            switch (data.Frequency)
            {
                case zaitun.Data.SeriesData.SeriesFrequency.Annual:
                    for (int i = 0; i < this.forcastingStep; i++)
                    {
                        currentDate = data.EndDate.AddYears(i + 1);
                        result[i] = currentDate.Year.ToString();
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.SemiAnnual:
                    for (int i = 0; i < this.forcastingStep; i++)
                    {
                        currentDate = data.EndDate.AddMonths(6 * (i + 1));
                        result[i] = "Pertengahan " + (currentDate.Month / 2) + " " +
                            currentDate.Year.ToString();
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Quarterly:
                    for (int i = 0; i < this.forcastingStep; i++)
                    {
                        currentDate = data.EndDate.AddMonths(3 * (i + 1));
                        result[i] = "Triwulan " + (currentDate.Month / 3) + " " +
                            currentDate.Year.ToString();
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Monthly:
                    for (int i = 0; i < this.forcastingStep; i++)
                    {
                        currentDate = data.EndDate.AddMonths(i + 1);
                        result[i] = zaitun.Data.SeriesData.ConvertIntToMonth(currentDate.Month)
                            + " " + currentDate.Year.ToString();
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Weekly:
                    for (int i = 0; i < this.forcastingStep; i++)
                    {
                        currentDate = data.EndDate.AddDays(7 * (i + 1));
                        result[i] = currentDate.ToString("dd/MM/yy");
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Daily:
                    for (int i = 0; i < this.forcastingStep; i++)
                    {
                        currentDate = data.EndDate.AddDays(i + 1);
                        result[i] = currentDate.ToString("dd/MM/yy");
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Daily6:
                    {
                        int i = 0;
                        currentDate = data.EndDate;
                        while (i < this.forcastingStep)
                        {
                            currentDate = currentDate.AddDays(1);
                            if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                            {
                                result[i] = currentDate.ToString("dd/MM/yy");
                                i++;
                            }
                        }
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Daily5:
                    {
                        int i = 0;
                        currentDate = data.EndDate;
                        while (i < this.forcastingStep)
                        {
                            currentDate = currentDate.AddDays(1);
                            if (currentDate.DayOfWeek != DayOfWeek.Sunday &&
                                currentDate.DayOfWeek != DayOfWeek.Saturday)
                            {
                                result[i] = currentDate.ToString("dd/MM/yy");
                                i++;
                            }
                        }
                    }
                    break;
                case zaitun.Data.SeriesData.SeriesFrequency.Undated:
                    {
                        for (int i = 0; i < this.forcastingStep; i++)
                        {
                            int current = data.NumberObservations + i + 1;
                            result[i] = current.ToString();
                        }
                    }
                    break;
            }

            return result;
        }
        #endregion

        #region btnCancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region btnOK
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdValues.Rows.Count; i++)
            {
                for (int j = 0; j < this.grdValues.Columns.Count; j++)
                {
                    try
                    {
                        this.testValues[j, i] = Convert.ToDouble(this.grdValues.Rows[i].Cells[j].Value);
                    }
                    catch
                    {
                        this.testValues[j, i] = 0.0D;
                        this.grdValues.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Properties
        public int ForcastingStep
        {
            set { this.forcastingStep = value; }
        }
        public string[] ForcastedTime
        {
            get { return this.time; }
        }
        public double[,] TestValues
        {
            get { return this.testValues; }
        }
        #endregion
    }
}