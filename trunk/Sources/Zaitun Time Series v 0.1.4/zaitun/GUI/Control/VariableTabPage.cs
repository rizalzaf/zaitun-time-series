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
