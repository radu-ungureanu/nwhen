using NWhen.Exceptions;

namespace NWhen.Components;

public class WeekDay(string day) : AvailableValuesComponent<InvalidWeekDayException>(day)
{
    public override string[] AvailableValues => ["su", "mo", "tu", "we", "th", "fr", "sa"];

    public static implicit operator WeekDay(string day) => new(day);

    public override InvalidWeekDayException ThrowWhenInvalid(string message) => new(message);
}
