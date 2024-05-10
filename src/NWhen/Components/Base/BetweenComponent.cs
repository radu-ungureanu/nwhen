using System;

namespace NWhen.Components.Base;

public abstract class BetweenComponent<TException>(int value) : Component<int, TException>(value)
    where TException : ArgumentException
{
    protected abstract int MinValue { get; }

    protected abstract int MaxValue { get; }

    protected override bool IsValid(int value) => value >= MinValue && value <= MaxValue;

    protected override string GetErrorMessage(int value) => $"{value} is an invalid value. Allowed values between {MinValue} and {MaxValue}";
}
