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

namespace zaitun.MatrixVector
{
    /// <summary>
    /// Kelas untuk mengestimasi regresi berganda dengan
    /// metode Least Square Estimator
    /// copyright (c) rzaf 2007
    /// </summary>
    public class LeastSquareEstimator
    {
        private Matrix x;
        private Vector y, ycap, b, e, eSquare;
        private double ssto, ssr, sse;
        private double msr, mse;
        private double r, rSquare;
        private Matrix sbSquare;

        #region Constructor

        /// <summary>
        /// Constructor. Menghitung LSE dari persamaan regresi dalam matriks
        /// Y = X B + E
        /// </summary>
        /// <param name="X">Matrix. Matriks berisi data variabel independen X</param>
        /// <param name="Y">Vector. Vektor berisi data variabel dependen Y</param>
        public LeastSquareEstimator(Matrix X, Vector Y)
        {
            this.x = X;
            this.y = Y;
            int n = Y.Tuples;
            int p = X.Cols;            

            Matrix xtx = x.GetTranspose() * x;
            Vector xty = x.GetTranspose() * y;
            
            b = xtx.Solve(xty);

            ycap = x * b;
            e = y - ycap;
            eSquare = e.GetDataSquare();

            Matrix j = new Matrix(n, n);
            j.InitializeAllValue(1.0);

            double yty =Vector.DoubleMultiply(Y.GetTranspose(), Y);
            Vector jy = j * y;
            ssto = yty - Vector.DoubleMultiply(Y.GetTranspose(), jy) / n;
            sse = yty - Vector.DoubleMultiply(b.GetTranspose(), xty);
            ssr = ssto - sse;

            msr = ssr / (p - 1);
            mse = sse / (n - p);
            rSquare = ssr / ssto;
            r = Math.Sqrt(rSquare);

            sbSquare = mse * xtx.GetInverse();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Mendapatkan nilai Matriks X
        /// </summary>
        public Matrix X
        {
            get { return x; }
        }

        /// <summary>
        /// Mendapatkan nilai Vektor Y
        /// </summary>
        public Vector Y
        {
            get { return y; }
        }

        /// <summary>
        /// Mendapatkan nilai Vektor Y^ (Y Predicted)
        /// </summary>
        public Vector YCap
        {
            get { return ycap; }
        }

        /// <summary>
        /// Mendapatkan nilai Vektor B (parameter)
        /// </summary>
        public Vector B
        {
            get { return b; }
        }

        /// <summary>
        /// Mendapatkan nilai Vektor E (Error)
        /// </summary>
        public Vector E
        {
            get { return e; }
        }

        /// <summary>
        /// Mendapatkan nilai Vektor ESquare (Error Kuadrat)
        /// </summary>
        public Vector ESquare
        {
            get { return eSquare; }
        }

        /// <summary>
        /// Mendapatkan nilai SSTO
        /// </summary>
        public double SSTO
        {
            get { return ssto; }
        }

        /// <summary>
        /// Mendapatkan nilai SSR
        /// </summary>
        public double SSR
        {
            get { return ssr; }
        }

        /// <summary>
        /// Mendapatkan nilai SSE
        /// </summary>
        public double SSE
        {
            get { return sse; }
        }

        /// <summary>
        /// Mendapatkan nilai MSR
        /// </summary>
        public double MSR
        {
            get { return msr; }
        }

        /// <summary>
        /// Mendapatkan nilai MSE
        /// </summary>
        public double MSE
        {
            get { return mse; }
        }

        /// <summary>
        /// Mendapatkan nilai R (koefisien korelasi berganda)
        /// </summary>
        public double R
        {
            get { return r; }
        }

        /// <summary>
        /// Mendapatkan nilai R^2 (koefisien determinasi berganda)
        /// </summary>
        public double RSquare
        {
            get { return rSquare; }
        }
        
        /// <summary>
        /// Mendapatkan nilai Matriks s^2{b} (variance-covariance matrix)
        /// </summary>
        public Matrix SbSquare
        {
            get { return sbSquare; }
        }

        #endregion
    }
}
