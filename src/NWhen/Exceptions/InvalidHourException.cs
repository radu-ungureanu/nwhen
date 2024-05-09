using System;

namespace NWhen.Exceptions;

public class InvalidHourException(string message) : ArgumentException(message)
{
}
