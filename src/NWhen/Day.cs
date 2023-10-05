using NWhen.Exceptions;
using System.Linq;

namespace NWhen
{
    public class Day
    {
        private static readonly string[] _allowedValues = new[]
        {
            "su",
            "mo",
            "tu",
            "we",
            "th",
            "fr",
            "sa"
        };

        public string Value { get; }

        public Day(string day)
        {
            day = day.ToLower();
            if (!_allowedValues.Contains(day))
                throw new InvalidDayException($"{day} is an invalid value. Allowed values: {string.Join(", ", _allowedValues)}.");

            Value = day;
        }

        public static implicit operator Day(string day) => new Day(day);
    }
}
