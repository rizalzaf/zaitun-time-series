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
    /// Class that provides methods to
    /// compute Fisher Function
    /// (c) anasikova 2009
    /// </summary>
    public class FisherFunction : BaseFunction
    {
        // the number degree of freedom
        private int k1, k2;
        /// <summary>
        /// Constructor of FisherFunction class
        /// </summary>
        /// <param name="k1">
        /// double. k1 is number degree of freedom for first random variable.
        /// </param>
        /// <param name="k2">
        /// double. k2 is number degree of freedom for second random variable.
        /// </param>
        public FisherFunction(int k1, int k2)
        {
            this.k1 = k1;
            this.k2 = k2;
        }
        /// <summary>
        /// This function return the value of FisherFunction for given x
        /// </summary>
        /// <param name="x">double. x</param>
        /// <returns>
        /// The value of FisherFunction for given x
        /// </returns>
        public override double Value(double x)
        {
            double GpG, result;
            int k1plusk2 = this.k1 + this.k2;
            GammaFunction function = new GammaFunction();
            GpG = function.Value(0.5 * k1plusk2) /
                (function.Value(0.5 * this.k1) * function.Value(0.5 * this.k2));
            result = GpG * Math.Pow(this.k1, 0.5 * this.k1) * Math.Pow(this.k2, 0.5 * this.k2);
            result *= Math.Pow(x, 0.5 * this.k1 - 1.0) * Math.Pow(this.k2 + this.k1 * x, -0.5 * k1plusk2);
            return result;
        }
    }
}
