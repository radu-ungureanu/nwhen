using System;
using System.Linq;

namespace NWhen.Components.Base;

public abstract class AvailableValuesComponent<TException>(string value) : Component<string, TException>(value)
    where TException : ArgumentException
{
    public abstract string[] AvailableValues { get; }

    protected override bool IsValid(string value) => AvailableValues.Any(v => v.Equals(value, StringComparison.OrdinalIgnoreCase));

    protected override string TransformValue(string value) => value.ToLower();

    protected override string GetErrorMessage(string value) => $"{value} is an invalid value. Allowed values: {string.Join(", ", AvailableValues)}.";
}
