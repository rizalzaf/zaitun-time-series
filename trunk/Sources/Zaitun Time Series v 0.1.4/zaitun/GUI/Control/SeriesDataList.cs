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
        private SeriesVariables sourceVariables;
        private SeriesGroups sourceGroups;
        private SeriesDataList.Item selectedItem;

        public enum Type
        {
            Series,
            Group
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

        public void SetData(SeriesVariables sourceVariables, SeriesGroups sourceGroups)
        {
            this.sourceVariables = sourceVariables;
            this.sourceGroups = sourceGroups;
            this.sourceVariables.Changed += new ChangedEventHandler(sourceVariables_Changed);
            this.sourceGroups.Changed += new ChangedEventHandler(sourceGroups_Changed);
            this.update();
        }

        private void update()
        {
            this.lstSeriesData.Items.Clear();     
            this.lstSeriesData.SuspendLayout();
            foreach (SeriesVariable item in sourceVariables)
            {
                ListViewItem listItem = new ListViewItem(item.VariableName, lstSeriesData.Groups[0]);
                //listItem.SubItems.Add(item.VariableName);
                listItem.SubItems.Add("Series");
                listItem.SubItems.Add(item.VariableDescription);
                lstSeriesData.Items.Add(listItem);                
            }
            foreach (SeriesGroup item in sourceGroups)
            {
                ListViewItem listItem = new ListViewItem(item.GroupName, lstSeriesData.Groups[1]);
                //listItem.SubItems.Add(item.GroupName);
                listItem.SubItems.Add("Group");
                string desc = "Group of";
                foreach (SeriesVariable descItem in item.GroupList)
                {
                    desc += " " + descItem.VariableName + ",";
                }                
                listItem.SubItems.Add(desc.Substring(0,desc.Length-1));
                lstSeriesData.Items.Add(listItem);                
            }            
            this.lstSeriesData.Sort();
            this.lstSeriesData.ResumeLayout();
        }        

        private void sourceGroups_Changed(object sender, EventArgs e)
        {
            this.update();
        }

        private void sourceVariables_Changed(object sender, EventArgs e)
        {
            this.update();
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
                                selectedItem.ListIndex = VariableFinder.FindVariableIndex(sourceVariables, lstSeriesData.Items[index].Text);
                            }
                            break;
                        case "Group":
                            selectedItem.Type = Type.Group;
                            {
                                selectedItem.ListIndex = GroupFinder.FindGroupIndex(sourceGroups, lstSeriesData.Items[index].Text);
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
