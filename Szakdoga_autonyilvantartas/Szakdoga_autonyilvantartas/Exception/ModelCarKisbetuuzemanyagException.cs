using System;
using System.Runtime.Serialization;

namespace Szakdoga_autonyilvantartas.Model
{
    [Serializable]
    public class ModelCarKisbetuuzemanyagException : Exception
    {
        public ModelCarKisbetuuzemanyagException()
        {
        }

        public ModelCarKisbetuuzemanyagException(string message) : base(message)
        {
        }

        public ModelCarKisbetuuzemanyagException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelCarKisbetuuzemanyagException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}