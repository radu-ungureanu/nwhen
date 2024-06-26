﻿using System;

namespace NWhen.Components.Base;

public abstract class Component<TValue, TException>
    where TException : ArgumentException
{
    public TValue Value { get; }

    public Component(TValue value)
    {
        if (!IsValid(value))
        {
            throw (TException)Activator.CreateInstance(typeof(TException), GetErrorMessage(value));
        }

        Value = TransformValue(value);
    }

    protected abstract bool IsValid(TValue value);

    protected virtual TValue TransformValue(TValue value) => value;

    protected abstract string GetErrorMessage(TValue value);
}
