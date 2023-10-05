using NWhen.Exceptions;

namespace NWhen.Tests.Components
{
    public class SecondTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(60)]
        public void ShouldAllowCorrectValues(int second)
        {
            var sut = new Second(second);

            sut.Value.Should().Be(second);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(90)]
        [InlineData(-60)]
        public void ShouldFailSetupFrequencyWhenProvidedWithAnIncorrectValue(int second)
        {
            var action = () => new Second(second);
            action.Should().Throw<InvalidSecondException>();
        }

        [Fact]
        public void ShouldHaveAnImplicitOperatorFromString()
        {
            var second = 10;
            Second sut = second;

            sut.Value.Should().Be(second);
        }
    }
}
