// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Core Programmer: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Programmer: Suryono Hadi Wibowo, Khaerul Anas, Almaratul Sholihah, Muhamad Fuad Hasan
//
// This is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as
// published by the Free Software Foundation; either version 3 of
// the License, or (at your option) any later version.
//
// This software is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public
// License along with this software; if not, write to the Free
// Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301 USA, or see the FSF site: http://www.fsf.org.

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
