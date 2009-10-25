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
using zaitun.Data;
using zaitun.MatrixVector;

namespace zaitun.MovingAverage
{
    public partial class MovingAverageForm : Form
    {
        private SingleMovingAverage sma;
        private DoubleMovingAverage dma;
        private SeriesVariable variable;
        private MASpecification maProperties;
        private MAComponent maTable;

        private bool isStoreSmoothed = false;
        private bool isStorePredicted = false;
        private bool isStoreResidual = false;
        private string smoothedName = "";
        private string predictedName = "";
        private string residualName = "";

        private bool isMaModelSummaryChecked = true;
        private bool isMovingAverageDataGridChecked = true;
        private bool isSmoothingChecked = false;
        private bool isActualPredictedAndResidualChecked = true;
        private bool isForecastedDataGridChecked = false;
        private bool isActualAndPredictedGraphChecked = true;
        private bool isActualAndSmoothedGraphChecked = false;
        private bool isActualAndForecastedGraphChecked = false;
        private bool isActualVsPredictedGraphChecked = false;
        private bool isResidualGraphChecked = true;
        private bool isResidualVsActualGraphChecked = false;
        private bool isResidualVsPredictedGraphChecked = false;
        private int forecastingStep = 0;


        #region Struct
        /// <summary>
        /// Struct: properti data dan ukuran kesalahan
        /// </summary>
        public struct MASpecification
        {
            public int includedObservations;
            public int orde;
            public bool isSingleMA;
            public double sseMA;
            public double mseMA;
            public double maeMA;
            public double mpeMA;
            public double mapeMA;
        }

        /// <summary>
        /// Struct: hasil penghitungan rata-rata bergerak
        /// </summary>
        public struct MAComponent
        {
            public double[] singleSmoothed;
            public double[] doubleSmoothed;
            public double[] predicted;
            public double[] residual;
        }
        #endregion

        /// <summary>
        /// Constructor: Moving Average Form
        /// </summary>
        public MovingAverageForm()
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

            this.maProperties.orde = 2;

            this.Text = "Moving Average : " + variable.VariableName;

            this.UpdateSettings();
        }

        /// <summary>
        /// Menampilkan default nilai panjang MA/Orde
        /// </summary>
        private void UpdateSettings()
        {
            this.OrdeBox.Text = this.maProperties.orde.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {            

            if (this.smaRadio.Checked)
            {
                if (this.OrdeBox.Text == "")
                {
                    MessageBox.Show("Please insert moving average length", "Moving Average", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
                else if (int.Parse(this.OrdeBox.Text) < 2 || int.Parse(this.OrdeBox.Text) > (this.variable.SeriesValuesNoNaN.Count - 1))
                {
                    MessageBox.Show("Incorrect Moving Average Length", "Moving Average", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
                else
                    this.EstimateParameters();
            }
            if (this.dmaRadio.Checked)
            {
                if (this.OrdeBox.Text == "")
                {
                    MessageBox.Show("Please insert moving average length", "Moving Average", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
                else if (this.variable.SeriesValuesNoNaN.Count < 5)
                {
                    MessageBox.Show("Unsufficent number of observations", "Moving Average", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
                else if (int.Parse(this.OrdeBox.Text) < 2 || int.Parse(this.OrdeBox.Text) > ((this.variable.SeriesValuesNoNaN.Count - 1) / 2))
                {
                    MessageBox.Show("Incorrect Moving Average Length", "Moving Average", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
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
            if (this.smaRadio.Checked == true)
            {
                //get Orde
                try { this.maProperties.orde = int.Parse(this.OrdeBox.Text); }
                catch { this.maProperties.orde = 2; }

                sma = new SingleMovingAverage(this.variable, this.maProperties.orde);

                this.maProperties.isSingleMA = true;

                this.maTable.singleSmoothed = sma.Smoothed1;
                this.maTable.predicted = sma.Predicted;
                this.maTable.residual = sma.Residual;

                this.maProperties.includedObservations = sma.IncludedObservations;
                this.maProperties.sseMA = sma.SSE;
                this.maProperties.mseMA = sma.MSE;
                this.maProperties.maeMA = sma.MAE;
                this.maProperties.mpeMA = sma.MPE;
                this.maProperties.mapeMA = sma.MAPE;
            }

            if (this.dmaRadio.Checked == true)
            {
                try { this.maProperties.orde = int.Parse(this.OrdeBox.Text); }
                catch { this.maProperties.orde = 2; }

                dma = new DoubleMovingAverage(this.variable, this.MaProperties.orde);

                this.maProperties.isSingleMA = false;

                this.maTable.singleSmoothed = dma.Smoothed1;
                this.maTable.doubleSmoothed = dma.Smoothed2;
                this.maTable.predicted = dma.Predicted;
                this.maTable.residual = dma.Residual;

                this.maProperties.includedObservations = dma.IncludedObservations;
                this.maProperties.sseMA = dma.SSE;
                this.maProperties.mseMA = dma.MSE;
                this.maProperties.maeMA = dma.MAE;
                this.maProperties.mpeMA = dma.MPE;
                this.maProperties.mapeMA = dma.MAPE;
            }
        }

        #region Properties
        /// <summary>
        /// Mengirimkan semua parameter yang ada dalam MASpecification
        /// </summary>
        public MASpecification MaProperties
        {
            get { return this.maProperties; }
        }

        /// <summary>
        /// Mengirimkan semua parameter yang ada dalam MAComponent
        /// </summary>
        public MAComponent MaTable
        {
            get { return this.maTable; }
        }

        /// <summary>
        /// Mendapatkan nilai hasil peramalan
        /// untuk model rata-rata bergerak tunggal
        /// </summary>
        /// <param name="step">Integer. Step: banyaknya periode yang akan diramalkan</param>
        /// <returns>ArrayDouble. Nilai peramalan untuk 'step' periode ke muka</returns>
        public double[] SmaForecast(int step)
        {
            return this.sma.Forecast(step);
        }

        /// <summary>
        /// Mendapatkan nilai hasil peramalan
        /// untuk model rata-rata bergerak ganda
        /// </summary>
        /// <param name="step">Integer. Step: banyaknya periode yang akan diramalkan</param>
        /// <returns>ArrayDouble. Nilai peramalan untuk 'step' periode ke muka</returns>
        public double[] DmaForecast(int step)
        {
            return this.dma.Forecast(step);
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

        public bool IsMaModelSummaryChecked
        {
            get { return this.isMaModelSummaryChecked; }
        }

        public bool IsSmoothingChecked
        {
            get { return this.isSmoothingChecked; }
        }

        public bool IsActualPredictedAndResidualChecked
        {
            get { return this.isActualPredictedAndResidualChecked; }
        }

        public bool IsMovingAverageDataGridChecked
        {
            get { return this.isMovingAverageDataGridChecked; }
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

        private void MovingAverageForm_Load(object sender, EventArgs e)
        {
            if (this.variable.SeriesValuesNoNaN.Count < 3)
            {
                MessageBox.Show("Unsufficent number of observations", "Moving Average", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }         
        }

        private void storageButton_Click(object sender, EventArgs e)
        {
            MAStorageForm storage = new MAStorageForm();

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
            MASelectResultView result = new MASelectResultView();

            // sending current value
            result.IsMaModelSummaryChecked = this.isMaModelSummaryChecked;
            result.IsMovingAverageDataGridChecked = this.isMovingAverageDataGridChecked;
            result.IsSmoothingChecked = this.isSmoothingChecked;
            result.IsActualPredictedAndResidualChecked = this.isActualPredictedAndResidualChecked;
            result.IsForecastedDataGridChecked = this.isForecastedDataGridChecked;
            result.IsActualAndPredictedGraphChecked = this.isActualAndPredictedGraphChecked;
            result.IsActualAndSmoothedGraphChecked = this.isActualAndSmoothedGraphChecked;
            result.IsActualAndForecastedGraphChecked = this.isActualAndForecastedGraphChecked;
            result.IsActualVsPredictedGraphChecked = this.isActualVsPredictedGraphChecked;
            result.IsResidualGraphChecked = this.isResidualGraphChecked;
            result.IsResidualVsActualGraphChecked = this.isResidualVsActualGraphChecked;
            result.IsResidualVsPredictedGraphChecked = this.isResidualVsPredictedGraphChecked;
            result.ForecastingStep = this.forecastingStep;

            result.ShowDialog();
            if (result.DialogResult == DialogResult.OK)
            {
                //accepting selected value

                this.isMaModelSummaryChecked = result.IsMaModelSummaryChecked;
                this.isMovingAverageDataGridChecked = result.IsMovingAverageDataGridChecked;
                this.isSmoothingChecked = result.IsSmoothingChecked;
                this.isActualPredictedAndResidualChecked = result.IsActualPredictedAndResidualChecked;
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
    }
}