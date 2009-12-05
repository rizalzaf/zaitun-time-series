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
using zaitun.NumericalComputation;

namespace zaitun.Distribution
{
    /// <summary>
    /// Class that provides static methods for Fisher
    /// Distribution computation
    /// (c) anasikova 2009
    /// </summary>
    public static class F
    {
        /// <summary>
        /// This function return the cummulative distribution function (CDF)
        /// for Fisher Distribution with X from 0 to x and number degree of freedoms
        /// are k1 and k2.
        /// </summary>
        /// <param name="x">double. x</param>
        /// <param name="k1">int. k1 is firt number degree of freedom</param>
        /// <param name="k2">int. k2 is second number degree of freedom</param>
        /// <returns>
        /// The value of cummulative distribution function (CDF)
        /// for Fisher Distribution with X from 0 to x and number degree of freedoms
        /// are k1 and k2.
        /// </returns>
        public static double CDF(double x, int k1, int k2)
        {
            // number degree of freedoms and x must greater than 0
            if (!(k1 > 0 && k2 > 0 && x > 0)) return double.NaN;
            FisherFunction function = new FisherFunction(k1, k2);
            return Integrator.GaussLegendre(function, 0, x, 1.0e-6);
        }
        /// <summary>
        /// This function return the probability density function (PDF)
        /// for Fisher Distribution for given x and number degree of
        /// freedoms are k1 and k2.
        /// </summary>
        /// <param name="x">double. x</param>
        /// <param name="k1">int. k1 is firt number degree of freedom</param>
        /// <param name="k2">int. k2 is second number degree of freedom</param>
        /// <returns>
        /// The value of probability density function (PDF)
        /// for Fisher Distribution for given x and number degree of
        /// freedoms are k1 and k2.
        /// </returns>
        private static double PDF(double x, int k1, int k2)
        {
            // number degree of freedoms and x must greater than 0
            if (!(k1 > 0 && k2 > 0 && x > 0)) return double.NaN;
            FisherFunction function = new FisherFunction(k1, k2);
            return function.Value(x);
        }
        /// <summary>
        /// This function return the value of x where x is 
        /// random variable of Fisher distribution
        /// with probability p and number degree of freedom k1 and k2.
        /// </summary>
        /// <param name="p">double. p is probability</param>
        /// <param name="k1">int. k1 is firt number degree of freedom</param>
        /// <param name="k2">int. k2 is second number degree of freedom</param>
        /// <returns>
        /// the value of x where x is random variable 
        /// of Fisher distribution with probability p and 
        /// number degree of freedom k1 and k2.
        /// </returns>
        public static double InversCDF(double p, int k1, int k2)
        {
            // number degree of freedoms must greater than 0

            if (!(k1 > 0 && k2 > 0)) return double.NaN;
            double startPoint, endPoint, midPoint, error;
            double accuracy = 1.0e-6; // double.Epsilon approximation
            // p must between 0 and 1.
            if (p < 0 || p > 1.0) return double.NaN;
            startPoint = 0;
            endPoint = 1000; // the greatest value for x is set to 1000
            // search solution for x using binary search method
            do
            {
                midPoint = (endPoint + startPoint) / 2;
                error = p - CDF(midPoint, k1,k2);
                if (error > 0) startPoint = midPoint;
                else endPoint = midPoint;
            } while (Math.Abs(error) > accuracy);
            return midPoint;
        }
        /// <summary>
        /// This function return the critical region for reject H0
        /// </summary>
        /// <param name="x">double. x</param>
        /// <param name="k1">int. k1 is firt number degree of freedom</param>
        /// <param name="k2">int. k2 is second number degree of freedom</param>
        /// <returns>
        /// The value of critical region for reject H0
        /// </returns>
        public static double PValue(double x, int k1, int k2)
        {
            double cdf;
            // number degree of freedoms and x must greater than 0
            if (!(k1 > 0 && k2 > 0 && x > 0)) return double.NaN;
            cdf = CDF(x, k1, k2);
            return 1.0 - cdf;
        }
    }
}
