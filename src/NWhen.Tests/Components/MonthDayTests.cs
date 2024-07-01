namespace NWhen.Tests.Components;

public class MonthDayTests
{
    [Theory]
    [InlineData(-23)]
    [InlineData(-12)]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(12)]
    [InlineData(31)]
    public void ShouldAllowCorrectValues(int monthDay)
    {
        var sut = new MonthDay(monthDay);

        sut.Value.Should().Be(monthDay);
    }

    [Theory]
    [InlineData(-32)]
    [InlineData(0)]
    [InlineData(32)]
    [InlineData(99)]
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
