using NWhen.Exceptions;

namespace NWhen
{
    public class Second
    {
        public int Value { get; }

        public Second(int second)
        {
            if (!IsValid(second))
                throw new InvalidSecondException($"{second} is an invalid value. Allowed values between 0 and 60.");

            Value = second;
        }

        private static bool IsValid(int second) => second >= 0 && second <= 60;

        public static implicit operator Second(int second) => new Second(second);
    }
}
