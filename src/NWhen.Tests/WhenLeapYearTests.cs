namespace NWhen.Tests;

public class WhenLeapYearTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>Yearly on Feb 29 (end of Feb) — FREQ=YEARLY;BYMONTH=2;BYMONTHDAY=-1 (5 occurrences)</summary>
    [Fact]
    public void TestRRuleEndOfMonthOnLeapYear()
    {
        var dates = new[]
        {
            new DateTime(2016,2,29,0,0,0), new DateTime(2017,2,28,0,0,0),
            new DateTime(2018,2,28,0,0,0), new DateTime(2019,2,28,0,0,0),
            new DateTime(2020,2,29,0,0,0),
        };

        var r = new When("20160229T000000");
        r.rrule("FREQ=YEARLY;BYMONTH=2;BYMONTHDAY=-1");
        r.RangeLimit = 5;
        r.generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        for (int i = 0; i < dates.Length; i++)
            Assert.Equal(Fmt(dates[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Monthly end-of-month from Feb 29: FREQ=MONTHLY;BYMONTHDAY=-1 (5 occs)</summary>
    [Fact]
    public void TestRRuleEndOfMonthByMonthOnLeapYear()
    {
        var dates = new[]
        {
            new DateTime(2016,2,29,0,0,0), new DateTime(2016,3,31,0,0,0),
            new DateTime(2016,4,30,0,0,0), new DateTime(2016,5,31,0,0,0),
            new DateTime(2016,6,30,0,0,0),
        };

        var r = new When("20160229T000000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-1");
        r.RangeLimit = 5;
        r.generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        for (int i = 0; i < dates.Length; i++)
            Assert.Equal(Fmt(dates[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Monthly end-of-month + 3rd: FREQ=MONTHLY;BYMONTHDAY=-1,3 from Jan 31 2020</summary>
    [Fact]
    public void TestRRuleEndOfMonthByMonthOnLeapYear2()
    {
        var dates = new[]
        {
            new DateTime(2020,1,31,0,0,0), new DateTime(2020,2,3,0,0,0),
            new DateTime(2020,2,29,0,0,0), new DateTime(2020,3,3,0,0,0),
            new DateTime(2020,3,31,0,0,0),
        };

        var r = new When("20200131T000000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-1,3");
        r.RangeLimit = 5;
        r.generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        for (int i = 0; i < dates.Length; i++)
            Assert.Equal(Fmt(dates[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Yearly on Jan 31 (non-leap): FREQ=YEARLY;BYMONTH=1;BYMONTHDAY=-1 (3 occs)</summary>
    [Fact]
    public void TestRRuleEndOfMonthOnRegularYear()
    {
        var dates = new[]
        {
            new DateTime(2016,1,31,0,0,0),
            new DateTime(2017,1,31,0,0,0),
            new DateTime(2018,1,31,0,0,0),
        };

        var r = new When("20160131T000000");
        r.rrule("FREQ=YEARLY;BYMONTH=1;BYMONTHDAY=-1");
        r.RangeLimit = 3;
        r.generateOccurrences();

        Assert.Equal(3, r.Occurrences.Count);
        for (int i = 0; i < dates.Length; i++)
            Assert.Equal(Fmt(dates[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Monthly end-of-month from Jan 31: FREQ=MONTHLY;BYMONTHDAY=-1 (3 occs)</summary>
    [Fact]
    public void TestRRuleEndOfMonthByMonth()
    {
        var dates = new[]
        {
            new DateTime(2016,1,31,0,0,0),
            new DateTime(2016,2,29,0,0,0),
            new DateTime(2016,3,31,0,0,0),
        };

        var r = new When("20160131T000000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-1");
        r.RangeLimit = 3;
        r.generateOccurrences();

        Assert.Equal(3, r.Occurrences.Count);
        for (int i = 0; i < dates.Length; i++)
            Assert.Equal(Fmt(dates[i]), Fmt(r.Occurrences[i]));
    }
}
