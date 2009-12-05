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
            this.cmdAdd.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane2;
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
            else if (selectedItem.Type == SeriesDataList.Type.Stock)
            {
                string key = "STOCK " + data.SeriesStocks[selectedItem.ListIndex].StockName;
                if (this.variableViewCollection.TabPages.ContainsKey(key))
                {
                    this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.IndexOfKey(key);
                }
                else
                {
                    StockTabPage stockTabPage = new StockTabPage();
                    stockTabPage.SetData(data.SeriesStocks[selectedItem.ListIndex], data);
                    stockTabPage.ShowDataGrid();
                    this.variableViewCollection.TabPages.Add(stockTabPage);
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
                int listIndex = VariableFinder.FindVariableIndex(data.SeriesVariables, temp[1]);
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
            else if (temp[0] == "STOCK")
            {
                StockTabPage stockTabPage = new StockTabPage();
                int listIndex = StockFinder.FindStockIndex(data.SeriesStocks, temp[1]);
                stockTabPage.SetData(data.SeriesStocks[listIndex], data);
                stockTabPage.ShowDataGrid();
                this.variableViewCollection.TabPages.Add(stockTabPage);
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
            else if (temp[0] == "STOCK")
            {
                StockTabPage stockTabPage = new StockTabPage();
                int listIndex = StockFinder.FindStockIndex(data.SeriesStocks, temp[1]);
                stockTabPage.SetData(data.SeriesStocks[listIndex], data);
                stockTabPage.ShowDataGrid();
                this.variableViewCollection.TabPages.Insert(index, stockTabPage);
                this.variableViewCollection.SelectedIndex = this.variableViewCollection.TabPages.Count - 1;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane2;
            if (this.variableViewCollection.TabPages.Count > 0)
                this.variableViewCollection.TabPages.RemoveAt(this.variableViewCollection.SelectedIndex);
        }

        private void variableViewCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editButton();
        }

        private void editButton()
        {
            if (variableViewCollection.SelectedIndex >= 0 && this.variableViewCollection.SelectedTab != null)
            {
                if (this.variableViewCollection.SelectedTab.Name.Contains("SERIES "))
                {
                    this.cmdSpreadSheet.Enabled = true;
                    this.cmdGraphic.Enabled = true;
                    this.cmdStatistics.Enabled = true;
                }
                else if (this.variableViewCollection.SelectedTab.Name.Contains("GROUP "))
                {
                    this.cmdSpreadSheet.Enabled = true;
                    this.cmdGraphic.Enabled = true;
                    this.cmdStatistics.Enabled = false;
                }
                else if (this.variableViewCollection.SelectedTab.Name.Contains("STOCK "))
                {
                    this.cmdSpreadSheet.Enabled = true;
                    this.cmdGraphic.Enabled = true;
                    this.cmdStatistics.Enabled = false;
                }
            }
            else
            {
                this.cmdSpreadSheet.Enabled = false;
                this.cmdGraphic.Enabled = false;
                this.cmdStatistics.Enabled = false;
            }
        }

        private void variableViewCollection_ControlAdded(object sender, ControlEventArgs e)
        {
            this.editButton();
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
            this.cmdAdd.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane;
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane_New_Enter;
            //this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdAddPane_Leave(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane_New;
            this.cmdAdd.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane_New_Enter;
            //this.cmdAdd.BackgroundImage = zaitun.Properties.Resources.button3;
            //this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane_New;
            this.cmdAdd.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
        }

        private void cmdDelete_MouseEnter(object sender, EventArgs e)
        {
            this.cmdDelete.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane;
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane_New_Enter;
            //this.cmdAdd.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdDelete_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = zaitun.Properties.Resources.Pane_New;
            this.cmdAdd.BackgroundImage = null;
            this.cmdDelete.BackgroundImage = null;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New_Enter;
            //this.cmdGraphic.BackgroundImage = zaitun.Properties.Resources.button3;
            //this.cmdSpreadSheet.BackgroundImage = zaitun.Properties.Resources.button3;
            //this.cmdStatistics.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New;
            this.cmdGraphic.BackgroundImage = null;
            this.cmdSpreadSheet.BackgroundImage = null;
            this.cmdStatistics.BackgroundImage = null;
        }
                
        private void cmdGraphic_Click(object sender, EventArgs e)
        {
            this.cmdGraphic.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane2;
            if (this.variableViewCollection.SelectedTab.Name.Contains("SERIES "))
            {
                VariableTabPage vtp = (VariableTabPage)this.variableViewCollection.SelectedTab;
                vtp.ShowGraph();
            }
            else if (this.variableViewCollection.SelectedTab.Name.Contains("GROUP "))
            {
                GroupTabPage gtp = (GroupTabPage)this.variableViewCollection.SelectedTab;
                gtp.ShowGraph();

            }
            else if (this.variableViewCollection.SelectedTab.Name.Contains("STOCK "))
            {
                StockTabPage stp = (StockTabPage)this.variableViewCollection.SelectedTab;
                stp.ShowGraph();
            }
        }

        private void cmdStatistics_Click(object sender, EventArgs e)
        {
            this.cmdStatistics.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane2;
            if (this.variableViewCollection.SelectedTab.Name.Contains("SERIES "))
            {
                VariableTabPage vtp = (VariableTabPage)this.variableViewCollection.SelectedTab;
                vtp.ShowStatistics();
            }
        }

        private void cmdSpreadsheet_Click(object sender, EventArgs e)
        {
            this.cmdSpreadSheet.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane2;
            if (this.variableViewCollection.SelectedTab.Name.Contains("SERIES "))
            {
                VariableTabPage vtp = (VariableTabPage)this.variableViewCollection.SelectedTab;
                vtp.ShowDataGrid();
            }
            else if (this.variableViewCollection.SelectedTab.Name.Contains("GROUP "))
            {
                GroupTabPage gtp = (GroupTabPage)this.variableViewCollection.SelectedTab;
                gtp.ShowDataGrid();
            }
            else if (this.variableViewCollection.SelectedTab.Name.Contains("STOCK "))
            {
                StockTabPage stp = (StockTabPage)this.variableViewCollection.SelectedTab;
                stp.ShowDataGrid();
            }
        }

        private void cmdSpreadsheet_Enter(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New_Enter;
            //this.cmdGraphic.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdSpreadSheet.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane;
            //this.cmdStatistics.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdSpreadsheet_Leave(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New_Enter;
            this.cmdGraphic.BackgroundImage = null;
            this.cmdSpreadSheet.BackgroundImage = null;
            this.cmdStatistics.BackgroundImage = null;
        }

        private void cmdStatistics_Enter(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New_Enter;
            //this.cmdGraphic.BackgroundImage = zaitun.Properties.Resources.button3;
            //this.cmdSpreadSheet.BackgroundImage = zaitun.Properties.Resources.button3;
            this.cmdStatistics.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane;
        }

        private void cmdStatistics_Leave(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New_Enter;
            this.cmdGraphic.BackgroundImage = null;
            this.cmdSpreadSheet.BackgroundImage = null;
            this.cmdStatistics.BackgroundImage = null;
        }

        private void cmdGraphic_Enter(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New_Enter;
            this.cmdGraphic.BackgroundImage = zaitun.Properties.Resources.button_selected_view_pane;
            //this.cmdSpreadSheet.BackgroundImage = zaitun.Properties.Resources.button3;
            //this.cmdStatistics.BackgroundImage = zaitun.Properties.Resources.button3;
        }

        private void cmdGraphic_Leave(object sender, EventArgs e)
        {
            this.panel2.BackgroundImage = zaitun.Properties.Resources.Variable_View_New_Enter;
            this.cmdGraphic.BackgroundImage = null;
            this.cmdSpreadSheet.BackgroundImage = null;
            this.cmdStatistics.BackgroundImage = null;
        }

        #endregion

        private void variableViewCollection_Enter(object sender, EventArgs e)
        {
            this.editButton();
        }

    }
}
