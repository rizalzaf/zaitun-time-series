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
    public partial class VariableViewPane : UserControl
    {
        private SeriesData data;

        public System.Windows.Forms.TabControl VariableViewCollection
        {
            get { return this.variableViewCollection; }
        }

        public VariableViewPane()
        {
            InitializeComponent();         
        }

        public void SetData(SeriesData data)
        {
            this.data = data;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SelectVariableDialog dialog = new SelectVariableDialog(this.data);
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                this.AddTabPage(dialog.SelectedItem);
            }
        }

        public void AddTabPage(SeriesDataList.Item selectedItem)
        {
            if (selectedItem.Type == SeriesDataList.Type.Series)
            {
                string key = "SERIES " + data.SeriesVariables[selectedItem.ListIndex].VariableName;
                if (this.variableViewCollection.TabPages.ContainsKey(key))
                {
                    this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.IndexOfKey(key);
                }
                else
                {
                    VariableTabPage seriesTabPage = new VariableTabPage();
                    seriesTabPage.SetData(data.SeriesVariables[selectedItem.ListIndex], data);
                    seriesTabPage.ShowDataGrid();
                    this.variableViewCollection.TabPages.Add(seriesTabPage);
                    this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.Count - 1;
                }
            }
            else if (selectedItem.Type == SeriesDataList.Type.Group)
            {
                string key = "GROUP " + data.SeriesGroups[selectedItem.ListIndex].GroupName;
                if (this.variableViewCollection.TabPages.ContainsKey(key))
                {
                    this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.IndexOfKey(key);
                }
                else
                {
                    GroupTabPage groupTabPage = new GroupTabPage();
                    groupTabPage.SetData(data.SeriesGroups[selectedItem.ListIndex], data);
                    groupTabPage.ShowDataGrid();
                    this.variableViewCollection.TabPages.Add(groupTabPage);
                    this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.Count - 1;
                }
            }

        }

        /// <summary>
        /// Tambah page. Untuk keperluan open file saja.
        /// </summary>
        /// <param name="key"></param>
        public void AddTabPage(string key)
        {
            string[] temp = key.Split(' ');
            if (temp[0] == "SERIES")
            {                
                VariableTabPage seriesTabPage = new VariableTabPage();
                int listIndex = VariableFinder.FindVariableIndex(data.SeriesVariables,temp[1]);
                seriesTabPage.SetData(data.SeriesVariables[listIndex], data);
                seriesTabPage.ShowDataGrid();
                this.variableViewCollection.TabPages.Add(seriesTabPage);
                this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.Count - 1;                
            }
            else if (temp[0] == "GROUP")
            {
                GroupTabPage groupTabPage = new GroupTabPage();
                int listIndex = GroupFinder.FindGroupIndex(data.SeriesGroups, temp[1]);
                groupTabPage.SetData(data.SeriesGroups[listIndex], data);
                groupTabPage.ShowDataGrid();
                this.variableViewCollection.TabPages.Add(groupTabPage);
                this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.Count - 1;
            }
        }

        public void AddTabPage(string key, int index)
        {
            string[] temp = key.Split(' ');
            if (temp[0] == "SERIES")
            {
                VariableTabPage seriesTabPage = new VariableTabPage();
                int listIndex = VariableFinder.FindVariableIndex(data.SeriesVariables, temp[1]);
                seriesTabPage.SetData(data.SeriesVariables[listIndex], data);
                seriesTabPage.ShowDataGrid();
                this.variableViewCollection.TabPages.Insert(index, seriesTabPage);
                this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.Count - 1;
            }
            else if (temp[0] == "GROUP")
            {
                GroupTabPage groupTabPage = new GroupTabPage();
                int listIndex = GroupFinder.FindGroupIndex(data.SeriesGroups, temp[1]);
                groupTabPage.SetData(data.SeriesGroups[listIndex], data);
                groupTabPage.ShowDataGrid();
                this.variableViewCollection.TabPages.Insert(index, groupTabPage);
                this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.Count - 1;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (this.variableViewCollection.TabPages.Count > 0)
                this.variableViewCollection.TabPages.RemoveAt(this.variableViewCollection.SelectedIndex);
        }

        private void variableViewCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.viewCombo();
        }

        private void viewSeriesCombo()
        {
            cmbSelectView.Items.Clear();
            cmbSelectView.Items.AddRange(new object[] { "Spreadsheet", "Graphic", "Statistics" });
        }

        private void viewGroupCombo()
        {
            cmbSelectView.Items.Clear();
            cmbSelectView.Items.AddRange(new object[] { "Spreadsheet", "Graphic" });
        }

        private void cmbSelectView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.variableViewCollection.SelectedIndex >= 0)
            {
                if (this.variableViewCollection.SelectedTab.Name.Contains("SERIES "))
                {
                    VariableTabPage vtp = (VariableTabPage)this.variableViewCollection.SelectedTab;
                    switch (this.cmbSelectView.SelectedIndex)
                    {
                        case 0: vtp.ShowDataGrid(); break;
                        case 1: vtp.ShowGraph(); break;
                        case 2: vtp.ShowStatistics(); break;
                    }
                }
                else if (this.variableViewCollection.SelectedTab.Name.Contains("GROUP "))
                {
                    GroupTabPage gtp = (GroupTabPage)this.variableViewCollection.SelectedTab;
                    switch (this.cmbSelectView.SelectedIndex)
                    {
                        case 0: gtp.ShowDataGrid(); break;
                        case 1: gtp.ShowGraph(); break;
                    }
                }
            }
        }      

        private void viewCombo()
        {
            if (variableViewCollection.SelectedIndex >= 0 && this.variableViewCollection.SelectedTab != null)
            {
                if (this.variableViewCollection.SelectedTab.Name.Contains("SERIES "))
                {
                    this.viewSeriesCombo();
                }
                else if (this.variableViewCollection.SelectedTab.Name.Contains("GROUP "))
                {
                    this.viewGroupCombo();
                }
            }
        }

        private void variableViewCollection_ControlAdded(object sender, ControlEventArgs e)
        {
            this.viewCombo();
            OnChanged(System.EventArgs.Empty); 
        }

        private void variableViewCollection_ControlRemoved(object sender, ControlEventArgs e)
        {
            OnChanged(System.EventArgs.Empty); 
        }

        #region Event
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(System.EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }       

        private void cmdAddPane_Enter(object sender, EventArgs e)
        {
            this.cmdAdd.BackgroundImage = zaitun.Properties.Resources.button_selected;
            this.panel1.BackgroundImage = zaitun.Properties.Resources.pane_enter;
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdAddPane_Leave(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane1;
            this.cmdAdd.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.pane_enter;
            this.cmdAdd.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane1;
            this.cmdAdd.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
        }

        private void cmdDelete_MouseEnter(object sender, EventArgs e)
        {
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button_selected;
            this.panel1.BackgroundImage = zaitun.Properties.Resources.pane_enter;
            this.cmdAdd.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdDelete_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane1;
            this.cmdAdd.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.variable_view_enter;
            
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.variable_view;
        }

        private void cmbSelectView_MouseEnter(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.variable_view_enter;
        }

        private void cmbSelectView_MouseLeave(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.variable_view;
        }
        #endregion
    }
}
