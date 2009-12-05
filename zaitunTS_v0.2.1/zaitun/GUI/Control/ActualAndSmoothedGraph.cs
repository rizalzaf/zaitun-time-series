// Zaitun Time Series 
// http://www.zaitunsoftware.com/
// http://code.google.com/p/zaitun-time-series/
//
// Copyright ©  2008-2009, Zaitun Time Series Developer Team and individual contributors
//
// Leader: Rizal Zaini Ahmad Fathony (rizalzaf@gmail.com)
// Members: Suryono Hadi Wibowo (ryonoha@gmail.com), Khaerul Anas (anasikova@gmail.com), 
//          Lia Amelia (afifahlia@gmail.com), Almaratul Sholihah, Muhamad Fuad Hasan
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

            zedGraphToolstrip1.SetData(actualAndSmoothedZedGraph, variablePane);
        }
    }
}
