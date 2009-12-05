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
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using zaitun.Data;

namespace zaitun.GUI
{
    public class StockTabPage : TabPage
    {        
        private zaitun.GUI.StockGraph stockGraph;
        private zaitun.GUI.StockDataGrid stockDataGrid;

        public StockTabPage()
        {
            this.initializeComponent();            
        }

        private void initializeComponent()
        {            
            this.stockGraph = new zaitun.GUI.StockGraph();
            this.stockDataGrid = new zaitun.GUI.StockDataGrid();

            this.SuspendLayout();            
            // 
            // stockGraph
            // 
            this.stockGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockGraph.Location = new System.Drawing.Point(0, 0);
            this.stockGraph.Name = "stockGraph";
            this.stockGraph.Size = new System.Drawing.Size(592, 375);
            this.stockGraph.TabIndex = 1;
            this.stockGraph.Visible = false;
            // 
            // stockDataGrid
            // 
            this.stockDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockDataGrid.Location = new System.Drawing.Point(0, 0);
            this.stockDataGrid.Name = "stockDataGrid";
            this.stockDataGrid.Size = new System.Drawing.Size(592, 375);
            this.stockDataGrid.TabIndex = 2;
            this.stockDataGrid.Visible = false;
            // 
            // StockTabPage
            //             
            this.Controls.Add(this.stockDataGrid);
            this.Controls.Add(this.stockGraph);
            this.Size = new System.Drawing.Size(592, 375);
            this.ResumeLayout(false);            
            this.UseVisualStyleBackColor = true;
        }

        public void SetData(SeriesStock stock, SeriesData data)
        {
            this.stockDataGrid.SetData(stock, data);
            this.stockGraph.SetData(stock, data);            
            this.Text = stock.StockName;
            this.Name = "STOCK " + stock.StockName;
        }

        public void ShowGraph()
        {
            this.stockDataGrid.Visible = false;
            this.stockGraph.Visible = true;            
        }

        public void ShowDataGrid()
        {
            this.stockDataGrid.Visible = true;
            this.stockGraph.Visible = false;            
        }        
    }
}
