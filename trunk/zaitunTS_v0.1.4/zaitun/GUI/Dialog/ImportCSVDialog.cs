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

namespace zaitun.GUI
{
    public partial class ImportCSVDialog : Form
    {
        private SeriesData data;

        private CSVReader reader;
        private int variableCount;
        private string[][] stringData;
        private double[][] doubleData;

        private SeriesVariables selectedVariables;

        public ImportCSVDialog()
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
            this.reader = new CSVReader(filePath);
            this.stringData = this.reader.ReadDataToString();
            this.variableCount = this.reader.ColumnCount;

            ValidatedNameTextBoxCell cellTemplate = new ValidatedNameTextBoxCell();
            this.nameColumn.CellTemplate = cellTemplate;
            this.variableNameGrid.RowCount = this.variableCount;
            for (int i = 0; i < this.variableCount; i++)
            {
                this.variableNameGrid[0, i].Value = true;
                this.variableNameGrid[1, i].Value = (i + 1).ToString();
                this.variableNameGrid[2, i].Value = "variable" + (i + 1).ToString();
            }

            for (int i = 0; i < reader.RowCount; i++)
            {
                for (int j = 0; j < reader.ColumnCount - 1; j++)
                {
                    this.previewTextBox.AppendText(this.stringData[i][j] + "\t");
                }
                this.previewTextBox.AppendText(this.stringData[i][reader.ColumnCount - 1] + "\n");
            }
            this.previewTextBox.Text = this.previewTextBox.Text;

            this.selectedVariables = new SeriesVariables();

        }

        private void customRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                for (int i = 0; i < this.variableCount; i++)
                {                    
                    this.variableNameGrid[2, i].Value = "variable" + (i + 1).ToString();
                    this.nameColumn.ReadOnly = false;
                }
            }
            else
            {
                for (int i = 0; i < this.variableCount; i++)
                {
                    this.variableNameGrid[2, i].Value = this.stringData[0][i];
                    this.nameColumn.ReadOnly = true;
                }
            }
            
        }        


        // change in version 0.1.2
        //         
        private void cmdOK_Click(object sender, EventArgs e)
        {
           
            if (this.useFirstRowRadio.Checked)
            {
                this.selectedVariables.Clear();
                for (int i = 0; i < this.variableCount; i++)
                {
                    if ((bool)this.variableNameGrid[0, i].Value == true)
                    {
                        SeriesVariable var = new SeriesVariable(this.variableNameGrid[2, i].Value.ToString(), this.variableNameGrid[2, i].Value.ToString());
                        var.InitializeItem(this.data.NumberObservations);
                        for (int j = 0; j < this.data.NumberObservations && j < this.reader.RowCount - 1; j++)
                        {
                            try
                            {
                                string str = this.stringData[j + 1][i];
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

                if (this.data.NumberObservations < this.reader.RowCount - 1)
                {
                    if (MessageBox.Show("Variable length in this file is longer than the current project variable length\n" +
                    "Only partial data are imported\n Are you sure you want to import this file?", "Import CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No) this.DialogResult = DialogResult.None;
                }
                else if (this.data.NumberObservations > this.reader.RowCount - 1)
                {
                    if (MessageBox.Show("Variable length in this file is shorter than the current project variable length\n" +
                    "Unavaliable data will be setted to 0\nAre you sure you want to import this file?", "Import CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.No) this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                this.selectedVariables.Clear();
                for (int i = 0; i < this.variableCount; i++)
                {
                    if ((bool)this.variableNameGrid[0, i].Value == true)
                    {
                        SeriesVariable var = new SeriesVariable(this.variableNameGrid[2, i].Value.ToString(), this.variableNameGrid[2, i].Value.ToString());
                        var.InitializeItem(this.data.NumberObservations);
                        for (int j = 0; j < this.data.NumberObservations && j < this.reader.RowCount; j++)
                        {
                            try
                            {
                                string str = this.stringData[j][i];
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

                if (this.data.NumberObservations < this.reader.RowCount)
                {
                    if (MessageBox.Show("Variable length in this file is longer than the current project variable length\n" +
                    "Only partial data are imported\n Are you sure you want to import this file?", "Import CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No) this.DialogResult = DialogResult.None;
                }
                else if (this.data.NumberObservations > this.reader.RowCount)
                {
                    if (MessageBox.Show("Variable length in this file is shorter than the current project variable length\n" +
                    "Unavaliable data will be setted to 0\nAre you sure you want to import this file?", "Import CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.No) this.DialogResult = DialogResult.None;
                }
            }
        }

        public SeriesVariables SelectedVariables
        {
            get { return this.selectedVariables; }
        }
    }
}