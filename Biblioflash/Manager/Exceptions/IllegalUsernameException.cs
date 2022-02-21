using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Biblioflash.Manager.Exceptions
{
    [Serializable]
    public class IllegalUsernameException : Exception
    {
        public IllegalUsernameException()
        {
        }

        public IllegalUsernameException(string message) : base(message)
        {
        }

        public IllegalUsernameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalUsernameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
