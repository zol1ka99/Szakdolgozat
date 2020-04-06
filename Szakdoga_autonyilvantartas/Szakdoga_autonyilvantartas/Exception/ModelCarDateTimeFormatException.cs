using System;
using System.Runtime.Serialization;

namespace Szakdoga_autonyilvantartas.Model
{
    [Serializable]
    public class ModelCarDateTimeFormatException : Exception
    {
        public ModelCarDateTimeFormatException()
        {
        }

        public ModelCarDateTimeFormatException(string message) : base(message)
        {
        }

        public ModelCarDateTimeFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelCarDateTimeFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}