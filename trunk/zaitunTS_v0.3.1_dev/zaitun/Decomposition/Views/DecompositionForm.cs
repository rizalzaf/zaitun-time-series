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
using zaitun.MatrixVector;

namespace zaitun.Decomposition
{
    public partial class DecompositionForm : Form
    {
        private DecompositionClassic dec;
        private SeriesVariable variable;
        private DECSpecification decProperties;
        private DECComponent decTable;

        private bool isStoreTrend = false;
        private bool isStoreDetrend = false;
        private bool isStoreDeseasonal = false;
        private bool isStorePredicted = false;
        private bool isStoreResidual = false;
        private string trendName = "";
        private string detrendName = "";
        private string deseasonalName = "";
        private string predictedName = "";
        private string residualName = "";

        private bool isDecModelSummaryChecked = true;
        private bool isDecompositionDataGridChecked = true;
        private bool isTrendChecked = true;
        private bool isDetrendChecked = true;
        private bool isSeasonalChecked = false;
        private bool isDeseasonalChecked = false;
        private bool isForecastedDataGridChecked = false;
        private bool isActualPredictedAndTrendGraphChecked = true;        
        private bool isActualAndForecastedGraphChecked = false;
        private bool isActualVsPredictedGraphChecked = false;
        private bool isResidualGraphChecked = false;
        private bool isResidualVsActualGraphChecked = false;
        private bool isResidualVsPredictedGraphChecked = false;
        private bool isDetrendGraphChecked = true;
        private bool isDeseasonalGraphChecked = false;
        private int forecastingStep = 0;

        /// <summary>
        /// Struct: properti data dan ukuran kesalahan
        /// </summary>
        public struct DECSpecification
        {
            public int includedObservations;
            public int seasonalLength;
            public double[] parameters;
            public double[] seasonalIdx;
            public bool isMultiplikatif;
            public int initialTrend;
            public double sseDEC;
            public double mseDEC;
            public double maeDEC;
            public double mpeDEC;
            public double mapeDEC;
        }

        /// <summary>
        /// Struct: Hasil penghitungan dekomposisi
        /// </summary>
        public struct DECComponent
        {
            public double[] trend;
            public double[] detrend;
            public double[] seasonal;
            public double[] deseasonal;
            public double[] predicted;
            public double[] residual;
        }

        /// <summary>
        /// Constructor. Decomposition Form
        /// </summary>
        public DecompositionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mengeset variabel yang telah dipilih
        /// </summary>
        /// <param name="variable">SeriesVariable. variable</param>
        public void SetVariable(SeriesVariable variable)
        {
            this.variable = variable;

            this.decProperties.seasonalLength = 2;

            this.Text = "Decomposition : " + variable.VariableName;

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip2 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip2.AutoPopDelay = 500000000;
            toolTip2.InitialDelay = 100;
            toolTip2.ReshowDelay = 1;
            //Force the ToolTip text to be displayed whether or not the form is active.
            toolTip2.ShowAlways = true;

            toolTip2.SetToolTip(this.SeasonalLengthBox, "SEASONAL LENGTH:\nThe length of one seasonal cycle\n\n" 
                + "RANGE:\nPossible seasonal length range for '" 
                + this.variable.VariableName + "' are 2 to " + this.variable.SeriesValuesNoNaN.Count / 2);
            toolTip2.SetToolTip(this.groupBox1, "SEASONAL LENGTH:\nThe length of one seasonal cycle\n\n"
                + "RANGE:\nPossible seasonal length range for '"
                + this.variable.VariableName + "' are 2 to " + this.variable.SeriesValuesNoNaN.Count / 2);

            this.UpdateSettings();
        }

        /// <summary>
        /// Menampilkan default nilai panjang musimaan
        /// </summary>
        private void UpdateSettings()
        {
            this.SeasonalLengthBox.Text = this.decProperties.seasonalLength.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.SeasonalLengthBox.Text == "")
            {
                MessageBox.Show("Please insert seasonal length", "Incorrect seasonal length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (int.Parse(this.SeasonalLengthBox.Text) < 2)
            {
                MessageBox.Show("The length of the seasonal is too small.", "Incorrect seasonal length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else if (int.Parse(this.SeasonalLengthBox.Text) > this.variable.SeriesValuesNoNaN.Count / 2)
            {
                MessageBox.Show("The length of the seasonal is too large.", "Incorrect seasonal length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else
                this.decProperties.seasonalLength = int.Parse(this.SeasonalLengthBox.Text);

            if (this.multiplikativeRdb.Checked)
                this.decProperties.isMultiplikatif = true;
            else if(this.additiveRdb.Checked)
                this.decProperties.isMultiplikatif = false;

            if (this.trendComboBox.Text == "Linear")
                this.decProperties.initialTrend = 1;
            else if (this.trendComboBox.Text == "Quadratic")
                this.decProperties.initialTrend = 2;
            else if (this.trendComboBox.Text == "Cubic")
                this.decProperties.initialTrend = 3;
            else if (this.trendComboBox.Text == "Exponential")
                this.decProperties.initialTrend = 4;           

            this.EstimateParameters();
        }

        private void EstimateParameters()
        {
            dec = new DecompositionClassic(this.variable, this.decProperties.seasonalLength, 
                this.decProperties.isMultiplikatif, this.decProperties.initialTrend);
            this.decProperties.includedObservations = dec.IncludedObservations;
            this.decProperties.sseDEC = dec.SSE;
            this.decProperties.mseDEC = dec.MSE;
            this.decProperties.maeDEC = dec.MAE;
            this.decProperties.mpeDEC = dec.MPE;
            this.decProperties.mapeDEC = dec.MAPE;
            this.decProperties.parameters = dec.Parameters;
            this.decProperties.seasonalIdx = dec.seasonalFactor();

            this.decTable.trend = dec.Trend;
            this.decTable.detrend = dec.Detrend;
            this.decTable.seasonal = dec.Seasonal;
            this.decTable.deseasonal = dec.Deseasonal;
            this.decTable.predicted = dec.Predicted;
            this.decTable.residual = dec.Residual;
        }

        public DECSpecification DecProperties
        {
            get { return this.decProperties; }
        }

        public DECComponent DecTable
        {
            get { return this.decTable; }
        }

        public bool IsMultiplikatif
        {
            get { return this.decProperties.isMultiplikatif; }
        }

        public double[] Forecast(int step)
        {
            return this.dec.Forecast(step);
        }

        public bool IsStoreTrend
        {
            get { return this.isStoreTrend; }
        }

        public bool IsStoreDetrend
        {
            get { return this.isStoreDetrend; }
        }

        public bool IsStoreDeseasonal
        {
            get { return this.isStoreDeseasonal; }
        }

        public bool IsStorePredicted
        {
            get { return this.isStorePredicted; }
        }

        public bool IsStoreResidual
        {
            get { return this.isStoreResidual; }
        }

        public string TrendName
        {
            get { return this.trendName; }
        }

        public string DetrendName
        {
            get { return this.detrendName; }
        }

        public string DeseasonalName
        {
            get { return this.deseasonalName; }
        }

        public string PredictedName
        {
            get { return this.predictedName; }
        }

        public string ResidualName
        {
            get { return this.residualName; }
        }

        public bool IsDecModelSummaryChecked
        {
            get { return this.isDecModelSummaryChecked; }            
        }

        public bool IsDecompositionDataGridChecked
        {
            get { return this.isDecompositionDataGridChecked; }            
        }

        public bool IsTrendChecked
        {
            get { return this.isTrendChecked; }            
        }

        public bool IsDetrendChecked
        {
            get { return this.isDetrendChecked; }
        }

        public bool IsSeasonalChecked
        {
            get { return this.isSeasonalChecked; }
        }

        public bool IsDeseasonalChecked
        {
            get { return this.isDeseasonalChecked; }
        }

        public bool IsForecastedDataGridChecked
        {
            get { return this.isForecastedDataGridChecked; }
        }

        public bool IsActualPredictedAndTrendGraphChecked
        {
            get { return this.isActualPredictedAndTrendGraphChecked; }
        }
                
        public bool IsActualAndForecastedGraphChecked
        {
            get { return this.isActualAndForecastedGraphChecked; }
        }

        public bool IsActualVsPredictedGraphChecked
        {
            get { return this.isActualVsPredictedGraphChecked; }
        }

        public bool IsResidualGraphChecked
        {
            get { return this.isResidualGraphChecked; }
        }

        public bool IsResidualVsActualGraphChecked
        {
            get { return this.isResidualVsActualGraphChecked; }
        }

        public bool IsResidualVsPredictedGraphChecked
        {
            get { return this.isResidualVsPredictedGraphChecked; }
        }

        public bool IsDetrendGraphChecked
        {
            get { return this.isDetrendGraphChecked; }
        }

        public bool IsDeseasonalGraphChecked
        {
            get { return this.isDeseasonalGraphChecked; }
        }

        public int ForecastingStep
        {
            get { return this.forecastingStep; }
        }

        private void DecompositionForm_Load(object sender, EventArgs e)
        {
            if (this.variable.SeriesValuesNoNaN.Count < 4)
            {
                MessageBox.Show("Unsufficent number of observations", "Moving Average", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            this.trendComboBox.SelectedIndex = 0;

            //// Create the ToolTip and associate with the Form container.
            //ToolTip toolTip1 = new ToolTip();

            //// Set up the delays for the ToolTip.
            //toolTip1.AutoPopDelay = 500000000;
            //toolTip1.InitialDelay = 100;
            //toolTip1.ReshowDelay = 1;
            ////Force the ToolTip text to be displayed whether or not the form is active.
            //toolTip1.ShowAlways = true;

            //// Set up the ToolTip text for the Button and Checkbox.
            ////toolTip1.SetToolTip(this, "Note: Select method and input the parameters for analysis");
            //toolTip1.SetToolTip(this.okButton, "Click here to continue");
            //toolTip1.SetToolTip(this.cancelButton, "Click here to cancel");
            //toolTip1.SetToolTip(this.groupBox2, "Choose the model type to use");
            //toolTip1.SetToolTip(this.multiplikativeRdb, "MULTIPLICATIVE Model:\nUse when the size of the seasonal pattern depends\n"
            //    + "on the level of the data. This model assumes that as\nthe data increase, so does the seasonal pattern.\n"
            //    + "The trend and seasonal components are\nmultiplied and then added to the error component.\n\n"
            //    + "Click here to use the multiplicative model");
            //toolTip1.SetToolTip(this.additiveRdb, "ADDITIVE Model:\nUse when the size of the seasonal\npattern does not depend on the level of\n"
            //    + "the data. In this model, the trend,\nseasonal, and error components are added.\n\n"
            //    + "Click here to use the additive model");
            //toolTip1.SetToolTip(this.groupBox4, "TREND MODEL:\nSelect the model that you want.\nChoose among the linear, quadratic, exponential growth");
            //toolTip1.SetToolTip(this.trendComboBox, "TREND MODEL:\nDrop down this list to choose trend model");
            //toolTip1.SetToolTip(this.isStorePredictedCheckBox, "Click here to store the predicted");
            //toolTip1.SetToolTip(this.predictedNameBox, "Type the name of variable predicted");
            //toolTip1.SetToolTip(this.isStoreResidualCheckBox, "Click here to store the residual");
            //toolTip1.SetToolTip(this.residualNameBox, "Type the name of variable residual");
        }

        private void storageButton_Click(object sender, EventArgs e)
        {
            DecompositionStorageForm storage = new DecompositionStorageForm();

            // sending current value
            storage.IsStorePredicted = this.isStorePredicted;
            storage.IsStoreResidual = this.isStoreResidual;
            storage.IsStoreTrend = this.isStoreTrend;
            storage.IsStoreDetrend = this.isStoreDetrend;
            storage.IsStoreDeseasonal = this.isStoreDeseasonal;
            storage.PredictedName = this.predictedName;
            storage.ResidualName = this.residualName;
            storage.TrendName = this.trendName;
            storage.DetrendName = this.detrendName;
            storage.DeseasonalName = this.deseasonalName;

            storage.ShowDialog();
            if (storage.DialogResult == DialogResult.OK)
            {
                //accepting selected value
                this.isStorePredicted = storage.IsStorePredicted;
                this.isStoreResidual = storage.IsStoreResidual;
                this.isStoreTrend = storage.IsStoreTrend;
                this.isStoreDetrend = storage.IsStoreDetrend;
                this.isStoreDeseasonal = storage.IsStoreDeseasonal;
                this.predictedName = storage.PredictedName;
                this.residualName = storage.ResidualName;
                this.trendName = storage.TrendName;
                this.detrendName = storage.DetrendName;
                this.deseasonalName = storage.DeseasonalName;
            }
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            DecompositionSelectResultView result = new DecompositionSelectResultView();

            // sending current value
            result.IsDecModelSummaryChecked = this.isDecModelSummaryChecked;
            result.IsDecompositionDataGridChecked = this.isDecompositionDataGridChecked;
            result.IsTrendChecked = this.isTrendChecked;
            result.IsDetrendChecked = this.isDetrendChecked;
            result.IsSeasonalChecked = this.isSeasonalChecked;
            result.IsDeseasonalChecked = this.isDeseasonalChecked;
            result.IsForecastedDataGridChecked = this.isForecastedDataGridChecked;
            result.IsActualPredictedAndTrendGraphChecked = this.isActualPredictedAndTrendGraphChecked;            
            result.IsActualAndForecastedGraphChecked = this.isActualAndForecastedGraphChecked;
            result.IsActualVsPredictedGraphChecked = this.isActualVsPredictedGraphChecked;
            result.IsResidualGraphChecked = this.isResidualGraphChecked;
            result.IsResidualVsActualGraphChecked = this.isResidualVsActualGraphChecked;
            result.IsResidualVsPredictedGraphChecked = this.isResidualVsPredictedGraphChecked;
            result.IsDetrendGraphChecked = this.isDetrendGraphChecked;
            result.IsDeseasonalGraphChecked = this.isDeseasonalGraphChecked;
            result.ForecastingStep = this.forecastingStep;

            result.ShowDialog();
            if (result.DialogResult == DialogResult.OK)
            {
                //accepting selected value
                this.isDecModelSummaryChecked = result.IsDecModelSummaryChecked;
                this.isDecompositionDataGridChecked = result.IsDecompositionDataGridChecked;
                this.isTrendChecked = result.IsTrendChecked;
                this.isDetrendChecked = result.IsDetrendChecked;
                this.isSeasonalChecked = result.IsSeasonalChecked;
                this.isDeseasonalChecked = result.IsDeseasonalChecked;
                this.isForecastedDataGridChecked = result.IsForecastedDataGridChecked;
                this.isActualPredictedAndTrendGraphChecked = result.IsActualPredictedAndTrendGraphChecked;                
                this.isActualAndForecastedGraphChecked = result.IsActualAndForecastedGraphChecked;
                this.isActualVsPredictedGraphChecked = result.IsActualVsPredictedGraphChecked;
                this.isResidualGraphChecked = result.IsResidualGraphChecked;
                this.isResidualVsActualGraphChecked = result.IsResidualVsActualGraphChecked;
                this.isResidualVsPredictedGraphChecked = result.IsResidualVsPredictedGraphChecked;
                this.isDetrendGraphChecked = result.IsDetrendGraphChecked;
                this.isDeseasonalGraphChecked = result.IsDeseasonalGraphChecked;
                this.forecastingStep = result.ForecastingStep;

           }
        }
    }
}