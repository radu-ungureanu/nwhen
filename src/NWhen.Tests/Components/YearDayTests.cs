﻿namespace NWhen.Tests.Components;

public class YearDayTests
{
    [Theory]
    [InlineData(-366)]
    [InlineData(-12)]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(12)]
    [InlineData(90)]
    public void ShouldAllowCorrectValues(int yearDay)
    {
        var sut = new YearDay(yearDay);

        sut.Value.Should().Be(yearDay);
    }

    [Theory]
    [InlineData(-367)]
    [InlineData(0)]
    [InlineData(367)]
    [InlineData(380)]
    [InlineData(399)]
    public void ShouldFailWhenProvidedWithAnIncorrectValue(int yearDay)
    {
        var action = () => new YearDay(yearDay);
        action.Should().Throw<InvalidYearDayException>();
    }

    [Fact]
    public void ShouldHaveAnImplicitOperatorFromInt()
    {
        var yearDay = 10;
        YearDay sut = yearDay;

        sut.Value.Should().Be(yearDay);
    }
}
