using NWhen.Exceptions;

namespace NWhen.Components
{
    public class Frequency : AvailableValuesComponent<InvalidFrequencyException>
    {
        public override string[] AvailableValues => new[]
        {
            "secondly",
            "minutely",
            "hourly",
            "daily",
            "weekly",
            "monthly",
            "yearly"
        };

        public Frequency(string frequency) : base(frequency) { }

        public static implicit operator Frequency(string frequency) => new Frequency(frequency);

        public override InvalidFrequencyException ThrowWhenInvalid(string message) => new InvalidFrequencyException(message);
    }
}
