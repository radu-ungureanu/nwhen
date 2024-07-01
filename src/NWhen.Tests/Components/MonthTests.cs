namespace NWhen.Tests.Components;

public class MonthTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(9)]
    [InlineData(12)]
    public void ShouldAllowCorrectValues(int month)
    {
        var sut = new Month(month);

        sut.Value.Should().Be(month);
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(99)]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(int month)
    {
        var action = () => new Month(month);
        action.Should().Throw<InvalidMonthException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromInt()
    {
        var month = 10;
        Month sut = month;

        sut.Value.Should().Be(month);
    }
}
