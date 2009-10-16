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
    public partial class ActualPredictedAndTrendGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] predicted;
        private double[] trend;

        public ActualPredictedAndTrendGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] predicted, double[] trend)
        {
            this.variable = variable;
            this.data = data;
            this.predicted = predicted;
            this.trend = trend;
            this.update();
        }


        private void update()
        {
            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;
            double[] predictedToView = new double[this.data.NumberObservations];
            double[] trendToView = new double[this.data.NumberObservations];

            for (int i = 0; i < notIncludedObservation; i++)
            {
                predictedToView[i] = double.NaN;
                trendToView[i] = double.NaN;
            }

            for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
            {
                predictedToView[i] = this.predicted[i - notIncludedObservation];
                trendToView[i] = this.trend[i - notIncludedObservation];
            }
        
            GraphPane variablePane = this.actualPredictedAndTrendZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Actual, Predicted and Trend Graph";
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = "Data";
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();

            variablePane.AddCurve("Actual", null, this.variable.SeriesValues.ToArray(), Color.Blue, SymbolType.None);
            variablePane.AddCurve("Predicted", null, predictedToView, Color.Red, SymbolType.None);
            variablePane.AddCurve("Trend", null, trendToView, Color.Green, SymbolType.None);

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            actualPredictedAndTrendZedGraph.AxisChange();


        }
    }
}
