namespace NWhen.Tests.Components;

public class SetPosTests
{
    [Theory]
    [InlineData(-366)]
    [InlineData(-12)]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(12)]
    [InlineData(150)]
    public void ShouldAllowCorrectValues(int setPos)
    {
        var sut = new SetPos(setPos);

        sut.Value.Should().Be(setPos);
    }

    [Theory]
    [InlineData(-367)]
    [InlineData(0)]
    [InlineData(367)]
    [InlineData(380)]
    [InlineData(399)]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(int setPos)
    {
        var action = () => new SetPos(setPos);
        action.Should().Throw<InvalidSetPosException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromInt()
    {
        var setPos = 10;
        SetPos sut = setPos;

        sut.Value.Should().Be(setPos);
    }
}
