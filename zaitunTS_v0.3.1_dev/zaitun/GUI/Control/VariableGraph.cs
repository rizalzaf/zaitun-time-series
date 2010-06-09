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
    public partial class VariableGraph : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;

        public VariableGraph()
        {
            InitializeComponent();
        }

        public void SetData(SeriesVariable variable, SeriesData data)
        {
            this.variable = variable;
            this.data = data;
            this.variable.SeriesValues.Changed += new ChangedEventHandler(SeriesValues_Changed);
            this.update();
        }

        void SeriesValues_Changed(object sender, EventArgs e)
        {
            this.update();

        }

        private void update()
        {
            GraphPane variablePane = this.grpGraph.GraphPane;

            variablePane.CurveList.Clear();

            variablePane.Title.Text = this.variable.VariableDescription;
            variablePane.XAxis.Title.Text = "Time";
            variablePane.YAxis.Title.Text = this.variable.VariableName;
            variablePane.XAxis.Type = AxisType.Text;
            variablePane.XAxis.Scale.TextLabels = data.Time.ToArray();
            
            variablePane.AddCurve(this.variable.VariableName, null, this.variable.SeriesValues.ToArray(),Color.Blue,SymbolType.None);

            variablePane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                        Color.FromArgb(255, 255, 190), 90F);
            variablePane.Fill = new Fill(Color.White, Color.LightBlue, 135.0f);

            grpGraph.AxisChange();

            zedGraphToolstrip1.SetData(grpGraph, variablePane);
        }
    }
}
