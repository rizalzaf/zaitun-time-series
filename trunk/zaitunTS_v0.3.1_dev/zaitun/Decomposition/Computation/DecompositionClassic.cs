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

namespace zaitun.Decomposition
{
    /// <summary>
    /// Kelas dekomposisi klasik dengan rasio pada rata-rata bergerak
    /// </summary>
    class DecompositionClassic
    {
        private SeriesVariable variable;
        private Vector y;
        private Matrix x;
        private SeasonalIndex ssnl;
        private LeastSquareEstimator lse;
        private double[] trend;
        private double[] detrend;
        private double[] seasonal;
        private double[] deseasonal;
        private double[] predicted;
        private double[] residual;

        private int n;
        private int seasonalLength;
        private double[] parameters;

        private double sse;
        private double mse;
        private double mae;
        private double mpe;
        private double mape;

        private bool isMultiplicative;
        private int initialTrend;

        #region Constructor
        /// <summary>
        /// Metode dekomposisi klasik dengan rasio pada rata-rata bergerak
        /// </summary>
        /// <param name="variable">SeriesVariable. variabel yang akan dianalisis</param>
        /// <param name="seasonalLength">Integer. panjang satu siklus musiman</param>
        /// <param name="isMultiplikatif">Bool. apakah menggunakan metode multiplikatif?</param>
        /// <param name="initialTrend">Integer. Inisial model tren yang digunakan, 1-Linear, 2-Quadratic, 3-Cubic, 4-Exponential</param>
        public DecompositionClassic(SeriesVariable variable, int seasonalLength, bool isMultiplicative, int initialTrend)
        {
            this.variable = variable;
            Vector var = new Vector(this.variable.SeriesValuesNoNaN.ToArray());
            this.y = new Vector(var.Tuples);
            for (int i = 0; i < y.Tuples; i++)
                this.y[i] = var[i];

            this.n = y.Tuples;
            this.seasonalLength = seasonalLength;

            this.trend = new double[this.n];
            this.detrend = new double[this.n];
            this.seasonal = new double[this.n];
            this.deseasonal = new double[this.n];
            this.predicted = new double[this.n];
            this.residual = new double[this.n];
            
            this.isMultiplicative = isMultiplicative;
            this.initialTrend = initialTrend;

            if (this.isMultiplicative)
                this.Multiplicative();
            else
                this.Additive();

            this.ForecastingError();
        }
        #endregion

        #region Procedure
        /// <summary>
        /// Prosedur untuk menghitung dekomposisi dengan metode aditif
        /// </summary>
        private void Additive()
        {
            //menghitung seasonal index
            ssnl = new SeasonalIndex(this.y, this.seasonalLength, false);
            //mendefinisikan data seasonal
            int index = 0;
            for (int i = 0; i < this.n; i++)
            {
                this.seasonal[i] = ssnl.SEASONAL[index];
                index++;
                if (index == this.seasonalLength)
                    index = 0;
            }

            //Melakukan penghitungan nilai deseasonal
            for (int i = 0; i < this.n; i++)
            {
                this.deseasonal[i] = this.y[i] - this.seasonal[i];
            }

            //Menghitung nilai tren
            this.ComponentTrend();

            //Melakukan penghitungan nilai detrend, deseasonal, cyclical and irregular, predicted, and residual
            for (int i = 0; i < this.n; ++i)
            {
                this.detrend[i] = this.y[i] - this.trend[i];
                this.predicted[i] = this.trend[i] + this.seasonal[i];
                this.residual[i] = this.y[i] - this.predicted[i];
            }
        }

        /// <summary>
        /// Prosedur untuk menghitung dekomposisi dengan metode multiplikatif
        /// </summary>
        private void Multiplicative()
        {
            //menghitung nilai seasonal index dengan rasio pada rata-rata bergerak
            ssnl = new SeasonalIndex(this.y, this.seasonalLength, true);
            //mendefinisikan nilai seasonal setiap data
            int index = 0;
            for (int i = 0; i < this.n; i++)
            {
                this.seasonal[i] = ssnl.SEASONAL[index];
                index++;
                if (index == this.seasonalLength)
                    index = 0;
            }

            //Melakukan penghitungan nilai deseasonal
            for (int i = 0; i < this.n; i++)
            {
                try
                {
                    this.deseasonal[i] = this.y[i] / this.seasonal[i];
                }
                catch
                {
                    this.deseasonal[i] = 0;
                }
            }

            this.ComponentTrend();

            //Melakukan penghitungan nilai detrend, predicted, and residual
            for (int i = 0; i < this.n; ++i)
            {
                try { this.detrend[i] = this.y[i] / this.trend[i]; }
                catch { this.detrend[i] = 0; }
                this.predicted[i] = this.trend[i] * this.seasonal[i];
                this.residual[i] = this.y[i] - this.predicted[i];
            }
        }

        private void ComponentTrend()
        {
            switch (this.initialTrend)
            {
                case 1:
                    {
                        //Model tren linier
                        x = new Matrix(this.n, 2);
                        for (int i = 0; i < this.n; ++i)
                        {
                            x[i, 0] = 1;
                            x[i, 1] = i + 1;
                        }
                        Vector z = new Vector(this.deseasonal);
                        lse = new LeastSquareEstimator(x, z);
                        this.parameters = lse.B.GetData();

                        for (int i = 0; i < this.n; i++)
                            this.trend[i] = this.parameters[0] + this.parameters[1] * (i + 1);

                        break;
                    }
                case 2:
                    {
                        //model tren kuadratik
                        x = new Matrix(this.n, 3);
                        for (int i = 0; i < this.n; ++i)
                        {
                            x[i, 0] = 1;
                            x[i, 1] = i + 1;
                            x[i, 2] = Math.Pow(i + 1, 2);
                        }
                        Vector z = new Vector(this.deseasonal);
                        lse = new LeastSquareEstimator(x, z);
                        this.parameters = lse.B.GetData();

                        for (int i = 0; i < this.n; i++)
                            this.trend[i] = this.parameters[0] + this.parameters[1] * (i + 1) + this.parameters[2] * Math.Pow(i + 1, 2);

                        break;
                    }
                case 3:
                    {
                        //model tren kubik
                        x = new Matrix(this.n, 4);
                        for (int i = 0; i < this.n; ++i)
                        {
                            x[i, 0] = 1;
                            x[i, 1] = i + 1;
                            x[i, 2] = Math.Pow(i + 1, 2);
                            x[i, 3] = Math.Pow(i + 1, 3);
                        }
                        Vector z = new Vector(this.deseasonal);
                        lse = new LeastSquareEstimator(x, z);
                        this.parameters = lse.B.GetData();

                        for (int i = 0; i < this.n; i++)
                            this.trend[i] = this.parameters[0] + this.parameters[1] * (i + 1) + this.parameters[2] * Math.Pow(i + 1, 2)
                                + this.parameters[3] * Math.Pow(i + 1, 3);

                        break;
                    }
                case 4:
                    {
                        //model tren eksponensial
                        x = new Matrix(this.n, 2);
                        for (int i = 0; i < this.n; ++i)
                        {
                            x[i, 0] = 1;
                            x[i, 1] = i + 1;
                        }

                        Vector z = new Vector(this.n);
                        for (int i = 0; i < this.n; ++i)
                            z[i] = Math.Log10(this.deseasonal[i]);

                        lse = new LeastSquareEstimator(x, z);
                        this.parameters = lse.B.GetData();
                        for (int i = 0; i < 2; ++i)
                            this.parameters[i] = Math.Pow(10, this.parameters[i]);

                        for (int i = 0; i < this.n; i++)
                            this.trend[i] = this.parameters[0] * Math.Pow(this.parameters[1], (i + 1));

                        break;
                    }
                default:
                    goto case 1;
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

        #region Properties
        /// <summary>
        /// Mendapatkan jumlah data observasi yang dianalisis
        /// </summary>
        public int IncludedObservations
        {
            get { return this.n; }
        }

        /// <summary>
        /// Mendapatkan nilai tren
        /// </summary>
        public double[] Trend
        {
            get { return trend; }
        }

        /// <summary>
        /// Mendapatkan nilai data yang mengandung musiman dan keacakan
        /// </summary>
        public double[] Detrend
        {
            get { return detrend; }
        }

        /// <summary>
        /// Mendapatkan nilai yang mengandung musiman
        /// </summary>
        public double[] Seasonal
        {
            get { return seasonal; }
        }

        /// <summary>
        /// Mendapatkan nilai yang mengandung tren dan keacakan
        /// </summary>
        public double[] Deseasonal
        {
            get { return deseasonal; }
        }

        public double[] seasonalFactor()
        {
            double[] value = new double[this.seasonalLength];

            for (int i = 0; i < this.seasonalLength; ++i)
                value[i] = this.ssnl.SEASONAL[i];

            return value;
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
        /// Mendapatkan nilai parameter persamaan tren
        /// </summary>
        public double[] Parameters
        {
            get { return parameters; }
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
        /// Menghitung nilai peramalan
        /// </summary>
        /// <param name="step">Integer. banyak periode yang akan diramal</param>
        /// <returns>ArrayDouble. nilai peramalan</returns>
        public double[] Forecast(int step)
        {
            double[] result = new double[step];

            switch (this.initialTrend)
            {
                case 1:
                    {
                        //Peramalan dengan model tren linier
                        for (int i = 0; i < step; i++)
                        {
                            result[i] = this.parameters[0] + this.parameters[1] * (this.n + i + 1);
                            if(this.isMultiplicative)
                                result[i] = result[i] * this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                            else
                                result[i] = result[i] + this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                        }
                        break;
                    }
                case 2:
                    {
                        //Peramalan dengan model tren kuadratik
                        for (int i = 0; i < step; i++)
                        {
                            result[i] = this.parameters[0] + this.parameters[1] * (this.n + i + 1)
                                + this.parameters[2] * Math.Pow(this.n + i + 1, 2);
                            if (this.isMultiplicative)
                                result[i] = result[i] * this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                            else
                                result[i] = result[i] + this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                        }
                        break;
                    }
                case 3:
                    {
                        //Peramalan dengan model tren kubik
                        for (int i = 0; i < step; i++)
                        {
                            result[i] = this.parameters[0] + this.parameters[1] * (this.n + i + 1)
                                + this.parameters[2] * Math.Pow(this.n + i + 1, 2)
                                + this.parameters[3] * Math.Pow(this.n + i + 1, 3);
                            if(this.isMultiplicative)
                                result[i] = result[i] * this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                            else
                                result[i] = result[i] + this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                        }

                        break;
                    }
                case 4:
                    {
                        //peramalan dengan model tren eksponensial
                        for (int i = 0; i < step; i++)
                        {
                            result[i] = this.parameters[0] * Math.Pow(this.parameters[1], (this.n + i + 1));
                            if(this.isMultiplicative)
                                result[i] = result[i] * this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                            else
                                result[i] = result[i] + this.ssnl.SEASONAL[(i + this.IncludedObservations) % this.seasonalLength];
                        }
                        break;
                    }
                default:
                    goto case 1;
            }
            return result;
        }
        #endregion
    }
}
