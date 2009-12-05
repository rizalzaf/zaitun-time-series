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
    public partial class SeriesDataList : UserControl
    {        
        private SeriesData data;
        private SeriesDataList.Item selectedItem;

        public enum Type
        {
            Series,
            Group,
            Stock
        }

        public struct Item
        {
            public Type Type; 
            public int ListIndex;
        }

        public SeriesDataList()
        {
            InitializeComponent();            
        }

        public void SetData(SeriesData data)
        {
            this.data = data;
            this.data.Changed += new ChangedEventHandler(data_Changed);
            this.update();
        }

        void data_Changed(object sender, EventArgs e)
        {
            this.update();
        }

        private void update()
        {
            this.lstSeriesData.Items.Clear();     
            this.lstSeriesData.SuspendLayout();
            foreach (SeriesVariable item in data.SeriesVariables)
            {
                ListViewItem listItem = new ListViewItem(item.VariableName, lstSeriesData.Groups[0]);                
                listItem.SubItems.Add("Series");
                listItem.SubItems.Add(item.VariableDescription);
                lstSeriesData.Items.Add(listItem);                
            }
            foreach (SeriesGroup item in data.SeriesGroups)
            {
                ListViewItem listItem = new ListViewItem(item.GroupName, lstSeriesData.Groups[1]);                
                listItem.SubItems.Add("Group");
                string desc = "Group of";
                foreach (SeriesVariable descItem in item.GroupList)
                {
                    desc += " " + descItem.VariableName + ",";
                }                
                listItem.SubItems.Add(desc.Substring(0,desc.Length-1));
                lstSeriesData.Items.Add(listItem);                
            }
            foreach (SeriesStock item in data.SeriesStocks)
            {
                ListViewItem listItem = new ListViewItem(item.StockName, lstSeriesData.Groups[2]);                
                listItem.SubItems.Add("Stock");
                listItem.SubItems.Add(item.StockDescription);
                lstSeriesData.Items.Add(listItem);
            }            
            this.lstSeriesData.Sort();
            this.lstSeriesData.ResumeLayout();
        }        

        private void lstSeriesData_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);            
        }       

        public SeriesDataList.Item SelectedItem
        {
            get
            {
                if (lstSeriesData.SelectedIndices.Count > 0)
                {
                    selectedItem = new SeriesDataList.Item();

                    int index = lstSeriesData.SelectedIndices[0];
                    switch (lstSeriesData.Items[index].SubItems[1].Text)
                    {
                        case "Series":
                            selectedItem.Type = Type.Series;
                            {
                                selectedItem.ListIndex = VariableFinder.FindVariableIndex(this.data.SeriesVariables, lstSeriesData.Items[index].Text);
                            }
                            break;
                        case "Group":
                            selectedItem.Type = Type.Group;
                            {
                                selectedItem.ListIndex = GroupFinder.FindGroupIndex(this.data.SeriesGroups, lstSeriesData.Items[index].Text);
                            }
                            break;
                        case "Stock":
                            selectedItem.Type = Type.Stock;
                            {
                                selectedItem.ListIndex = StockFinder.FindStockIndex(this.data.SeriesStocks, lstSeriesData.Items[index].Text);
                            }
                            break;
                    }
                }
                else
                {
                    this.selectedItem.Type = Type.Series;
                    this.selectedItem.ListIndex = -1;
                }
                return selectedItem;
            }
        }
    }
}
