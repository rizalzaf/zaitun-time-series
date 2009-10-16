using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using zaitun.Data;
using ZedGraph;

namespace zaitun.Decomposition
{
    public partial class DeseasonalGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] deseasonal;

        public DeseasonalGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] deseasonal)
        {
            this.variable = variable;
            this.data = data;
            this.deseasonal = deseasonal;
            this.update();
        }


        private void update()
        {
            int notIncludedObservation = this.data.NumberObservations - this.deseasonal.Length;
            double[] deseasonalToView = new double[this.data.NumberObservations];

            for (int i = 0; i < notIncludedObservation; i++)
                deseasonalToView[i] = double.NaN;

            for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                deseasonalToView[i] = this.deseasonal[i - notIncludedObservation];

            GraphPane variablePane = this.deseasonalZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Deseasonal Graph";
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = "Data";
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();

            LineItem myCurve = variablePane.AddCurve("Deseasonal", null, deseasonalToView, Color.Blue, SymbolType.Circle);


            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Red);
            myCurve.Symbol.Size = 5;

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            deseasonalZedGraph.AxisChange();


        }
    }
}
