using System;

namespace NWhen.Exceptions;

public class InvalidMonthDayException(string message) : ArgumentException(message)
{
}
