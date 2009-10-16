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
    public partial class ResidualGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        private double[] residual;

        public ResidualGraph()
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
            double[] residualToView = new double[this.data.NumberObservations];

            for (int i = 0; i < notIncludedObservation; i++)
                residualToView[i] = double.NaN;

            for (int i = notIncludedObservation; i < this.data.NumberObservations; i++)
                residualToView[i] = this.residual[i - notIncludedObservation];

            GraphPane variablePane = this.residualZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = "Residual Graph";
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = "Residual";
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();

            LineItem myCurve = variablePane.AddCurve("Residual", null, residualToView, Color.Blue, SymbolType.Circle);            

        
            myCurve.Symbol.Border.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Red);
            myCurve.Symbol.Size = 5;

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            residualZedGraph.AxisChange();


        }
    }
}
