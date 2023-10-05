using NWhen.Exceptions;

namespace NWhen.Tests.Components
{
    public class DayTests
    {
        [Theory]
        [InlineData("SU")]
        [InlineData("MO")]
        [InlineData("tu")]
        [InlineData("We")]
        [InlineData("th")]
        [InlineData("FR")]
        [InlineData("sa")]
        public void ShouldAllowCaseInsensitiveCorrectValues(string day)
        {
            var sut = new Day(day);

            sut.Value.Should().Be(day.ToLower());
        }

        [Theory]
        [InlineData("va")]
        public void ShouldFailWhenProvidedWithAnIncorrectValue(string day)
        {
            var action = () => new Day(day);
            action.Should().Throw<InvalidDayException>();
        }

        [Fact]
        public void ShouldHaveAnImplicitOperatorFromString()
        {
            var day = "su";
            Day sut = day;

            sut.Value.Should().Be(day);
        }
    }
}
