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
