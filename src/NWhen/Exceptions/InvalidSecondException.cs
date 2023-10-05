using System;

namespace NWhen.Exceptions
{
    public class InvalidSecondException : ArgumentException
    {
        public InvalidSecondException(string message) : base(message) { }
    }
}
