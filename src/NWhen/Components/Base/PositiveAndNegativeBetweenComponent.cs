using System;

namespace NWhen.Components.Base;

public abstract class PositiveAndNegativeBetweenComponent<TException>(int value) : BetweenComponent<TException>(value)
    where TException : ArgumentException
{
    protected override bool IsValid(int value) => Math.Abs(value) >= MinValue && Math.Abs(value) <= MaxValue;

    protected override string GetErrorMessage(int value) => $"{value} is an invalid value. Allowed positive and negative values between {MinValue} and {MaxValue}";
}
