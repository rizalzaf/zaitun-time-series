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
using System.Text;
using zaitun.Data;
using zaitun.MatrixVector;

namespace zaitun.ExponentialSmoothing
{
    /// <summary>
    /// Kelas untuk menghitung Pemulusan Eksponensial Ganda
    /// dengan Metode Brown
    /// </summary>
    class DoubleExponentialSmoothingBrown
    {
        private SeriesVariable variable;
        private Vector y;
        private double[] smoothing1;
        private double[] smoothing2;
        private double[] predicted;
        private double[] residual;
        private int n;
        private double a;

        private double sse;
        private double mse;
        private double mae;
        private double mpe;
        private double mape;

        #region Constructor
        /// <summary>
        /// Constructor. Pemulusan Eksponensial Ganda dengan metode Brown
        /// </summary>
        /// <param name="variable">SeriesVariable. variabel</param>
        /// <param name="alpha">Double. Smoothing constanta for data</param>
        public DoubleExponentialSmoothingBrown(SeriesVariable variable, double alpha)
        {
            this.variable = variable;
            Vector var = new Vector(this.variable.SeriesValuesNoNaN.ToArray());

            this.y = new Vector(var.Tuples);
            for (int i = 0; i < y.Tuples; i++)
                this.y[i] = var[i];
            this.n = this.y.Tuples;

            this.a = alpha;

            this.smoothing1 = new double[this.n];
            this.smoothing2 = new double[this.n];
            this.predicted = new double[this.n];
            this.residual = new double[this.n];

            this.Smoothing();
            this.ForecastingError();
        }
        #endregion

        #region Procedure Member
        /// <summary>
        /// Prosedur untuk menghitung inisialisasi nilai awal
        /// nilai awal ditentukan dengan menggunakan lse
        /// </summary>
        private void Init()
        {
            Matrix x = new Matrix(this.n, 2);
            for (int i = 0; i < this.n; ++i)
            {
                x[i, 0] = 1;
                x[i, 1] = i + 1;
            }

            LeastSquareEstimator lse = new LeastSquareEstimator(x, y);
            double[] parameters = lse.B.GetData();

            double w = 1 - this.a;
            double a0 = (double)(parameters[0] - ((w / this.a) * parameters[1]));
            double b0 = (double)(parameters[0] - (2 * (w / this.a) * parameters[1]));

            this.smoothing1[0] = this.a * this.y[0] + w * a0;
            this.smoothing2[0] = this.a * this.smoothing1[0] + w * b0; ;
        }

        /// <summary>
        /// Prosedur untuk menghitung nilai pemulusan, prediksi dan residual
        /// </summary>
        private void Smoothing()
        {
            this.Init();
            for (int i = 1; i < this.n; ++i)
            {
                this.smoothing1[i] = this.a * this.y[i] + (1 - this.a) * this.smoothing1[i - 1];
                this.smoothing2[i] = this.a * this.smoothing1[i] + (1 - this.a) * this.smoothing2[i - 1];
                this.predicted[i] = 2 * this.smoothing1[i - 1] - this.smoothing2[i - 1] + (this.a / (1 - this.a)) * (this.smoothing1[i - 1] - this.smoothing2[i - 1]);
                this.residual[i] = this.y[i] - this.predicted[i];
            }

            this.predicted[0] = double.NaN;
            this.residual[0] = double.NaN;
        }

        /// <summary>
        /// Prosedur untuk menghitung nilai error hasil prediksi
        /// </summary>
        private void ForecastingError()
        {
            MeasuringForecastingError mfe = new MeasuringForecastingError(this.y, this.residual, 1, this.n);
            this.sse = mfe.SSE;
            this.mse = mfe.MSE;
            this.mae = mfe.MAE;
            this.mpe = mfe.MPE;
            this.mape = mfe.MAPE;
        }
        #endregion

        #region Properties
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
            get { return this.smoothing2; }
        }

        /// <summary>
        /// Mendapatkan nilai predikasi
        /// </summary>
        public double[] Predicted
        {
            get { return this.predicted; }
        }

        /// <summary>
        /// Mendapatkan nilai sisaan
        /// </summary>
        public double[] Residual
        {
            get { return this.residual; }
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
            get { return this.a; }
        }
        #endregion

        #region Forecast
        /// <summary>
        /// Menghitung peramalan dengan metode Brown
        /// </summary>
        /// <param name="step">Integer. Banyaknya periode yang akan diprediksi</param>
        /// <returns>ArrayDouble. Hasil Peramalan</returns>
        public double[] Forecast(int step)
        {
            double[] result = new double[step];

            for (int i = 0; i < step; i++)
                result[i] = 2 * this.smoothing1[this.n - 1] - this.smoothing2[this.n - 1] + (this.a / (1 - this.a)) * (this.smoothing1[this.n - 1] - this.smoothing2[this.n - 1]) * (i + 1);

            return result;
        }
        #endregion
    }
}
