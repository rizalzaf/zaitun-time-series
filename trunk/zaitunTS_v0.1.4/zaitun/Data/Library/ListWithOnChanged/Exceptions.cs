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
using System.Runtime.Serialization;

namespace zaitun.Data
{
    /// <summary>
    /// Exception yang akan digunakan ListWithOnChanged Class
    /// </summary>
    [Serializable]
    public class Exceptions : ApplicationException 
    {
        #region Constructors
        public Exceptions()
        { }
        public Exceptions(string message) : base(message)
        { }
        public Exceptions(string message, Exception inner)
            : base(message, inner)
        { }
        protected Exceptions(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class NotNowException : Exceptions
    {
        #region Constructors
        public NotNowException()
        { }
        public NotNowException(string message)
            : base(message)
        { }
        public NotNowException(string message, Exception inner)
            : base(message, inner)
        { }
        protected NotNowException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class ListReadOnlyException : NotNowException
    {
        #region Constructors
        public ListReadOnlyException()
        { }
        public ListReadOnlyException(string message)
            : base(message)
        { }
        public ListReadOnlyException(string message, Exception inner)
            : base(message, inner)
        { }
        protected ListReadOnlyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }
}
