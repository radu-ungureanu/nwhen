using Xunit;
using When;
using System;

namespace When.Tests;

public class WhenYearlyRruleTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    [Fact]
    public void TestYearlyOne()
    {
        var results = new[]
        {
            new DateTime(1997,6,10,9,0,0), new DateTime(1997,7,10,9,0,0),
            new DateTime(1998,6,10,9,0,0), new DateTime(1998,7,10,9,0,0),
            new DateTime(1999,6,10,9,0,0), new DateTime(1999,7,10,9,0,0),
            new DateTime(2000,6,10,9,0,0), new DateTime(2000,7,10,9,0,0),
            new DateTime(2001,6,10,9,0,0), new DateTime(2001,7,10,9,0,0),
        };

        var r = new When("19970610T090000");
        r.rrule("FREQ=YEARLY;COUNT=10;BYMONTH=6,7").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestYearlyTwo()
    {
        var results = new[]
        {
            new DateTime(1997,1,1,9,0,0), new DateTime(1997,4,10,9,0,0),
            new DateTime(1997,7,19,9,0,0), new DateTime(2000,1,1,9,0,0),
            new DateTime(2000,4,9,9,0,0), new DateTime(2000,7,18,9,0,0),
            new DateTime(2003,1,1,9,0,0), new DateTime(2003,4,10,9,0,0),
            new DateTime(2003,7,19,9,0,0), new DateTime(2006,1,1,9,0,0),
        };

        var r = new When("19970101T090000");
        r.rrule("FREQ=YEARLY;INTERVAL=3;COUNT=10;BYYEARDAY=1,100,200").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestYearlyThree()
    {
        var results = new[]
        {
            new DateTime(1997,3,10,9,0,0), new DateTime(1999,1,10,9,0,0),
            new DateTime(1999,2,10,9,0,0), new DateTime(1999,3,10,9,0,0),
            new DateTime(2001,1,10,9,0,0), new DateTime(2001,2,10,9,0,0),
            new DateTime(2001,3,10,9,0,0), new DateTime(2003,1,10,9,0,0),
            new DateTime(2003,2,10,9,0,0), new DateTime(2003,3,10,9,0,0),
        };

        var r = new When("19970310T090000");
        r.rrule("FREQ=YEARLY;INTERVAL=2;COUNT=10;BYMONTH=1,2,3").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestYearlyFive()
    {
        var results = new[]
        {
            new DateTime(1997,5,12,9,0,0), new DateTime(1998,5,11,9,0,0),
            new DateTime(1999,5,17,9,0,0), new DateTime(2000,5,15,9,0,0),
            new DateTime(2001,5,14,9,0,0), new DateTime(2002,5,13,9,0,0),
            new DateTime(2003,5,12,9,0,0), new DateTime(2004,5,10,9,0,0),
            new DateTime(2005,5,16,9,0,0), new DateTime(2006,5,15,9,0,0),
        };

        var r = new When("19970512T090000");
        r.rrule("FREQ=YEARLY;COUNT=10;BYWEEKNO=20;BYDAY=MO").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestYearlySix()
    {
        var results = new[]
        {
            new DateTime(1997,3,13,9,0,0), new DateTime(1997,3,20,9,0,0),
            new DateTime(1997,3,27,9,0,0), new DateTime(1998,3,5,9,0,0),
            new DateTime(1998,3,12,9,0,0), new DateTime(1998,3,19,9,0,0),
            new DateTime(1998,3,26,9,0,0), new DateTime(1999,3,4,9,0,0),
            new DateTime(1999,3,11,9,0,0), new DateTime(1999,3,18,9,0,0),
        };

        var r = new When("19970313T090000");
        r.rrule("FREQ=YEARLY;COUNT=10;BYMONTH=3;BYDAY=TH").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestYearlyEight()
    {
        var results = new[]
        {
            new DateTime(1996,11,5,9,0,0), new DateTime(2000,11,7,9,0,0),
            new DateTime(2004,11,2,9,0,0), new DateTime(2008,11,4,9,0,0),
            new DateTime(2012,11,6,9,0,0), new DateTime(2016,11,8,9,0,0),
            new DateTime(2020,11,3,9,0,0), new DateTime(2024,11,5,9,0,0),
            new DateTime(2028,11,7,9,0,0), new DateTime(2032,11,2,9,0,0),
        };

        var r = new When("19961105T090000");
        r.rrule("FREQ=YEARLY;COUNT=10;INTERVAL=4;BYMONTH=11;BYDAY=TU;BYMONTHDAY=2,3,4,5,6,7,8").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}
