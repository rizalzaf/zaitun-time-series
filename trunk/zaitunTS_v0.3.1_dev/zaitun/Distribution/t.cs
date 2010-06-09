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
    /// Class that provides static methods for Student's t
    /// Distribution computation
    /// (c) anasikova 2009
    /// </summary>
    public static class T
    {
        // Type of hypothesis test using T Statistic
        public enum TestType
        {
            OneSided = 1,
            TwoSided = 2
        }
        /// <summary>
        /// This function return the cummulative distribution function (CDF)
        /// for Student's t distribution less than t and number degree of
        /// freedom k.
        /// </summary>
        /// <param name="t">double. t</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <returns>
        /// The value of cummulative distribution function (CDF)
        /// for Student's t distribution less than t and number degree of
        /// freedom k.
        /// </returns>
        public static double CDF(double t, int k)
        {
            // number degree of freedom must be mor than 0
            if (k <= 0) return double.NaN;
            if (t == 0) return 0.5;
            StudentFunction function = new StudentFunction(k);
            if (t < 0)
                return 0.5 - Integrator.GaussLegendre(function, t, 0, 1.0e-6);
            else
                return 0.5 + Integrator.GaussLegendre(function, 0, t, 1.0e-6);
        }
        /// <summary>
        /// This function return the probability density function (PDF)
        /// for Student's t distribution with T=t and number degree
        /// of freedom k.
        /// </summary>
        /// <param name="t">double. t</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <returns>
        /// The value of probability density function (PDF)
        /// for Student's t distribution with T=t and number degree
        /// of freedom k.
        /// </returns>
        private static double PDF(double t, int k)
        {
            StudentFunction function = new StudentFunction(k);
            return function.Value(t);
        }
        /// <summary>
        /// This function return the value of t where t is 
        /// random variable of Student's t distribution
        /// with probability p and number degree of freedom k.
        /// </summary>
        /// <param name="p">double. p is probability</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <returns>
        /// the value of t where t is random
        /// variable of Student's t distribution with
        /// probability p and number degree of freedom k.
        /// </returns>
        public static double InversCDF(double p, int k)
        {
            // number degree of freedom must be mor than 0
            if (k <= 0) return double.NaN;
            double startPoint, endPoint, midPoint, error;
            double accuracy = 1.0e-10; // double.Epsilon approximation

            if (p < 0 || p > 1.0) return double.NaN;
            if (p == 0.5) return 0;
            if (p < 0.5)
            {
                startPoint = -10.0;
                endPoint = 0;
            }
            else
            {
                startPoint = 0;
                endPoint = 10.0;
            }
            // search solution for t using binary search method
            do
            {
                midPoint = (endPoint + startPoint) / 2;
                error = p - CDF(midPoint,k);
                if (error > 0) startPoint = midPoint;
                else endPoint = midPoint;
            } while (Math.Abs(error) > accuracy);
            return midPoint;
        }
        /// <summary>
        /// This function return the critical region for reject H0.
        /// </summary>
        /// <param name="t">double. t</param>
        /// <param name="k">int. k is number degree of freedom</param>
        /// <param name="type">TestType. type of hypothesis test</param>
        /// <returns>
        /// The value of critical region for reject H0.
        /// </returns>
        public static double PValue(double t, int k, TestType type)
        {
            double cdf, pvalue;
            if (k <= 0) return double.NaN;
            cdf = CDF(t, k);
            pvalue = cdf > 0.5 ? 1.0 - cdf : cdf;
            if (type == TestType.OneSided)
                return pvalue;
            else
                return 2.0 * pvalue;
        }
    }
}
