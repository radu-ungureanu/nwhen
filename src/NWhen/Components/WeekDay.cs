using NWhen.Exceptions;

namespace NWhen.Components
{
    public class WeekDay : AvailableValuesComponent<InvalidWeekDayException>
    {
        public override string[] AvailableValues => new[] { "su", "mo", "tu", "we", "th", "fr", "sa" };

        public WeekDay(string day) : base(day) { }

        public static implicit operator WeekDay(string day) => new WeekDay(day);

        public override InvalidWeekDayException ThrowWhenInvalid(string message) => new InvalidWeekDayException(message);
    }
}
