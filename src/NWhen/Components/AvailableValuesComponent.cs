using System;
using System.Linq;

namespace NWhen.Components
{
    public abstract class AvailableValuesComponent<TException>
        where TException : ArgumentException
    {
        public abstract string[] AvailableValues { get; }

        public string Value { get; }

        public AvailableValuesComponent(string value)
        {
            value = value.ToLower();
            if (!AvailableValues.Contains(value))
                throw ThrowWhenInvalid($"{value} is an invalid value. Allowed values: {string.Join(", ", AvailableValues)}.");

            Value = value;
        }

        public abstract TException ThrowWhenInvalid(string message);
    }
}
