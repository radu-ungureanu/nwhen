namespace NWhen.Tests;

public class SetupTests
{
    private readonly When _sut;

    public SetupTests()
    {
        _sut = new When();
    }

    [Fact]
    public void ShouldSetupOnlyStartDate()
    {
        var date = new DateTime();
        var reference = _sut.SetStartDate(date);

        _sut.StartDate.Should().Be(date);
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyUntilDate()
    {
        var date = new DateTime();
        var reference = _sut.SetUntilDate(date);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().Be(date);
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyFrequencyWhenProvidedWithACorrectValue()
    {
        var frequency = "secondly";
        var reference = _sut.SetFrequency(frequency);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().Be(frequency);
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyCount()
    {
        var count = 20;
        var reference = _sut.SetCount(count);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().Be(count);
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyInterval()
    {
        var interval = 20;
        var reference = _sut.SetInterval(interval);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().Be(interval);
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyWorkWeekStartDay()
    {
        var day = "mo";
        var reference = _sut.SetWorkWeekStartDay(day);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().Be(day);
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlySeconds()
    {
        var second = 12;
        var reference = _sut.SetBySecond(second);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().Equal([second]);
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyMinutes()
    {
        var minute = 12;
        var reference = _sut.SetByMinute(minute);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().Equal([minute]);
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyHours()
    {
        var hour = 12;
        var reference = _sut.SetByHour(hour);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().Equal([hour]);
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyMonths()
    {
        var month = 12;
        var reference = _sut.SetByMonth(month);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().Equal([month]);
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyWeekNumbers()
    {
        var weekNumber = 12;
        var reference = _sut.SetByWeekNumber(weekNumber);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().Equal([weekNumber]);
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyMonthDays()
    {
        var monthDay = 12;
        var reference = _sut.SetByMonthDay(monthDay);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().Equal([monthDay]);
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyYearDays()
    {
        var yearDay = 12;
        var reference = _sut.SetByYearDay(yearDay);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().Equal([yearDay]);
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlySetPositions()
    {
        var setPos = 12;
        var reference = _sut.SetBySetPos(setPos);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().Equal([setPos]);
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyDays()
    {
        var day = "31tu";
        var reference = _sut.SetByDay(day);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().Equal([day]);
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void ShouldSetupOnlyAdjustMonthEnd(bool adjustMonthEnd, bool expected)
    {
        var reference = _sut.SetAdjustMonthEnd(adjustMonthEnd);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().Be(expected);
        _sut.Exclusions.Should().BeNull();
        _sut.Should().BeSameAs(reference);
    }

    [Fact]
    public void ShouldSetupOnlyExclusions()
    {
        var exclusions = new[]
        {
            DateTime.Parse("2019-01-01"),
            DateTime.Parse("2019-01-02")
        };
        var reference = _sut.SetExclusions(exclusions);

        _sut.StartDate.Should().BeNull();
        _sut.UntilDate.Should().BeNull();
        _sut.Frequency.Should().BeNull();
        _sut.Count.Should().BeNull();
        _sut.Interval.Should().BeNull();
        _sut.WorkWeekStartDay.Should().BeNull();
        _sut.BySeconds.Should().BeNull();
        _sut.ByMinutes.Should().BeNull();
        _sut.ByHours.Should().BeNull();
        _sut.ByMonths.Should().BeNull();
        _sut.ByWeekNumbers.Should().BeNull();
        _sut.ByMonthDays.Should().BeNull();
        _sut.ByYearDays.Should().BeNull();
        _sut.BySetPositions.Should().BeNull();
        _sut.ByDays.Should().BeNull();
        _sut.AdjustMonthEnd.Should().BeFalse();
        _sut.Exclusions.Should().Equal(exclusions);
        _sut.Should().BeSameAs(reference);
    }
}
