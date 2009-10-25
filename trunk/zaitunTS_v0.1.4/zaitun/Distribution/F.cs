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

namespace zaitun.Distribution
{
    /// <summary>
    /// Class untuk mendapatkan nilai probability dari Distribusi F.
    /// </summary>
    public class F
    {
        /// <summary>
        /// DF = nilai degree of Freedom(derajat Bebas)
        /// x = nilai batas sumbu X dari tabel distribusi F
        /// pValue = nilai peluang(probability) dari distribusi F pada batas sumbu X
        /// </summary>
        private double df1,df2;

        /// <summary>
        /// Constructor-->Statement-statement yang pertama kali akan di eksekusi
        /// ketika object di inisialisasi.
        /// Menghitung nilai pValue F
        /// </summary>
        /// <param name="DF">Double. Nilai Degree of Freedom (Derajat Bebas)</param>
        public F()
        {

        }

        /// <summary>
        /// Mendapatkan nilai Probability(PValue)
        /// </summary>
        /// <param name="X">Double. Batas X</param>
        /// <returns>Double. Nilai PValue</returns>
        public double PValue(double X, double DF1, double DF2)
        {
            this.df1 = DF1;
            this.df2 = DF2;
            if (df1 == 1 && df2 == 1)
            {
                return (0.00223606 + integration(0.00001, X)); //CDF 0.00001 = 0.00223606 
            }
            else if (df1 == 1)
            {
                return (1 - this.PValue(1/X, df2, df1));
            }
            else
            {
                return (1 - integration(double.Epsilon, X));
            }

           
        }

        /// <summary>
        /// Fungsi untuk menghitung nilai Gamma r.
        /// </summary>
        /// <param name="r">Double. Nilai yang dicari</param>
        /// <returns>Double. Nilai Gamma(r)</returns>
        private double recGamma(double r)
        {
            if (r == 1) return 1;
            else if (r == 0) return 1;
            else if (r == 0.5) return Math.Sqrt(Math.PI);
            else if (r < 0) return recGamma(r + 1) / r;
            else return (r - 1) * recGamma(r - 1);
        }

        /// <summary>
        /// Metode untuk menghitung nilai dari persamaan Chi Square pada nilai x
        /// </summary>
        /// <param name="x">Double. Nilai X</param>
        /// <returns>Double. Hasil Penghitungan dari Persamaan</returns>
        private double FEquation(double x)
        {
            double result, rG1, rG2,rG12;

            rG1 = recGamma(df1 / 2);
            rG2 = recGamma(df2 / 2);
            rG12 = recGamma((df1+df2) / 2);
            result = (rG12 / (rG1 * rG2)) * Math.Pow((df1 / df2), df1 / 2) * Math.Pow(x, (df1 / 2) - 1) * Math.Pow((1 + (df1 / df2) * x), -(df1 + df2) / 2);
            //if (df == 1 && x == 0)
            //{
            //    result = ((1 / (Math.Pow(2, df / 2) * rG)) * 0 * Math.Pow(Math.E, -x / 2));
            //}
            //else
            //{
            //    result = ((1 / (Math.Pow(2, df / 2) * rG)) * (Math.Pow(x, (df / 2) - 1) * Math.Pow(Math.E, -x / 2)));
            //}
            return result;
        }

        /// <summary>
        /// Fungsi untuk menghitung nilai integral dari batas bawah sampai batas atas
        /// dari Persamaan F.
        /// Menggunakan metode Simpson.
        /// </summary>
        /// <param name="lowerBound">Double. Batas Bawah</param>
        /// <param name="upperBound">Double. Batas Atas</param>
        /// <returns>Double. Hasil Penghitungan Integral</returns>
        private double integration(double lowerBound, double upperBound)
        {
            double XN_1, int1, sum1, x2j_1, x2j, h, result;
            int interval = 10000;
            h = (upperBound - lowerBound) / interval;
            XN_1 = lowerBound + (interval - 1) * h;
            int1 = FEquation(lowerBound) + 4 * FEquation(XN_1) + FEquation(upperBound);
            sum1 = 0;
            for (int j = 1; j <= (interval / 2 - 1); j++)
            {
                x2j_1 = lowerBound + (2 * j - 1) * h;
                x2j = lowerBound + (2 * j) * h;
                sum1 = sum1 + 2 * FEquation(x2j_1) + FEquation(x2j);

                double aaa = FEquation(x2j);
            }
            result = ((h / 3 * (int1 + 2 * sum1)));
            if (result >= 1) result = 1;
            return result;
        }

        /// <summary>
        /// Mendapatkan nilai X --> nilai batas sumbu X pada tabel distribusi F
        /// </summary>
        public double X
        {
            get { return X; }
        }

        /// <summary>
        /// Mendapatkan nilai DF - Degree of Freedom - atau Derajat Bebas. 
        /// </summary>
        public double DF
        {
            get { return df1; }
        }

    }
}