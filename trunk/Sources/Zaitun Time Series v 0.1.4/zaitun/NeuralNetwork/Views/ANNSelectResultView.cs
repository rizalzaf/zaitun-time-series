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