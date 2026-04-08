namespace NWhen.Tests;

public class WhenMinutelyTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>Every 90 minutes for 4 occurrences: FREQ=MINUTELY;INTERVAL=90;COUNT=4</summary>
    [Fact]
    public void TestMinutelyOne()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,2,10,30,0),
            new DateTime(1997,9,2,12,0,0), new DateTime(1997,9,2,13,30,0),
        };

        var r = new When("19970902T090000");
        r.freq("minutely").interval(90).count(4).generateOccurrences();

        Assert.Equal(4, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Every 15 minutes for 6 occurrences: FREQ=MINUTELY;INTERVAL=15;COUNT=6</summary>
    [Fact]
    public void TestMinutelyTwo()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,2,9,15,0),
            new DateTime(1997,9,2,9,30,0), new DateTime(1997,9,2,9,45,0),
            new DateTime(1997,9,2,10,0,0), new DateTime(1997,9,2,10,15,0),
        };

        var r = new When("19970902T090000");
        r.freq("minutely").interval(15).count(6).generateOccurrences();

        Assert.Equal(6, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}

public class WhenMinutelyRruleTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    [Fact]
    public void TestMinutelyOne()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,2,10,30,0),
            new DateTime(1997,9,2,12,0,0), new DateTime(1997,9,2,13,30,0),
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=MINUTELY;INTERVAL=90;COUNT=4").generateOccurrences();

        Assert.Equal(4, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestMinutelyTwo()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,2,9,15,0),
            new DateTime(1997,9,2,9,30,0), new DateTime(1997,9,2,9,45,0),
            new DateTime(1997,9,2,10,0,0), new DateTime(1997,9,2,10,15,0),
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=MINUTELY;INTERVAL=15;COUNT=6").generateOccurrences();

        Assert.Equal(6, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}
