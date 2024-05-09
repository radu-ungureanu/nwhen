using NWhen.Exceptions;

namespace NWhen.Components;

// Accepts positive and negative values between 1 and 366
public class YearDay(int yearDay) : BetweenComponent<InvalidYearDayException>(yearDay)
{
    protected override int MinValue => -366;

    protected override int MaxValue => 366;

    protected override int[] Except => [0];

    public static implicit operator YearDay(int yearDay) => new(yearDay);

    public override InvalidYearDayException ThrowWhenInvalid(string message) => new(message);
}
