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
