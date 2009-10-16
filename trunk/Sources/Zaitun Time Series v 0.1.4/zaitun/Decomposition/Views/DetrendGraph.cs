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
    public partial class DetrendGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] detrend;

        public DetrendGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] detrend)
        {
            this.variable = variable;
            this.data = data;
            this.detrend = detrend;
            this.update();
        }


        private void update()
        {
            int notIncludedObservation = this.data.NumberObservations - this.detrend.Length;
            double[] detrendToView = new double[this.data.NumberObservations];

            for (int i = 0; i < notIncludedObservation; i++)
                detrendToView[i] = double.NaN;

            for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                detrendToView[i] = this.detrend[i - notIncludedObservation];

            GraphPane variablePane = this.detrendZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Detrend Graph";
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = "Data";
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();

            LineItem myCurve = variablePane.AddCurve("Detrend", null, detrendToView, Color.Blue, SymbolType.Circle);


            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Red);
            myCurve.Symbol.Size = 5;

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            detrendZedGraph.AxisChange();


        }
    }
}
