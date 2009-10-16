using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using zaitun.GUI;
using zaitun.Data;


namespace zaitun.ExponentialSmoothing
{
    public partial class ESSelectResultView : Form
    {

        private int initialModel;

        public ESSelectResultView()
        {
            InitializeComponent();

            this.Text = "Exponential Smoothing Select Result View";            
        }

        public void SetInitialModel(int initialModel)
        {
            this.initialModel = initialModel;
            if (this.initialModel == 1 || this.initialModel == 2)
            {
                this.trendCheckBox.Enabled = false;
                this.SeasonalCheckBox.Enabled = false;

                this.trendCheckBox.Checked = false;
                this.SeasonalCheckBox.Checked = false;
            }

            if (this.initialModel == 3)
            {
                this.SeasonalCheckBox.Enabled = false;
                this.SeasonalCheckBox.Checked = false;
            }
        }

        private void forecastedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkedCheck=((CheckBox)sender).Checked;
            this.forecastingStepTextBox.Enabled = checkedCheck;
            this.actualForecastedGraphCheckBox.Enabled = checkedCheck;
        }

        public bool IsEsModelSummaryChecked
        {
            get { return this.modelSummaryCheckBox.Checked; }
            set { this.modelSummaryCheckBox.Checked = value; }
        }

        public bool IsExponentialSmoothingDataGridChecked
        {
            get { return this.exponentialSmoothingCheckBox.Checked; }
            set { this.exponentialSmoothingCheckBox.Checked = value; }
        }

        public bool IsSmoothingChecked
        {
            get { return this.smoothingCheckBox.Checked; }
            set { this.smoothingCheckBox.Checked = value; }
        }

        public bool IsTrendChecked
        {
            get { return this.trendCheckBox.Checked; }
            set { this.trendCheckBox.Checked = value; }
        }

        public bool IsSeasonalChecked
        {
            get { return this.SeasonalCheckBox.Checked; }
            set { this.SeasonalCheckBox.Checked = value; }
        }

        public bool IsForecastedDataGridChecked
        {
            get { return this.forecastedCheckBox.Checked; }
            set { this.forecastedCheckBox.Checked = value; }
        }

        public bool IsActualAndPredictedGraphChecked
        {
            get { return this.actualPredictedGraphCheckBox.Checked; }
            set { this.actualPredictedGraphCheckBox.Checked = value; }
        }

        public bool IsActualAndSmoothedGraphChecked
        {
            get { return this.actualSmoothedGraphCheckBox.Checked; }
            set { this.actualSmoothedGraphCheckBox.Checked = value; }
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

        private void exponentialSmoothingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.exponentialSmoothingCheckBox.Checked)
            {
                this.smoothingCheckBox.Enabled = true;
                this.actualPredictedAndResidualCheckBox.Checked = true;

                if (initialModel == 1 || this.initialModel == 2)
                {
                    this.trendCheckBox.Enabled = false;
                    this.SeasonalCheckBox.Enabled = false;
                }

                if (initialModel == 3)
                {
                    this.trendCheckBox.Enabled = true;
                    this.SeasonalCheckBox.Enabled = false;
                }

                if (this.initialModel == 4)
                {
                    this.trendCheckBox.Enabled = true;
                    this.SeasonalCheckBox.Enabled = true;
                }
            }
            else
            {
                this.smoothingCheckBox.Enabled = false;
                this.trendCheckBox.Enabled = false;
                this.SeasonalCheckBox.Enabled = false;
                this.actualPredictedAndResidualCheckBox.Checked = false;
            }
        }
    }
}