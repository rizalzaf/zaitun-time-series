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
    public partial class ActualAndSmoothedGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] smoothed;
        //private double[] forecasted;

        public ActualAndSmoothedGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesData data, SeriesVariable variable, double[] smoothed)
        {
            this.variable = variable;
            this.data = data;
            this.smoothed = smoothed;
            //this.forecasted = forecasted;
            this.update();
        }


        private void update()
        {
            //int totalDataToView = this.data.NumberObservations + this.forecasted.Length;
            int notIncludedObservation = this.data.NumberObservations - this.smoothed.Length;

            double[] smoothedToView = new double[this.data.NumberObservations];

            //double[] actualToView = new double[totalDataToView];
            //double[] smoothedToView = new double[totalDataToView];
            //double[] forecastedToView = new double[totalDataToView];

            for (int i = 0; i < notIncludedObservation; i++)
                smoothedToView[i] = double.NaN;

            //for (int i = 0; i < this.data.NumberObservations; i++)
            //{
            //    actualToView[i] = this.variable.SeriesValues[i];
            //    smoothedToView[i] = this.smoothed[i];
            //    forecastedToView[i] = double.NaN;
            //}

            for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                smoothedToView[i] = this.smoothed[i - notIncludedObservation];
            
            //for (int i = 0; i < this.forecasted.Length; i++)
            //{
            //    actualToView[i + this.data.NumberObservations] = double.NaN;
            //    smoothedToView[i + this.data.NumberObservations] = double.NaN;
            //    forecastedToView[i + this.data.NumberObservations] = this.forecasted[i];
            //}

            GraphPane variablePane = this.actualAndSmoothedZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Actual and Smoothed Graph";
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = "Data";
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();

            variablePane.AddCurve("Actual", null, this.variable.SeriesValues.ToArray(), Color.Blue, SymbolType.None);
            //variablePane.AddCurve("Actual", null, actualToView, Color.Blue, SymbolType.None);
            variablePane.AddCurve("Smoothed", null, smoothedToView, Color.Red, SymbolType.None);
            //variablePane.AddCurve("Forecasted", null, forecastedToView, Color.Green, SymbolType.None);

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            actualAndSmoothedZedGraph.AxisChange();


        }
    }
}
