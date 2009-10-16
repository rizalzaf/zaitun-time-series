using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.GUI
{
    public class GroupTabPage : TabPage
    {        
        private zaitun.GUI.GroupGraph groupGraph;
        private zaitun.GUI.GroupDataGrid groupDataGrid;

        public GroupTabPage()
        {
            this.initializeComponent();            
        }

        private void initializeComponent()
        {            
            this.groupGraph = new zaitun.GUI.GroupGraph();
            this.groupDataGrid = new zaitun.GUI.GroupDataGrid();

            this.SuspendLayout();            
            // 
            // groupGraph
            // 
            this.groupGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGraph.Location = new System.Drawing.Point(0, 0);
            this.groupGraph.Name = "groupGraph";
            this.groupGraph.Size = new System.Drawing.Size(592, 375);
            this.groupGraph.TabIndex = 1;
            this.groupGraph.Visible = false;
            // 
            // groupDataGrid
            // 
            this.groupDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDataGrid.Location = new System.Drawing.Point(0, 0);
            this.groupDataGrid.Name = "groupDataGrid";
            this.groupDataGrid.Size = new System.Drawing.Size(592, 375);
            this.groupDataGrid.TabIndex = 2;
            this.groupDataGrid.Visible = false;
            // 
            // GroupTabPage
            //             
            this.Controls.Add(this.groupDataGrid);
            this.Controls.Add(this.groupGraph);
            this.Size = new System.Drawing.Size(592, 375);
            this.ResumeLayout(false);            
            this.UseVisualStyleBackColor = true;
        }

        public void SetData(SeriesGroup group, SeriesData data)
        {
            this.groupDataGrid.SetData(group, data);
            this.groupGraph.SetData(group, data);            
            this.Text = group.GroupName;
            this.Name = "GROUP " + group.GroupName;
        }

        public void ShowGraph()
        {
            this.groupDataGrid.Visible = false;
            this.groupGraph.Visible = true;            
        }

        public void ShowDataGrid()
        {
            this.groupDataGrid.Visible = true;
            this.groupGraph.Visible = false;            
        }        
    }
}
