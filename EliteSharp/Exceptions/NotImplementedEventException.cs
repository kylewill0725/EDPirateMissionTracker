using System;

namespace EliteSharp.Exceptions
{
    /// <summary>
    /// Thrown when an event is not implemented
    /// </summary>
    public class NotImplementedEventException : Exception
    {
        public NotImplementedEventException()
        {

        }


        public NotImplementedEventException(string message) : base(message)
        {
        }

        public NotImplementedEventException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
