using NWhen.Exceptions;

namespace NWhen.Tests.Components
{
    public class FrequencyTests
    {
        [Theory]
        [InlineData("secondly")]
        [InlineData("Secondly")]
        [InlineData("minuTely")]
        [InlineData("HOURLY")]
        [InlineData("daily")]
        [InlineData("weekly")]
        [InlineData("monthly")]
        [InlineData("yearly")]
        public void ShouldAllowCaseInsensitiveCorrectValues(string frequency)
        {
            var sut = new Frequency(frequency);

            sut.Value.Should().Be(frequency.ToLower());
        }

        [Theory]
        [InlineData("month")]
        [InlineData("monthy")]
        public void ShouldFailWhenProvidedWithAnIncorrectValue(string frequency)
        {
            var action = () => new Frequency(frequency);
            action.Should().Throw<InvalidFrequencyException>();
        }

        [Fact]
        public void ShouldHaveAnImplicitOperatorFromString()
        {
            var frequency = "daily";
            Frequency sut = frequency;

            sut.Value.Should().Be(frequency);
        }
    }
}
