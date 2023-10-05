using NWhen.Exceptions;

namespace NWhen.Tests.Components
{
    public class HourTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(23)]
        public void ShouldAllowCorrectValues(int hour)
        {
            var sut = new Hour(hour);

            sut.Value.Should().Be(hour);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(24)]
        [InlineData(1000)]
        [InlineData(-60)]
        public void ShouldFailWhenProvidedWithAnIncorrectValue(int hour)
        {
            var action = () => new Hour(hour);
            action.Should().Throw<InvalidHourException>();
        }

        [Fact]
        public void ShouldHaveAnImplicitOperatorFromString()
        {
            var hour = 10;
            Hour sut = hour;

            sut.Value.Should().Be(hour);
        }
    }
}
