using System;

namespace NWhen.Exceptions
{
    public class InvalidWeekDayException : ArgumentException
    {
       public InvalidWeekDayException(string message) : base(message) { }
    }
}
