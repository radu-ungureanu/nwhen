using System;

namespace NWhen.Exceptions
{
    public class InvalidFrequencyException : ArgumentException
    {
        public InvalidFrequencyException(string message) : base(message) { }
    }
}
