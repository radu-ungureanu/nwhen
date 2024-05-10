using System;

namespace NWhen.Exceptions;

public class InvalidWeekNumberException(string message) : ArgumentException(message)
{
}
