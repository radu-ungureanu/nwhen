using NWhen.Exceptions;

namespace NWhen
{
    public class Hour
    {
        private const int _minValue = 0;
        private const int _maxValue = 23;

        public int Value { get; }

        public Hour(int hour)
        {
            if (!IsValid(hour))
                throw new InvalidHourException($"{hour} is an invalid value. Allowed values between {_minValue} and {_maxValue}.");

            Value = hour;
        }

        private static bool IsValid(int hour) => hour >= _minValue && hour <= _maxValue;

        public static implicit operator Hour(int hour) => new Hour(hour);
    }
}
