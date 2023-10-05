using NWhen.Exceptions;
using System.Linq;

namespace NWhen
{
    public class Frequency
    {
        private static readonly string[] _allowedValues = new[]
        {
            "secondly",
            "minutely",
            "hourly",
            "daily",
            "weekly",
            "monthly",
            "yearly"
        };

        public string Value { get; }

        public Frequency(string frequency)
        {
            frequency = frequency.ToLower();
            if (!_allowedValues.Contains(frequency))
                throw new InvalidFrequencyException($"{frequency} is an invalid value. Allowed values: {string.Join(", ", _allowedValues)}.");

            Value = frequency;
        }

        public static implicit operator Frequency(string frequency) => new Frequency(frequency);
    }
}
