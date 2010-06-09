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
using System.Text;
using zaitun.Data;
using zaitun.MatrixVector;

namespace zaitun.ExponentialSmoothing
{
    /// <summary>
    /// Kelas untuk menghitung Pemulusan Eksponensial Tripel
    /// dengan metode Winter
    /// </summary>
    class TripleExponentialSmoothingWinter
    {
        private SeriesVariable variable;
        private Vector y;
        private LeastSquareEstimator lse;
        private double[] smoothing;
        private double[] trend;
        private double[] seasonal;
        private double[] predicted;
        private double[] residual;
        private int[] term;
        private int n;
        private int l;
        private double alpha;
        private double gamma;
        private double beta;

        private bool isMultiplicative;

        private double sse;
        private double mse;
        private double mae;
        private double mpe;
        private double mape;

        #region Constructor
        /// <summary>
        /// Constructor. Menghitung Pemulusan Eksponensial Tripel
        /// </summary>
        /// <param name="variable">SeriesVariable. variabel</param>
        /// <param name="alpha">Double. Smoothing constant for data</param>
        /// <param name="gamma">Double. Smoothing constant for trend</param>
        /// <param name="beta">Double. Smoothing constant for seasonal</param>
        /// <param name="seasonalLength">Integer. Panjang seasonal</param>
        public TripleExponentialSmoothingWinter(SeriesVariable variable, double alpha, double gamma, double beta, int seasonalLength, bool isMultiplicative)
        {
            this.variable = variable;
            Vector var = new Vector(this.variable.SeriesValuesNoNaN.ToArray());
            this.y = new Vector(var.Tuples);
            for (int i = 0; i < y.Tuples; i++)
                this.y[i] = var[i];

            this.n = this.y.Tuples;
            this.alpha = alpha;
            this.gamma = gamma;
            this.beta = beta;
            this.l = seasonalLength;

            this.isMultiplicative = isMultiplicative;

            this.smoothing = new double[this.n];
            this.trend = new double[this.n];
            this.seasonal = new double[this.n];
            this.predicted= new double[this.n];
            this.residual = new double[this.n];

            //term
            term = new int[this.n];
            for (int i = 0; i < this.n; )
            {
                for (int j = 0; j < this.l; ++j)
                {
                    if (i + j != this.n)
                        term[i + j] = j;
                    else
                        break;
                }
                i += this.l;
            }

            if(this.isMultiplicative)
                SmoothingMultiplicative();
            else                
                SmoothingAdditive();

            ForecastingError();
        }
        #endregion

        #region Procedure Member
        /// <summary>
        /// Prosedur untuk menghitung inisialisasi Pemulusan dan trend periode 0 (nol)
        /// Dihitung lse untuk data sebanyak panjang musiman pertama
        /// </summary>
        private void EstimateValue()
        {
            //Menghitung nilai detrend
            Matrix xL = new Matrix(this.l, 2);
            for (int i = 0; i < this.l; ++i)
            {
                xL[i, 0] = 1;
                xL[i, 1] = i + 1;
            }

            Vector yL = new Vector(this.l);
            for (int i = 0; i < this.l; ++i)
                yL[i] = this.y[i];

            lse = new LeastSquareEstimator(xL, yL);
        }

        /// <summary>
        /// Inisialisasi nilai awal untuk tipe model aditif
        /// Nilai awal musiman ditentukan dengan menggunakan Dummy Variabel dari data detrend
        /// </summary>
        private void InitAdditive()
        {
            //Menghitung nilai detrend
            Matrix x = new Matrix(this.n, 2);
            for (int i = 0; i < this.n; ++i)
            {
                x[i, 0] = 1;
                x[i, 1] = i + 1;
            }

            LeastSquareEstimator lse1 = new LeastSquareEstimator(x, this.y);
            Vector detrend = new Vector(this.n);

            for (int i = 0; i < this.n; i++)
                detrend[i] = this.y[i] - lse1.YCap[i];

            //Mencari indeks musiman dengan Dummy Regresi
            Matrix z = new Matrix(this.n, this.l);

            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.l; j++)
                {
                    if (j == this.term[i])
                        z[i, j] = 1;
                    else
                        z[i, j] = 0;
                }
            }

            LeastSquareEstimator lse2 = new LeastSquareEstimator(z, detrend);
            double[] seasonalIndex = lse2.B.GetData();

            this.EstimateValue();

            double trend0 = lse.B[1];
            double smoothing0 = lse.B[0];

            this.smoothing[0] = (this.alpha * (this.y[0] - seasonalIndex[0])) + (1 - this.alpha) * (smoothing0 + trend0);
            this.trend[0] = this.gamma * (this.smoothing[0] - smoothing0) + (1 - this.gamma) * trend0;
            this.seasonal[0] = (this.beta * (this.y[0] - this.smoothing[0])) + (1 - this.beta) * seasonalIndex[0];
            this.predicted[0] = smoothing0 + trend0 + seasonalIndex[0];
            this.residual[0] = this.y[0] - this.predicted[0];

            for (int i = 1; i < l; i++)
            {
                this.smoothing[i] = (this.alpha * (this.y[i] - seasonalIndex[i])) + (1 - this.alpha) * (this.smoothing[i - 1] + this.trend[i - 1]);
                this.trend[i] = this.gamma * (this.smoothing[i] - this.smoothing[i - 1]) + (1 - this.gamma) * this.trend[i - 1];
                this.seasonal[i] = (this.beta * (this.y[i] - this.smoothing[i])) + (1 - this.beta) * seasonalIndex[i];
                this.predicted[i] = this.smoothing[i - 1] + this.trend[i - 1] + seasonalIndex[i];
                this.residual[i] = this.y[i] - this.predicted[i];
            }
        }

        /// <summary>
        /// Menghitung nilai pemulusan dengan tipe model aditif
        /// </summary>
        private void SmoothingAdditive()
        {
            this.InitAdditive();

            for (int i = l; i < n; i++)
            {
                this.smoothing[i] = (this.alpha * (this.y[i] - this.seasonal[i - l])) + (1 - this.alpha) * (this.smoothing[i - 1] + this.trend[i - 1]);
                this.trend[i] = this.gamma * (this.smoothing[i] - this.smoothing[i - 1]) + (1 - this.gamma) * this.trend[i - 1];
                this.seasonal[i] = (this.beta * (this.y[i] - this.smoothing[i])) + (1 - this.beta) * this.seasonal[i - l];
                this.predicted[i] = (this.smoothing[i - 1] + this.trend[i - 1]) + this.seasonal[i - l];
                this.residual[i] = this.y[i] - this.predicted[i];
            }
        }

        /// <summary>
        /// Inisialisasi nilai awal untuk tipe model multiplikatif
        /// Nilai awal musiman ditentukan dengan menggunakan Dummy Variabel dari data detrend
        /// </summary>
        private void InitMultiplicative()
        {
            //Menghitung nilai detrend
            Matrix x = new Matrix(this.n, 2);
            for (int i = 0; i < this.n; ++i)
            {
                x[i, 0] = 1;
                x[i, 1] = i + 1;
            }

            LeastSquareEstimator lse1 = new LeastSquareEstimator(x, this.y);

            Vector detrend = new Vector(this.n);
            for (int i = 0; i < this.n; i++)
                detrend[i] = this.y[i] / lse1.YCap[i];

            //Mencari indeks musiman dengan Dummy Regresi
            Matrix z = new Matrix(this.n, this.l);

            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.l; j++)
                {
                    if (j == this.term[i])
                        z[i, j] = 1;
                    else
                        z[i, j] = 0;
                }
            }

            LeastSquareEstimator lse2 = new LeastSquareEstimator(z, detrend);
            double[] seasonalIndex = lse2.B.GetData();

            this.EstimateValue();

            double smoothing0 = lse.B[0];
            double trend0 = lse.B[1];

            this.smoothing[0] = (this.alpha * this.y[0] / seasonalIndex[0]) + (1 - this.alpha) * (smoothing0 + trend0);
            this.trend[0] = this.gamma * (this.smoothing[0] - smoothing0) + (1 - this.gamma) * trend0;
            this.seasonal[0] = (this.beta * this.y[0] / this.smoothing[0]) + (1 - this.beta) * seasonalIndex[0];
            this.predicted[0] = (smoothing0 + trend0) * seasonalIndex[0];
            this.residual[0] = this.y[0] - this.predicted[0];

            for (int i = 1; i < l; i++)
            {
                this.smoothing[i] = (this.alpha * this.y[i] / seasonalIndex[i]) + (1 - this.alpha) * (this.smoothing[i - 1] + this.trend[i - 1]);
                this.trend[i] = this.gamma * (this.smoothing[i] - this.smoothing[i - 1]) + (1 - this.gamma) * this.trend[i - 1];
                this.seasonal[i] = (this.beta * this.y[i] / this.smoothing[i]) + (1 - this.beta) * seasonalIndex[i];
                this.predicted[i] = (this.smoothing[i - 1] + this.trend[i - 1]) * seasonalIndex[i];
                this.residual[i] = this.y[i] - this.predicted[i];
            }
        }

        /// <summary>
        /// Menghitung nilai pemulusan dengan tipe model multiplikatif
        /// </summary>
        private void SmoothingMultiplicative()
        {
            this.InitMultiplicative();

            for (int i = l; i < n; i++)
            {
                this.smoothing[i] = (this.alpha * this.y[i] / this.seasonal[i - l]) + (1 - this.alpha) * (this.smoothing[i - 1] + this.trend[i - 1]);
                this.trend[i] = this.gamma * (this.smoothing[i] - this.smoothing[i - 1]) + (1 - this.gamma) * this.trend[i - 1];
                this.seasonal[i] = (this.beta * this.y[i] / this.smoothing[i]) + (1 - this.beta) * this.seasonal[i - l];
                this.predicted[i] = (this.smoothing[i - 1] + this.trend[i - 1]) * this.seasonal[i - l];
                this.residual[i] = this.y[i] - this.predicted[i];
            }
        }

        /// <summary>
        /// Prosedur untuk menghitung nilai error hasil prediksi
        /// </summary>
        private void ForecastingError()
        {
            MeasuringForecastingError mfe = new MeasuringForecastingError(this.y, this.residual, 0, this.n);
            this.sse = mfe.SSE;
            this.mse = mfe.MSE;
            this.mae = mfe.MAE;
            this.mpe = mfe.MPE;
            this.mape = mfe.MAPE;
        }
        #endregion

        #region Properties Member
        /// <summary>
        /// Mendapatkan jumlah observasi
        /// </summary>
        public int IncludedObservations
        {
            get { return this.n; }
        }

        /// <summary>
        /// Mendapatkan nilai pemulusan
        /// </summary>
        public double[] Smoothed
        {
            get { return smoothing; }
        }

        /// <summary>
        /// Mendapatkan nilai trend
        /// </summary>
        public double[] Trend
        {
            get { return trend; }
        }

        /// <summary>
        /// Mendapatkan nilai musiman
        /// </summary>
        public double[] Seasonal
        {
            get { return seasonal; }
        }

        /// <summary>
        /// Mendapatkan nilai prediksi
        /// </summary>
        public double[] Predicted
        {
            get { return predicted; }
        }

        /// <summary>
        /// Mendapatkan nilai sisaan
        /// </summary>
        public double[] Residual
        {
            get { return residual; }
        }

        /// <summary>
        /// Mendapatkan nilai SSE
        /// </summary>
        public double SSE
        {
            get { return this.sse; }
        }

        /// <summary>
        /// Mendapatkan nilai MSE
        /// </summary>
        public double MSE
        {
            get { return this.mse; }
        }

        /// <summary>
        /// Mendapatkan nilai MAE
        /// </summary>
        public double MAE
        {
            get { return this.mae; }
        }

        /// <summary>
        /// Mendapatkan nilai MPE
        /// </summary>
        public double MPE
        {
            get { return this.mpe; }
        }

        /// <summary>
        /// Mendapatkan nilai MAPE
        /// </summary>
        public double MAPE
        {
            get { return this.mape; }
        }

        /// <summary>
        /// Mendapatkan nilai alpha
        /// </summary>
        public double Alpha
        {
            get { return this.alpha; }
        }

        /// <summary>
        /// Mendapatkan nilai gamma
        /// </summary>
        public double Gamma
        {
            get { return this.gamma; }
        }

        /// <summary>
        /// Mendapatkan nilai beta
        /// </summary>
        public double Beta
        {
            get { return this.beta; }
        }
        #endregion

        #region Forecast
        /// <summary>
        /// Menghitung peramalan dengan metode Winter
        /// </summary>
        /// <param name="step">Integer. Banyaknya periode yang akan diprediksi</param>
        /// <returns>ArrayDouble. Hasil Peramalan</returns>
        public double[] Forecast(int step)
        {
            double[] result = new double[step];
            int index = 0;
            if (this.isMultiplicative)
            {
                for (int j = 1; j <= Convert.ToInt32(step / this.l) + 1; ++j)
                {
                    for (int i = index; i < index + this.l; ++i)
                    {
                        if (i < step)
                            result[i] = (this.smoothing[this.n - 1] + (i + 1) * this.trend[this.n - 1]) * this.seasonal[this.n + i - (j * l)];
                        else
                            break;
                    }
                    index += this.l;
                }
            }
            else
            {
                for (int j = 1; j <= Convert.ToInt32(step / this.l) + 1; ++j)
                {
                    for (int i = index; i < index + this.l; ++i)
                    {
                        if (i < step)
                            result[i] = (this.smoothing[this.n - 1] + (i + 1) * this.trend[this.n - 1]) + this.seasonal[this.n + i - (j * l)];
                        else
                            break;
                    }
                    index += this.l;
                }
            }

            return result;
        }
        #endregion
    }
}
