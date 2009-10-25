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
