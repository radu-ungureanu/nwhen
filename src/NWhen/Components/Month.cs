using NWhen.Exceptions;

namespace NWhen.Components;

public class Month(int month) : BetweenComponent<InvalidMonthException>(month)
{
    protected override int MinValue => 1;

    protected override int MaxValue => 12;

    protected override int[] Except => [];

    public static implicit operator Month(int month) => new(month);

    public override InvalidMonthException ThrowWhenInvalid(string message) => new(message);
}
