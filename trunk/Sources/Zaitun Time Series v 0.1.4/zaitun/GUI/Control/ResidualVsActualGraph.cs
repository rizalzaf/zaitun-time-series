using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using zaitun.Data;
using ZedGraph;

namespace zaitun.GUI
{
    public partial class ResidualVsActualGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] residual;

        public ResidualVsActualGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] residual)
        {
            this.variable = variable;
            this.data = data;
            this.residual = residual;
            this.update();
        }


        private void update()
        {
            int notIncludedObservation = this.data.NumberObservations - this.residual.Length;
            double[] actualToView = new double[this.residual.Length];
           
            for (int i = 0 ; i < this.residual.Length; i++)
                actualToView[i] = this.variable.SeriesValues[i + notIncludedObservation];

            GraphPane variablePane = this.residualVsActualZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Residual vs Actual Graph";
            variablePane.XAxis.Title.Text = "Actual";
            variablePane.YAxis.Title.Text = "Residual";
            

            LineItem myCurve = variablePane.AddCurve("Residual vs Actual", actualToView, this.residual, Color.Red, SymbolType.Circle);

            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Red);
            myCurve.Symbol.Size = 5;

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            residualVsActualZedGraph.AxisChange();


        }
    }
}
