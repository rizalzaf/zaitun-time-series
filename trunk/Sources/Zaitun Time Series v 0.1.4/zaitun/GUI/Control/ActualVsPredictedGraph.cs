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
    public partial class ActualVsPredictedGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] predicted;

        public ActualVsPredictedGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] predicted)
        {
            this.variable = variable;
            this.data = data;
            this.predicted = predicted;
            this.update();
        }


        private void update()
        {
            double maxActual = double.MinValue, minActual = double.MaxValue, 
                maxPredicted = double.MinValue, minPredicted = double.MaxValue;

            int notIncludedObservation = this.data.NumberObservations - this.predicted.Length;
            double[] actualToView = new double[this.predicted.Length];

            for (int i = 0; i < this.predicted.Length; i++)
                actualToView[i] = this.variable.SeriesValues[i + notIncludedObservation];

            for (int i = 0; i < this.predicted.Length; i++)
            {
                if (actualToView[i] > maxActual) maxActual = actualToView[i];
                if (actualToView[i] < minActual) minActual = actualToView[i];

                if (this.predicted[i] > maxPredicted) maxPredicted = this.predicted[i];
                if (this.predicted[i] < minPredicted) minPredicted = this.predicted[i];
            }

            double minAll = Math.Min(minPredicted, minActual);
            double maxAll = Math.Max(maxPredicted, maxActual);

            double range = maxAll - minAll;

            double[] minMax = new double[2];
            minMax[0] = minAll - 0.2 * range;
            minMax[1] = maxAll + 0.2 * range;

            GraphPane variablePane = this.actualVsPredictedZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Actual vs Predicted Graph";
            variablePane.XAxis.Title.Text = "Actual";
            variablePane.YAxis.Title.Text = "Predicted";


            LineItem myCurve = variablePane.AddCurve("Actual vs Pr edicted", actualToView, this.predicted, Color.Red, SymbolType.Circle);
            LineItem myCurveLine = variablePane.AddCurve("min max", minMax, minMax, Color.Blue, SymbolType.None);

            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Red);
            myCurve.Symbol.Size = 5;
            
            myCurveLine.Label.IsVisible = false;

            variablePane.YAxis.Scale.Min = minAll - 0.2 * range;
            variablePane.YAxis.Scale.Max = maxAll + 0.2 * range;
            variablePane.XAxis.Scale.Min = minAll - 0.2 * range;
            variablePane.XAxis.Scale.Max = maxAll + 0.2 * range;

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            actualVsPredictedZedGraph.AxisChange();


        }
    }
}
