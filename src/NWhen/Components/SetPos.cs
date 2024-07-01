using NWhen.Components.Base;
using NWhen.Exceptions;

namespace NWhen.Components;

public class SetPos(int setPos) : PositiveAndNegativeBetweenComponent<InvalidSetPosException>(setPos)
{
    protected override int MinValue => 1;

    protected override int MaxValue => 366;

    public static implicit operator SetPos(int setPos) => new(setPos);
}
