using NWhen.Components;
using NWhen.Exceptions;

namespace NWhen.Tests.Components;

public class SecondTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(59)]
    [InlineData(60)]
    public void ShouldAllowCorrectValues(int second)
    {
        var sut = new Second(second);

        sut.Value.Should().Be(second);
    }

    [Theory]
    [InlineData(-60)]
    [InlineData(-1)]
    [InlineData(61)]
    [InlineData(65)]
    [InlineData(90)]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(int second)
    {
        var action = () => new Second(second);
        action.Should().Throw<InvalidSecondException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromInt()
    {
        var second = 10;
        Second sut = second;

        sut.Value.Should().Be(second);
    }
}
