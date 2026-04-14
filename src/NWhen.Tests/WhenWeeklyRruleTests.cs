namespace NWhen.Tests;

public class WhenWeeklyRruleTests
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
        r.rrule("FREQ=WEEKLY;COUNT=10").generateOccurrences();

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
        r.rrule("FREQ=WEEKLY;UNTIL=19971224T000000Z").generateOccurrences();

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
        r.rrule("FREQ=WEEKLY;INTERVAL=2;WKST=SU;COUNT=13").generateOccurrences();

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

        var r1 = new When("19970902T090000");
        r1.rrule("FREQ=WEEKLY;UNTIL=19971007T000000Z;WKST=SU;BYDAY=TU,TH").generateOccurrences();

        Assert.Equal(expected, r1.Occurrences);

        var r2 = new When("19970902T090000");
        r2.rrule("FREQ=WEEKLY;COUNT=10;WKST=SU;BYDAY=TU,TH").generateOccurrences();

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
        r.rrule("FREQ=WEEKLY;INTERVAL=2;UNTIL=19971224T000000Z;WKST=SU;BYDAY=MO,WE,FR").generateOccurrences();

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
        r.rrule("FREQ=WEEKLY;INTERVAL=2;COUNT=8;WKST=SU;BYDAY=TU,TH").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklySeven()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 8, 5, 9, 0, 0), new DateTime(1997, 8, 10, 9, 0, 0),
            new DateTime(1997, 8, 19, 9, 0, 0), new DateTime(1997, 8, 24, 9, 0, 0)
        };

        var r = new When("19970805T090000");
        r.rrule("FREQ=WEEKLY;INTERVAL=2;COUNT=4;BYDAY=TU,SU;WKST=MO").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklyEight()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 8, 5, 9, 0, 0), new DateTime(1997, 8, 17, 9, 0, 0),
            new DateTime(1997, 8, 19, 9, 0, 0), new DateTime(1997, 8, 31, 9, 0, 0)
        };

        var r = new When("19970805T090000");
        r.rrule("FREQ=WEEKLY;INTERVAL=2;COUNT=4;BYDAY=TU,SU;WKST=SU").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestNman12WeeklyBug()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2014, 2, 10, 0, 0, 0), new DateTime(2014, 2, 11, 0, 0, 0),
            new DateTime(2014, 2, 24, 0, 0, 0), new DateTime(2014, 2, 25, 0, 0, 0),
            new DateTime(2014, 3, 10, 0, 0, 0), new DateTime(2014, 3, 11, 0, 0, 0),
            new DateTime(2014, 3, 24, 0, 0, 0), new DateTime(2014, 3, 25, 0, 0, 0),
            new DateTime(2014, 4, 7, 0, 0, 0), new DateTime(2014, 4, 8, 0, 0, 0)
        };

        var r = new When("2014-02-10");
        r.rrule("FREQ=WEEKLY;INTERVAL=2;BYDAY=MO,TU;COUNT=10").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestWeeklyNine()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 8, 8, 9, 0, 0), new DateTime(1997, 8, 11, 9, 0, 0),
            new DateTime(1997, 8, 18, 9, 0, 0), new DateTime(1997, 8, 25, 9, 0, 0)
        };

        var r = new When("19970808T090000");
        r.rrule("FREQ=WEEKLY;BYDAY=MO,FR;COUNT=4;BYSETPOS=1").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestGeneratedTimeGreaterThanUntilDateTimeBug()
    {
        var r = new When("20210831T090000");
        r.rrule("FREQ=WEEKLY;BYDAY=TU;BYHOUR=18;BYMINUTE=0;BYSECOND=0")
         .until(new DateTime(2021, 8, 31, 17, 0, 0))
         .generateOccurrences();

        Assert.Empty(r.Occurrences);
    }
}
