using System;

namespace NWhen.Exceptions
{
    public class InvalidMinuteException : ArgumentException
    {
        public InvalidMinuteException(string message) : base(message) { }
    }
}
