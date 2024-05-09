using System;
using System.Linq;

namespace NWhen.Components;

public abstract class BetweenComponent<TException>
    where TException : ArgumentException
{
    protected abstract int MinValue { get; }
    protected abstract int MaxValue { get; }
    protected abstract int[] Except { get; }
    public int Value { get; }

    protected BetweenComponent(int value)
    {
        if (!IsValid(value))
            throw ThrowWhenInvalid($"{value} is an invalid value. Allowed values between {MinValue} and {MaxValue}.");

        Value = value;
    }

    public bool IsValid(int value) => value >= MinValue && value <= MaxValue && !Except.Contains(value);

    public abstract TException ThrowWhenInvalid(string message);
}
