using System;

namespace NWhen.Components.Base;

public abstract class CustomValidationComponent<TValue, TException>(TValue value) : Component<TValue, TException>(value)
    where TException : ArgumentException
{
    protected override abstract bool IsValid(TValue value);

    protected override string GetErrorMessage(TValue value) => $"{value} is an invalid value.";
}
