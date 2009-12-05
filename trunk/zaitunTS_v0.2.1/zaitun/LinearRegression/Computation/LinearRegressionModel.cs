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
using zaitun.Distribution;

namespace zaitun.LinearRegression
{
    /// <summary>
    /// Class for  Linear Regression Analysis computation
    /// </summary>
    public class LinearRegressionModel
    {
        #region Fields
        private LeastSquareEstimator lse;
        private double f, sigOfF, durbinWatson;
        private double[] stdErrorOfParameters, t, sigOfT, expectedResidual, 
            lbOfParameters, ubOfParameters, vifForPredictors,corr, partialCorr;
        #endregion

        # region Constructor
        /// <summary>
        /// Linear regression with Y and one or more independent variables
        /// equation: y = b0 + b1x1 + b2x2 + ... + b(p-1)x(p-1) + e
        /// equation in matrix form: Y = XB + E
        /// </summary>
        /// <param name="dependent">SeriesVariable. dependent variable</param>
        /// <param name="independents">SeriesVariables. independent variable</param>
        public LinearRegressionModel(SeriesVariable dependent, SeriesVariables independents)
        {
            //Vector vY = new Vector(dependent.SeriesValuesNoNaN.ToArray());
            //int n = vY.Tuples;
            //int p = independents.Count + 1;
            //Matrix mX = new Matrix(n, p);
            //for (int i = 0; i < p; i++) //kolom
            //{
            //    for (int j = 0; j < n; j++) //baris
            //    {
            //        if (i == 0)
            //            mX[j, i] = 1.0;
            //        else
            //            mX[j, i] = independents[i - 1][j];
            //    }
            //}

            // changed to deal with missing values
            Vector vY = new Vector(dependent.SeriesValuesNoNaN.ToArray());
            int n = vY.Tuples;
            int p = independents.Count + 1;
            Matrix mX = new Matrix(n, p);
            for (int i = 0; i < p; i++) //kolom
            {
                for (int j = 0; j < n; j++) //baris
                {
                    if (i == 0)
                        mX[j, i] = 1.0;
                    else
                        mX[j, i] = independents[i - 1].SeriesValuesNoNaN[j];
                }
            }


            this.lse = new LeastSquareEstimator(mX, vY);

            this.f = this.lse.MSR / this.lse.MSE;
            this.sigOfF = Distribution.F.PValue(this.f, p - 1, n - p);
            
            double sumOfEtMinusEt_1Square = 0;
            double sumOfESquare = this.lse.ESquare[0];
            for (int i = 1; i < n; i++)
            {
                sumOfEtMinusEt_1Square += Math.Pow(this.lse.E[i] - this.lse.E[i - 1],2.0);
                sumOfESquare += this.lse.ESquare[i];
            }
            this.durbinWatson = sumOfEtMinusEt_1Square / sumOfESquare;

            this.stdErrorOfParameters = new double[p];
            this.t = new double[p];
            this.sigOfT = new double[p];
            this.lbOfParameters = new double[p];
            this.ubOfParameters = new double[p];
            for (int i = 0; i < p; i++)
            {
                this.stdErrorOfParameters[i] = Math.Sqrt(this.lse.SbSquare[i, i]);
                this.t[i] = this.lse.B[i] / this.stdErrorOfParameters[i];
                this.sigOfT[i] = Distribution.T.PValue(this.t[i], n - p, Distribution.T.TestType.TwoSided);
                double error = Distribution.T.InversCDF(0.975, n - p);
                this.ubOfParameters[i] = this.lse.B[i] + error * this.stdErrorOfParameters[i];
                this.lbOfParameters[i] = this.lse.B[i] - error * this.stdErrorOfParameters[i];
            }

            this.vifForPredictors = new double[p - 1];
            this.partialCorr = new double[p - 1];
            this.corr = new double[p - 1];
            for (int i = 1; i < p; i++)
            {
                Vector y = new Vector(mX.GetColData(i));
                Matrix x = new Matrix(n, p - 1);
                int col = 0;
                for (int j = 0; j < p; j++)
                {
                    if (j != i)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            x[k, col] = mX[k, j];
                        }
                        col++;
                    }
                }
                Matrix xtx = x.GetTranspose() * x;
                Vector xty = x.GetTranspose() * y;
                Vector b = xtx.Solve(xty);
                Matrix mJ = new Matrix(n, n);
                mJ.InitializeAllValue(1.0);
                double yty = Vector.DoubleMultiply(y.GetTranspose(), y);
                Vector jy = mJ * y;
                double ssto = yty - Vector.DoubleMultiply(y.GetTranspose(), jy) / n;
                double sse = yty - Vector.DoubleMultiply(b.GetTranspose(), xty);
                double ssr = ssto - sse;
                double rSquare = ssr / ssto;
                this.vifForPredictors[i - 1] = 1 / (1 - rSquare);
                this.corr[i - 1] = computePearsonCorr(vY,y);
                
                Vector xty2 = x.GetTranspose() * vY;
                Vector b2 = xtx.Solve(xty2);
                double yty2 = Vector.DoubleMultiply(vY.GetTranspose(), vY);
                double sse2 = yty2 - Vector.DoubleMultiply(b2.GetTranspose(), xty2);
                double partDetermination = (sse2 - this.lse.SSE) / sse2;
                this.partialCorr[i - 1] = Math.Sqrt(partDetermination);
               
            }

            this.expectedResidual = new double[n];
            for (int k = 1; k <= n; k++)
            {
                this.expectedResidual[k - 1] = this.lse.StandardError * Distribution.Normal.InversCDF((k - 0.375) / (n + 0.25));
            }

        }
        //r = Cov(x,y)/(StandardDeviation(x)*StandardDeviation(y))
        private double computePearsonCorr(Vector x, Vector y)
        {
            int n = x.Tuples;
            Vector xy = new Vector(n);
            for (int i = 0; i < n; i++)
                xy[i] = x[i] * y[i];
            double sumxy = xy.GetSumData();
            double xbar = x.GetSumData() / (double)n;
            double ybar = y.GetSumData() / (double)n;
            double covxy = (sumxy - n * xbar * ybar) / (double)(n - 1);
            Vector x2 = x.GetDataSquare();
            Vector y2 = y.GetDataSquare();
            double varx = (n * x2.GetSumData() - Math.Pow(x.GetSumData(), 2.0)) / (double)(n * (n - 1));
            double vary = (n * y2.GetSumData() - Math.Pow(y.GetSumData(), 2.0)) / (double)(n * (n - 1));
            return covxy / Math.Sqrt(varx * vary);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get least square estimator
        /// </summary>
        public LeastSquareEstimator LSE
        {
            get { return this.lse; }
        }

        /// <summary>
        /// Get test statistic F (F=MSR/MSE)
        /// used for overall test
        /// </summary>
        public double F
        {
            get { return this.f; }
        }

        /// <summary>
        /// Get p-value of F
        /// </summary>
        public double SigOfF
        {
            get{return this.sigOfF;}
        }

        /// <summary>
        /// Get Durbin-Watson value
        /// used for test of autocorrelation
        /// DW = Sum(t=2->n){e(t)-e(t-1)}^2/Sum(t=1->n){e(t)}^2
        /// </summary>
        public double DurbinWatson
        {
            get { return this.durbinWatson; }
        }
        /// <summary>
        /// Get value of standard eror model
        /// std. eror = sqrt(MSE)
        /// </summary>
        public double[] StandardErrorOfParameters
        {
            get { return this.stdErrorOfParameters; }
        }
        /// <summary>
        /// Get test statistic t
        /// tj = Bj/Se(Bj) = Bj / sqrt(inv(x'x)*MSE)
        /// </summary>
        public double[] T
        {
            get { return this.t; }
        }
        /// <summary>
        /// Get p-value of t
        /// </summary>
        public double[] SigOfT
        {
            get { return this.sigOfT; }
        }
        /// <summary>
        /// Get lower bound of Confidence interval of Bj
        /// </summary>
        public double[] LowerBoundCIForParameters
        {
            get { return this.lbOfParameters; }
        }
        /// <summary>
        ///  Get upper bound of Confidence interval of Bj
        /// </summary>
        public double[] UpperBoundCIForParameters
        {
            get { return this.ubOfParameters; }
        }
        /// <summary>
        /// Get VIF value for multicollinearity test
        /// VIFj = 1/(1-R^2j)
        /// </summary>
        public double[] VifForPredictors
        {
            get { return this.vifForPredictors; }
        }
        /// <summary>
        /// Get expected residual
        /// ExpectedResidual = sqrt(MSE)Z((k-0.375)/(n+0.25))
        /// </summary>
        public double[] ExpectedResidual
        {
            get { return this.expectedResidual; }
        }
        public double[] PartialCorrelation
        {
            get { return this.partialCorr; }
        }
        public double[] Correlations
        {
            get { return this.corr; }
        }
        #endregion
    }
}
