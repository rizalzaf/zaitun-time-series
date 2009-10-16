using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using ZedGraph;
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class GroupGraph : UserControl
    {
        private SeriesGroup group;
        private SeriesData data;

        private static Color[] colorCollection = new Color[] {Color.Blue, Color.Red, Color.Green, Color.Yellow,
                Color.Cyan, Color.Magenta, Color.Khaki, Color.LawnGreen, Color.LightGray};

        public GroupGraph()
        {
            InitializeComponent();            
        }

        public void SetData(SeriesGroup group, SeriesData data)
        {
            this.group = group;
            this.data = data;
            foreach (SeriesVariable var in this.group.GroupList)
            {
                var.SeriesValues.Changed += new ChangedEventHandler(SeriesValues_Changed);
            }            
            this.update();
        }

        void SeriesValues_Changed(object sender, EventArgs e)
        {
            this.update();
        }

        private void update()
        {
            GraphPane variablePane = this.grpGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Group from";
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = this.group.GroupName;
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();

            for (int i = 0; i < group.GroupList.Count; i++)
            {
                variablePane.Title.Text += " " + this.group.GroupList[i].VariableName + ",";
                variablePane.AddCurve(this.group.GroupList[i].VariableName, null, this.group.GroupList[i].SeriesValues.ToArray(), colorCollection[i % colorCollection.Length],SymbolType.None);
            }
            variablePane.Title.Text = variablePane.Title.Text.Substring(variablePane.Title.Text.Length - 1);

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            grpGraph.AxisChange();            
        }
    }
}
