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
using zaitun.GUI;
using zaitun.Data;
using zaitun.MatrixVector;

namespace zaitun.ExponentialSmoothing
{
    public partial class ExponentialSmoothingForm : Form
    {
        private SingleExponentialSmoothing ses;
        private DoubleExponentialSmoothingBrown brown;
        private DoubleExponentialSmoothingHolt holt;
        private TripleExponentialSmoothingWinter winter;
        private SeriesVariable variable;
        private ESSpecification esProperties;
        private ESComponent esTable;

        private bool isStoreSmoothed = false;
        private bool isStorePredicted = false;
        private bool isStoreResidual = false;
        private string smoothedName = "";
        private string predictedName = "";
        private string residualName = "";

        private bool isEsModelSummaryChecked = true;
        private bool isExponentialSmoothingDataGridChecked = true;
        private bool isSmoothingChecked = true;
        private bool isTrendChecked = true;
        private bool isSeasonalChecked = true;
        private bool isForecastedDataGridChecked = false;
        private bool isActualAndPredictedGraphChecked = true;
        private bool isActualAndSmoothedGraphChecked = false;
        private bool isActualAndForecastedGraphChecked = false;
        private bool isActualVsPredictedGraphChecked = false;
        private bool isResidualGraphChecked = true;
        private bool isResidualVsActualGraphChecked = false;
        private bool isResidualVsPredictedGraphChecked = false;
        private int forecastingStep = 0;

        private int singleInitialSmoothed = 6;

        /// <summary>
        /// Struct: properti data dan ukuran kesalahan
        /// </summary>
        public struct ESSpecification
        {
            public int includedObservations;
            public double alpha;
            public double gamma;
            public double beta;
            public int seasonalLength;
            public int initialModel;
            public bool isMultiplicative;
            public double sseES;
            public double mseES;
            public double maeES;
            public double mpeES;
            public double mapeES;
        }

        /// <summary>
        /// Struct: hasil penghitungan pemulusan eksponensial
        /// </summary>
        public struct ESComponent
        {
            public double[] smoothed;
            public double[] trend;
            public double[] seasonal;
            public double[] predicted;
            public double[] residual;
        }

        /// <summary>
        /// Constructor: Exponential Smoothing Form
        /// </summary>
        public ExponentialSmoothingForm()
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
            this.esProperties.alpha = 0.2;
            this.esProperties.gamma = 0.2;
            this.esProperties.beta = 0.2;
            this.esProperties.seasonalLength = 2;
            this.esProperties.isMultiplicative = true;
            this.Text = "Exponential Smoothing : " + variable.VariableName;
            
            this.UpdateSettings();
        }

        /// <summary>
        /// Menampilkan default nilai-nilai parameter
        /// </summary>
        private void UpdateSettings()
        {
            this.seasonalBox.Text = this.esProperties.seasonalLength.ToString();
            this.alpha.Text = this.esProperties.alpha.ToString();
            this.gamma.Text = this.esProperties.gamma.ToString();
            this.beta.Text = this.esProperties.beta.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.alpha.Enabled)
            {
                if (this.alpha.Text == "")
                {
                    MessageBox.Show("Please insert smoothing constant for data", "Incorrect Alpha Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
                else if (double.Parse(this.alpha.Text) < 0 || double.Parse(this.alpha.Text) > 1)
                {
                    MessageBox.Show("Incorrect smoothing constant for data", "Alpha Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Alpha Range are 0 to 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
                else if (this.gamma.Enabled)
                {
                    if (this.gamma.Text == "")
                    {
                        MessageBox.Show("Please insert smoothing constant for trend", "Incorrect Gamma value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (double.Parse(this.gamma.Text) < 0 || double.Parse(this.gamma.Text) > 1)
                    {
                        MessageBox.Show("Incorrect smoothing constant for trend", "Gamma Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("Gamma Range are 0 to 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (this.beta.Enabled)
                    {
                        if (this.beta.Text == "")
                        {
                            MessageBox.Show("Please insert smoothing constant for seasonal", "Incorrect Beta value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.None;
                        }
                        else if (double.Parse(this.beta.Text) < 0 || double.Parse(this.beta.Text) > 1)
                        {
                            MessageBox.Show("Incorrect smoothing constant for seasonal", "Beta Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("Beta Range are 0 to 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else if (this.seasonalBox.Enabled)
                        {
                            if (this.seasonalBox.Text == "")
                            {
                                MessageBox.Show("Please insert seasonal length", "Incorrect seasonal length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                            }
                            else if (int.Parse(this.seasonalBox.Text) < 2)
                            {
                                MessageBox.Show("The length of the seasonal is too small.", "Incorrect seasonal length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show("Seasonal length range for " + this.variable.VariableName + " are 2 to " + this.variable.SeriesValuesNoNaN.Count / 2, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                            }
                            else if (int.Parse(this.seasonalBox.Text) > this.variable.SeriesValuesNoNaN.Count / 2)
                            {
                                MessageBox.Show("The length of the seasonal is too large.", "Incorrect seasonal length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show("Seasonal length range for " + this.variable.VariableName + " are 2 to " + this.variable.SeriesValuesNoNaN.Count / 2, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                            }

                            else
                                this.EstimateParameters();
                        }
                        else
                            this.EstimateParameters();
                    }
                    else
                        this.EstimateParameters();
                }

                else
                    this.EstimateParameters();
            }
        }

        /// <summary>
        /// Mengestimasi parameter
        /// </summary>
        private void EstimateParameters()
        {
            if (this.sesRdb.Checked == true)
            {
                if (this.variable.SeriesValuesNoNaN.Count < 7)
                {
                    MessageBox.Show("Unsufficent number of observations", "Exponential Smoothing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                //get alpha
                try { this.esProperties.alpha = double.Parse(this.alpha.Text); }
                catch { this.esProperties.alpha = 0.2; }

                this.esProperties.initialModel = 1;
                ses = new SingleExponentialSmoothing(this.variable, this.esProperties.alpha,this.singleInitialSmoothed);
                
                this.esTable.smoothed = ses.Smoothed;
                this.esTable.predicted = ses.Predicted;
                this.esTable.residual = ses.Residual;

                this.esProperties.includedObservations = ses.IncludedObservations;
                this.esProperties.sseES = ses.SSE;
                this.esProperties.mseES = ses.MSE;
                this.esProperties.maeES = ses.MAE;
                this.esProperties.mpeES = ses.MPE;
                this.esProperties.mapeES = ses.MAPE;
            }

            else if (this.brownRdb.Checked == true)
            {
                //get alpha
                try { this.esProperties.alpha = double.Parse(this.alpha.Text); }
                catch { this.esProperties.alpha = 0.2; }

                this.esProperties.initialModel = 2;
                brown = new DoubleExponentialSmoothingBrown(this.variable, this.esProperties.alpha);

                this.esTable.smoothed = brown.Smoothed;
                this.esTable.predicted = brown.Predicted;
                this.esTable.residual = brown.Residual;

                this.esProperties.includedObservations = brown.IncludedObservations;
                this.esProperties.sseES = brown.SSE;
                this.esProperties.mseES = brown.MSE;
                this.esProperties.maeES = brown.MAE;
                this.esProperties.mpeES = brown.MPE;
                this.esProperties.mapeES = brown.MAPE;
            }

            else if (this.holtRdb.Checked == true)
            {
                //get alpha
                try { this.esProperties.alpha = double.Parse(this.alpha.Text); }
                catch { this.esProperties.alpha = 0.2; }
                //get gamma
                try { this.esProperties.gamma = double.Parse(this.gamma.Text); }
                catch { this.esProperties.gamma = 0.2; }

                this.esProperties.initialModel = 3;

                holt = new DoubleExponentialSmoothingHolt(this.variable, this.esProperties.alpha, this.esProperties.gamma);

                this.esTable.smoothed = holt.Smoothed;
                this.esTable.trend = holt.Trend;
                this.esTable.predicted = holt.Predicted;
                this.esTable.residual = holt.Residual;

                this.esProperties.includedObservations = holt.IncludedObservations;
                this.esProperties.sseES = holt.SSE;
                this.esProperties.mseES = holt.MSE;
                this.esProperties.maeES = holt.MAE;
                this.esProperties.mpeES = holt.MPE;
                this.esProperties.mapeES = holt.MAPE;
            }

            else if (this.winterRdb.Checked == true)
            {
                if (this.variable.SeriesValuesNoNaN.Count < 4)
                {
                    MessageBox.Show("Unsufficent number of observations", "Exponential Smoothing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                //get alpha
                try { this.esProperties.alpha = double.Parse(this.alpha.Text); }
                catch { this.esProperties.alpha = 0.2; }
                //get gamma
                try { this.esProperties.gamma = double.Parse(this.gamma.Text); }
                catch { this.esProperties.gamma = 0.2; }
                //get beta
                try { this.esProperties.beta = double.Parse(this.beta.Text); }
                catch { this.esProperties.beta = 0.2; }

                //get seasonal length
                try { this.esProperties.seasonalLength = int.Parse(this.seasonalBox.Text); }
                catch { this.esProperties.seasonalLength = 2; }

                this.esProperties.initialModel = 4;
                winter = new TripleExponentialSmoothingWinter(this.variable, this.esProperties.alpha, this.esProperties.gamma, this.esProperties.beta, this.esProperties.seasonalLength, this.esProperties.isMultiplicative);

                this.esTable.smoothed = winter.Smoothed;
                this.esTable.trend = winter.Trend;
                this.esTable.seasonal = winter.Seasonal;
                this.esTable.predicted = winter.Predicted;
                this.esTable.residual = winter.Residual;

                this.esProperties.includedObservations = winter.IncludedObservations;
                this.esProperties.sseES = winter.SSE;
                this.esProperties.mseES = winter.MSE;
                this.esProperties.maeES = winter.MAE;
                this.esProperties.mpeES = winter.MPE;
                this.esProperties.mapeES = winter.MAPE;
            }
        }

        private void sesRdb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sesRdb.Checked == true)
            {
                this.optionsButton.Enabled = true;
            }
            else
            {
                this.optionsButton.Enabled = false;
            }
        }

        private void brownRdb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.brownRdb.Checked == true)
            {
                this.alphaLbl.Enabled = true;
                this.levelLbl.Enabled = true;
                this.alpha.Enabled = true;
            }
        }

        private void holtRdb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.holtRdb.Checked == true)
            {
                this.gammaLbl.Enabled = true;
                this.trendLbl.Enabled = true;
                this.gamma.Enabled = true;
            }
            else
            {
                this.gammaLbl.Enabled = false;
                this.trendLbl.Enabled = false;
                this.gamma.Enabled = false;
            }
        }

        private void winterRdb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.winterRdb.Checked == true)
            {
                this.seasonalLbl.Enabled = true;
                this.seasonalBox.Enabled = true;
                this.gammaLbl.Enabled = true;
                this.trendLbl.Enabled = true;
                this.gamma.Enabled = true;
                this.betaLbl.Enabled = true;
                this.slengthLbl.Enabled = true;
                this.beta.Enabled = true;
                this.mtpRdb.Enabled = true;
                this.adtRdb.Enabled = true;
            }
            else
            {
                this.seasonalLbl.Enabled = false;
                this.seasonalBox.Enabled = false;
                this.gammaLbl.Enabled = false;
                this.trendLbl.Enabled = false;
                this.gamma.Enabled = false;
                this.betaLbl.Enabled = false;
                this.slengthLbl.Enabled = false;
                this.beta.Enabled = false;
                this.mtpRdb.Enabled = false;
                this.adtRdb.Enabled = false;
            }
        }

        #region Properties
        /// <summary>
        /// Mengirimkan semua parameter yang ada dalam ESSpecification
        /// </summary>
        public ESSpecification EsProperties
        {
            get { return this.esProperties; }
        }

        /// <summary>
        /// Mengirimkan semua parameter yang ada dalam ESComponent
        /// </summary>
        public ESComponent EsTable
        {
            get { return this.esTable; }
        }

        /// <summary>
        /// Mendapatkan nilai hasil peramalan
        /// untuk metode pemulusan eksponensial tunggal
        /// </summary>
        /// <param name="step">Integer. Step: banyaknya periode yang akan diramalkan</param>
        /// <returns>ArrayDouble. Nilai peramalan untuk 'step' periode ke muka</returns>
        public double[] SesForecast(int step)
        {
            return this.ses.Forecast(step);
        }

        /// <summary>
        /// Mendapatkan nilai hasil peramalan
        /// untuk metode pemulusan eksponensial ganda dengan metode Brown
        /// </summary>
        /// <param name="step">Integer. Step: banyaknya periode yang akan diramalkan</param>
        /// <returns>ArrayDouble. Nilai peramalan untuk 'step' periode ke muka</returns>
        public double[] BrownForecast(int step)
        {
            return this.brown.Forecast(step);
        }

        /// <summary>
        /// Mendapatkan nilai hasil peramalan
        /// untuk metode pemulusan eksponensial ganda dengan metode Holt
        /// </summary>
        /// <param name="step">Integer. Step: banyaknya periode yang akan diramalkan</param>
        /// <returns>ArrayDouble. Nilai peramalan untuk 'step' periode ke muka</returns>
        public double[] HoltForecast(int step)
        {
            return this.holt.Forecast(step);
        }

        /// <summary>
        /// Mendapatkan nilai hasil peramalan
        /// untuk metode pemulusan eksponensial tripel dengan metode Winter
        /// </summary>
        /// <param name="step">Integer. Step: banyaknya periode yang akan diramalkan</param>
        /// <returns>ArrayDouble. Nilai peramalan untuk 'step' periode ke muka</returns>
        public double[] WinterForecast(int step)
        {
            return this.winter.Forecast(step);
        }

        /// <summary>
        /// Menentukan apakah nilai pemulusan akan ditambahkan sebagai variabel baru
        /// </summary>
        public bool IsStoreSmoothed
        {
            get { return this.isStoreSmoothed; }
        }

        /// <summary>
        /// Menentukan apakah prediksi akan ditambahkan sebagai variabel baru
        /// </summary>
        public bool IsStorePredicted
        {
            get { return this.isStorePredicted; }
        }

        /// <summary>
        /// Menentukan apakah residual akan ditambahkan sebagai variabel baru
        /// </summary>
        public bool IsStoreResidual
        {
            get { return this.isStoreResidual; }
        }

        /// <summary>
        /// Mendapatkan nama variabel baru pemulusan
        /// </summary>
        public string SmoothedName
        {
            get { return this.smoothedName; }
        }

        /// <summary>
        /// Mendapatkan nama variabel baru prediksi
        /// </summary>
        public string PredictedName
        {
            get { return this.predictedName; }
        }

        /// <summary>
        /// Mendapatkan nama variabel baru residual
        /// </summary>
        public string ResidualName
        {
            get { return this.residualName; }
        }

        public bool IsEsModelSummaryChecked
        {
            get { return this.isEsModelSummaryChecked; }
        }

        public bool IsExponentialSmoothingDataGridChecked
        {
            get { return this.isExponentialSmoothingDataGridChecked; }
        }

        public bool IsSmoothingChecked
        {
            get { return this.isSmoothingChecked; }
        }

        public bool IsTrendChecked
        {
            get { return this.isTrendChecked; }
        }

        public bool IsSeasonalChecked
        {
            get { return this.isSeasonalChecked; }
        }

        public bool IsForecastedDataGridChecked
        {
            get { return this.isForecastedDataGridChecked; }
        }

        public bool IsActualAndPredictedGraphChecked
        {
            get { return this.isActualAndPredictedGraphChecked; }
        }

        public bool IsActualAndSmoothedGraphChecked
        {
            get { return this.isActualAndSmoothedGraphChecked; }
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

        public int ForecastingStep
        {
            get { return this.forecastingStep; }
        }

        #endregion

        private void gridSearchButton_Click(object sender, EventArgs e)
        {
            if (this.sesRdb.Checked)
            {
                SingleESGridSearch ses = new SingleESGridSearch();
                ses.SetVariable(this.variable);
                ses.ShowDialog();
                if (ses.DialogResult == DialogResult.OK)
                    this.alpha.Text = ses.SelectedAlpha.ToString();
            }
            else if (this.brownRdb.Checked)
            {
                DoubleESBrownGridSearch des = new DoubleESBrownGridSearch();
                des.SetVariable(this.variable);
                des.ShowDialog();
                if (des.DialogResult == DialogResult.OK)
                    this.alpha.Text = des.SelectedAlpha.ToString();
            }
            else if (this.holtRdb.Checked)
            {
                DoubleESHoltGridSearch des = new DoubleESHoltGridSearch();
                des.SetVariable(this.variable);
                des.ShowDialog();
                if (des.DialogResult == DialogResult.OK)
                {
                    this.alpha.Text = des.SelectedAlpha.ToString();
                    this.gamma.Text = des.SelectedGamma.ToString();
                }
            }
            else if (this.winterRdb.Checked)
            {
                //get seasonal length
                try { this.esProperties.seasonalLength = int.Parse(this.seasonalBox.Text); }
                catch { this.esProperties.seasonalLength = 2; }

                TripleESWinterGridSearch tes = new TripleESWinterGridSearch();
                tes.SetVariable(this.variable, this.esProperties.seasonalLength, this.esProperties.isMultiplicative);
                tes.ShowDialog();
                if (tes.DialogResult == DialogResult.OK)
                {
                    this.alpha.Text = tes.SelectedAlpha.ToString();
                    this.gamma.Text = tes.SelectedGamma.ToString();
                    this.beta.Text = tes.SelectedBeta.ToString();
                }
            }
        }

        private void adtRdb_CheckedChanged(object sender, EventArgs e)
        {
            this.esProperties.isMultiplicative = false;
        }

        private void mtpRdb_CheckedChanged(object sender, EventArgs e)
        {
            this.esProperties.isMultiplicative = true;
        }        

        private void ExponentialSmoothingForm_Load(object sender, EventArgs e)
        {
            if (this.variable.SeriesValuesNoNaN.Count < 3)
            {
                MessageBox.Show("Unsufficent number of observations", "Exponential Smoothing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            } 
        }

        private void storageButton_Click(object sender, EventArgs e)
        {
            ESStorageForm storage = new ESStorageForm();

            // sending current value
            storage.IsStoreSmoothed = this.isStoreSmoothed;
            storage.IsStorePredicted = this.isStorePredicted;
            storage.IsStoreResidual = this.isStoreResidual;
            storage.SmoothedName = this.smoothedName;
            storage.PredictedName = this.predictedName;
            storage.ResidualName = this.residualName;

            storage.ShowDialog();
            if (storage.DialogResult == DialogResult.OK)
            {
                //accepting selected value
                this.isStoreSmoothed = storage.IsStoreSmoothed;
                this.isStorePredicted = storage.IsStorePredicted;
                this.isStoreResidual = storage.IsStoreResidual;
                this.smoothedName = storage.SmoothedName;
                this.predictedName = storage.PredictedName;
                this.residualName = storage.ResidualName;
            }
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            int initialModel = 1;
            if (this.sesRdb.Checked == true)
                initialModel = 1;
            else if (this.brownRdb.Checked == true)
                initialModel = 2;
            else if (this.holtRdb.Checked == true)
                initialModel = 3;
            else if (this.winterRdb.Checked == true)
                initialModel = 4;

            ESSelectResultView result = new ESSelectResultView();

            // sending current value
            result.IsEsModelSummaryChecked = this.isEsModelSummaryChecked;
            result.IsExponentialSmoothingDataGridChecked = this.isExponentialSmoothingDataGridChecked;
            result.IsSmoothingChecked = this.isSmoothingChecked;
            result.IsTrendChecked = this.isTrendChecked;
            result.IsSeasonalChecked = this.isSeasonalChecked;            
            result.IsForecastedDataGridChecked = this.isForecastedDataGridChecked;
            result.IsActualAndPredictedGraphChecked = this.isActualAndPredictedGraphChecked;
            result.IsActualAndSmoothedGraphChecked = this.isActualAndSmoothedGraphChecked;
            result.IsActualAndForecastedGraphChecked = this.isActualAndForecastedGraphChecked;
            result.IsActualVsPredictedGraphChecked = this.isActualVsPredictedGraphChecked;
            result.IsResidualGraphChecked = this.isResidualGraphChecked;
            result.IsResidualVsActualGraphChecked = this.isResidualVsActualGraphChecked;
            result.IsResidualVsPredictedGraphChecked = this.isResidualVsPredictedGraphChecked;
            result.ForecastingStep = this.forecastingStep;

            result.SetInitialModel(initialModel);

            result.ShowDialog();
            if (result.DialogResult == DialogResult.OK)
            {
                //accepting selected value
                this.isEsModelSummaryChecked = result.IsEsModelSummaryChecked;
                this.isExponentialSmoothingDataGridChecked = result.IsExponentialSmoothingDataGridChecked;
                this.isSmoothingChecked = result.IsSmoothingChecked;
                this.isTrendChecked = result.IsTrendChecked;
                this.isSeasonalChecked = result.IsSeasonalChecked;                                  
                this.isForecastedDataGridChecked = result.IsForecastedDataGridChecked;
                this.isActualAndPredictedGraphChecked = result.IsActualAndPredictedGraphChecked;
                this.isActualAndSmoothedGraphChecked = result.IsActualAndSmoothedGraphChecked;
                this.isActualAndForecastedGraphChecked = result.IsActualAndForecastedGraphChecked;
                this.isActualVsPredictedGraphChecked = result.IsActualVsPredictedGraphChecked;
                this.isResidualGraphChecked = result.IsResidualGraphChecked;
                this.isResidualVsActualGraphChecked = result.IsResidualVsActualGraphChecked;
                this.isResidualVsPredictedGraphChecked = result.IsResidualVsPredictedGraphChecked;
                this.forecastingStep = result.ForecastingStep;

            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            SingleESOptionsForm op = new SingleESOptionsForm();
            op.InitialSmoothed = this.singleInitialSmoothed;

            if (op.ShowDialog() == DialogResult.OK)
            {
                this.singleInitialSmoothed = op.InitialSmoothed;
            }
        }

        
    }
}