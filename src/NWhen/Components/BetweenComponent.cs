using System;

namespace NWhen.Components;

public abstract class BetweenComponent<TException>
    where TException : ArgumentException
{
    public abstract int MinValue { get; }
    public abstract int MaxValue { get; }
    public int Value { get; }

    protected BetweenComponent(int value)
    {
        if (!IsValid(value))
            throw ThrowWhenInvalid($"{value} is an invalid value. Allowed values between {MinValue} and {MaxValue}.");

        Value = value;
    }

    public bool IsValid(int value) => value >= MinValue && value <= MaxValue;

    public abstract TException ThrowWhenInvalid(string message);
}
