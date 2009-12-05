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
    /// Kelas untuk menghitung Pemulusan Eksponensial Tunggal
    /// </summary>
    class SingleExponentialSmoothing
    {
        private SeriesVariable variable;
        private Vector y;
        private double[] smoothing;
        private double[] predicted;
        private double[] residual;

        private int n;
        private double a;

        private int initialSmoothed = 6;

        private double sse;
        private double mse;
        private double mae;
        private double mpe;
        private double mape;

        #region Constructor
        /// <summary>
        /// Menghitung Pemulusan Eksponensial Tunggal
        /// </summary>
        /// <param name="variable">SeriesVariable. variabel</param>
        /// <param name="alpha">Double. Smoothing constanta for data</param>
        public SingleExponentialSmoothing(SeriesVariable variable, double alpha)
        {
            this.construct(variable, alpha);
        }

        public SingleExponentialSmoothing(SeriesVariable variable, double alpha, int initialSmoothed)
        {
            this.initialSmoothed = initialSmoothed;
            this.construct(variable, alpha);
        }

        private void construct(SeriesVariable variable, double alpha)
        {
            this.variable = variable;
            Vector var = new Vector(this.variable.SeriesValuesNoNaN.ToArray());
            this.y = new Vector(var.Tuples);
            for (int i = 0; i < y.Tuples; i++)
                this.y[i] = var[i];

            this.n = this.y.Tuples;
            this.a = alpha;
            this.smoothing = new double[this.n];
            this.predicted = new double[this.n];
            this.residual = new double[this.n];

            this.Smoothing();
            this.ForecastingError();
        }
        #endregion

        #region Procedure Member
        /// <summary>
        /// Prosedur untuk menghitung inisialisasi nilai awal
        /// Inisialisasi yang digunakan Minitab
        /// </summary>
        private void Init()
        {
            double value = 0;
            for (int i = 0; i < this.initialSmoothed; ++i)
            {
                value += this.y[i];
            }
            value = value / this.initialSmoothed;

            this.predicted[0] = value;
            this.smoothing[0] = this.a * this.y[0] + (1 - this.a) * this.predicted[0];
            this.residual[0] = this.y[0] - this.predicted[0];
        }

        /// <summary>
        /// Prosedur untuk menghitung nilai pemulusan, prediksi dan residual
        /// </summary>
        private void Smoothing()
        {
            this.Init();

            for (int i = 1; i < this.n; ++i)
            {
                this.smoothing[i] = (this.a * this.y[i]) + ((1 - this.a) * this.smoothing[i - 1]);
                this.predicted[i] = this.smoothing[i - 1];
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

        #region Properties member       

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
            get { return this.smoothing; }
        }

        /// <summary>
        /// Mendapatkan nilai prediksi
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
        /// Mendapatkan nilai Alpha
        /// </summary>
        public double Alpha
        {
            get { return this.a; }
        }
        #endregion

        #region Forecast
        /// <summary>
        /// Menghitung peramalan dengan metode pemulusan eksponensial tunggal
        /// </summary>
        /// <param name="step">Integer. Banyaknya periode yang akan diprediksi</param>
        /// <returns>ArrayDouble. Hasil Peramalan</returns>
        public double[] Forecast(int step)
        {
            double[] result = new double[step];

            for (int i = 0; i < step; ++i)
                result[i] = this.smoothing[n - 1];

            return result;
        }
        #endregion
    }
}
