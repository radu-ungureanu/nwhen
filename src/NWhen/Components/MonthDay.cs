using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class MonthDay(int monthDay) : PositiveAndNegativeBetweenComponent<InvalidMonthDayException>(monthDay)
{
    protected override int MinValue => 1;

    protected override int MaxValue => 31;

    public static implicit operator MonthDay(int monthDay) => new(monthDay);
}
