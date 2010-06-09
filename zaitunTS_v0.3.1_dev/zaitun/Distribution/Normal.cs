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
    /// Class that provides static methods for Normal
    /// Distribution computation
    /// (c) anasikova 2009
    /// </summary>
    public static class Normal
    {
        // Type of hypothesis test using Z Statistic
        public enum TestType
        {
            OneSided = 1,
            TwoSided = 2
        }
        /// <summary>
        /// Return the cumulative distribution function (CDF)
        /// for normal distribution with mean mu, standard
        /// deviation sig and X has a value less than x
        /// </summary>
        /// <param name="x">
        /// double. x is observing data where X ~ N(mu, sig)
        /// </param>
        /// <param name="mu">
        /// double. mu is mean value of data
        /// </param>
        /// <param name="sig">
        /// double. sig is standard deviation of data
        /// </param>
        /// <returns>
        /// The cumulative distribution function for normal 
        /// distribution has a value less then x
        /// </returns>
        public static double CDF(double x, double mu, double sig)
        {
            double z = (x-mu)/sig;
            return CDF(z);
        }
        /// <summary>
        /// Return the cumulative distribution function (CDF)
        /// for normal standard distribution with mean 0, standard
        /// deviation 1 and Z has a value less than z
        /// </summary>
        /// <param name="z">
        /// double. z is standard value where Z ~ N(0, 1)
        /// </param>
        /// <returns>
        /// The cumulative distribution function for normal 
        /// standard distribution has a value less then z
        /// </returns>
        public static double CDF(double z)
        {
            // The CDF value for z < -10 --> 0
            if (z < -10.0) return double.Epsilon;
            // The CDF value for z > 10 --> 1
            if (z > 10.0) return (1.0 - double.Epsilon);
            NormalFunction function = new NormalFunction(0.0, 1.0);
            // accuracy of the integration method is 1.0e-6
            if (z < 0) return 0.5 - Integrator.GaussLegendre(function, z, 0, 1.0e-6);
            else return 0.5 + Integrator.GaussLegendre(function, 0, z, 1.0e-6);
        }
        /// <summary>
        /// This function return the value of probability density 
        /// function(PDF) for normal distribution with X=x, mean mu, 
        /// and standard deviation sig.
        /// </summary>
        /// <param name="x">double. x is observing data</param>
        /// <param name="mu">double. mu is mean of data</param>
        /// <param name="sig">double. sig is standard deviation data</param>
        /// <returns>
        /// The value of probability density function (PDF) for x
        /// where X ~ N(mu, sig)
        /// </returns>
        public static double PDF(double x, double mu, double sig)
        {
            NormalFunction function = new NormalFunction(mu, sig);
            return function.Value(x);
        }
        /// <summary>
        /// This function return the value of probability density 
        /// function(PDF) for normal standard distribution with Z=z 
        /// and Z ~ N(0,1)
        /// </summary>
        /// <param name="z">double. z is standard value</param>
        /// <returns>
        /// The value of probability density function (PDF) for x
        /// where Z ~ N(0, 1)
        /// </returns>
        public static double PDF(double z)
        {
            NormalFunction function = new NormalFunction();
            return function.Value(z);
        }
        /// <summary>
        /// This function return te value of x where F(X<x)=p
        /// X ~ N(mu, sig)
        /// </summary>
        /// <param name="p">double. p is the value of probability</param>
        /// <param name="mu">double. mu is mean data</param>
        /// <param name="sig">double. sig is standard deviation data</param>
        /// <returns>
        /// The value of x where F(X<x)=p, X ~ N(mu, sig)
        /// </returns>
        public static double InversCDF(double p, double mu, double sig)
        {
            double startPoint, endPoint, midPoint, error;
            double accuracy = 1.0e-12; // double.Epsilon approximation

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
            // search solution for z using binary search method
            do
            {
                midPoint = (endPoint + startPoint) / 2;
                error = p - CDF(midPoint);
                if (error > 0) startPoint = midPoint;
                else endPoint = midPoint;
            } while (Math.Abs(error) > accuracy);
            return mu + midPoint * sig;
        }
        /// <summary>
        /// This function return te value of z where F(Z<z)=p
        /// Z ~ N(0, 1)
        /// </summary>
        /// <param name="p">double. p is the value of probability</param>
        /// <returns>
        /// The value of z where F(Z<z)=p, Z ~ N(0, 1)
        /// </returns>
        public static double InversCDF(double p)
        {
            return InversCDF(p, 0, 1.0);
        }
        /// <summary>
        /// This function return the value of critical region for reject H0
        /// </summary>
        /// <param name="x">
        /// double. x is observing data where X ~ N(mu, sig)
        /// </param>
        /// <param name="mu">double. mu is mean data</param>
        /// <param name="sig">double. sig is standard deviation data</param>
        /// <param name="type">TestType. type of hypothesis test</param>
        /// <returns>
        /// The value of critical region for reject H0
        /// </returns>
        public static double PValue(double x, 
            double mu, double sig, TestType type)
        {
            double cdf = CDF(x, mu, sig);
            double pvalue = cdf > 0.5 ? 1.0 - cdf : cdf;
            if (type == TestType.OneSided)
                return pvalue;
            else 
                return 2.0 * pvalue;
        }
        /// <summary>
        /// This function return the value of critical region for reject H0
        /// </summary>
        /// <param name="x">
        /// double. z is standard value where Z ~ N(0, 1)
        /// </param>
        /// <param name="type">TestType. type of hypothesis test</param>
        /// <returns>
        /// The value of critical region for reject H0
        /// </returns>
        public static double PValue(double z, TestType type)
        {
            double cdf, pvalue;
            cdf = CDF(z, 0, 1);
            pvalue = cdf > 0.5 ? 1.0 - cdf : cdf;
            if (type == TestType.OneSided)
                return pvalue;
            else
                return 2.0 * pvalue;
        }
    }
}
