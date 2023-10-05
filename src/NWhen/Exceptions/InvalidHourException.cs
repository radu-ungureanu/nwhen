using System;

namespace NWhen.Exceptions
{
    public class InvalidHourException : ArgumentException
    {
        public InvalidHourException(string message) : base(message) { }
    }
}
