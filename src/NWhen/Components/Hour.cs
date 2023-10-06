using NWhen.Exceptions;

namespace NWhen.Components
{
    public class Hour : BetweenComponent<InvalidHourException>
    {
        public override int MinValue => 0;

        public override int MaxValue => 23;

        public Hour(int hour) : base(hour) { }

        public static implicit operator Hour(int hour) => new Hour(hour);

        public override InvalidHourException ThrowWhenInvalid(string message) => new InvalidHourException(message);
    }
}
