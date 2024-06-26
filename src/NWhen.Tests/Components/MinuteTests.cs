﻿namespace NWhen.Tests.Components;

public class MinuteTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(21)]
    [InlineData(31)]
    [InlineData(55)]
    [InlineData(59)]
    public void ShouldAllowCorrectValues(int minute)
    {
        var sut = new Minute(minute);

        sut.Value.Should().Be(minute);
    }

    [Theory]
    [InlineData(-60)]
    [InlineData(-1)]
    [InlineData(60)]
    [InlineData(65)]
    [InlineData(99)]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(int minute)
    {
        var action = () => new Minute(minute);
        action.Should().Throw<InvalidMinuteException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromInt()
    {
        var minute = 10;
        Minute sut = minute;

        sut.Value.Should().Be(minute);
    }
}
