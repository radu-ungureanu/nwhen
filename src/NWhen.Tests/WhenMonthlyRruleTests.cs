using Xunit;
using When;
using System;

namespace When.Tests;

public class WhenMonthlyRruleTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    [Fact]
    public void TestMonthlyOne()
    {
        var results = new[]
        {
            new DateTime(1997,9,5,9,0,0), new DateTime(1997,10,3,9,0,0),
            new DateTime(1997,11,7,9,0,0), new DateTime(1997,12,5,9,0,0),
            new DateTime(1998,1,2,9,0,0), new DateTime(1998,2,6,9,0,0),
            new DateTime(1998,3,6,9,0,0), new DateTime(1998,4,3,9,0,0),
            new DateTime(1998,5,1,9,0,0), new DateTime(1998,6,5,9,0,0),
        };

        var r = new When("19970905T090000");
        r.rrule("FREQ=MONTHLY;COUNT=10;BYDAY=1FR").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestMonthlyTwo()
    {
        var results = new[]
        {
            new DateTime(1997,9,5,9,0,0), new DateTime(1997,10,3,9,0,0),
            new DateTime(1997,11,7,9,0,0), new DateTime(1997,12,5,9,0,0),
        };

        var r = new When("19970905T090000");
        r.rrule("FREQ=MONTHLY;UNTIL=19971224T000000Z;BYDAY=1FR").generateOccurrences();

        Assert.Equal(4, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestMonthlyThree()
    {
        var results = new[]
        {
            new DateTime(1997,9,7,9,0,0), new DateTime(1997,9,28,9,0,0),
            new DateTime(1997,11,2,9,0,0), new DateTime(1997,11,30,9,0,0),
            new DateTime(1998,1,4,9,0,0), new DateTime(1998,1,25,9,0,0),
            new DateTime(1998,3,1,9,0,0), new DateTime(1998,3,29,9,0,0),
            new DateTime(1998,5,3,9,0,0), new DateTime(1998,5,31,9,0,0),
        };

        var r = new When("19970907T090000");
        r.rrule("FREQ=MONTHLY;INTERVAL=2;COUNT=10;BYDAY=1SU,-1SU").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestMonthlyFour()
    {
        var results = new[]
        {
            new DateTime(1997,9,22,9,0,0), new DateTime(1997,10,20,9,0,0),
            new DateTime(1997,11,17,9,0,0), new DateTime(1997,12,22,9,0,0),
            new DateTime(1998,1,19,9,0,0), new DateTime(1998,2,16,9,0,0),
        };

        var r = new When("19970922T090000");
        r.rrule("FREQ=MONTHLY;COUNT=6;BYDAY=-2MO").generateOccurrences();

        Assert.Equal(6, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestMonthlyFive()
    {
        var results = new[]
        {
            new DateTime(1997,9,28,9,0,0), new DateTime(1997,10,29,9,0,0),
            new DateTime(1997,11,28,9,0,0), new DateTime(1997,12,29,9,0,0),
            new DateTime(1998,1,29,9,0,0), new DateTime(1998,2,26,9,0,0),
        };

        var r = new When("19970928T090000");
        r.rrule("FREQ=MONTHLY;BYMONTHDAY=-3").count(6).generateOccurrences();

        Assert.Equal(6, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestMonthlySix()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,15,9,0,0),
            new DateTime(1997,10,2,9,0,0), new DateTime(1997,10,15,9,0,0),
            new DateTime(1997,11,2,9,0,0), new DateTime(1997,11,15,9,0,0),
            new DateTime(1997,12,2,9,0,0), new DateTime(1997,12,15,9,0,0),
            new DateTime(1998,1,2,9,0,0), new DateTime(1998,1,15,9,0,0),
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=MONTHLY;COUNT=10;BYMONTHDAY=2,15").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    [Fact]
    public void TestMonthlySeven()
    {
        var results = new[]
        {
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,1,9,0,0),
            new DateTime(1997,10,31,9,0,0), new DateTime(1997,11,1,9,0,0),
            new DateTime(1997,11,30,9,0,0), new DateTime(1997,12,1,9,0,0),
            new DateTime(1997,12,31,9,0,0), new DateTime(1998,1,1,9,0,0),
            new DateTime(1998,1,31,9,0,0), new DateTime(1998,2,1,9,0,0),
        };

        var r = new When("19970930T090000");
        r.rrule("FREQ=MONTHLY;COUNT=10;BYMONTHDAY=1,-1").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}
