using System;

namespace NWhen.Components.Base;

public abstract class CustomStringValidationComponent<TException>(string value) : CustomValidationComponent<string, TException>(value)
    where TException : ArgumentException
{
}
