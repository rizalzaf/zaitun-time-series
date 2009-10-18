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
    /// Class untuk mendapatkan nilai probability dari Distribusi t.
    /// </summary>
    public class t
    {
        /// <summary>
        /// DF = nilai degree of Freedom(derajat Bebas)
        /// x = nilai batas sumbu X dari tabel distribusi t
        /// pValue = nilai peluang(probability) dari distribusi t pada batas sumbu X
        /// </summary>
        private double df;

        /// <summary>
        /// Constructor-->Statement-statement yang pertama kali akan di eksekusi
        /// ketika object di inisialisasi.
        /// Menghitung nilai pValue t
        /// </summary>
        /// <param name="DF">Double. Nilai Degree of Freedom (Derajat Bebas)</param>
        public t()
        {

        }

        /// <summary>
        /// Mendapatkan nilai Probability(PValue) distribusi t untuk uji 1 sisi.
        /// </summary>
        /// <param name="X">Double. Batas X</param>
        /// <returns>Double. Nilai PValue</returns>
        public double HalfPValue(double X, double DF)
        {
            this.df = DF;
            if (X < 0) X = -X;
            //double Z1 = 0;
            //double Z2 = 0;
            //Normal normal = new Normal(0, 1);
            //ChiSquare cs = new ChiSquare(df);
            //Z1 = normal.FullValue(X);
            //Z2 = cs.PValue(X);
            //double ret = ((Z1 / Math.Sqrt(Z2 / df)));
            //return ret;
            return (0.5 - integration(0, X));
        }

        /// <summary>
        /// Mendapatkan nilai Probability(PValue) distribusi t untuk uji 2 sisi.
        /// </summary>
        /// <param name="X">Double. Batas X</param>
        /// <returns>Double. Nilai PValue</returns>
        public double FullPValue(double X, double DF)
        {
            this.df = DF;
            if (X < 0) X = -X;
            //double Z1 = 0;
            //double Z2 = 0;
            //Normal normal = new Normal(0, 1);
            //ChiSquare cs = new ChiSquare(df);
            //Z1 = normal.FullValue(X);
            //Z2 = cs.PValue(X);

            //return (Z1 / Math.Sqrt(Z2 / df));
            return 2 * (0.5 - integration(0, X));
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
        /// Metode untuk menghitung nilai dari persamaan t pada nilai x
        /// </summary>
        /// <param name="x">Double. Nilai X</param>
        /// <returns>Double. Hasil Penghitungan dari Persamaan</returns>
        private double tEquation(double x)
        {
            double result, GpG;
          
            if (df % 2 == 0)
            {
                GpG = Math.Sqrt(Math.PI)/2;
                for (int i = 3; i < df; i += 2)
                {
                    GpG *= (i / (double)(i - 1));
                }
            }
            else
            {
                GpG = 2 / Math.Sqrt(Math.PI); 
                for (int i = 4; i < df; i += 2)
                {
                    GpG *= ((double)(i) / (i - 1));
                }                
            }

            result = (GpG / Math.Sqrt((df * Math.PI))) * Math.Pow((1 + (x * x / df)), -(df + 1) / 2);
            return result;
        }

        /// <summary>
        /// Fungsi untuk menghitung nilai integral dari batas bawah sampai batas atas
        /// dari Persamaan t.
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
            int1 = tEquation(lowerBound) + 4 * tEquation(XN_1) + tEquation(upperBound);
            sum1 = 0;
            for (int j = 1; j <= (interval / 2 - 1); j++)
            {
                x2j_1 = lowerBound + (2 * j - 1) * h;
                x2j = lowerBound + (2 * j) * h;
                sum1 = sum1 + 2 * tEquation(x2j_1) + tEquation(x2j);
            }
            result = ((h / 3 * (int1 + 2 * sum1)));
            //if (result >= 0.5) result = 0.5;
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
            get { return df; }
        }

    }
}