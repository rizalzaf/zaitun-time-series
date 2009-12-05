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
using System.Runtime.Serialization;

namespace zaitun.MatrixVector
{
    [Serializable]
    public class MatrixException: ApplicationException
    {
        #region Constructors
        public MatrixException()
        { }
        public MatrixException(string message)
            : base(message)
        { }
        public MatrixException(string message, Exception inner)
            : base(message, inner)
        { }
        protected MatrixException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class NonSquareMatrixException : MatrixException
    {
        #region Constructors
        public NonSquareMatrixException()
        { }
        public NonSquareMatrixException(string message)
            : base(message)
        { }
        public NonSquareMatrixException(string message, Exception inner)
            : base(message, inner)
        { }
        protected NonSquareMatrixException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class WrongMatrixSizeException : MatrixException
    {
        #region Constructors
        public WrongMatrixSizeException()
        { }
        public WrongMatrixSizeException(string message)
            : base(message)
        { }
        public WrongMatrixSizeException(string message, Exception inner)
            : base(message, inner)
        { }
        protected WrongMatrixSizeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class NotSameSizeMatrixException : MatrixException
    {
        #region Constructors
        public NotSameSizeMatrixException()
        { }
        public NotSameSizeMatrixException(string message)
            : base(message)
        { }
        public NotSameSizeMatrixException(string message, Exception inner)
            : base(message, inner)
        { }
        protected NotSameSizeMatrixException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class SingularMatrixException : MatrixException
    {
        #region Constructors
        public SingularMatrixException()
        { }
        public SingularMatrixException(string message)
            : base(message)
        { }
        public SingularMatrixException(string message, Exception inner)
            : base(message, inner)
        { }
        protected SingularMatrixException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class VectorException: ApplicationException
    {
        #region Constructors
        public VectorException()
        { }
        public VectorException(string message)
            : base(message)
        { }
        public VectorException(string message, Exception inner)
            : base(message, inner)
        { }
        protected VectorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class NotSameSizeVectorException : VectorException
    {
        #region Constructors
        public NotSameSizeVectorException()
        { }
        public NotSameSizeVectorException(string message)
            : base(message)
        { }
        public NotSameSizeVectorException(string message, Exception inner)
            : base(message, inner)
        { }
        protected NotSameSizeVectorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class WrongVectorSizeException : VectorException
    {
        #region Constructors
        public WrongVectorSizeException()
        { }
        public WrongVectorSizeException(string message)
            : base(message)
        { }
        public WrongVectorSizeException(string message, Exception inner)
            : base(message, inner)
        { }
        protected WrongVectorSizeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class WrongVectorTypeException : VectorException
    {
        #region Constructors
        public WrongVectorTypeException()
        { }
        public WrongVectorTypeException(string message)
            : base(message)
        { }
        public WrongVectorTypeException(string message, Exception inner)
            : base(message, inner)
        { }
        protected WrongVectorTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class WrongVectorSizeOrTypeException : VectorException
    {
        #region Constructors
        public WrongVectorSizeOrTypeException()
        { }
        public WrongVectorSizeOrTypeException(string message)
            : base(message)
        { }
        public WrongVectorSizeOrTypeException(string message, Exception inner)
            : base(message, inner)
        { }
        protected WrongVectorSizeOrTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }
}
