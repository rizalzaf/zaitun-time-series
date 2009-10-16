using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zaitun.Decomposition
{
    public partial class DecompositionSelectResultView : Form
    {
        public DecompositionSelectResultView()
        {
            InitializeComponent();
            this.Text = "Decomposition Select Result View";
        }

        private void forecastedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedCheck=((CheckBox)sender).Checked;
            this.forecastingStepTextBox.Enabled = checkedCheck;
            this.actualForecastedGraphCheckBox.Enabled = checkedCheck;
        }

        public bool IsDecModelSummaryChecked
        {
            get { return this.modelSummaryCheckBox.Checked; }
            set { this.modelSummaryCheckBox.Checked = value; }
        }

        public bool IsDecompositionDataGridChecked
        {
            get { return this.decompositionCheckBox.Checked; }
            set { this.decompositionCheckBox.Checked = value; }
        }

        public bool IsTrendChecked
        {
            get { return this.trendCheckBox.Checked; }
            set { this.trendCheckBox.Checked = value; }
        }

        public bool IsDetrendChecked
        {
            get { return this.detrendCheckBox.Checked; }
            set { this.detrendCheckBox.Checked = value; }
        }

        public bool IsSeasonalChecked
        {
            get { return this.seasonalCheckBox.Checked; }
            set { this.seasonalCheckBox.Checked = value; }
        }

        public bool IsDeseasonalChecked
        {
            get { return this.deseasonalCheckBox.Checked; }
            set { this.deseasonalCheckBox.Checked = value; }
        }

        public bool IsForecastedDataGridChecked
        {
            get { return this.forecastedCheckBox.Checked; }
            set { this.forecastedCheckBox.Checked = value; }
        }

        public bool IsActualPredictedAndTrendGraphChecked
        {
            get { return this.actualPredictedTrendGraphCheckBox.Checked; }
            set { this.actualPredictedTrendGraphCheckBox.Checked = value; }
        }

        public bool IsActualAndForecastedGraphChecked
        {
            get { return this.actualForecastedGraphCheckBox.Checked; }
            set { this.actualForecastedGraphCheckBox.Checked = value; }
        }

        public bool IsActualVsPredictedGraphChecked
        {
            get { return this.actualVsPredictedGraphCheckBox.Checked; }
            set { this.actualVsPredictedGraphCheckBox.Checked = value; }
        }

        public bool IsResidualGraphChecked
        {
            get { return this.residualGraphCheckBox.Checked; }
            set { this.residualGraphCheckBox.Checked = value; }
        }

        public bool IsResidualVsActualGraphChecked
        {
            get { return this.residualVsActualGraphCheckBox.Checked; }
            set { this.residualVsActualGraphCheckBox.Checked = value; }
        }

        public bool IsResidualVsPredictedGraphChecked
        {
            get { return this.residualVsPredictedCheckBox.Checked; }
            set { this.residualVsPredictedCheckBox.Checked = value; }
        }

        public bool IsDetrendGraphChecked
        {
            get { return this.detrendGraphCheckBox.Checked; }
            set { this.detrendGraphCheckBox.Checked = value; }
        }

        public bool IsDeseasonalGraphChecked
        {
            get { return this.deseasonalGraphCheckBox.Checked; }
            set { this.deseasonalGraphCheckBox.Checked = value; }
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
            set
            {
                if (value > 0)
                {
                    this.forecastingStepTextBox.Text = value.ToString();
                }
            }
        }
    }
}