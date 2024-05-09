using NWhen.Exceptions;

namespace NWhen.Components;

public class Hour(int hour) : BetweenComponent<InvalidHourException>(hour)
{
    protected override int MinValue => 0;

    protected override int MaxValue => 23;

    protected override int[] Except => [];

    public static implicit operator Hour(int hour) => new(hour);

    public override InvalidHourException ThrowWhenInvalid(string message) => new(message);
}
