namespace NWhen;

public class InvalidCombinationException : Exception
{
    public InvalidCombinationException(string message = "Invalid combination.") : base(message) { }
}

public class FrequencyRequiredException : Exception
{
    public FrequencyRequiredException(string message = "You are required to set a frequency.") : base(message) { }
}

public class InvalidStartDateException : Exception
{
    public InvalidStartDateException(string message = "The start date must be the first occurrence.") : base(message) { }
}
