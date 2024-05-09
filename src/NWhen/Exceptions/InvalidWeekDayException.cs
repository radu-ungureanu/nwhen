using System;

namespace NWhen.Exceptions;

public class InvalidWeekDayException(string message) : ArgumentException(message)
{
}
