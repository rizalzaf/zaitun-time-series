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


namespace zaitun.MovingAverage
{
    /// <summary>
    /// Kelas untuk menghitung "Double Moving Average" (Rata-Rata Bergerak Ganda)
    /// </summary>
    class DoubleMovingAverage
    {
        private SeriesVariable variable;
        private Vector y;
        private SingleMovingAverage sma1;
        private SingleMovingAverage sma2;
        private double[] smoothing1;
        private double[] smoothing2;
        private double[] predicted;
        private double[] residual;
        private double[] at, bt;
        private int index, n, t;
        private double sse;
        private double mse;
        private double mae;
        private double mpe;
        private double mape;

        #region Constructor
        /// <summary>
        /// Pemulusan dengan metode Rata-Rata Bergerak ganda
        /// </summary>
        /// <param name="variable">SeriesVariable. variabel yang akan dianalisis</param>
        /// <param name="maLength">Integer. MA Length</param>
        public DoubleMovingAverage(SeriesVariable variable, int maLength)
        {
            this.variable = variable;
            Vector var = new Vector(this.variable.SeriesValuesNoNaN.ToArray());
            this.y = new Vector(var.Tuples);
            for (int i = 0; i < y.Tuples; i++)
                y[i] = var[i];

            this.n = y.Tuples;
            this.t = maLength;

            this.smoothing1 = new double[n];
            this.smoothing2 = new double[n];
            this.at = new double[n];
            this.bt = new double[n];
            this.predicted = new double[n];
            this.residual = new double[n];

            Smoothing();
            ForecastingError();
        }
        #endregion

        #region Procedure Member
        /// <summary>
        /// Prosedur untuk menghitung nilai pemulusan, prediksi, dan residual
        /// </summary>
        private void Smoothing()
        {
            //Menghitung pemulusan pertama
            sma1 = new SingleMovingAverage(this.y, this.t);

            Vector ma1 = new Vector(n);
            for (this.index = t - 1; this.index < n; ++this.index)
                ma1[this.index] = this.sma1.Smoothed1[index];

            //Menghitung pemulusan kedua
            sma2 = new SingleMovingAverage(ma1, this.t);

            Vector ma2 = new Vector(n);
            for (this.index = 2 * t - 2; this.index < n; ++this.index)
            {
                ma2[this.index] = this.sma2.Smoothed1[index];
                at[this.index] = 2 * ma1[index] - ma2[index];
                bt[this.index] = 2 * (ma1[index] - ma2[index]) / (this.t - 1);
            }

            for (this.index = 2 * t - 1; this.index < n; ++this.index)
            {
                this.predicted[this.index] = this.at[index - 1] + this.bt[index - 1];
                residual[this.index] = y[index] - predicted[index];
            }

            //mengkonversi vector ke array double
            for (int i = 0; i < y.Tuples; i++)
            {
                this.smoothing1[i] = ma1[i];
                this.smoothing2[i] = ma2[i];
            }

            //inisialisasi nilai null
            for (int i = 0; i < this.t - 1; i++)
            {
                this.smoothing1[i] = double.NaN;
            }

            for (int i = 0; i < 2 * this.t - 2; i++)
            {
                this.smoothing2[i] = double.NaN;
            }

            for (int i = 0; i < 2 * this.t - 1; i++)
            {
                this.predicted[i] = double.NaN;
                this.residual[i] = double.NaN;
            }
        }

        /// <summary>
        /// Prosedur untuk menghitung nilai error hasil prediksi
        /// </summary>
        private void ForecastingError()
        {
            int testPeriode = 2 * this.t - 1;
            MeasuringForecastingError mfe = new MeasuringForecastingError(this.y, this.residual, testPeriode, this.n);
            this.sse = mfe.SSE;
            this.mse = mfe.MSE;
            this.mae = mfe.MAE;
            this.mpe = mfe.MPE;
            this.mape = mfe.MAPE;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mendapatkan nilai banyaknya observasi
        /// </summary>
        public int IncludedObservations
        {
            get { return this.n; }
        }

        /// <summary>
        /// Mendapatkan nilai pemulusan ganda
        /// </summary>
        public double[] Smoothed2
        {
            get { return this.smoothing2; }
        }

        /// <summary>
        /// Mendapatkan nilai pemulusan tunggal
        /// </summary>
        public double[] Smoothed1
        {
            get { return this.smoothing1; }
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
        #endregion

        #region Forecast
        /// <summary>
        /// Menghitung peramalan
        /// </summary>
        /// <param name="step">Integer. Banyaknya periode yang akan diprediksi</param>
        /// <returns>ArrayDouble. Hasil Peramalan</returns>
        public double[] Forecast(int step)
        {
            double[] result = new double[step];

            for (int i = 0; i < step; ++i)
                result[i] = this.at[this.n - 1] + this.bt[this.n - 1] * (i + 1);

            return result;
        }
        #endregion
    }
}
