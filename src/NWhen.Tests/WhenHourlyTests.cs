namespace NWhen.Tests;

public class WhenHourlyTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>Every 3 hours from 9:00 AM to 5:00 PM: FREQ=HOURLY;INTERVAL=3;UNTIL=19970902T170000Z</summary>
    [Fact]
    public void TestHourlyOne()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,2,12,0,0),
            new DateTime(1997,9,2,15,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("hourly").interval(3).until(new DateTime(1997,9,2,17,0,0)).generateOccurrences();

        Assert.Equal(3, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}

public class WhenHourlyRruleTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    [Fact]
    public void TestHourlyOne()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,2,12,0,0),
            new DateTime(1997,9,2,15,0,0),
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=HOURLY;INTERVAL=3;UNTIL=19970902T170000Z").generateOccurrences();

        Assert.Equal(3, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}
