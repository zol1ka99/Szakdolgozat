using System;
using System.Runtime.Serialization;

namespace Szakdoga_autonyilvantartas.Model
{
    [Serializable]
    public class ModelCarDateTimeException : Exception
    {
        public ModelCarDateTimeException()
        {
        }

        public ModelCarDateTimeException(string message) : base(message)
        {
        }

        public ModelCarDateTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelCarDateTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}