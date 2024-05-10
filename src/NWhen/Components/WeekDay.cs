using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class WeekDay(string weekDay) : AvailableValuesComponent<InvalidWeekDayException>(weekDay)
{
    public override string[] AvailableValues => ["su", "mo", "tu", "we", "th", "fr", "sa"];

    public static implicit operator WeekDay(string weekDay) => new(weekDay);
}
