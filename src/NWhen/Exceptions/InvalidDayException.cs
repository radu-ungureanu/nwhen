using System;

namespace NWhen.Exceptions;

public class InvalidDayException(string message) : ArgumentException(message)
{
}
