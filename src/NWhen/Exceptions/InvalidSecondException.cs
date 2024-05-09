using System;

namespace NWhen.Exceptions;

public class InvalidSecondException(string message) : ArgumentException(message)
{
}
