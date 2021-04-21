using System;

namespace vigalileo.Utilities.Exceptions
{
    public class ViException : Exception
    {
        public ViException()
        {
        }

        public ViException(string message)
            : base(message)
        {
        }

        public ViException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}