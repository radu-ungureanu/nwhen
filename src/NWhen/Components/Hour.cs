using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class Hour(int hour) : BetweenComponent<InvalidHourException>(hour)
{
    protected override int MinValue => 0;

    protected override int MaxValue => 23;

    public static implicit operator Hour(int hour) => new(hour);
}
