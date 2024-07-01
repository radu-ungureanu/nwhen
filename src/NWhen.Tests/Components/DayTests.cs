namespace NWhen.Tests.Components;

public class DayTests
{
    [Theory]
    [InlineData("-52MO", "-52mo")]
    [InlineData("-52Mo", "-52mo")]
    [InlineData("-20MO", "-20mo")]
    [InlineData("-10MO", "-10mo")]
    [InlineData("-2TU", "-2tu")]
    [InlineData("-2tU", "-2tu")]
    [InlineData("0TU", "0tu")]
    [InlineData("SA", "0sa")]
    [InlineData("+1WE", "1we")]
    [InlineData("+5MO", "5mo")]
    [InlineData("+5mo", "5mo")]
    [InlineData("31TU", "31tu")]
    [InlineData("31tU", "31tu")]
    [InlineData("40TU", "40tu")]
    public void ShouldAllowCaseInsensitiveCorrectValues(string day, string expected)
    {
        var sut = new Day(day);

        sut.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData("-92SA")]
    [InlineData("-54mo")]
    [InlineData("-54TA")]
    [InlineData("+1WA")]
    [InlineData("-asdf")]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(string day)
    {
        var action = () => new Day(day);
        action.Should().Throw<InvalidDayException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromString()
    {
        var day = "0sa";
        Day sut = day;

        sut.Value.Should().Be(day);
    }
}
