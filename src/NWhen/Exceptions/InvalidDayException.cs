using System;

namespace NWhen.Exceptions
{
    public class InvalidDayException : ArgumentException
    {
       public InvalidDayException(string message) : base(message) { }
    }
}
