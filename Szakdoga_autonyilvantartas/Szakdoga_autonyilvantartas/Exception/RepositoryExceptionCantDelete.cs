using System;
using System.Runtime.Serialization;

namespace Szakdoga_autonyilvantartas.Repository
{
    [Serializable]
    internal class RepositoryExceptionCantDelete : Exception
    {
        public RepositoryExceptionCantDelete()
        {
        }

        public RepositoryExceptionCantDelete(string message) : base(message)
        {
        }

        public RepositoryExceptionCantDelete(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RepositoryExceptionCantDelete(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}