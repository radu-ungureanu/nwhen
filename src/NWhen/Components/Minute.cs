using NWhen.Exceptions;

namespace NWhen.Components;

public class Minute(int minute) : BetweenComponent<InvalidMinuteException>(minute)
{
    protected override int MinValue => 0;

    protected override int MaxValue => 59;

    protected override int[] Except => [];

    public static implicit operator Minute(int minute) => new(minute);

    public override InvalidMinuteException ThrowWhenInvalid(string message) => new(message);
}
