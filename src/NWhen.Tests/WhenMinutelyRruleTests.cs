namespace NWhen.Tests;

public class WhenMinutelyRruleTests
{
    [Fact]
    public void TestMinutelyOne()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 2, 10, 30, 0),
            new DateTime(1997, 9, 2, 12, 0, 0), new DateTime(1997, 9, 2, 13, 30, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=MINUTELY;INTERVAL=90;COUNT=4").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMinutelyTwo()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 2, 9, 15, 0),
            new DateTime(1997, 9, 2, 9, 30, 0), new DateTime(1997, 9, 2, 9, 45, 0),
            new DateTime(1997, 9, 2, 10, 0, 0), new DateTime(1997, 9, 2, 10, 15, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=MINUTELY;INTERVAL=15;COUNT=6").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}
