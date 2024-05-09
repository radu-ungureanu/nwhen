using NWhen.Exceptions;

namespace NWhen.Components;

public class Hour(int hour) : BetweenComponent<InvalidHourException>(hour)
{
    public override int MinValue => 0;

    public override int MaxValue => 23;

    public static implicit operator Hour(int hour) => new(hour);

    public override InvalidHourException ThrowWhenInvalid(string message) => new(message);
}
