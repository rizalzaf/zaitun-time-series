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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.NeuralNetwork
{
    public partial class ANNSelectResultView : Form
    {
        public ANNSelectResultView()
        {
            InitializeComponent();
        }

        private void forecastedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedCheck=((CheckBox)sender).Checked;
            this.forecastingStepTextBox.Enabled = checkedCheck;
            this.actualForecastedGraphCheckBox.Enabled = checkedCheck;
        }

        public bool IsAnnModelSummaryChecked
        {
            get { return this.modelSummaryCheckBox.Checked; }
        }

        public bool IsActualPredictedResidualDataGridChecked
        {
            get { return this.actualPredictedResidualCheckBox.Checked; }
        }

        public bool IsForecastedDataGridChecked
        {
            get { return this.forecastedCheckBox.Checked; }
        }

        public bool IsActualAndPredictedGraphChecked
        {
            get { return this.actualPredictedGraphCheckBox.Checked; }
        }

        public bool IsActualAndForecastedGraphChecked
        {
            get { return this.actualForecastedGraphCheckBox.Checked; }
        }

        public bool IsActualVsPredictedGraphChecked
        {
            get { return this.actualVsPredictedGraphCheckBox.Checked; }
        }

        public bool IsResidualGraphChecked
        {
            get { return this.residualGraphCheckBox.Checked; }
        }

        public bool IsResidualVsActualGraphChecked
        {
            get { return this.residualVsActualGraphCheckBox.Checked; }
        }

        public bool IsResidualVsPredictedGraphChecked
        {
            get { return this.residualVsPredictedCheckBox.Checked; }
        }

        public int ForecastingStep
        {
            get
            {
                int result;
                try { result = int.Parse(forecastingStepTextBox.Text); }
                catch { result = 1; }
                return result;
            }
        }
    }
}