using NWhen.Exceptions;

namespace NWhen.Components
{
    public class Minute : BetweenComponent<InvalidMinuteException>
    {
        public override int MinValue => 0;

        public override int MaxValue => 59;

        public Minute(int minute) : base(minute) { }

        public static implicit operator Minute(int minute) => new Minute(minute);

        public override InvalidMinuteException ThrowWhenInvalid(string message) => new InvalidMinuteException(message);
    }
}
