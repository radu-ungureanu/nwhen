using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class Frequency(string frequency) : AvailableValuesComponent<InvalidFrequencyException>(frequency)
{
    public override string[] AvailableValues =>
    [
        "secondly",
        "minutely",
        "hourly",
        "daily",
        "weekly",
        "monthly",
        "yearly"
    ];

    public static implicit operator Frequency(string frequency) => new(frequency);
}
