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

namespace zaitun.NumericalComputation
{
    /// <summary>
    /// Class that provides static methods to
    /// compute integral using trapezoidal, simpson, 
    /// midpoint, and gauss legendre method.
    /// (c) anasikova 2009
    /// </summary>
    public static class Integrator
    {
        /// <summary>
        /// This function return the area under curve using trapezoidal rule
        /// </summary>
        /// <param name="function">Function. function for curve</param>
        /// <param name="lowerBound">double. lowerBound is lower bound of integral</param>
        /// <param name="upperBound">double. upperBound is lower bound of integral</param>
        /// <param name="accuracy">double. accuracy is the value of corvergence tolerance</param>
        /// <returns>The area under the curve</returns>
        public static double Trapezoidal(BaseFunction function,
            double lowerBound, double upperBound, double accuracy)
        {

            double dx = upperBound - lowerBound;
            double value, oldValue, sum, scale;
            int maxIter = 20;

            //  first, compute an value of the integral using
            //  the two-point trapezoidal rule.

            value = 0.5 * dx * (function.Value(lowerBound) +
                function.Value(upperBound));

            // Subdivide the integration range by adding more
            // points. Recompute the integral value each time. 
            // If the solution convergences, return the value.

            for (int i = 0; i < maxIter; ++i)
            {
                sum = 0.0;
                scale = Math.Pow(0.5, i + 1);
                for (int j = 0; j < Math.Pow(2, i); ++j)
                {
                    sum += function.Value(lowerBound +
                        scale * (2 * j + 1.0) * dx);
                }

                oldValue = value;
                value = 0.5 * value + scale * dx * sum;

                if (Math.Abs(value - oldValue) <=
                    accuracy * Math.Abs(oldValue))
                {
                    return value;
                }
            }

            //  Solution did not convergence
            return value; ;
        }
        /// <summary>
        /// This function return the area under curve using Simpson's rule
        /// </summary>
        /// <param name="function">Function. function for curve</param>
        /// <param name="lowerBound">double. lowerBound is lower bound of integral</param>
        /// <param name="upperBound">double. upperBound is lower bound of integral</param>
        /// <param name="accuracy">double. accuracy is the value of corvergence tolerance</param>
        /// <returns>The area under the curve</returns>
        public static double SimpsonsRule(BaseFunction function,
            double lowerBound, double upperBound, double accuracy)
        {

            double dx = upperBound - lowerBound;
            double value, oldValue, sum, scale;
            double valueSimpson, oldValueSimpson;
            int maxIter = 20;

            //  Set initial values for the trapezoidal
            //  method (value) and Simpson's rule (valueSimpson)

            value = 0.5 * dx * (function.Value(lowerBound) +
                           function.Value(upperBound));
            valueSimpson = double.MaxValue;

            //  Subdivide the integration range by adding more
            //  points. Recompute the extended trapezoidal value
            //  and the Simpson's rule value. If the Simpson's
            //  rule value convergences, return the value.

            for (int i = 0; i < maxIter; ++i)
            {
                sum = 0.0;
                scale = Math.Pow(0.5, i + 1);
                for (int j = 0; j < Math.Pow(2, i); ++j)
                {
                    sum += function.Value(
                    lowerBound + scale * (2 * j + 1.0) * dx);
                }

                oldValue = value;
                value = 0.5 * value + scale * dx * sum;
                oldValueSimpson = valueSimpson;
                valueSimpson = (4.0 * value - oldValue) / 3.0;

                if (Math.Abs(valueSimpson - oldValueSimpson) <=
                    accuracy * Math.Abs(oldValueSimpson))
                {
                    return valueSimpson;
                }
            }
            //  Solution did not convergence
            return value; ;
        }
        /// <summary>
        /// This function return the area under curve using MidPoint rule
        /// </summary>
        /// <param name="function">Function. function for curve</param>
        /// <param name="lowerBound">double. lowerBound is lower bound of integral</param>
        /// <param name="upperBound">double. upperBound is lower bound of integral</param>
        /// <param name="accuracy">double. accuracy is the value of corvergence tolerance</param>
        /// <returns>The area under the curve</returns>
        public static double MidPoint(BaseFunction function,
            double lowerBound, double upperBound, double accuracy)
        {
            double dx = upperBound - lowerBound;
            double value, oldValue, sum, temp;
            double scale = 1.0 / 3.0;
            int numPoints, numPairs;
            int maxIter = 20;

            //  Start with a two-point midpoint
            //  evaluation.

            value = 0.5 * dx * (function.Value(lowerBound + 0.25 * dx) +
                function.Value(upperBound - 0.25 * dx));

            //  Refine the solution by adding points to the
            //  integration domain. Each iteration adds three
            //  times as many points as the previous iteration.
            //  When the solution convergences, return the result.

            for (int i = 0; i < maxIter; ++i)
            {
                numPoints = 4 * (int)Math.Pow(3, i);
                numPairs = (numPoints - 2) / 2;
                temp = 1.0 / (3.0 * numPoints);

                //  Add the two endpoint values to the sum

                sum = function.Value(lowerBound + temp * dx) +
                    function.Value(upperBound - temp * dx);

                //  Add in each pair to the sum

                for (int j = 0; j < numPairs; ++j)
                {
                    sum = sum +
                    function.Value(lowerBound + (6 * j + 5) * temp * dx) +
                    function.Value(lowerBound + (6 * j + 7) * temp * dx);
                }

                oldValue = value;
                value = value / 3.0 + 0.5 * Math.Pow(scale, i + 1) * dx * sum;

                if (Math.Abs(value - oldValue) <=
                    accuracy * Math.Abs(oldValue))
                {
                    return value;
                }
            }
            //  Solution did not convergence
            return value; ;
        }
        /// <summary>
        /// This function return the area under curve using Gauss Legendre rule
        /// </summary>
        /// <param name="function">Function. function for curve</param>
        /// <param name="lowerBound">double. lowerBound is lower bound of integral</param>
        /// <param name="upperBound">double. upperBound is lower bound of integral</param>
        /// <param name="accuracy">double. accuracy is the value of corvergence tolerance</param>
        /// <returns>The area under the curve</returns>
        public static double GaussLegendre(BaseFunction function,
            double lowerBound, double upperBound, double accuracy)
        {

            double dx = upperBound - lowerBound;
            double value = 1.0e+10;
            double oldValue;
            int numPoints = 10;
            int maxPoints = 10000;
            double[] x = new double[maxPoints];
            double[] w = new double[maxPoints];

            //  Compute the integral value adding points
            //  until the solution convergences or maxPoints
            //  is reached.

            do
            {

                //  Calculate the Gauss-Legendre weights and
                //  abscissas

                computeGaussWeights(x, w, numPoints);

                //  Compute the integral value by summing up the
                //  weights times the function value at each
                //  abscissa

                oldValue = value;

                value = 0.0;
                for (int i = 0; i < numPoints; ++i)
                {
                    value += w[i] * function.Value(lowerBound + x[i] * dx);
                }
                value *= dx;

                //  If the solution is convergences, return the
                //  value. Otherwise, double the points in the
                //  integration domain and try again.

                if (Math.Abs(value - oldValue) <=
                    accuracy * Math.Abs(oldValue))
                {
                    return value;
                }

                numPoints *= 2;
            } while (numPoints < maxPoints);
            //  Solution did not convergence
            return value; ;
        }
        /// <summary>
        /// This function compute weights and abcissas for 
        /// Legendre polynomial using Newton's method
        /// </summary>
        /// <param name="x">double[]. x is abcissas</param>
        /// <param name="w">double[]. w is weights</param>
        /// <param name="numPoints">int. number of point</param>
        private static void computeGaussWeights(
            double[] x, double[] w, int numPoints) {
        
            int i,j,m;
            double z, zOld, root, p3, p2, p1;
            double EPS = 1.0e-10; // double.Epsilon approximation

            //  The weights and abscissa values are normalized
            //  for an integration range between 0 and 1. The
            //  values are symmetric about x=0.5 so we only
            //  have to compute half of them.

            m = (numPoints + 1)/2;

            //  Compute the Legendre polynomial, p1, at point
            //  z using Newton's method.

            for(i=0; i<m; ++i) {
                z = Math.Cos(Math.PI*(i+0.75)/(numPoints+0.5));
                do {
                    p1 = 1.0;
                    p2 = 0.0;
                    for(j=0; j<numPoints; ++j) {
                        p3 = p2;
                        p2 = p1;
                        p1 = ((2.0*(j+1) - 1.0)*z*p2 - j*p3)/(j+1.0);
                    }
                    root = numPoints*(z*p1 - p2)/(z*z - 1.0);
                    zOld = z;
                    z = zOld - p1/root;
                } while ( Math.Abs(z-zOld) > EPS);

                //  Compute the weights and abscissas. The values
                //  are symmetric about the point z=0.5

                x[i] = 0.5*(1.0 - z);
                x[numPoints-1-i] = 0.5*(1.0 + z);
                w[i] = 1.0/((1.0- z*z)*root*root);
                w[numPoints-1-i] = w[i];
            }
        }
    }
}
