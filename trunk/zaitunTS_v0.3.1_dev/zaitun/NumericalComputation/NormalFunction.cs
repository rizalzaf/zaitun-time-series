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

namespace zaitun.NumericalComputation
{
    /// <summary>
    /// Class that provides methods to
    /// compute Normal Function
    /// (c) anasikova 2009
    /// </summary>
    public class NormalFunction : BaseFunction
    {
        // value of mean and standard deviation data
        private double mu;
        private double sig;
        /// <summary>
        /// Constructor of NormalFunction class
        /// </summary>
        public NormalFunction()
        {
            this.mu = 0;
            this.sig = 1;
        }
        /// <summary>
        /// Constructor of NormalFunction class with
        /// mean mu and standard deviation sig
        /// </summary>
        /// <param name="mu">double. mu is mean</param>
        /// <param name="sig">double. sig is standard deviation</param>
        public NormalFunction(double mu, double sig)
        {
            this.mu = mu;
            this.sig = sig;
        }
        /// <summary>
        /// This function return the value of NormalFunction
        /// for given x
        /// </summary>
        /// <param name="x">double. x</param>
        /// <returns>
        /// the value of NormalFunction for given x
        /// </returns>
        public override double Value(double x)
        {
            // if mu=0 and sig=1 then x=z
            return (1.0/(this.sig*Math.Sqrt(2.0*Math.PI)))*
                Math.Exp(-1.0*Math.Pow((x-this.mu)/this.sig,2)/2.0);
        }
    }
}
