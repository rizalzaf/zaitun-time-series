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
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class TransformVariable : Form
    {

        public enum TransformationType
        {
            Differencing,
            SeasonalDifferencing,
            Logarithm,
            NaturalLogarithm,
            SquareRoot
        }

        public TransformVariable(SeriesVariables sourceVariables)
        {
            InitializeComponent();
            this.lstVariables.Items.Clear();
            foreach (SeriesVariable item in sourceVariables)
            {
                this.lstVariables.Items.Add(item);
            }     
        }

        public string NewVariableName
        {
            get { return this.txtName.Text; }
        }

        public SeriesVariable SelectedVariable
        {
            get { return (SeriesVariable)this.lstVariables.SelectedItem; }
        }

        public TransformationType Transform
        {
            get
            {
                TransformationType trans = new TransformationType();
                if (radioDifferencing.Checked)
                    trans = TransformationType.Differencing;
                else if (radioLogarithm.Checked)
                    trans = TransformationType.Logarithm;
                else if (radioSeasonalDifferencing.Checked)
                    trans = TransformationType.SeasonalDifferencing;
                else if (radioNaturalLogarithm.Checked)
                    trans = TransformationType.NaturalLogarithm;
                else if (radioSquareRoot.Checked)
                    trans = TransformationType.SquareRoot;
                return trans;
            }
        }

        public int SeasonalLag
        {
            get { return (int)this.numericSeasonalLag.Value; }
        }

        public int LogarithmBase
        {
            get { return (int)this.numericLogarithmBase.Value; }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.lstVariables.SelectedIndex < 0)
            {
                MessageBox.Show("You must select transformed variable", "Transform Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (!this.radioDifferencing.Checked && !this.radioLogarithm.Checked && !this.radioSeasonalDifferencing.Checked && !this.radioNaturalLogarithm.Checked && !this.radioSquareRoot.Checked)
            {
                MessageBox.Show("You must select tranformation type", "Transform Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (txtName.Text.Length < 1)
            {
                MessageBox.Show("You must type new variable name", "Transform Variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void radioLogarithm_CheckedChanged(object sender, EventArgs e)
        {
            numericLogarithmBase.Enabled = ((RadioButton)sender).Checked;
        }

        private void radioSeasonalDifferencing_CheckedChanged(object sender, EventArgs e)
        {
            numericSeasonalLag.Enabled = ((RadioButton)sender).Checked;
        }
    }
}