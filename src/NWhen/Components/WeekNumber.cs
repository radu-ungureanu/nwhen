using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class WeekNumber(int weekNumber) : PositiveAndNegativeBetweenComponent<InvalidWeekNumberException>(weekNumber)
{
    protected override int MinValue => 1;

    protected override int MaxValue => 53;

    public static implicit operator WeekNumber(int weekNumber) => new(weekNumber);
}
