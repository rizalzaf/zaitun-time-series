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
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class CreateSeriesStock : Form
    {
        private SeriesVariables sourceVariables;
        private SeriesVariable openVariable;
        private SeriesVariable closeVariable;
        private SeriesVariable highVariable;
        private SeriesVariable lowVariable;
        private SeriesVariable volumeVariable;

        public CreateSeriesStock(SeriesVariables sourceVariables)
        {
            InitializeComponent();
            this.sourceVariables = sourceVariables;            
            this.lstVariables.Items.Clear();
            foreach (SeriesVariable item in sourceVariables)
            {
                this.lstVariables.Items.Add(item);
            }            
        }

        public SeriesVariable OpenVariable
        {
            get { return this.openVariable; }            
        }

        public SeriesVariable CloseVariable
        {
            get { return this.closeVariable; }            
        }

        public SeriesVariable HighVariable
        {
            get { return this.highVariable; }
        }

        public SeriesVariable LowVariable
        {
            get { return this.lowVariable; }
        }

        public SeriesVariable VolumeVariable
        {
            get { return this.volumeVariable; }
        }

        public string StockName
        {
            get { return this.txtName.Text; }
        }

        public string StockDescription
        {
            get { return this.txtDescription.Text; }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length < 1)
            {
                MessageBox.Show("Type the stock name", "Create Series Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (txtOpen.Text.Length < 1)
            {
                MessageBox.Show("Select the stock's Open Variable", "Create Series Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (txtHigh.Text.Length < 1)
            {
                MessageBox.Show("Select the stock's High Variable", "Create Series Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (txtLow.Text.Length < 1)
            {
                MessageBox.Show("Select the stock's Low Variable", "Create Series Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (txtClose.Text.Length < 1)
            {
                MessageBox.Show("Select the stock's Close Variable", "Create Series Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (txtVolume.Text.Length < 1)
            {
                MessageBox.Show("Select the stock's Volume Variable", "Create Series Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }            
            else if (txtDescription.Text.Length < 1)
            {
                this.txtDescription.Text = this.txtName.Text;
            }
          
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            if (this.cmdOpen.Text == ">")
            {
                if (this.lstVariables.SelectedItem != null)
                {
                    this.openVariable = (SeriesVariable)this.lstVariables.SelectedItem;
                    this.lstVariables.Items.Remove(this.lstVariables.SelectedItem);
                    this.txtOpen.Text = this.openVariable.VariableName;
                    this.cmdOpen.Text = "<";
                }
            }
            else
            {
                int index = this.sourceVariables.IndexOf(this.openVariable);
                
                int indexOnList = Math.Min(index, this.lstVariables.Items.Count - 1);
                if (indexOnList != -1)
                {                    
                    int indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    while (indexOnList < indexCurrList && indexOnList > 0)
                    {
                        indexOnList--;
                        indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    }

                    this.lstVariables.Items.Insert(indexOnList, this.openVariable);
                }
                else
                {
                    this.lstVariables.Items.Add(this.openVariable);
                }
                this.txtOpen.Text = "";
                this.cmdOpen.Text = ">";
                
            }
        
        }

        private void cmdHigh_Click(object sender, EventArgs e)
        {
            if (this.cmdHigh.Text == ">")
            {
                if (this.lstVariables.SelectedItem != null)
                {
                    this.highVariable = (SeriesVariable)this.lstVariables.SelectedItem;
                    this.lstVariables.Items.Remove(this.lstVariables.SelectedItem);
                    this.txtHigh.Text = this.highVariable.VariableName;
                    this.cmdHigh.Text = "<";
                }
            }
            else
            {
                int index = this.sourceVariables.IndexOf(this.highVariable);

                int indexOnList = Math.Min(index, this.lstVariables.Items.Count - 1);
                if (indexOnList != -1)
                {
                    
                    int indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    while (indexOnList < indexCurrList && indexOnList > 0)
                    {
                        indexOnList--;
                        indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    }

                    this.lstVariables.Items.Insert(indexOnList, this.highVariable);
                }
                else
                {
                    this.lstVariables.Items.Add(this.highVariable);
                }
                this.txtHigh.Text = "";
                this.cmdHigh.Text = ">";

            }
        }

        private void cmdLow_Click(object sender, EventArgs e)
        {
            if (this.cmdLow.Text == ">")
            {
                if (this.lstVariables.SelectedItem != null)
                {
                    this.lowVariable = (SeriesVariable)this.lstVariables.SelectedItem;
                    this.lstVariables.Items.Remove(this.lstVariables.SelectedItem);
                    this.txtLow.Text = this.lowVariable.VariableName;
                    this.cmdLow.Text = "<";
                }
            }
            else
            {
                int index = this.sourceVariables.IndexOf(this.lowVariable);

                int indexOnList = Math.Min(index, this.lstVariables.Items.Count - 1);
                if (indexOnList != -1)
                {
                    int indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    while (indexOnList < indexCurrList && indexOnList > 0)
                    {
                        indexOnList--;
                        indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    }

                    this.lstVariables.Items.Insert(indexOnList, this.lowVariable);
                }
                else
                {
                    this.lstVariables.Items.Add(this.lowVariable);
                }
                this.txtLow.Text = "";
                this.cmdLow.Text = ">";

            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (this.cmdClose.Text == ">")
            {
                if (this.lstVariables.SelectedItem != null)
                {
                    this.closeVariable = (SeriesVariable)this.lstVariables.SelectedItem;
                    this.lstVariables.Items.Remove(this.lstVariables.SelectedItem);
                    this.txtClose.Text = this.closeVariable.VariableName;
                    this.cmdClose.Text = "<";
                }
            }
            else
            {
                int index = this.sourceVariables.IndexOf(this.closeVariable);

                int indexOnList = Math.Min(index, this.lstVariables.Items.Count - 1);
                if (indexOnList != -1)
                {
                    int indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    while (indexOnList < indexCurrList && indexOnList > 0)
                    {
                        indexOnList--;
                        indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    }

                    this.lstVariables.Items.Insert(indexOnList, this.closeVariable);
                }
                else
                {
                    this.lstVariables.Items.Add(this.closeVariable);
                }
                this.txtClose.Text = "";
                this.cmdClose.Text = ">";

            }
        }

        private void cmdVolume_Click(object sender, EventArgs e)
        {
            if (this.cmdVolume.Text == ">")
            {
                if (this.lstVariables.SelectedItem != null)
                {
                    this.volumeVariable = (SeriesVariable)this.lstVariables.SelectedItem;
                    this.lstVariables.Items.Remove(this.lstVariables.SelectedItem);
                    this.txtVolume.Text = this.volumeVariable.VariableName;
                    this.cmdVolume.Text = "<";
                }
            }
            else
            {
                int index = this.sourceVariables.IndexOf(this.volumeVariable);

                int indexOnList = Math.Min(index, this.lstVariables.Items.Count - 1);
                if (indexOnList != -1)
                {
                    int indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    while (indexOnList < indexCurrList && indexOnList > 0)
                    {
                        indexOnList--;
                        indexCurrList = this.sourceVariables.IndexOf((SeriesVariable)this.lstVariables.Items[indexOnList]);
                    }

                    this.lstVariables.Items.Insert(indexOnList, this.volumeVariable);
                }
                else
                {
                    this.lstVariables.Items.Add(this.volumeVariable);
                }
                this.txtVolume.Text = "";
                this.cmdVolume.Text = ">";

            }
        }
    }
}