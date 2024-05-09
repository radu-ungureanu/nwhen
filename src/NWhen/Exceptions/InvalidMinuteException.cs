using System;

namespace NWhen.Exceptions;

public class InvalidMinuteException(string message) : ArgumentException(message)
{
}
