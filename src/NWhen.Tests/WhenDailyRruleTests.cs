namespace NWhen.Tests;

public class WhenDailyRruleTests
{
    [Fact]
    public void TestDailyOne()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0),
            new DateTime(1997, 9, 3, 9, 0, 0),
            new DateTime(1997, 9, 4, 9, 0, 0),
            new DateTime(1997, 9, 5, 9, 0, 0),
            new DateTime(1997, 9, 6, 9, 0, 0),
            new DateTime(1997, 9, 7, 9, 0, 0),
            new DateTime(1997, 9, 8, 9, 0, 0),
            new DateTime(1997, 9, 9, 9, 0, 0),
            new DateTime(1997, 9, 10, 9, 0, 0),
            new DateTime(1997, 9, 11, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=DAILY;COUNT=10").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyTwo()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0),
            new DateTime(1997, 9, 3, 9, 0, 0),
            new DateTime(1997, 9, 4, 9, 0, 0),
            new DateTime(1997, 9, 5, 9, 0, 0),
            new DateTime(1997, 9, 6, 9, 0, 0),
            new DateTime(1997, 9, 7, 9, 0, 0),
            new DateTime(1997, 9, 8, 9, 0, 0),
            new DateTime(1997, 9, 9, 9, 0, 0),
            new DateTime(1997, 9, 10, 9, 0, 0),
            new DateTime(1997, 9, 11, 9, 0, 0),
            new DateTime(1997, 9, 12, 9, 0, 0),
            new DateTime(1997, 9, 13, 9, 0, 0),
            new DateTime(1997, 9, 14, 9, 0, 0),
            new DateTime(1997, 9, 15, 9, 0, 0),
            new DateTime(1997, 9, 16, 9, 0, 0),
            new DateTime(1997, 9, 17, 9, 0, 0),
            new DateTime(1997, 9, 18, 9, 0, 0),
            new DateTime(1997, 9, 19, 9, 0, 0),
            new DateTime(1997, 9, 20, 9, 0, 0),
            new DateTime(1997, 9, 21, 9, 0, 0),
            new DateTime(1997, 9, 22, 9, 0, 0),
            new DateTime(1997, 9, 23, 9, 0, 0),
            new DateTime(1997, 9, 24, 9, 0, 0),
            new DateTime(1997, 9, 25, 9, 0, 0),
            new DateTime(1997, 9, 26, 9, 0, 0),
            new DateTime(1997, 9, 27, 9, 0, 0),
            new DateTime(1997, 9, 28, 9, 0, 0),
            new DateTime(1997, 9, 29, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0),
            new DateTime(1997, 10, 1, 9, 0, 0),
            new DateTime(1997, 10, 2, 9, 0, 0),
            new DateTime(1997, 10, 3, 9, 0, 0),
            new DateTime(1997, 10, 4, 9, 0, 0),
            new DateTime(1997, 10, 5, 9, 0, 0),
            new DateTime(1997, 10, 6, 9, 0, 0),
            new DateTime(1997, 10, 7, 9, 0, 0),
            new DateTime(1997, 10, 8, 9, 0, 0),
            new DateTime(1997, 10, 9, 9, 0, 0),
            new DateTime(1997, 10, 10, 9, 0, 0),
            new DateTime(1997, 10, 11, 9, 0, 0),
            new DateTime(1997, 10, 12, 9, 0, 0),
            new DateTime(1997, 10, 13, 9, 0, 0),
            new DateTime(1997, 10, 14, 9, 0, 0),
            new DateTime(1997, 10, 15, 9, 0, 0),
            new DateTime(1997, 10, 16, 9, 0, 0),
            new DateTime(1997, 10, 17, 9, 0, 0),
            new DateTime(1997, 10, 18, 9, 0, 0),
            new DateTime(1997, 10, 19, 9, 0, 0),
            new DateTime(1997, 10, 20, 9, 0, 0),
            new DateTime(1997, 10, 21, 9, 0, 0),
            new DateTime(1997, 10, 22, 9, 0, 0),
            new DateTime(1997, 10, 23, 9, 0, 0),
            new DateTime(1997, 10, 24, 9, 0, 0),
            new DateTime(1997, 10, 25, 9, 0, 0),
            new DateTime(1997, 10, 26, 9, 0, 0),
            new DateTime(1997, 10, 27, 9, 0, 0),
            new DateTime(1997, 10, 28, 9, 0, 0),
            new DateTime(1997, 10, 29, 9, 0, 0),
            new DateTime(1997, 10, 30, 9, 0, 0),
            new DateTime(1997, 10, 31, 9, 0, 0),
            new DateTime(1997, 11, 1, 9, 0, 0),
            new DateTime(1997, 11, 2, 9, 0, 0),
            new DateTime(1997, 11, 3, 9, 0, 0),
            new DateTime(1997, 11, 4, 9, 0, 0),
            new DateTime(1997, 11, 5, 9, 0, 0),
            new DateTime(1997, 11, 6, 9, 0, 0),
            new DateTime(1997, 11, 7, 9, 0, 0),
            new DateTime(1997, 11, 8, 9, 0, 0),
            new DateTime(1997, 11, 9, 9, 0, 0),
            new DateTime(1997, 11, 10, 9, 0, 0),
            new DateTime(1997, 11, 11, 9, 0, 0),
            new DateTime(1997, 11, 12, 9, 0, 0),
            new DateTime(1997, 11, 13, 9, 0, 0),
            new DateTime(1997, 11, 14, 9, 0, 0),
            new DateTime(1997, 11, 15, 9, 0, 0),
            new DateTime(1997, 11, 16, 9, 0, 0),
            new DateTime(1997, 11, 17, 9, 0, 0),
            new DateTime(1997, 11, 18, 9, 0, 0),
            new DateTime(1997, 11, 19, 9, 0, 0),
            new DateTime(1997, 11, 20, 9, 0, 0),
            new DateTime(1997, 11, 21, 9, 0, 0),
            new DateTime(1997, 11, 22, 9, 0, 0),
            new DateTime(1997, 11, 23, 9, 0, 0),
            new DateTime(1997, 11, 24, 9, 0, 0),
            new DateTime(1997, 11, 25, 9, 0, 0),
            new DateTime(1997, 11, 26, 9, 0, 0),
            new DateTime(1997, 11, 27, 9, 0, 0),
            new DateTime(1997, 11, 28, 9, 0, 0),
            new DateTime(1997, 11, 29, 9, 0, 0),
            new DateTime(1997, 11, 30, 9, 0, 0),
            new DateTime(1997, 12, 1, 9, 0, 0),
            new DateTime(1997, 12, 2, 9, 0, 0),
            new DateTime(1997, 12, 3, 9, 0, 0),
            new DateTime(1997, 12, 4, 9, 0, 0),
            new DateTime(1997, 12, 5, 9, 0, 0),
            new DateTime(1997, 12, 6, 9, 0, 0),
            new DateTime(1997, 12, 7, 9, 0, 0),
            new DateTime(1997, 12, 8, 9, 0, 0),
            new DateTime(1997, 12, 9, 9, 0, 0),
            new DateTime(1997, 12, 10, 9, 0, 0),
            new DateTime(1997, 12, 11, 9, 0, 0),
            new DateTime(1997, 12, 12, 9, 0, 0),
            new DateTime(1997, 12, 13, 9, 0, 0),
            new DateTime(1997, 12, 14, 9, 0, 0),
            new DateTime(1997, 12, 15, 9, 0, 0),
            new DateTime(1997, 12, 16, 9, 0, 0),
            new DateTime(1997, 12, 17, 9, 0, 0),
            new DateTime(1997, 12, 18, 9, 0, 0),
            new DateTime(1997, 12, 19, 9, 0, 0),
            new DateTime(1997, 12, 20, 9, 0, 0),
            new DateTime(1997, 12, 21, 9, 0, 0),
            new DateTime(1997, 12, 22, 9, 0, 0),
            new DateTime(1997, 12, 23, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=DAILY;UNTIL=19971224T000000Z").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyThree()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0),
            new DateTime(1997, 9, 4, 9, 0, 0),
            new DateTime(1997, 9, 6, 9, 0, 0),
            new DateTime(1997, 9, 8, 9, 0, 0),
            new DateTime(1997, 9, 10, 9, 0, 0),
            new DateTime(1997, 9, 12, 9, 0, 0),
            new DateTime(1997, 9, 14, 9, 0, 0),
            new DateTime(1997, 9, 16, 9, 0, 0),
            new DateTime(1997, 9, 18, 9, 0, 0),
            new DateTime(1997, 9, 20, 9, 0, 0),
            new DateTime(1997, 9, 22, 9, 0, 0),
            new DateTime(1997, 9, 24, 9, 0, 0),
            new DateTime(1997, 9, 26, 9, 0, 0),
            new DateTime(1997, 9, 28, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0),
            new DateTime(1997, 10, 2, 9, 0, 0),
            new DateTime(1997, 10, 4, 9, 0, 0),
            new DateTime(1997, 10, 6, 9, 0, 0),
            new DateTime(1997, 10, 8, 9, 0, 0),
            new DateTime(1997, 10, 10, 9, 0, 0),
            new DateTime(1997, 10, 12, 9, 0, 0),
            new DateTime(1997, 10, 14, 9, 0, 0),
            new DateTime(1997, 10, 16, 9, 0, 0),
            new DateTime(1997, 10, 18, 9, 0, 0),
            new DateTime(1997, 10, 20, 9, 0, 0),
            new DateTime(1997, 10, 22, 9, 0, 0),
            new DateTime(1997, 10, 24, 9, 0, 0),
            new DateTime(1997, 10, 26, 9, 0, 0),
            new DateTime(1997, 10, 28, 9, 0, 0),
            new DateTime(1997, 10, 30, 9, 0, 0),
            new DateTime(1997, 11, 1, 9, 0, 0),
            new DateTime(1997, 11, 3, 9, 0, 0),
            new DateTime(1997, 11, 5, 9, 0, 0),
            new DateTime(1997, 11, 7, 9, 0, 0),
            new DateTime(1997, 11, 9, 9, 0, 0),
            new DateTime(1997, 11, 11, 9, 0, 0),
            new DateTime(1997, 11, 13, 9, 0, 0),
            new DateTime(1997, 11, 15, 9, 0, 0),
            new DateTime(1997, 11, 17, 9, 0, 0),
            new DateTime(1997, 11, 19, 9, 0, 0),
            new DateTime(1997, 11, 21, 9, 0, 0),
            new DateTime(1997, 11, 23, 9, 0, 0),
            new DateTime(1997, 11, 25, 9, 0, 0),
            new DateTime(1997, 11, 27, 9, 0, 0),
            new DateTime(1997, 11, 29, 9, 0, 0),
            new DateTime(1997, 12, 1, 9, 0, 0),
            new DateTime(1997, 12, 3, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=DAILY;INTERVAL=2;COUNT=47").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyFour()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0),
            new DateTime(1997, 9, 12, 9, 0, 0),
            new DateTime(1997, 9, 22, 9, 0, 0),
            new DateTime(1997, 10, 2, 9, 0, 0),
            new DateTime(1997, 10, 12, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=DAILY;INTERVAL=10;COUNT=5").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyFive()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1998, 1, 1, 9, 0, 0),
            new DateTime(1998, 1, 2, 9, 0, 0),
            new DateTime(1998, 1, 3, 9, 0, 0),
            new DateTime(1998, 1, 4, 9, 0, 0),
            new DateTime(1998, 1, 5, 9, 0, 0),
            new DateTime(1998, 1, 6, 9, 0, 0),
            new DateTime(1998, 1, 7, 9, 0, 0),
            new DateTime(1998, 1, 8, 9, 0, 0),
            new DateTime(1998, 1, 9, 9, 0, 0),
            new DateTime(1998, 1, 10, 9, 0, 0),
            new DateTime(1998, 1, 11, 9, 0, 0),
            new DateTime(1998, 1, 12, 9, 0, 0),
            new DateTime(1998, 1, 13, 9, 0, 0),
            new DateTime(1998, 1, 14, 9, 0, 0),
            new DateTime(1998, 1, 15, 9, 0, 0),
            new DateTime(1998, 1, 16, 9, 0, 0),
            new DateTime(1998, 1, 17, 9, 0, 0),
            new DateTime(1998, 1, 18, 9, 0, 0),
            new DateTime(1998, 1, 19, 9, 0, 0),
            new DateTime(1998, 1, 20, 9, 0, 0),
            new DateTime(1998, 1, 21, 9, 0, 0),
            new DateTime(1998, 1, 22, 9, 0, 0),
            new DateTime(1998, 1, 23, 9, 0, 0),
            new DateTime(1998, 1, 24, 9, 0, 0),
            new DateTime(1998, 1, 25, 9, 0, 0),
            new DateTime(1998, 1, 26, 9, 0, 0),
            new DateTime(1998, 1, 27, 9, 0, 0),
            new DateTime(1998, 1, 28, 9, 0, 0),
            new DateTime(1998, 1, 29, 9, 0, 0),
            new DateTime(1998, 1, 30, 9, 0, 0),
            new DateTime(1998, 1, 31, 9, 0, 0),
            new DateTime(1999, 1, 1, 9, 0, 0),
            new DateTime(1999, 1, 2, 9, 0, 0),
            new DateTime(1999, 1, 3, 9, 0, 0),
            new DateTime(1999, 1, 4, 9, 0, 0),
            new DateTime(1999, 1, 5, 9, 0, 0),
            new DateTime(1999, 1, 6, 9, 0, 0),
            new DateTime(1999, 1, 7, 9, 0, 0),
            new DateTime(1999, 1, 8, 9, 0, 0),
            new DateTime(1999, 1, 9, 9, 0, 0),
            new DateTime(1999, 1, 10, 9, 0, 0),
            new DateTime(1999, 1, 11, 9, 0, 0),
            new DateTime(1999, 1, 12, 9, 0, 0),
            new DateTime(1999, 1, 13, 9, 0, 0),
            new DateTime(1999, 1, 14, 9, 0, 0),
            new DateTime(1999, 1, 15, 9, 0, 0),
            new DateTime(1999, 1, 16, 9, 0, 0),
            new DateTime(1999, 1, 17, 9, 0, 0),
            new DateTime(1999, 1, 18, 9, 0, 0),
            new DateTime(1999, 1, 19, 9, 0, 0),
            new DateTime(1999, 1, 20, 9, 0, 0),
            new DateTime(1999, 1, 21, 9, 0, 0),
            new DateTime(1999, 1, 22, 9, 0, 0),
            new DateTime(1999, 1, 23, 9, 0, 0),
            new DateTime(1999, 1, 24, 9, 0, 0),
            new DateTime(1999, 1, 25, 9, 0, 0),
            new DateTime(1999, 1, 26, 9, 0, 0),
            new DateTime(1999, 1, 27, 9, 0, 0),
            new DateTime(1999, 1, 28, 9, 0, 0),
            new DateTime(1999, 1, 29, 9, 0, 0),
            new DateTime(1999, 1, 30, 9, 0, 0),
            new DateTime(1999, 1, 31, 9, 0, 0),
            new DateTime(2000, 1, 1, 9, 0, 0),
            new DateTime(2000, 1, 2, 9, 0, 0),
            new DateTime(2000, 1, 3, 9, 0, 0),
            new DateTime(2000, 1, 4, 9, 0, 0),
            new DateTime(2000, 1, 5, 9, 0, 0),
            new DateTime(2000, 1, 6, 9, 0, 0),
            new DateTime(2000, 1, 7, 9, 0, 0),
            new DateTime(2000, 1, 8, 9, 0, 0),
            new DateTime(2000, 1, 9, 9, 0, 0),
            new DateTime(2000, 1, 10, 9, 0, 0),
            new DateTime(2000, 1, 11, 9, 0, 0),
            new DateTime(2000, 1, 12, 9, 0, 0),
            new DateTime(2000, 1, 13, 9, 0, 0),
            new DateTime(2000, 1, 14, 9, 0, 0),
            new DateTime(2000, 1, 15, 9, 0, 0),
            new DateTime(2000, 1, 16, 9, 0, 0),
            new DateTime(2000, 1, 17, 9, 0, 0),
            new DateTime(2000, 1, 18, 9, 0, 0),
            new DateTime(2000, 1, 19, 9, 0, 0),
            new DateTime(2000, 1, 20, 9, 0, 0),
            new DateTime(2000, 1, 21, 9, 0, 0),
            new DateTime(2000, 1, 22, 9, 0, 0),
            new DateTime(2000, 1, 23, 9, 0, 0),
            new DateTime(2000, 1, 24, 9, 0, 0),
            new DateTime(2000, 1, 25, 9, 0, 0),
            new DateTime(2000, 1, 26, 9, 0, 0),
            new DateTime(2000, 1, 27, 9, 0, 0),
            new DateTime(2000, 1, 28, 9, 0, 0),
            new DateTime(2000, 1, 29, 9, 0, 0),
            new DateTime(2000, 1, 30, 9, 0, 0),
            new DateTime(2000, 1, 31, 9, 0, 0)
        };

        var r = new When("19980101T090000");
        r.rrule("FREQ=DAILY;UNTIL=20000131T140000;BYMONTH=1").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}
