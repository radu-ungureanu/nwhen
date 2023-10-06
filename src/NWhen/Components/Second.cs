using NWhen.Exceptions;

namespace NWhen.Components
{
    public class Second : BetweenComponent<InvalidSecondException>
    {
        public override int MinValue => 0;

        // TODO: shouldn't this be between 0 and 59?
        public override int MaxValue => 60;

        public Second(int second) : base(second) { }

        public static implicit operator Second(int second) => new Second(second);

        public override InvalidSecondException ThrowWhenInvalid(string message) => new InvalidSecondException(message);
    }
}
