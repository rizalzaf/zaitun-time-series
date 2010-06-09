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
using zaitun.Data;

namespace zaitun.NeuralNetwork
{
    public partial class ANNModelSummary : UserControl
    {
        private SeriesVariable variable;
        private SeriesData data;
        private NeuralNetworkAnalysisForm.NetworkSpecification networkProperties;        

        public ANNModelSummary()
        {
            InitializeComponent();
            grdModelSummary.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;            
        }

        public void SetData(SeriesData data, SeriesVariable variable, NeuralNetworkAnalysisForm.NetworkSpecification networkProperties)
        {
            this.data = data;
            this.variable = variable;
            this.networkProperties = networkProperties;
            this.lblVariable.Text = variable.VariableName;            
            this.update();
        }

        private void update()
        {            
            grdModelSummary.RowCount = 18;
            grdModelSummary.Rows[0].HeaderCell.Value = "Variable";
            grdModelSummary.Rows[0].Cells[0].Value = this.variable.VariableName;
            grdModelSummary.Rows[1].HeaderCell.Value = "Included Observation";
            grdModelSummary.Rows[1].Cells[0].Value = this.networkProperties.IncludedObservations + " (After Adjusting Endpoints)";
            
            grdModelSummary.Rows[3].HeaderCell.Value = "Network Archiecture";            
            grdModelSummary.Rows[4].HeaderCell.Value = "Input Layer Neurons";
            grdModelSummary.Rows[4].Cells[0].Value = this.networkProperties.InputLayerNeurons;
            grdModelSummary.Rows[5].HeaderCell.Value = "Hidden Layer Neurons";
            grdModelSummary.Rows[5].Cells[0].Value = this.networkProperties.HiddenLayerNeurons;
            grdModelSummary.Rows[6].HeaderCell.Value = "Output Layer Neurons";
            grdModelSummary.Rows[6].Cells[0].Value = this.networkProperties.OutputLayerNeurons;
            grdModelSummary.Rows[7].HeaderCell.Value = "Activation Function";
            grdModelSummary.Rows[7].Cells[0].Value = this.networkProperties.ActivationFunction.ToString();
                        
            grdModelSummary.Rows[9].HeaderCell.Value = "Back Propagation Learning";           
            grdModelSummary.Rows[10].HeaderCell.Value = "Learning Rate";
            grdModelSummary.Rows[10].Cells[0].Value = this.networkProperties.LearningRate.ToString();
            grdModelSummary.Rows[11].HeaderCell.Value = "Momentum";
            grdModelSummary.Rows[11].Cells[0].Value = this.networkProperties.Momentum.ToString();

            grdModelSummary.Rows[13].HeaderCell.Value = "Criteria";
            grdModelSummary.Rows[14].HeaderCell.Value = "Error";
            grdModelSummary.Rows[14].Cells[0].Value = this.networkProperties.Error.ToString("F6");
            grdModelSummary.Rows[15].HeaderCell.Value = "MSE";
            grdModelSummary.Rows[15].Cells[0].Value = this.networkProperties.MSE.ToString("F6");
            grdModelSummary.Rows[16].HeaderCell.Value = "MAE";
            grdModelSummary.Rows[16].Cells[0].Value = this.networkProperties.MAE.ToString("F6");


        }      
        
    }
}
