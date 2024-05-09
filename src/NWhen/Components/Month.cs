using NWhen.Exceptions;

namespace NWhen.Components;

public class Month(int month) : BetweenComponent<InvalidMonthException>(month)
{
    public override int MinValue => 1;

    public override int MaxValue => 12;

    public static implicit operator Month(int month) => new(month);

    public override InvalidMonthException ThrowWhenInvalid(string message) => new(message);
}
