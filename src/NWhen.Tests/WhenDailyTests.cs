namespace NWhen.Tests;

public class WhenDailyTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>Daily for 10 occurrences: FREQ=DAILY;COUNT=10</summary>
    [Fact]
    public void TestDailyOne()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,3,9,0,0),
            new DateTime(1997,9,4,9,0,0), new DateTime(1997,9,5,9,0,0),
            new DateTime(1997,9,6,9,0,0), new DateTime(1997,9,7,9,0,0),
            new DateTime(1997,9,8,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,10,9,0,0), new DateTime(1997,9,11,9,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("daily").count(10).generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Daily until December 24, 1997: FREQ=DAILY;UNTIL=19971224T000000Z</summary>
    [Fact]
    public void TestDailyTwo()
    {
        var r = new When("19970902T090000");
        r.freq("daily").until(new DateTime(1997,12,24,0,0,0)).generateOccurrences();

        Assert.Equal("1997-09-02 09:00:00", Fmt(r.Occurrences[0]));
        Assert.Equal("1997-12-23 09:00:00", Fmt(r.Occurrences[^1]));
        Assert.Equal(113, r.Occurrences.Count);
    }

    /// <summary>Every other day — 5 occurrences: FREQ=DAILY;INTERVAL=2;COUNT=5</summary>
    [Fact]
    public void TestDailyThree()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,4,9,0,0),
            new DateTime(1997,9,6,9,0,0), new DateTime(1997,9,8,9,0,0),
            new DateTime(1997,9,10,9,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("daily").interval(2).count(5).generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Every 10 days, 5 occurrences: FREQ=DAILY;INTERVAL=10;COUNT=5</summary>
    [Fact]
    public void TestDailyFour()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,12,9,0,0),
            new DateTime(1997,9,22,9,0,0), new DateTime(1997,10,2,9,0,0),
            new DateTime(1997,10,12,9,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("daily").interval(10).count(5).generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}
