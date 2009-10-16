using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace zaitun.Data
{
    [Serializable]
    public class DuplicateException : ApplicationException
    {
        #region Constructors
        public DuplicateException()
        { }
        public DuplicateException(string message)
            : base(message)
        { }
        public DuplicateException(string message, Exception inner)
            : base(message, inner)
        { }
        protected DuplicateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class DuplicateVariableException : DuplicateException 
    {
        #region Constructors
        public DuplicateVariableException()
        { }
        public DuplicateVariableException(string message) : base(message)
        { }
        public DuplicateVariableException(string message, Exception inner)
            : base(message, inner)
        { }
        protected DuplicateVariableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }

    [Serializable]
    public class DuplicateGroupException : DuplicateException
    {
        #region Constructors
        public DuplicateGroupException()
        { }
        public DuplicateGroupException(string message)
            : base(message)
        { }
        public DuplicateGroupException(string message, Exception inner)
            : base(message, inner)
        { }
        protected DuplicateGroupException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }
}
