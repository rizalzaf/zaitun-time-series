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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using zaitun.Data;
using System.IO;

namespace zaitun.GUI
{
    public partial class ImportExcelDialog : Form
    {
        private SeriesData data;

        private ExcelReader excel;
        private DataSet excelData;

        private SeriesVariables selectedVariables;

        public ImportExcelDialog()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data)
        {
            this.data = data;
        }

        public void SetFilePath(string filePath)
        {
            this.filePathLabel.Text = filePath;
            
            excel = new ExcelReader(filePath);
            this.excelData = excel.ReadData();

            cboSheet.Items.Clear();
            cboSheet.DisplayMember = "TableName";
            foreach (DataTable dt in this.excelData.Tables)
                cboSheet.Items.Add(dt);

            if (cboSheet.Items.Count == 0) return;            
            cboSheet.SelectedIndex = 0;

            ValidatedNameTextBoxCell cellTemplate = new ValidatedNameTextBoxCell();
            this.nameColumn.CellTemplate = cellTemplate;
            if (this.excelData.Tables[cboSheet.SelectedIndex].Rows.Count > 0)
            {
                this.variableNameGrid.RowCount = this.excelData.Tables[0].Columns.Count;
                for (int i = 0; i < this.excelData.Tables[0].Columns.Count; i++)
                {
                    this.variableNameGrid[0, i].Value = false;
                    this.variableNameGrid[1, i].Value = (i + 1).ToString();
                    this.variableNameGrid[2, i].Value = "variable" + (i + 1).ToString();
                }
            }

            this.selectedVariables = new SeriesVariables();

        }

        private void customRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.excelData.Tables[cboSheet.SelectedIndex].Rows.Count > 0)
            {
                this.variableNameGrid.RowCount = this.excelData.Tables[cboSheet.SelectedIndex].Columns.Count;

                if (this.useFirstRowRadio.Checked)
                {
                    for (int i = 0; i < this.excelData.Tables[cboSheet.SelectedIndex].Columns.Count; i++)
                    {
                        this.variableNameGrid[0, i].Value = false;
                        this.variableNameGrid[1, i].Value = (i + 1).ToString();
                        this.variableNameGrid[2, i].Value = this.excelData.Tables[cboSheet.SelectedIndex].Rows[0].ItemArray[i].ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < this.excelData.Tables[cboSheet.SelectedIndex].Columns.Count; i++)
                    {
                        this.variableNameGrid[0, i].Value = false;
                        this.variableNameGrid[1, i].Value = (i + 1).ToString();
                        this.variableNameGrid[2, i].Value = "variable" + (i + 1).ToString();                         
                    }
                }
            }
            else
            {
                this.variableNameGrid.RowCount = 0;
            }
            
        }        

        private void cmdOK_Click(object sender, EventArgs e)
        {
            int selectedCount = 0;

            for (int i = 0; i < this.variableNameGrid.RowCount; i++)            
                if ((bool)this.variableNameGrid[0, i].Value == true)                
                    selectedCount++;

            if (selectedCount == 0)
            {
                MessageBox.Show("Select a variable first", "Import Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (this.useFirstRowRadio.Checked)
            {
                this.selectedVariables.Clear();
                for (int i = 0; i < this.variableNameGrid.RowCount; i++)
                {
                    if ((bool)this.variableNameGrid[0, i].Value == true)
                    {
                        SeriesVariable var = new SeriesVariable(this.variableNameGrid[2, i].Value.ToString(), this.variableNameGrid[2, i].Value.ToString());
                        var.InitializeItem(this.data.NumberObservations);
                        for (int j = 0; j < this.data.NumberObservations && j < this.grdPreviewSheet.RowCount - 1; j++)
                        {
                            try
                            {
                                string str = this.grdPreviewSheet[i, j + 1].Value.ToString();
                                if (str == "") var[j] = 0.0D;
                                else var[j] = double.Parse(str);
                            }                           
                            catch (Exception)
                            {
                                MessageBox.Show("Non numeric value is found in variable: '" + this.variableNameGrid[2,i].Value.ToString() + "'", "Import from Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        this.selectedVariables.Add(var);
                    }
                }

                if (this.data.NumberObservations < this.grdPreviewSheet.RowCount - 1)
                {
                    if (MessageBox.Show("Variable length in this file is longer than the current project variable length\n" +
                    "Only partial data are imported\n Are you sure you want to import this file?", "Import Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No) this.DialogResult = DialogResult.None;
                }
                else if (this.data.NumberObservations > this.grdPreviewSheet.RowCount - 1)
                {
                    if (MessageBox.Show("Variable length in this file is shorter than the current project variable length\n" +
                    "Unavaliable data will be setted to 0\nAre you sure you want to import this file?", "Import Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.No) this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                this.selectedVariables.Clear();
                for (int i = 0; i < this.variableNameGrid.RowCount; i++)
                {
                    if ((bool)this.variableNameGrid[0, i].Value == true)
                    {
                        SeriesVariable var = new SeriesVariable(this.variableNameGrid[2, i].Value.ToString(), this.variableNameGrid[2, i].Value.ToString());
                        var.InitializeItem(this.data.NumberObservations);
                        for (int j = 0; j < this.data.NumberObservations && j < this.grdPreviewSheet.RowCount; j++)
                        {
                            try
                            {
                                string str = this.grdPreviewSheet[i, j].Value.ToString();
                                if (str == "") var[j] = 0.0D;
                                else var[j] = double.Parse(str);
                                
                            }                            
                            catch (Exception)
                            {
                                MessageBox.Show("Non numeric value is found in variable: '" + this.variableNameGrid[2, i].Value.ToString() + "'", "Import from Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        this.selectedVariables.Add(var);
                    }
                }

                if (this.data.NumberObservations < this.grdPreviewSheet.RowCount)
                {
                    if (MessageBox.Show("Variable length in this file is longer than the current project variable length\n" +
                    "Only partial data are imported\n Are you sure you want to import this file?", "Import Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No) this.DialogResult = DialogResult.None;
                }
                else if (this.data.NumberObservations > this.grdPreviewSheet.RowCount)
                {
                    if (MessageBox.Show("Variable length in this file is shorter than the current project variable length\n" +
                    "Unavaliable data will be setted to 0\nAre you sure you want to import this file?", "Import Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.No) this.DialogResult = DialogResult.None;
                }
            }
        }

        public SeriesVariables SelectedVariables
        {
            get { return this.selectedVariables; }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null) return;
            this.grdPreviewSheet.DataSource = ((ComboBox)sender).SelectedItem;

            if (this.excelData.Tables[cboSheet.SelectedIndex].Rows.Count > 0)
            {
                this.variableNameGrid.RowCount = this.excelData.Tables[cboSheet.SelectedIndex].Columns.Count;

                if (this.useFirstRowRadio.Checked)
                {
                    for (int i = 0; i < this.excelData.Tables[cboSheet.SelectedIndex].Columns.Count; i++)
                    {
                        this.variableNameGrid[0, i].Value = false;
                        this.variableNameGrid[1, i].Value = (i + 1).ToString();
                        this.variableNameGrid[2, i].Value = this.excelData.Tables[cboSheet.SelectedIndex].Rows[0].ItemArray[i].ToString();   
                    }
                }
                else
                {
                    for (int i = 0; i < this.excelData.Tables[cboSheet.SelectedIndex].Columns.Count; i++)
                    {
                        this.variableNameGrid[0, i].Value = false;
                        this.variableNameGrid[1, i].Value = (i + 1).ToString();
                        this.variableNameGrid[2, i].Value = "variable" + (i + 1).ToString();                         
                    }
                }
            }
            else
            {
                this.variableNameGrid.RowCount = 0;
            }
        }

        private void grdPreviewSheet_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.Programmatic;
        }
    }
}