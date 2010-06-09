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
using zaitun.ExponentialSmoothing;

namespace zaitun.TrendAnalysis
{
    public partial class TrendAnalysisForm : Form
    {
        private SeriesVariable variable;
        private Vector y;
        private Matrix x;
        private LeastSquareEstimator lse;
        private TrendSpecification trendProperties;
        private double[] predicted;
        private double[] residual;

        private bool isStorePredicted = false;
        private bool isStoreResidual = false;
        private string predictedName = "";
        private string residualName = "";

        private bool isTrendAnalysisModelSummaryChecked=true;
        private bool isActualPredictedResidualDataGridChecked=true;
        private bool isForecastedDataGridChecked=false;
        private bool isActualAndPredictedGraphChecked=true;        
        private bool isActualAndForecastedGraphChecked=false;
        private bool isActualVsPredictedGraphChecked=false;
        private bool isResidualGraphChecked=true;
        private bool isResidualVsActualGraphChecked=false;
        private bool isResidualVsPredictedGraphChecked = false;
        private int forecastingStep = 0;
        
        /// <summary>
        /// Struct: ukuran statistik dari tren analisis
        /// </summary>
        public struct TrendSpecification
        {
            public int includedObservations;
            public double r;
            public double rSquare;
            public double rSquareAdjusted;
            public double sse;
            public double mse;
            public double[] parameters;
            public int initialModel;
        } 

        /// <summary>
        /// Constructor: Trend Analysis Form
        /// </summary>
        public TrendAnalysisForm()
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

            this.Text = "Trend Analysis : " + variable.VariableName;
        }

        /// <summary>
        /// Mengirimkan semua parameter yang ada dalam TrendSpecification
        /// </summary>
        public TrendSpecification TrendProperties
        {
            get { return this.trendProperties; }
        }

        /// <summary>
        /// Mendapatkan nilai prediksi
        /// </summary>
        public double[] Predicted
        {
            get { return this.predicted; }
        }

        /// <summary>
        /// Mendapatkan nilai residual
        /// </summary>
        public double[] Residual
        {
            get { return this.residual; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {            

            Vector var = new Vector(this.variable.SeriesValuesNoNaN.ToArray());
            this.y = new Vector(var.Tuples);
            for (int i = 0; i < y.Tuples; i++)
                this.y[i] = var[i];

            this.estimateParameters();
        }

        /// <summary>
        /// Mengestimasi parameter
        /// </summary>
        private void estimateParameters()
        {
            if (this.linearRdb.Checked)
            {
                x = new Matrix(this.y.Tuples, 2);
                for (int i = 0; i < this.y.Tuples; ++i)
                {
                    x[i, 0] = 1;
                    x[i, 1] = i + 1;
                }

                lse = new LeastSquareEstimator(x, this.y);

                this.trendProperties.initialModel = 1;
                this.trendProperties.includedObservations = this.y.Tuples;
                this.trendProperties.parameters = lse.B.GetData();
                this.trendProperties.sse = lse.SSE;
                this.trendProperties.mse = lse.MSE;
                this.trendProperties.r = lse.R;
                this.trendProperties.rSquare = lse.RSquare;
                this.trendProperties.rSquareAdjusted = 1 - (Math.Sqrt(lse.SSE) / lse.SSTO);

                this.predicted = lse.YCap.GetData();
                this.residual = lse.E.GetData();
            }
            else if (this.quadraticRdb.Checked)
            {
                x = new Matrix(this.y.Tuples, 3);
                for (int i = 0; i < this.y.Tuples; ++i)
                {
                    x[i, 0] = 1;
                    x[i, 1] = i + 1;
                    x[i, 2] = Math.Pow(i + 1, 2);
                }
                lse = new LeastSquareEstimator(x, this.y);

                this.trendProperties.initialModel = 2;
                this.trendProperties.includedObservations = this.y.Tuples;
                this.trendProperties.parameters = lse.B.GetData();
                this.trendProperties.sse = lse.SSE;
                this.trendProperties.mse = lse.MSE;
                this.trendProperties.r = lse.R;
                this.trendProperties.rSquare = lse.RSquare;
                this.trendProperties.rSquareAdjusted = 1 - (Math.Sqrt(lse.SSE) / lse.SSTO);

                this.predicted = lse.YCap.GetData();
                this.residual = lse.E.GetData();
            }
            else if (this.expGrowthRdb.Checked)
            {
                x = new Matrix(this.y.Tuples, 2);
                for (int i = 0; i < this.y.Tuples; ++i)
                {
                    x[i, 0] = 1;
                    x[i, 1] = i + 1;
                }

                Vector z = new Vector(this.y.Tuples);
                for (int i = 0; i < this.y.Tuples; ++i)
                    z[i] = Math.Log10(this.y[i]);

                lse = new LeastSquareEstimator(x, z);
                this.trendProperties.parameters = lse.B.GetData();
                this.trendProperties.includedObservations = this.y.Tuples;
                this.trendProperties.initialModel = 4;

                for (int i = 0; i < 2; ++i)
                    this.trendProperties.parameters[i] = Math.Pow(10, this.trendProperties.parameters[i]);

                predicted = new double[this.y.Tuples];
                residual = new double[this.y.Tuples];
                for (int i = 0; i < this.y.Tuples; ++i)
                {
                    this.predicted[i] = this.trendProperties.parameters[0] * Math.Pow(this.trendProperties.parameters[1], (i + 1));
                    this.residual[i] = this.y[i] - this.predicted[i];
                }

                this.trendProperties.sse = lse.SSE;
                this.trendProperties.mse = lse.MSE;
                this.trendProperties.r = lse.R;
                this.trendProperties.rSquare = lse.RSquare;
                this.trendProperties.rSquareAdjusted = 1 - (Math.Sqrt(lse.SSE) / lse.SSTO);
            }
            else if (this.cubicRdb.Checked)
            {
                x = new Matrix(this.y.Tuples, 4);
                for (int i = 0; i < this.y.Tuples; ++i)
                {
                    x[i, 0] = 1;
                    x[i, 1] = i + 1;
                    x[i, 2] = Math.Pow(i + 1, 2);
                    x[i, 3] = Math.Pow(i + 1, 3);
                }
                lse = new LeastSquareEstimator(x, this.y);

                this.trendProperties.initialModel = 3;
                this.trendProperties.includedObservations = this.y.Tuples;
                this.trendProperties.parameters = lse.B.GetData();
                this.trendProperties.sse = lse.SSE;
                this.trendProperties.mse = lse.MSE;
                this.trendProperties.r = lse.R;
                this.trendProperties.rSquare = lse.RSquare;
                this.trendProperties.rSquareAdjusted = 1 - (Math.Sqrt(lse.SSE) / lse.SSTO);

                this.predicted = lse.YCap.GetData();
                this.residual = lse.E.GetData();
            }
        }

        /// <summary>
        /// Mendapatkan nilai hasil peramalan
        /// </summary>
        /// <param name="step">Integer. Step: banyaknya periode yang akan diramalkan</param>
        /// <returns>ArrayDouble. Nilai peramalan untuk 'step' periode ke muka</returns>
        public double[] Forecast(int step)
        {
            double[] result = new double[step];

            switch (this.TrendProperties.initialModel)
            {
                case 1:
                    {
                        for (int i = 0; i < step; i++)
                            result[i] = this.TrendProperties.parameters[0] + this.TrendProperties.parameters[1] * (this.trendProperties.includedObservations + i + 1);
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < step; i++)
                            result[i] = this.TrendProperties.parameters[0] + this.TrendProperties.parameters[1] * (this.trendProperties.includedObservations + i + 1) 
                                + this.TrendProperties.parameters[2] * Math.Pow(this.trendProperties.includedObservations + i + 1, 2);
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < step; i++)
                            result[i] = this.TrendProperties.parameters[0] + this.TrendProperties.parameters[1] * (this.trendProperties.includedObservations + i + 1)
                                + this.TrendProperties.parameters[2] * Math.Pow(this.trendProperties.includedObservations + i + 1, 2)
                                + this.TrendProperties.parameters[3] * Math.Pow(this.trendProperties.includedObservations + i + 1, 3);
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < step; i++)
                            result[i] = this.TrendProperties.parameters[0] * Math.Pow(this.TrendProperties.parameters[1], (trendProperties.includedObservations + i + 1));
                        break;
                    }
            }

            return result;
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

        public bool IsTrendAnalysisModelSummaryChecked
        {
            get { return this.isTrendAnalysisModelSummaryChecked; }
        }

        public bool IsActualPredictedResidualDataGridChecked
        {
            get { return this.isActualPredictedResidualDataGridChecked; }
        }

        public bool IsForecastedDataGridChecked
        {
            get { return this.isForecastedDataGridChecked; }
        }

        public bool IsActualAndPredictedGraphChecked
        {
            get { return this.isActualAndPredictedGraphChecked; }
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

        private void TrendAnalysisForm_Load(object sender, EventArgs e)
        {
            if (this.variable.SeriesValuesNoNaN.Count < 3)
            {
                MessageBox.Show("Unsufficent number of observations", "Trend Analysis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            //// Create the ToolTip and associate with the Form container.
            //ToolTip toolTip1 = new ToolTip();

            //// Set up the delays for the ToolTip.
            //toolTip1.AutoPopDelay = 50000000;
            //toolTip1.InitialDelay = 100;
            //toolTip1.ReshowDelay = 1;
            //// Force the ToolTip text to be displayed whether or not the form is active.
            //toolTip1.ShowAlways = true;

            //// Set up the ToolTip text for the Button and Checkbox.
            //toolTip1.SetToolTip(this, "Note: Select method for analysis");
            //toolTip1.SetToolTip(this.okButton, "Click here to continue");
            //toolTip1.SetToolTip(this.cancelButton, "Click here to cancel");
            //toolTip1.SetToolTip(this.groupBox1, "Select method for analysis");
            //toolTip1.SetToolTip(this.linearRdb, "Click here to choose this method for analysis");
            //toolTip1.SetToolTip(this.quadraticRdb, "Click here to choose this method for analysis");
            //toolTip1.SetToolTip(this.cubicRdb, "Click here to choose this method for analysis");
            //toolTip1.SetToolTip(this.expGrowthRdb, "Click here to choose this method for analysis");
            //toolTip1.SetToolTip(this.isStorePredictedCheckBox, "Click here to store the predicted");
            //toolTip1.SetToolTip(this.predictedNameBox, "Type the name of variable predicted");
            //toolTip1.SetToolTip(this.isStoreResidualCheckBox, "Click here to store the residual");
            //toolTip1.SetToolTip(this.residualNameBox, "Type the name of variable residual");
        }

        private void storageButton_Click(object sender, EventArgs e)
        {
            TrendAnalysisStorageForm storage = new TrendAnalysisStorageForm();

            // sending current value
            storage.IsStorePredicted = this.isStorePredicted;
            storage.IsStoreResidual = this.isStoreResidual;
            storage.PredictedName = this.predictedName;
            storage.ResidualName = this.residualName;

            storage.ShowDialog();
            if (storage.DialogResult == DialogResult.OK)
            {
                //accepting selected value
                this.isStorePredicted = storage.IsStorePredicted;
                this.isStoreResidual = storage.IsStoreResidual;
                this.predictedName = storage.PredictedName;
                this.residualName = storage.ResidualName;
            }
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            TrendAnalysisSelectResultView result = new TrendAnalysisSelectResultView();

            // sending current value
            result.IsTrendAnalysisModelSummaryChecked = this.isTrendAnalysisModelSummaryChecked;
            result.IsActualPredictedResidualDataGridChecked = this.isActualPredictedResidualDataGridChecked;
            result.IsForecastedDataGridChecked = this.isForecastedDataGridChecked;
            result.IsActualAndPredictedGraphChecked = this.isActualAndPredictedGraphChecked;            
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
                this.isTrendAnalysisModelSummaryChecked = result.IsTrendAnalysisModelSummaryChecked;
                this.isActualPredictedResidualDataGridChecked = result.IsActualPredictedResidualDataGridChecked;
                this.isForecastedDataGridChecked = result.IsForecastedDataGridChecked;
                this.isActualAndPredictedGraphChecked = result.IsActualAndPredictedGraphChecked;                
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