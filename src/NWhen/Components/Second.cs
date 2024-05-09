using NWhen.Exceptions;

namespace NWhen.Components;

public class Second(int second) : BetweenComponent<InvalidSecondException>(second)
{
    public override int MinValue => 0;

    // TODO: shouldn't this be between 0 and 59?
    public override int MaxValue => 60;

    public static implicit operator Second(int second) => new(second);

    public override InvalidSecondException ThrowWhenInvalid(string message) => new(message);
}
