using NWhen.Exceptions;

namespace NWhen.Components
{
    public class Day : AvailableValuesComponent<InvalidDayException>
    {
        public override string[] AvailableValues => new[] { "su", "mo", "tu", "we", "th", "fr", "sa" };

        public Day(string day) : base(day) { }

        public static implicit operator Day(string day) => new Day(day);

        public override InvalidDayException ThrowWhenInvalid(string message) => new InvalidDayException(message);
    }
}
