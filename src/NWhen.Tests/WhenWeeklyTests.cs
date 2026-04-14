namespace NWhen.Tests;

public class WhenWeeklyTests
{
    [Fact]
    public void TestWeeklyOne()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 9, 9, 0, 0),
            new DateTime(1997, 9, 16, 9, 0, 0), new DateTime(1997, 9, 23, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0), new DateTime(1997, 10, 7, 9, 0, 0),
            new DateTime(1997, 10, 14, 9, 0, 0), new DateTime(1997, 10, 21, 9, 0, 0),
            new DateTime(1997, 10, 28, 9, 0, 0), new DateTime(1997, 11, 4, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.freq("weekly").count(10).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklyTwo()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 9, 9, 0, 0),
            new DateTime(1997, 9, 16, 9, 0, 0), new DateTime(1997, 9, 23, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0), new DateTime(1997, 10, 7, 9, 0, 0),
            new DateTime(1997, 10, 14, 9, 0, 0), new DateTime(1997, 10, 21, 9, 0, 0),
            new DateTime(1997, 10, 28, 9, 0, 0), new DateTime(1997, 11, 4, 9, 0, 0),
            new DateTime(1997, 11, 11, 9, 0, 0), new DateTime(1997, 11, 18, 9, 0, 0),
            new DateTime(1997, 11, 25, 9, 0, 0), new DateTime(1997, 12, 2, 9, 0, 0),
            new DateTime(1997, 12, 9, 9, 0, 0), new DateTime(1997, 12, 16, 9, 0, 0),
            new DateTime(1997, 12, 23, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.freq("weekly").until(new DateTime(1997, 12, 24, 0, 0, 0)).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklyThree()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 16, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0), new DateTime(1997, 10, 14, 9, 0, 0),
            new DateTime(1997, 10, 28, 9, 0, 0), new DateTime(1997, 11, 11, 9, 0, 0),
            new DateTime(1997, 11, 25, 9, 0, 0), new DateTime(1997, 12, 9, 9, 0, 0),
            new DateTime(1997, 12, 23, 9, 0, 0), new DateTime(1998, 1, 6, 9, 0, 0),
            new DateTime(1998, 1, 20, 9, 0, 0), new DateTime(1998, 2, 3, 9, 0, 0),
            new DateTime(1998, 2, 17, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.freq("weekly").count(13).interval(2).wkst("SU").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklyFour()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 4, 9, 0, 0),
            new DateTime(1997, 9, 9, 9, 0, 0), new DateTime(1997, 9, 11, 9, 0, 0),
            new DateTime(1997, 9, 16, 9, 0, 0), new DateTime(1997, 9, 18, 9, 0, 0),
            new DateTime(1997, 9, 23, 9, 0, 0), new DateTime(1997, 9, 25, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0), new DateTime(1997, 10, 2, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.freq("weekly").until(new DateTime(1997, 10, 7, 0, 0, 0)).wkst("SU")
         .byday(new[] { "TU", "TH" }).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);

        var r2 = new When("19970902T090000");
        r2.freq("weekly").count(10).wkst("SU").byday(new[] { "TU", "TH" }).generateOccurrences();

        Assert.Equal(expected, r2.Occurrences);
    }

    [Fact]
    public void TestWeeklyFive()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 1, 9, 0, 0), new DateTime(1997, 9, 3, 9, 0, 0),
            new DateTime(1997, 9, 5, 9, 0, 0), new DateTime(1997, 9, 15, 9, 0, 0),
            new DateTime(1997, 9, 17, 9, 0, 0), new DateTime(1997, 9, 19, 9, 0, 0),
            new DateTime(1997, 9, 29, 9, 0, 0), new DateTime(1997, 10, 1, 9, 0, 0),
            new DateTime(1997, 10, 3, 9, 0, 0), new DateTime(1997, 10, 13, 9, 0, 0),
            new DateTime(1997, 10, 15, 9, 0, 0), new DateTime(1997, 10, 17, 9, 0, 0),
            new DateTime(1997, 10, 27, 9, 0, 0), new DateTime(1997, 10, 29, 9, 0, 0),
            new DateTime(1997, 10, 31, 9, 0, 0), new DateTime(1997, 11, 10, 9, 0, 0),
            new DateTime(1997, 11, 12, 9, 0, 0), new DateTime(1997, 11, 14, 9, 0, 0),
            new DateTime(1997, 11, 24, 9, 0, 0), new DateTime(1997, 11, 26, 9, 0, 0),
            new DateTime(1997, 11, 28, 9, 0, 0), new DateTime(1997, 12, 8, 9, 0, 0),
            new DateTime(1997, 12, 10, 9, 0, 0), new DateTime(1997, 12, 12, 9, 0, 0),
            new DateTime(1997, 12, 22, 9, 0, 0)
        };

        var r = new When("19970901T090000");
        r.freq("weekly").interval(2).until(new DateTime(1997, 12, 24, 0, 0, 0))
         .wkst("SU").byday(new[] { "MO", "WE", "FR" }).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklySix()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 4, 9, 0, 0),
            new DateTime(1997, 9, 16, 9, 0, 0), new DateTime(1997, 9, 18, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0), new DateTime(1997, 10, 2, 9, 0, 0),
            new DateTime(1997, 10, 14, 9, 0, 0), new DateTime(1997, 10, 16, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.freq("weekly").wkst("SU").interval(2).count(8)
         .byday(new[] { "TU", "TH" }).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklySeven()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 8, 5, 9, 0, 0),
            new DateTime(1997, 8, 10, 9, 0, 0),
            new DateTime(1997, 8, 19, 9, 0, 0),
            new DateTime(1997, 8, 24, 9, 0, 0)
        };

        var r = new When("19970805T090000");
        r.freq("weekly").interval(2).count(4)
         .byday(new[] { "TU", "SU" }).wkst("MO").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklyEight()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 8, 5, 9, 0, 0),
            new DateTime(1997, 8, 17, 9, 0, 0),
            new DateTime(1997, 8, 19, 9, 0, 0),
            new DateTime(1997, 8, 31, 9, 0, 0)
        };

        var r = new When("19970805T090000");
        r.freq("weekly").interval(2).count(4)
         .byday(new[] { "TU", "SU" }).wkst("SU").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklyNine()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 0, 0, 0), new DateTime(1997, 9, 16, 0, 0, 0),
            new DateTime(1997, 9, 30, 0, 0, 0), new DateTime(1997, 10, 14, 0, 0, 0),
            new DateTime(1997, 10, 28, 0, 0, 0), new DateTime(1997, 11, 11, 0, 0, 0),
            new DateTime(1997, 11, 25, 0, 0, 0), new DateTime(1997, 12, 9, 0, 0, 0),
            new DateTime(1997, 12, 23, 0, 0, 0), new DateTime(1998, 1, 6, 0, 0, 0),
            new DateTime(1998, 1, 20, 0, 0, 0), new DateTime(1998, 2, 3, 0, 0, 0),
            new DateTime(1998, 2, 17, 0, 0, 0)
        };

        var r = new When("19970902T000000");
        r.freq("weekly").interval(2).wkst("TU").count(13).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}
