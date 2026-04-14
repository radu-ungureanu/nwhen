namespace NWhen.Tests;

public class WhenHourlyRruleTests
{
    [Fact]
    public void TestHourlyOne()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0),
            new DateTime(1997, 9, 2, 12, 0, 0),
            new DateTime(1997, 9, 2, 15, 0, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=HOURLY;INTERVAL=3;UNTIL=19970902T170000Z").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}
