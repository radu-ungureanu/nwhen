using NWhen.Components;
using NWhen.Exceptions;

namespace NWhen.Tests.Components;

public class MonthDayTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(31)]
    public void ShouldAllowCorrectValues(int monthDay)
    {
        var sut = new MonthDay(monthDay);

        sut.Value.Should().Be(monthDay);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-32)]
    [InlineData(32)]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(int monthDay)
    {
        var action = () => new MonthDay(monthDay);
        action.Should().Throw<InvalidMonthDayException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromInt()
    {
        var monthDay = 10;
        MonthDay sut = monthDay;

        sut.Value.Should().Be(monthDay);
    }
}
