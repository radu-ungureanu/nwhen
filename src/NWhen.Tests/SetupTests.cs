namespace NWhen.Tests
{
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
            _sut.BySeconds.Should().Equal(new[] { second });
            _sut.ByMinutes.Should().BeNull();
            _sut.ByHours.Should().BeNull();
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
            _sut.ByMinutes.Should().Equal(new[] { minute });
            _sut.ByHours.Should().BeNull();
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
            _sut.ByHours.Should().Equal(new[] { hour });
            _sut.Should().BeSameAs(reference);
        }
    }
}
