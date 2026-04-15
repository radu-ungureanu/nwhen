namespace NWhen.Tests;

public class WhenMonthlyRruleTests
{
    [Fact]
    public void TestMonthlyOne()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 5, 9, 0, 0), new DateTime(1997, 10, 3, 9, 0, 0),
            new DateTime(1997, 11, 7, 9, 0, 0), new DateTime(1997, 12, 5, 9, 0, 0),
            new DateTime(1998, 1, 2, 9, 0, 0), new DateTime(1998, 2, 6, 9, 0, 0),
            new DateTime(1998, 3, 6, 9, 0, 0), new DateTime(1998, 4, 3, 9, 0, 0),
            new DateTime(1998, 5, 1, 9, 0, 0), new DateTime(1998, 6, 5, 9, 0, 0)
        };

        var r = new When("19970905T090000");
        r.rrule("FREQ=MONTHLY;COUNT=10;BYDAY=1FR").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyTwo()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 5, 9, 0, 0), new DateTime(1997, 10, 3, 9, 0, 0),
            new DateTime(1997, 11, 7, 9, 0, 0), new DateTime(1997, 12, 5, 9, 0, 0)
        };

        var r = new When("19970905T090000");
        r.rrule("FREQ=MONTHLY;UNTIL=19971224T000000Z;BYDAY=1FR").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyThree()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 7, 9, 0, 0), new DateTime(1997, 9, 28, 9, 0, 0),
            new DateTime(1997, 11, 2, 9, 0, 0), new DateTime(1997, 11, 30, 9, 0, 0),
            new DateTime(1998, 1, 4, 9, 0, 0), new DateTime(1998, 1, 25, 9, 0, 0),
            new DateTime(1998, 3, 1, 9, 0, 0), new DateTime(1998, 3, 29, 9, 0, 0),
            new DateTime(1998, 5, 3, 9, 0, 0), new DateTime(1998, 5, 31, 9, 0, 0)
        };

        var r = new When("19970907T090000");
        r.rrule("FREQ=MONTHLY;INTERVAL=2;COUNT=10;BYDAY=1SU,-1SU").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyFour()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 22, 9, 0, 0), new DateTime(1997, 10, 20, 9, 0, 0),
            new DateTime(1997, 11, 17, 9, 0, 0), new DateTime(1997, 12, 22, 9, 0, 0),
            new DateTime(1998, 1, 19, 9, 0, 0), new DateTime(1998, 2, 16, 9, 0, 0)
        };

        var r = new When("19970922T090000");
        r.rrule("FREQ=MONTHLY;COUNT=6;BYDAY=-2MO").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyFive()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 28, 9, 0, 0), new DateTime(1997, 10, 29, 9, 0, 0),
            new DateTime(1997, 11, 28, 9, 0, 0), new DateTime(1997, 12, 29, 9, 0, 0),
            new DateTime(1998, 1, 29, 9, 0, 0), new DateTime(1998, 2, 26, 9, 0, 0)
        };

        var r = new When("19970928T090000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-3").count(6).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlySix()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 15, 9, 0, 0),
            new DateTime(1997, 10, 2, 9, 0, 0), new DateTime(1997, 10, 15, 9, 0, 0),
            new DateTime(1997, 11, 2, 9, 0, 0), new DateTime(1997, 11, 15, 9, 0, 0),
            new DateTime(1997, 12, 2, 9, 0, 0), new DateTime(1997, 12, 15, 9, 0, 0),
            new DateTime(1998, 1, 2, 9, 0, 0), new DateTime(1998, 1, 15, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=MONTHLY;COUNT=10;BYMONTHDAY=2,15").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlySeven()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 30, 9, 0, 0), new DateTime(1997, 10, 1, 9, 0, 0),
            new DateTime(1997, 10, 31, 9, 0, 0), new DateTime(1997, 11, 1, 9, 0, 0),
            new DateTime(1997, 11, 30, 9, 0, 0), new DateTime(1997, 12, 1, 9, 0, 0),
            new DateTime(1997, 12, 31, 9, 0, 0), new DateTime(1998, 1, 1, 9, 0, 0),
            new DateTime(1998, 1, 31, 9, 0, 0), new DateTime(1998, 2, 1, 9, 0, 0)
        };

        var r = new When("19970930T090000");
        r.rrule("FREQ=MONTHLY;COUNT=10;BYMONTHDAY=1,-1").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyEight()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 10, 9, 0, 0), new DateTime(1997, 9, 11, 9, 0, 0),
            new DateTime(1997, 9, 12, 9, 0, 0), new DateTime(1997, 9, 13, 9, 0, 0),
            new DateTime(1997, 9, 14, 9, 0, 0), new DateTime(1997, 9, 15, 9, 0, 0),
            new DateTime(1999, 3, 10, 9, 0, 0), new DateTime(1999, 3, 11, 9, 0, 0),
            new DateTime(1999, 3, 12, 9, 0, 0), new DateTime(1999, 3, 13, 9, 0, 0)
        };

        var r = new When("19970910T090000");
        r.rrule("FREQ=MONTHLY;INTERVAL=18;COUNT=10;BYMONTHDAY=10,11,12,13,14,15").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyNine()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 2, 9, 0, 0), new DateTime(1997, 9, 9, 9, 0, 0),
            new DateTime(1997, 9, 16, 9, 0, 0), new DateTime(1997, 9, 23, 9, 0, 0),
            new DateTime(1997, 9, 30, 9, 0, 0), new DateTime(1997, 11, 4, 9, 0, 0),
            new DateTime(1997, 11, 11, 9, 0, 0), new DateTime(1997, 11, 18, 9, 0, 0),
            new DateTime(1997, 11, 25, 9, 0, 0), new DateTime(1998, 1, 6, 9, 0, 0),
            new DateTime(1998, 1, 13, 9, 0, 0), new DateTime(1998, 1, 20, 9, 0, 0),
            new DateTime(1998, 1, 27, 9, 0, 0), new DateTime(1998, 3, 3, 9, 0, 0),
            new DateTime(1998, 3, 10, 9, 0, 0), new DateTime(1998, 3, 17, 9, 0, 0),
            new DateTime(1998, 3, 24, 9, 0, 0), new DateTime(1998, 3, 31, 9, 0, 0)
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=MONTHLY;INTERVAL=2;BYDAY=TU;COUNT=18").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyTen()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1998, 2, 13, 9, 0, 0), new DateTime(1998, 3, 13, 9, 0, 0),
            new DateTime(1998, 11, 13, 9, 0, 0), new DateTime(1999, 8, 13, 9, 0, 0),
            new DateTime(2000, 10, 13, 9, 0, 0)
        };

        var r = new When("19980213T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=FR;BYMONTHDAY=13;COUNT=5").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyEleven()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 13, 9, 0, 0), new DateTime(1997, 10, 11, 9, 0, 0),
            new DateTime(1997, 11, 8, 9, 0, 0), new DateTime(1997, 12, 13, 9, 0, 0),
            new DateTime(1998, 1, 10, 9, 0, 0), new DateTime(1998, 2, 7, 9, 0, 0),
            new DateTime(1998, 3, 7, 9, 0, 0), new DateTime(1998, 4, 11, 9, 0, 0),
            new DateTime(1998, 5, 9, 9, 0, 0), new DateTime(1998, 6, 13, 9, 0, 0)
        };

        var r = new When("19970913T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=SA;BYMONTHDAY=7,8,9,10,11,12,13;COUNT=10").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyTwelve()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 4, 9, 0, 0),
            new DateTime(1997, 10, 7, 9, 0, 0),
            new DateTime(1997, 11, 6, 9, 0, 0)
        };

        var r = new When("19970904T090000");
        r.rrule("FREQ=MONTHLY;COUNT=3;BYDAY=TU,WE,TH;BYSETPOS=3").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyThirteen()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2007, 1, 15, 9, 0, 0), new DateTime(2007, 1, 30, 9, 0, 0),
            new DateTime(2007, 2, 15, 9, 0, 0), new DateTime(2007, 3, 15, 9, 0, 0),
            new DateTime(2007, 3, 30, 9, 0, 0)
        };

        var r = new When("20070115T090000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=15,30;COUNT=5").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyFourteen()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 29, 9, 0, 0), new DateTime(1997, 10, 30, 9, 0, 0),
            new DateTime(1997, 11, 27, 9, 0, 0), new DateTime(1997, 12, 30, 9, 0, 0),
            new DateTime(1998, 1, 29, 9, 0, 0), new DateTime(1998, 2, 26, 9, 0, 0),
            new DateTime(1998, 3, 30, 9, 0, 0)
        };

        var r = new When("19970929T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=MO,TU,WE,TH,FR;BYSETPOS=-2;COUNT=7").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlyFifteen()
    {
        var expected = Enumerable.Range(0, 61)
            .Select(i => new DateTime(2011, 9, 15, 10, 0, 0).AddMonths(i))
            .ToList();

        var r = new When("2011-09-15 10:00:00");
        r.rrule("INTERVAL=1;FREQ=MONTHLY;UNTIL=2016-09-15T10:00:00").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlySixteen()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 4, 9, 0, 0),
            new DateTime(1997, 10, 7, 9, 0, 0),
            new DateTime(1997, 11, 6, 9, 0, 0)
        };

        var r = new When("19970904T090000");
        r.rrule("FREQ=MONTHLY;COUNT=3;BYDAY=TU,WE,TH;BYSETPOS=3").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestMonthlySeventeen()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 9, 8, 9, 0, 0), new DateTime(1997, 10, 13, 9, 0, 0),
            new DateTime(1997, 11, 10, 9, 0, 0), new DateTime(1997, 12, 8, 9, 0, 0)
        };

        var r = new When("19970908T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=MO;BYSETPOS=2;COUNT=4").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}
