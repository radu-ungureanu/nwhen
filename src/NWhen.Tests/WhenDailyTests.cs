namespace NWhen.Tests;

public class WhenDailyTests
{
    [Fact]
    public void TestDailyOne()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 3, 9, 0, 0),
            new DateTime(1997, 9, 4, 9, 0, 0), new DateTime(1997, 9, 5, 9, 0, 0),
            new DateTime(1997, 9, 6, 9, 0, 0), new DateTime(1997, 9, 7, 9, 0, 0),
            new DateTime(1997, 9, 8, 9, 0, 0), new DateTime(1997, 9, 9, 9, 0, 0),
            new DateTime(1997, 9, 10, 9, 0, 0), new DateTime(1997, 9, 11, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.freq("daily").count(10).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyTwo()
    {
        var expected = Enumerable.Range(0, 113)
            .Select(i => new DateTime(1997, 9, 2, 9, 0, 0).AddDays(i))
            .ToList();

        var r = new When("19970902T090000");
        r.freq("daily").until(new DateTime(1997, 12, 24, 0, 0, 0)).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyThree()
    {
        var expected = Enumerable.Range(0, 47)
            .Select(i => new DateTime(1997, 9, 2, 9, 0, 0).AddDays(i * 2))
            .ToList();

        var r = new When("19970902T090000");
        r.freq("daily").interval(2).count(47).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyFour()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 12, 9, 0, 0),
            new DateTime(1997, 9, 22, 9, 0, 0), new DateTime(1997, 10, 2, 9, 0, 0),
            new DateTime(1997, 10, 12, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.freq("daily").interval(10).count(5).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestDailyFive()
    {
        var expected = new int[] { 1998, 1999, 2000 }
            .SelectMany(y => Enumerable.Range(1, 31).Select(d => new DateTime(y, 1, d, 9, 0, 0)))
            .ToList();

        var r = new When("19980101T090000");
        r.freq("daily").bymonth(1).until(new DateTime(2000, 1, 31, 14, 0, 0)).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}