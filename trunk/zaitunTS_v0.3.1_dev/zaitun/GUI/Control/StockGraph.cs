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
using zaitun.GUI;
using ZedGraph;
using zaitun.Data;

namespace zaitun.GUI
{
    public partial class StockGraph : UserControl
    {
        private SeriesStock stock;
        private SeriesData data;
       
        public StockGraph()
        {
            InitializeComponent();            
        }

        public void SetData(SeriesStock stock, SeriesData data)
        {
            this.stock = stock;
            this.data = data;

            this.stock.Changed += new ChangedEventHandler(stock_Changed);
      
            this.update();
        }

        void stock_Changed(object sender, EventArgs e)
        {
            this.update();
        }

        private void update()
        {
            GraphPane variablePane = this.grpGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = this.stock.StockName;
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = this.stock.StockName;
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();

            StockPointList stockList = new StockPointList();

            for (int i = 0; i < this.data.NumberObservations; i++)
            {
                XDate date = new XDate(this.data.XTime[i]);
                StockPt point = new StockPt(date.XLDate, this.stock.High[i], this.stock.Low[i], this.stock.Open[i], this.stock.Close[i], this.stock.Volume[i]);
                stockList.Add(point);
            }

            JapaneseCandleStickItem candle = variablePane.AddJapaneseCandleStick(this.stock.StockName, stockList);

            candle.Stick.RisingFill = new Fill(Color.Blue, Color.LightBlue);
            candle.Stick.FallingFill = new Fill(Color.Red, Color.IndianRed);

            candle.Stick.IsAutoSize = true;
            
            
            
            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            grpGraph.AxisChange();

            zedGraphToolstrip1.SetData(grpGraph, variablePane);
        }
    }
}
