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
    public class VariableTabPage : TabPage
    {
        private zaitun.GUI.VariableStatistics variableStatistics;
        private zaitun.GUI.VariableGraph variableGraph;
        private zaitun.GUI.VariableDataGrid variableDataGrid;

        public VariableTabPage()
        {
            this.initializeComponent();
        }

        private void initializeComponent()
        {
            this.variableStatistics = new zaitun.GUI.VariableStatistics();
            this.variableGraph = new zaitun.GUI.VariableGraph();
            this.variableDataGrid = new zaitun.GUI.VariableDataGrid();

            this.SuspendLayout();
            // 
            // variableStatistics
            // 
            this.variableStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableStatistics.Location = new System.Drawing.Point(0, 0);
            this.variableStatistics.Name = "variableStatistics";
            this.variableStatistics.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.variableStatistics.Size = new System.Drawing.Size(592, 375);
            this.variableStatistics.TabIndex = 0;
            this.variableStatistics.Visible = false;
            // 
            // variableGraph
            // 
            this.variableGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableGraph.Location = new System.Drawing.Point(0, 0);
            this.variableGraph.Name = "variableGraph";
            this.variableGraph.Size = new System.Drawing.Size(592, 375);
            this.variableGraph.TabIndex = 1;
            this.variableGraph.Visible = false;
            // 
            // variableDataGrid
            // 
            this.variableDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableDataGrid.Location = new System.Drawing.Point(0, 0);
            this.variableDataGrid.Name = "variableDataGrid";
            this.variableDataGrid.Size = new System.Drawing.Size(592, 375);
            this.variableDataGrid.TabIndex = 2;
            this.variableDataGrid.Visible = false;
            // 
            // VariableTabPage
            //             
            this.Controls.Add(this.variableDataGrid);
            this.Controls.Add(this.variableGraph);
            this.Controls.Add(this.variableStatistics);            
            this.Size = new System.Drawing.Size(592, 375);
            this.ResumeLayout(false);            
            this.UseVisualStyleBackColor = true;
        }

        public void SetData(SeriesVariable variable, SeriesData data)
        {
            this.variableDataGrid.SetData(variable, data);
            this.variableGraph.SetData(variable, data);
            this.variableStatistics.SetData(variable, data);
            this.Text = variable.VariableName;
            this.Name = "SERIES " + variable.VariableName;
        }

        public void ShowGraph()
        {
            this.variableDataGrid.Visible = false;
            this.variableGraph.Visible = true;
            this.variableStatistics.Visible = false;
        }

        public void ShowDataGrid()
        {
            this.variableDataGrid.Visible = true;
            this.variableGraph.Visible = false;
            this.variableStatistics.Visible = false;
        }

        public void ShowStatistics()
        {
            this.variableDataGrid.Visible = false;
            this.variableGraph.Visible = false;
            this.variableStatistics.Visible = true;
        }
    }
}
