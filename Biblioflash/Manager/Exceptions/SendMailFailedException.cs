using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Biblioflash.Manager.Exceptions
{
    [Serializable]
    public class SendMailFailedException : Exception
    {
        public SendMailFailedException()
        {
        }

        public SendMailFailedException(string message) : base(message)
        {
        }

        public SendMailFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SendMailFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
