using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class YearDay(int yearDay) : PositiveAndNegativeBetweenComponent<InvalidYearDayException>(yearDay)
{
    protected override int MinValue => 1;

    protected override int MaxValue => 366;

    public static implicit operator YearDay(int yearDay) => new(yearDay);
}
