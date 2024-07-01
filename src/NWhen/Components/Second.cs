using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class Second(int second) : BetweenComponent<InvalidSecondException>(second)
{
    protected override int MinValue => 0;

    protected override int MaxValue => 60;

    public static implicit operator Second(int second) => new(second);
}
