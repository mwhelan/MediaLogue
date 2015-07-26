using System;

namespace MediaLogue.Domain.Exceptions
{
    public class ServerNotAvailableException : Exception
    {
        public ServerNotAvailableException(string message = "Server is currently not available. Please try again later", Exception inner = null)
            : base(message, inner)
        {
        }
    }
}