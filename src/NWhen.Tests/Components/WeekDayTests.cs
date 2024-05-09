using NWhen.Components;
using NWhen.Exceptions;

namespace NWhen.Tests.Components
{
    public class WeekDayTests
    {
        [Theory]
        [InlineData("SU")]
        [InlineData("MO")]
        [InlineData("tu")]
        [InlineData("We")]
        [InlineData("th")]
        [InlineData("FR")]
        [InlineData("sa")]
        public void ShouldAllowCaseInsensitiveCorrectValues(string weekDay)
        {
            var sut = new WeekDay(weekDay);

            sut.Value.Should().Be(weekDay.ToLower());
        }

        [Theory]
        [InlineData("va")]
        public void ShouldFailWhenProvidedWithAnIncorrectValue(string weekDay)
        {
            var action = () => new WeekDay(weekDay);
            action.Should().Throw<InvalidWeekDayException>();
        }

        [Fact]
        public void ShouldHaveAnImplicitOperatorFromString()
        {
            var weekDay = "su";
            WeekDay sut = weekDay;

            sut.Value.Should().Be(weekDay);
        }
    }
}
