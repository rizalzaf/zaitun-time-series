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
