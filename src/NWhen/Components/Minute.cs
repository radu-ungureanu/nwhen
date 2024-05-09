using NWhen.Exceptions;

namespace NWhen.Components;

public class Minute(int minute) : BetweenComponent<InvalidMinuteException>(minute)
{
    public override int MinValue => 0;

    public override int MaxValue => 59;

    public static implicit operator Minute(int minute) => new(minute);

    public override InvalidMinuteException ThrowWhenInvalid(string message) => new(message);
}
