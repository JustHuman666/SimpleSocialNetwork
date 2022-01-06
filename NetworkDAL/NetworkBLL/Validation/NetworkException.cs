using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NetworkBLL.Validation
{
    [Serializable()]
    public class NetworkException : Exception
    {
        public NetworkException() : base() { }

        public NetworkException(string message) : base(message) { }

        public NetworkException(string message, Exception inner) : base(message, inner) { }

        protected NetworkException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
