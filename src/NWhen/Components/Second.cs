﻿using NWhen.Exceptions;

namespace NWhen.Components;

public class Second(int second) : BetweenComponent<InvalidSecondException>(second)
{
    protected override int MinValue => 0;

    // TODO: shouldn't this be between 0 and 59?
    protected override int MaxValue => 60;

    protected override int[] Except => [];

    public static implicit operator Second(int second) => new(second);

    public override InvalidSecondException ThrowWhenInvalid(string message) => new(message);
}
