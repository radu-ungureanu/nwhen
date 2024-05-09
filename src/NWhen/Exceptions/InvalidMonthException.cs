using System;

namespace NWhen.Exceptions;

public class InvalidMonthException(string message) : ArgumentException(message)
{
}
