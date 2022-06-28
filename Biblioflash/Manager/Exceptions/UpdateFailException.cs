using System;
using System.Runtime.Serialization;

namespace Biblioflash.Manager.Exceptions
{
    [Serializable]
    public class UpdateFailException : Exception
    {
        public UpdateFailException()
        {
        }

        public UpdateFailException(string message) : base(message)
        {
        }

        public UpdateFailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdateFailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
