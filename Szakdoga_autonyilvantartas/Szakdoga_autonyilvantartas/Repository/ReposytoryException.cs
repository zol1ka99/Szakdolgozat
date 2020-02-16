using System;
using System.Runtime.Serialization;

namespace Szakdoga_autonyilvantartas.Repository
{
    [Serializable]
    internal class ReposytoryException : Exception
    {
        public ReposytoryException()
        {
        }

        public ReposytoryException(string message) : base(message)
        {
        }

        public ReposytoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReposytoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}