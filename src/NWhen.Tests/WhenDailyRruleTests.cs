using Xunit;
using When;
using System;

namespace When.Tests;

public class WhenDailyRruleTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    [Fact]
    public void TestDailyOne()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=DAILY;COUNT=10").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        Assert.Equal("1997-09-02 09:00:00", Fmt(r.Occurrences[0]));
        Assert.Equal("1997-09-11 09:00:00", Fmt(r.Occurrences[9]));
    }

    [Fact]
    public void TestDailyTwo()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=DAILY;UNTIL=19971224T000000Z").generateOccurrences();

        Assert.Equal("1997-09-02 09:00:00", Fmt(r.Occurrences[0]));
        Assert.Equal("1997-12-23 09:00:00", Fmt(r.Occurrences[^1]));
        Assert.Equal(113, r.Occurrences.Count);
    }

    [Fact]
    public void TestDailyThree()
    {
        // FREQ=DAILY;INTERVAL=2;COUNT=5
        var r = new When("19970902T090000");
        r.rrule("FREQ=DAILY;INTERVAL=2;COUNT=5").generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        Assert.Equal("1997-09-02 09:00:00", Fmt(r.Occurrences[0]));
        Assert.Equal("1997-09-04 09:00:00", Fmt(r.Occurrences[1]));
        Assert.Equal("1997-09-10 09:00:00", Fmt(r.Occurrences[4]));
    }
}
