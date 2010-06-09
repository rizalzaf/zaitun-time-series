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
    /// Class that provides static methods for Chi Square
    /// Distribution computation
    /// (c) anasikova 2009
    /// </summary>
    public static class ChiSquare
    {
        /// <summary>
        /// This function return the cummulative distribution function (CDF)
        /// for ChiSquare Distribution where X2 from 0 t x2 and
        /// number degree of freedom k.
        /// </summary>
        /// <param name="x2">double. x2</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <returns>
        /// The value of cummulative distribution function (CDF)
        /// for ChiSquare Distribution where X2 form 0 t x2 and
        /// number degree of freedom k.
        /// </returns>
        public static double CDF(double x2, int k)
        {
            // the number degree of freedom must be 
            // more or equal than 1. The value of x must be
            // not less than 0
            if (k < 1 || x2 < 0) return double.NaN;
            ChiSquareFunction function = new ChiSquareFunction(k);
            return Integrator.GaussLegendre(function, 0, x2, 1.0e-6);
        }
        /// <summary>
        /// This function return the probability density function (PDF)
        /// for ChiSquare Distribution for X2=x2 and
        /// number degree of freedom k.
        /// </summary>
        /// <param name="x2">double. x2</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <returns>
        /// The value of probability distribution function (PDF)
        /// for ChiSquare Distribution for X2=x2 and
        /// number degree of freedom k.
        /// </returns>
        private static double PDF(double x2, int k)
        {
            // the number degree of freedom must be 
            // more or equal than 1. The value of x must be
            // not less than 0
            if (k < 1 || x2 < 0) return double.NaN;
            ChiSquareFunction function = new ChiSquareFunction(k);
            return function.Value(x2);
        }
        /// <summary>
        /// This function return the value of x2 where x2 is
        /// random variable of ChiSquare Distribution with
        /// probability p and number degree of freedom k.
        /// </summary>
        /// <param name="p">double. probability value</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <returns>
        /// The value of x2 where x2 is random
        /// variable of ChiSquare Distribution with
        /// probability p and number degree of freedom k.
        /// </returns>
        public static double InversCDF(double p, int k)
        {
            // the number degree of freedom must be 
            // more or equal than 1.
            if (k < 1) return double.NaN;
            double startPoint, endPoint, midPoint, error;
            double accuracy = 1.0e-6; // double.Epsilon approximation

            if (p < 0 || p > 1.0) return double.NaN;
            startPoint = 0;
            endPoint = 10000; // the greatest value for x2 is set to 10000
            // search solution for x2 using binary search method
            do
            {
                midPoint = (endPoint + startPoint) / 2;
                error = p - CDF(midPoint, k);
                if (error > 0) startPoint = midPoint;
                else endPoint = midPoint;
            } while (Math.Abs(error) > accuracy);
            return midPoint;
        }
        /// <summary>
        /// This function return the critical region for reject H0
        /// </summary>
        /// <param name="x2">double. x2</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <returns>
        /// The critical region for reject H0
        /// </returns>
        public static double PValue(double x2, int k)
        {
            double cdf;
            // the number degree of freedom must be 
            // more or equal than 1. The value of x must be
            // not less than 0
            if (k < 1 || x2 < 0) return double.NaN;
            cdf = CDF(x2, k);
            return 1.0 - cdf;
        }
    }
}
