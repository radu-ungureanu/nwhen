using NWhen.Exceptions;

namespace NWhen
{
    public class Second
    {
        private const int _minValue = 0;
        // TODO: shouldn't this be between 0 and 59?
        private const int _maxValue = 60;

        public int Value { get; }

        public Second(int second)
        {
            if (!IsValid(second))
                throw new InvalidSecondException($"{second} is an invalid value. Allowed values between {_minValue} and {_maxValue}.");

            Value = second;
        }

        private static bool IsValid(int second) => second >= _minValue && second <= _maxValue;

        public static implicit operator Second(int second) => new Second(second);
    }
}
