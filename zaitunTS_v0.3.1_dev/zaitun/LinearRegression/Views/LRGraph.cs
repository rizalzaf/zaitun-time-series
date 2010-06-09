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

namespace zaitun.LinearRegression
{
    public partial class LRGraph : UserControl
    {
        #region Fields
        private SeriesData data;

        private string graphTitle;
        private string yTitle;
        private string xTitle;

        private List<CurveProperties> curveItems;
        #endregion

        private struct CurveProperties
        {
            public double[] yData;
            public double[] xData;
            public string label;
            public Color color;
            public SymbolType simbolType;
            public bool isLineVisible;
        }

        #region Constructor
        public LRGraph()
        {
            InitializeComponent();
        }
        #endregion

        #region Procedure Members
        public void SetData(SeriesData data, string graphTitle, 
            string yTitle, string xTitle)
        {
            this.data = data;
            this.graphTitle = graphTitle;
            this.yTitle = yTitle;
            this.xTitle = xTitle;
            this.curveItems = new List<CurveProperties>(); 
        }
        public void UpdateGraph()
        {          

            GraphPane variablePane = this.lrZedGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = graphTitle;
            variablePane.XAxis.Title.Text = xTitle;
            variablePane.YAxis.Title.Text = yTitle;

            if (xTitle == "Time")
            {
                variablePane.XAxis.Type = AxisType.Text;
                variablePane.XAxis.Scale.TextLabels = this.data.Time.ToArray();
            }

            for(int i=0; i<this.curveItems.Count; i++)
            {
                LineItem myCurve = variablePane.AddCurve(curveItems[i].label, curveItems[i].xData, 
                    curveItems[i].yData, curveItems[i].color, curveItems[i].simbolType);

                myCurve.Line.IsVisible = curveItems[i].isLineVisible;
                myCurve.Symbol.Border.IsVisible = false;
                myCurve.Symbol.Fill = new Fill(Color.Red);
                myCurve.Symbol.Size = 5;
            }
            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            lrZedGraph.AxisChange();
        }

        public void AddCurve(string label, double[] xData, double[] yData,
            Color color, SymbolType symbolType, bool isLineVisible)
        {
            CurveProperties item = new CurveProperties();
            item.label = label;
            item.xData = xData;
            item.yData = yData;
            item.color = color;
            item.simbolType = symbolType;
            item.isLineVisible = isLineVisible;
            this.curveItems.Add(item);
        }
        #endregion
    }
}
