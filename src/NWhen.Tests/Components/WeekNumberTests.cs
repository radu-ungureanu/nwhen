namespace NWhen.Tests.Components;

public class WeekNumberTests
{
    [Theory]
    [InlineData(-53)]
    [InlineData(-12)]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(12)]
    [InlineData(52)]
    public void ShouldAllowCorrectValues(int weekNumber)
    {
        var sut = new WeekNumber(weekNumber);

        sut.Value.Should().Be(weekNumber);
    }

    [Theory]
    [InlineData(-54)]
    [InlineData(0)]
    [InlineData(54)]
    [InlineData(55)]
    [InlineData(93)]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(int weekNumber)
    {
        var action = () => new WeekNumber(weekNumber);
        action.Should().Throw<InvalidWeekNumberException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromInt()
    {
        var weekNumber = 10;
        WeekNumber sut = weekNumber;

        sut.Value.Should().Be(weekNumber);
    }
}
