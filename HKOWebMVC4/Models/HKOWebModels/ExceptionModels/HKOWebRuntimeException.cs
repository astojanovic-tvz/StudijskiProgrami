using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HKOWebMVC4.Models.HKOWebModels.ExceptionModels
{
    [Serializable]
    public class HKOWebRuntimeException : System.Exception
    {
        public HKOWebRuntimeException()
        { }
        public HKOWebRuntimeException(string message)
            : base(message)
        { }
        public HKOWebRuntimeException(string message, Exception innerException)
            : base(message, innerException)
        { }
        protected HKOWebRuntimeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}