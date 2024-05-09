using NWhen.Exceptions;

namespace NWhen.Components;

// Accepts positive and negative values between 1 and 31
public class MonthDay(int monthDay) : BetweenComponent<InvalidMonthDayException>(monthDay)
{
    protected override int MinValue => -31;

    protected override int MaxValue => 31;

    protected override int[] Except => [0];

    public static implicit operator MonthDay(int monthDay) => new(monthDay);

    public override InvalidMonthDayException ThrowWhenInvalid(string message) => new(message);
}
