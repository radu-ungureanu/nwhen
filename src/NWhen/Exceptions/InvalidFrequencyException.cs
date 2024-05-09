using System;

namespace NWhen.Exceptions;

public class InvalidFrequencyException(string message) : ArgumentException(message)
{
}
