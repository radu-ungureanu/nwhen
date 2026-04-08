using Xunit;
using When;
using System;

namespace When.Tests;

public class WhenMonthlyTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>Monthly on the 1st Friday for 10 occurrences: BYDAY=1FR</summary>
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
        r.freq("monthly").count(10).byday("1FR").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Monthly on 1st Friday until Dec 24 1997: BYDAY=1FR;UNTIL=19971224T000000Z</summary>
    [Fact]
    public void TestMonthlyTwo()
    {
        var results = new[]
        {
            new DateTime(1997,9,5,9,0,0), new DateTime(1997,10,3,9,0,0),
            new DateTime(1997,11,7,9,0,0), new DateTime(1997,12,5,9,0,0),
        };

        var r = new When("19970905T090000");
        r.freq("monthly").until(new DateTime(1997,12,24,0,0,0)).byday("1FR").generateOccurrences();

        Assert.Equal(4, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Every other month, 1st and last Sunday: INTERVAL=2;BYDAY=1SU,-1SU</summary>
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
        r.freq("monthly").interval(2).count(10).byday("1SU,-1SU").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Second-to-last Monday of the month: BYDAY=-2MO</summary>
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
        r.freq("monthly").count(6).byday("-2MO").generateOccurrences();

        Assert.Equal(6, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Third-to-last day of month: BYMONTHDAY=-3</summary>
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
        r.freq("monthly").count(6).bymonthday(-3).generateOccurrences();

        Assert.Equal(6, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>2nd and 15th of month: BYMONTHDAY=2,15;COUNT=10</summary>
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
        r.freq("monthly").count(10).bymonthday("2, 15").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>1st and last day of month: BYMONTHDAY=1,-1;COUNT=10</summary>
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
        r.freq("monthly").count(10).bymonthday("1, -1").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Every 18 months, 10th-15th: INTERVAL=18;BYMONTHDAY=10,11,12,13,14,15</summary>
    [Fact]
    public void TestMonthlyEight()
    {
        var results = new[]
        {
            new DateTime(1997,9,10,9,0,0), new DateTime(1997,9,11,9,0,0),
            new DateTime(1997,9,12,9,0,0), new DateTime(1997,9,13,9,0,0),
            new DateTime(1997,9,14,9,0,0), new DateTime(1997,9,15,9,0,0),
            new DateTime(1999,3,10,9,0,0), new DateTime(1999,3,11,9,0,0),
            new DateTime(1999,3,12,9,0,0), new DateTime(1999,3,13,9,0,0),
        };

        var r = new When("19970910T090000");
        r.freq("monthly").interval(18).count(10).bymonthday("10,11,12,13,14,15").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Every Tuesday, every other month: INTERVAL=2;BYDAY=TU</summary>
    [Fact]
    public void TestMonthlyNine()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,11,4,9,0,0),
            new DateTime(1997,11,11,9,0,0), new DateTime(1997,11,18,9,0,0),
            new DateTime(1997,11,25,9,0,0), new DateTime(1998,1,6,9,0,0),
            new DateTime(1998,1,13,9,0,0), new DateTime(1998,1,20,9,0,0),
            new DateTime(1998,1,27,9,0,0), new DateTime(1998,3,3,9,0,0),
            new DateTime(1998,3,10,9,0,0), new DateTime(1998,3,17,9,0,0),
            new DateTime(1998,3,24,9,0,0), new DateTime(1998,3,31,9,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("monthly").interval(2).count(18).byday("tu").generateOccurrences();

        Assert.Equal(18, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Friday the 13th: BYDAY=FR;BYMONTHDAY=13;COUNT=5</summary>
    [Fact]
    public void TestMonthlyTen()
    {
        var results = new[]
        {
            new DateTime(1998,2,13,9,0,0), new DateTime(1998,3,13,9,0,0),
            new DateTime(1998,11,13,9,0,0), new DateTime(1999,8,13,9,0,0),
            new DateTime(2000,10,13,9,0,0),
        };

        var r = new When("19980213T090000");
        r.freq("monthly").count(5).byday("fr").bymonthday(13).generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>First Saturday after first Sunday: BYDAY=SA;BYMONTHDAY=7..13</summary>
    [Fact]
    public void TestMonthlyEleven()
    {
        var results = new[]
        {
            new DateTime(1997,9,13,9,0,0), new DateTime(1997,10,11,9,0,0),
            new DateTime(1997,11,8,9,0,0), new DateTime(1997,12,13,9,0,0),
            new DateTime(1998,1,10,9,0,0), new DateTime(1998,2,7,9,0,0),
            new DateTime(1998,3,7,9,0,0), new DateTime(1998,4,11,9,0,0),
            new DateTime(1998,5,9,9,0,0), new DateTime(1998,6,13,9,0,0),
        };

        var r = new When("19970913T090000");
        r.freq("monthly").count(10).byday("sa").bymonthday("7,8,9,10,11,12,13").generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>3rd TU/WE/TH of month via BYSETPOS=3</summary>
    [Fact]
    public void TestMonthlyTwelve()
    {
        var results = new[]
        {
            new DateTime(1997,9,4,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,11,6,9,0,0),
        };

        var r = new When("19970904T090000");
        r.freq("monthly").count(3).byday("TU, WE, TH").bysetpos("3").generateOccurrences();

        Assert.Equal(3, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Invalid dates (Feb 30) are ignored: BYMONTHDAY=15,30;COUNT=5</summary>
    [Fact]
    public void TestMonthlyThirteen()
    {
        var results = new[]
        {
            new DateTime(2007,1,15,9,0,0), new DateTime(2007,1,30,9,0,0),
            new DateTime(2007,2,15,9,0,0), new DateTime(2007,3,15,9,0,0),
            new DateTime(2007,3,30,9,0,0),
        };

        var r = new When("20070115T090000");
        r.freq("monthly").count(5).bymonthday("15,30").generateOccurrences();

        Assert.Equal(5, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Second-to-last weekday of month: BYDAY=MO..FR;BYSETPOS=-2</summary>
    [Fact]
    public void TestMonthlyFourteen()
    {
        var results = new[]
        {
            new DateTime(1997,9,29,9,0,0), new DateTime(1997,10,30,9,0,0),
            new DateTime(1997,11,27,9,0,0), new DateTime(1997,12,30,9,0,0),
            new DateTime(1998,1,29,9,0,0), new DateTime(1998,2,26,9,0,0),
            new DateTime(1998,3,30,9,0,0),
        };

        var r = new When("19970929T090000");
        r.freq("monthly").count(7)
         .byday(new[] { "MO", "TU", "WE", "TH", "FR" })
         .bysetpos(new[] { -2 })
         .generateOccurrences();

        Assert.Equal(7, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Quarterly first Monday: FREQ=MONTHLY;INTERVAL=3;BYDAY=1MO</summary>
    [Fact]
    public void TestQuarterlyOne()
    {
        var results = new[]
        {
            new DateTime(2019,1,7,17,0,0), new DateTime(2019,4,1,17,0,0),
            new DateTime(2019,7,1,17,0,0), new DateTime(2019,10,7,17,0,0),
            new DateTime(2020,1,6,17,0,0), new DateTime(2020,4,6,17,0,0),
            new DateTime(2020,7,6,17,0,0), new DateTime(2020,10,5,17,0,0),
            new DateTime(2021,1,4,17,0,0),
        };

        var r = new When("20190107T170000");
        r.freq("monthly").interval(3).byday("1MO")
         .until(new DateTime(2021,2,1,18,0,0))
         .generateOccurrences();

        Assert.Equal(results.Length, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }
}
