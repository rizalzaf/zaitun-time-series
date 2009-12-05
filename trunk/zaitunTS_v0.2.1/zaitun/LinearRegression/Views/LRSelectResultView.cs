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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using zaitun.Data;

namespace zaitun.LinearRegression
{
    public partial class LRSelectResultView : Form
    {
        #region Fields
        private SeriesData data;
        private SeriesVariables independentVariables;
        private int forcastingStep;
        private double[,] testValues;
        private string[] time;
        private bool isValuesSet = false;
        #endregion

        #region Constructor
        public LRSelectResultView()
        {
            InitializeComponent();
        }
        #endregion

        #region btnOK
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.chkForcasted.Checked && !isValuesSet)
                MessageBox.Show("Please set values first for forcasting!", "Linear Regression",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region btnCancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region chkCoefficient
        private void chkCoefficient_CheckedChanged(object sender, EventArgs e)
        {
            this.chkConfidenceIntervals.Enabled = this.chkCoefficient.Checked;
            this.chkVIF.Enabled = this.chkCoefficient.Checked;
            this.chkPartialCorrelation.Enabled = this.chkCoefficient.Checked;
        }
        #endregion

        #region chkForcasted
        private void chkForcasted_CheckedChanged(object sender, EventArgs e)
        {
            this.btnSetValues.Enabled = this.chkForcasted.Checked;
            this.forcastingStepTextBox.Enabled = this.chkForcasted.Checked;
        }
        #endregion

        #region btnSetValues
        private void btnSetValues_Click(object sender, EventArgs e)
        {
            LRSetValuesForm frm = new LRSetValuesForm();
            try
            {
                this.forcastingStep = Int32.Parse(this.forcastingStepTextBox.Text);
            }
            catch
            {
                this.forcastingStep = 1;
            }
            frm.ForcastingStep = this.forcastingStep;
            frm.SetData(this.data, this.independentVariables);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                isValuesSet = true;
                this.testValues = frm.TestValues;
                this.time = frm.ForcastedTime;
            }
        }
        #endregion

        #region Procedure Members
        public void SetData(SeriesData data, SeriesVariables independentVariables)
        {
            this.data = data;
            this.independentVariables = independentVariables;
        }
        #endregion

        #region Properties
        public bool IsAnovaTableChecked
        {
            set { this.chkAnova.Checked = value; }
            get { return this.chkAnova.Checked; }
        }
        public bool IsCoefficientTableChecked
        {
            set { this.chkCoefficient.Checked = value; }
            get { return this.chkCoefficient.Checked; }
        }
        public bool IsPartialCorrelationChecked
        {
            set { this.chkPartialCorrelation.Checked = value; }
            get { return this.chkPartialCorrelation.Checked; }
        }
        public bool IsConfidenceIntervalsChecked
        {
            set { this.chkConfidenceIntervals.Checked = value; }
            get { return this.chkConfidenceIntervals.Checked; }
        }
        public bool IsVIFChecked
        {
            set { this.chkVIF.Checked = value; }
            get { return this.chkVIF.Checked; }
        }
        public bool IsDurbinWatsonChecked
        {
            set { this.chkDurbinWatson.Checked = value; }
            get { return this.chkDurbinWatson.Checked; }
        }
        public bool IsForcastedTableChecked
        {
            set { this.chkForcasted.Checked = value; }
            get { return this.chkForcasted.Checked; }
        }
        public bool IsActualPredictedAndResidualChecked
        {
            set { this.chkActualPredictedAndResidual.Checked = value; }
            get { return this.chkActualPredictedAndResidual.Checked; }
        }
        public bool IsResidualVsPredictedGraphChecked
        {
            set { this.chkResidualVsPredictedGraph.Checked = value; }
            get { return this.chkResidualVsPredictedGraph.Checked; }
        }
        public bool IsResidualGraphChecked
        {
            set { this.chkResidualGraph.Checked = value; }
            get { return this.chkResidualGraph.Checked; }
        }
        public bool IsNormalProbabilityPlotChecked
        {
            set { this.chkNPPForResidual.Checked = value; }
            get { return this.chkNPPForResidual.Checked; }
        }
        public bool IsForcastedTableEnabled
        {
            set { this.chkForcasted.Enabled = value; }
        }
        public int ForcastingStep
        {
            get { return this.forcastingStep; }
        }
        public string[] ForcastedTime
        {
            get { return this.time; }
        }
        public double[,] TestValues
        {
            get { return this.testValues; }
        }
        #endregion

    }
}