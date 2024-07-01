using System;

namespace NWhen.Exceptions;

public class InvalidSetPosException(string message) : ArgumentException(message)
{
}
