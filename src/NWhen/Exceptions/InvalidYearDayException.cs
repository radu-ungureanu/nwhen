using System;

namespace NWhen.Exceptions;

public class InvalidYearDayException(string message) : ArgumentException(message)
{
}
