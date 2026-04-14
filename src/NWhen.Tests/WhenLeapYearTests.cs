namespace NWhen.Tests;

public class WhenLeapYearTests
{
    [Fact]
    public void TestRRuleEndOfMonthOnLeapYear()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2016, 2, 29, 0, 0, 0), new DateTime(2017, 2, 28, 0, 0, 0),
            new DateTime(2018, 2, 28, 0, 0, 0), new DateTime(2019, 2, 28, 0, 0, 0),
            new DateTime(2020, 2, 29, 0, 0, 0)
        };

        var r = new When("20160229T000000");
        r.rrule("FREQ=YEARLY;BYMONTH=2;BYMONTHDAY=-1");
        r.RangeLimit = 5;
        r.generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestRRuleEndOfMonthByMonthOnLeapYear()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2016, 2, 29, 0, 0, 0), new DateTime(2016, 3, 31, 0, 0, 0),
            new DateTime(2016, 4, 30, 0, 0, 0), new DateTime(2016, 5, 31, 0, 0, 0),
            new DateTime(2016, 6, 30, 0, 0, 0)
        };

        var r = new When("20160229T000000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-1");
        r.RangeLimit = 5;
        r.generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestRRuleEndOfMonthByMonthOnLeapYear2()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2020, 1, 31, 0, 0, 0), new DateTime(2020, 2, 3, 0, 0, 0),
            new DateTime(2020, 2, 29, 0, 0, 0), new DateTime(2020, 3, 3, 0, 0, 0),
            new DateTime(2020, 3, 31, 0, 0, 0)
        };

        var r = new When("20200131T000000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-1,3");
        r.RangeLimit = 5;
        r.generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestRRuleEndOfMonthOnRegularYear()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2016, 1, 31, 0, 0, 0),
            new DateTime(2017, 1, 31, 0, 0, 0),
            new DateTime(2018, 1, 31, 0, 0, 0)
        };

        var r = new When("20160131T000000");
        r.rrule("FREQ=YEARLY;BYMONTH=1;BYMONTHDAY=-1");
        r.RangeLimit = 3;
        r.generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestRRuleEndOfMonthByMonth()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2016, 1, 31, 0, 0, 0),
            new DateTime(2016, 2, 29, 0, 0, 0),
            new DateTime(2016, 3, 31, 0, 0, 0)
        };

        var r = new When("20160131T000000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-1");
        r.RangeLimit = 3;
        r.generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}