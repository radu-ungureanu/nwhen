using System;
using System.Linq;

namespace NWhen.Components.Base;

public abstract class AvailableValuesComponent<TException>(string value) : Component<string, TException>(value.ToLower())
    where TException : ArgumentException
{
    public abstract string[] AvailableValues { get; }

    protected override bool IsValid(string value) => AvailableValues.Contains(value);

    protected override string GetErrorMessage(string value) => $"{value} is an invalid value. Allowed values: {string.Join(", ", AvailableValues)}.";
}
