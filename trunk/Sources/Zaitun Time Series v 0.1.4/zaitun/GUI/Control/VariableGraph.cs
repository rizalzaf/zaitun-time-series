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
    public partial class VariableGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        public VariableGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesVariable variable, SeriesData data)
        {
            this.variable = variable;
            this.data = data;
            this.variable.SeriesValues.Changed += new ChangedEventHandler(SeriesValues_Changed);
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

            variablePane.Title.Text = this.variable.VariableDescription;
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = this.variable.VariableName;
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();
            
            variablePane.AddCurve(this.variable.VariableName, null, this.variable.SeriesValues.ToArray(),Color.Blue,SymbolType.None);

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            grpGraph.AxisChange();     
       
            
        }
    }
}
