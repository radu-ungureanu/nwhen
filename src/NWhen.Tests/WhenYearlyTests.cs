namespace NWhen.Tests;

public class WhenYearlyTests
{
    [Fact]
    public void TestYearlyOne()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 6, 10, 9, 0, 0), new DateTime(1997, 7, 10, 9, 0, 0),
            new DateTime(1998, 6, 10, 9, 0, 0), new DateTime(1998, 7, 10, 9, 0, 0),
            new DateTime(1999, 6, 10, 9, 0, 0), new DateTime(1999, 7, 10, 9, 0, 0),
            new DateTime(2000, 6, 10, 9, 0, 0), new DateTime(2000, 7, 10, 9, 0, 0),
            new DateTime(2001, 6, 10, 9, 0, 0), new DateTime(2001, 7, 10, 9, 0, 0)
        };

        var r = new When("19970610T090000");
        r.freq("yearly").count(10).bymonth("6, 7").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyTwo()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 1, 1, 9, 0, 0), new DateTime(1997, 4, 10, 9, 0, 0),
            new DateTime(1997, 7, 19, 9, 0, 0), new DateTime(2000, 1, 1, 9, 0, 0),
            new DateTime(2000, 4, 9, 9, 0, 0), new DateTime(2000, 7, 18, 9, 0, 0),
            new DateTime(2003, 1, 1, 9, 0, 0), new DateTime(2003, 4, 10, 9, 0, 0),
            new DateTime(2003, 7, 19, 9, 0, 0), new DateTime(2006, 1, 1, 9, 0, 0)
        };

        var r = new When("19970101T090000");
        r.freq("yearly").interval(3).count(10).byyearday("1,100,200").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyThree()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 3, 10, 9, 0, 0), new DateTime(1999, 1, 10, 9, 0, 0),
            new DateTime(1999, 2, 10, 9, 0, 0), new DateTime(1999, 3, 10, 9, 0, 0),
            new DateTime(2001, 1, 10, 9, 0, 0), new DateTime(2001, 2, 10, 9, 0, 0),
            new DateTime(2001, 3, 10, 9, 0, 0), new DateTime(2003, 1, 10, 9, 0, 0),
            new DateTime(2003, 2, 10, 9, 0, 0), new DateTime(2003, 3, 10, 9, 0, 0)
        };

        var r = new When("19970310T090000");
        r.freq("yearly").interval(2).count(10).bymonth("1,2,3").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyFour()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1998, 1, 1, 9, 0, 0), new DateTime(1998, 1, 2, 9, 0, 0),
            new DateTime(1998, 1, 3, 9, 0, 0), new DateTime(1998, 1, 4, 9, 0, 0),
            new DateTime(1998, 1, 5, 9, 0, 0), new DateTime(1998, 1, 6, 9, 0, 0),
            new DateTime(1998, 1, 7, 9, 0, 0), new DateTime(1998, 1, 8, 9, 0, 0),
            new DateTime(1998, 1, 9, 9, 0, 0), new DateTime(1998, 1, 10, 9, 0, 0),
            new DateTime(1998, 1, 11, 9, 0, 0), new DateTime(1998, 1, 12, 9, 0, 0),
            new DateTime(1998, 1, 13, 9, 0, 0), new DateTime(1998, 1, 14, 9, 0, 0),
            new DateTime(1998, 1, 15, 9, 0, 0), new DateTime(1998, 1, 16, 9, 0, 0),
            new DateTime(1998, 1, 17, 9, 0, 0), new DateTime(1998, 1, 18, 9, 0, 0),
            new DateTime(1998, 1, 19, 9, 0, 0), new DateTime(1998, 1, 20, 9, 0, 0),
            new DateTime(1998, 1, 21, 9, 0, 0), new DateTime(1998, 1, 22, 9, 0, 0),
            new DateTime(1998, 1, 23, 9, 0, 0), new DateTime(1998, 1, 24, 9, 0, 0),
            new DateTime(1998, 1, 25, 9, 0, 0), new DateTime(1998, 1, 26, 9, 0, 0),
            new DateTime(1998, 1, 27, 9, 0, 0), new DateTime(1998, 1, 28, 9, 0, 0),
            new DateTime(1998, 1, 29, 9, 0, 0), new DateTime(1998, 1, 30, 9, 0, 0),
            new DateTime(1998, 1, 31, 9, 0, 0),
            new DateTime(1999, 1, 1, 9, 0, 0), new DateTime(1999, 1, 2, 9, 0, 0),
            new DateTime(1999, 1, 3, 9, 0, 0), new DateTime(1999, 1, 4, 9, 0, 0),
            new DateTime(1999, 1, 5, 9, 0, 0), new DateTime(1999, 1, 6, 9, 0, 0),
            new DateTime(1999, 1, 7, 9, 0, 0), new DateTime(1999, 1, 8, 9, 0, 0),
            new DateTime(1999, 1, 9, 9, 0, 0), new DateTime(1999, 1, 10, 9, 0, 0),
            new DateTime(1999, 1, 11, 9, 0, 0), new DateTime(1999, 1, 12, 9, 0, 0),
            new DateTime(1999, 1, 13, 9, 0, 0), new DateTime(1999, 1, 14, 9, 0, 0),
            new DateTime(1999, 1, 15, 9, 0, 0), new DateTime(1999, 1, 16, 9, 0, 0),
            new DateTime(1999, 1, 17, 9, 0, 0), new DateTime(1999, 1, 18, 9, 0, 0),
            new DateTime(1999, 1, 19, 9, 0, 0), new DateTime(1999, 1, 20, 9, 0, 0),
            new DateTime(1999, 1, 21, 9, 0, 0), new DateTime(1999, 1, 22, 9, 0, 0),
            new DateTime(1999, 1, 23, 9, 0, 0), new DateTime(1999, 1, 24, 9, 0, 0),
            new DateTime(1999, 1, 25, 9, 0, 0), new DateTime(1999, 1, 26, 9, 0, 0),
            new DateTime(1999, 1, 27, 9, 0, 0), new DateTime(1999, 1, 28, 9, 0, 0),
            new DateTime(1999, 1, 29, 9, 0, 0), new DateTime(1999, 1, 30, 9, 0, 0),
            new DateTime(1999, 1, 31, 9, 0, 0),
            new DateTime(2000, 1, 1, 9, 0, 0), new DateTime(2000, 1, 2, 9, 0, 0),
            new DateTime(2000, 1, 3, 9, 0, 0), new DateTime(2000, 1, 4, 9, 0, 0),
            new DateTime(2000, 1, 5, 9, 0, 0), new DateTime(2000, 1, 6, 9, 0, 0),
            new DateTime(2000, 1, 7, 9, 0, 0), new DateTime(2000, 1, 8, 9, 0, 0),
            new DateTime(2000, 1, 9, 9, 0, 0), new DateTime(2000, 1, 10, 9, 0, 0),
            new DateTime(2000, 1, 11, 9, 0, 0), new DateTime(2000, 1, 12, 9, 0, 0),
            new DateTime(2000, 1, 13, 9, 0, 0), new DateTime(2000, 1, 14, 9, 0, 0),
            new DateTime(2000, 1, 15, 9, 0, 0), new DateTime(2000, 1, 16, 9, 0, 0),
            new DateTime(2000, 1, 17, 9, 0, 0), new DateTime(2000, 1, 18, 9, 0, 0),
            new DateTime(2000, 1, 19, 9, 0, 0), new DateTime(2000, 1, 20, 9, 0, 0),
            new DateTime(2000, 1, 21, 9, 0, 0), new DateTime(2000, 1, 22, 9, 0, 0),
            new DateTime(2000, 1, 23, 9, 0, 0), new DateTime(2000, 1, 24, 9, 0, 0),
            new DateTime(2000, 1, 25, 9, 0, 0), new DateTime(2000, 1, 26, 9, 0, 0),
            new DateTime(2000, 1, 27, 9, 0, 0), new DateTime(2000, 1, 28, 9, 0, 0),
            new DateTime(2000, 1, 29, 9, 0, 0), new DateTime(2000, 1, 30, 9, 0, 0),
            new DateTime(2000, 1, 31, 9, 0, 0)
        };

        var r = new When("19980101T090000");
        r.freq("yearly")
         .until(new DateTime(2000, 1, 31, 9, 0, 0))
         .bymonth("1")
         .byday("su,mo,tu,we,th,fr,sa")
         .generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyFive()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 5, 12, 9, 0, 0), new DateTime(1998, 5, 11, 9, 0, 0),
            new DateTime(1999, 5, 17, 9, 0, 0), new DateTime(2000, 5, 15, 9, 0, 0),
            new DateTime(2001, 5, 14, 9, 0, 0), new DateTime(2002, 5, 13, 9, 0, 0),
            new DateTime(2003, 5, 12, 9, 0, 0), new DateTime(2004, 5, 10, 9, 0, 0),
            new DateTime(2005, 5, 16, 9, 0, 0), new DateTime(2006, 5, 15, 9, 0, 0)
        };

        var r = new When("19970512T090000");
        r.freq("yearly").count(10).byweekno(20).byday("mo").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlySix()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 3, 13, 9, 0, 0), new DateTime(1997, 3, 20, 9, 0, 0),
            new DateTime(1997, 3, 27, 9, 0, 0), new DateTime(1998, 3, 5, 9, 0, 0),
            new DateTime(1998, 3, 12, 9, 0, 0), new DateTime(1998, 3, 19, 9, 0, 0),
            new DateTime(1998, 3, 26, 9, 0, 0), new DateTime(1999, 3, 4, 9, 0, 0),
            new DateTime(1999, 3, 11, 9, 0, 0), new DateTime(1999, 3, 18, 9, 0, 0)
        };

        var r = new When("19970313T090000");
        r.freq("yearly").count(10).bymonth(3).byday("th").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlySeven()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 6, 5, 9, 0, 0), new DateTime(1997, 6, 12, 9, 0, 0),
            new DateTime(1997, 6, 19, 9, 0, 0), new DateTime(1997, 6, 26, 9, 0, 0),
            new DateTime(1997, 7, 3, 9, 0, 0), new DateTime(1997, 7, 10, 9, 0, 0),
            new DateTime(1997, 7, 17, 9, 0, 0), new DateTime(1997, 7, 24, 9, 0, 0),
            new DateTime(1997, 7, 31, 9, 0, 0), new DateTime(1997, 8, 7, 9, 0, 0),
            new DateTime(1997, 8, 14, 9, 0, 0), new DateTime(1997, 8, 21, 9, 0, 0),
            new DateTime(1997, 8, 28, 9, 0, 0), new DateTime(1998, 6, 4, 9, 0, 0),
            new DateTime(1998, 6, 11, 9, 0, 0), new DateTime(1998, 6, 18, 9, 0, 0),
            new DateTime(1998, 6, 25, 9, 0, 0), new DateTime(1998, 7, 2, 9, 0, 0),
            new DateTime(1998, 7, 9, 9, 0, 0), new DateTime(1998, 7, 16, 9, 0, 0),
            new DateTime(1998, 7, 23, 9, 0, 0), new DateTime(1998, 7, 30, 9, 0, 0),
            new DateTime(1998, 8, 6, 9, 0, 0), new DateTime(1998, 8, 13, 9, 0, 0),
            new DateTime(1998, 8, 20, 9, 0, 0), new DateTime(1998, 8, 27, 9, 0, 0),
            new DateTime(1999, 6, 3, 9, 0, 0), new DateTime(1999, 6, 10, 9, 0, 0),
            new DateTime(1999, 6, 17, 9, 0, 0), new DateTime(1999, 6, 24, 9, 0, 0),
            new DateTime(1999, 7, 1, 9, 0, 0), new DateTime(1999, 7, 8, 9, 0, 0),
            new DateTime(1999, 7, 15, 9, 0, 0), new DateTime(1999, 7, 22, 9, 0, 0),
            new DateTime(1999, 7, 29, 9, 0, 0), new DateTime(1999, 8, 5, 9, 0, 0),
            new DateTime(1999, 8, 12, 9, 0, 0), new DateTime(1999, 8, 19, 9, 0, 0),
            new DateTime(1999, 8, 26, 9, 0, 0)
        };

        var r = new When("19970605T090000");
        r.freq("yearly").count(39).bymonth("6,7,8").byday("th").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyEight()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1996, 11, 5, 9, 0, 0), new DateTime(2000, 11, 7, 9, 0, 0),
            new DateTime(2004, 11, 2, 9, 0, 0), new DateTime(2008, 11, 4, 9, 0, 0),
            new DateTime(2012, 11, 6, 9, 0, 0), new DateTime(2016, 11, 8, 9, 0, 0),
            new DateTime(2020, 11, 3, 9, 0, 0), new DateTime(2024, 11, 5, 9, 0, 0),
            new DateTime(2028, 11, 7, 9, 0, 0), new DateTime(2032, 11, 2, 9, 0, 0)
        };

        var r = new When("19961105T090000");
        r.freq("yearly").count(10).interval(4)
         .bymonth(11).byday("tu").bymonthday("2,3,4,5,6,7,8")
         .generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyNine()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 1, 1, 9, 0, 0), new DateTime(1997, 4, 10, 9, 0, 0),
            new DateTime(1997, 7, 19, 9, 0, 0), new DateTime(2000, 1, 1, 9, 0, 0),
            new DateTime(2000, 4, 9, 9, 0, 0), new DateTime(2000, 7, 18, 9, 0, 0),
            new DateTime(2003, 1, 1, 9, 0, 0), new DateTime(2003, 4, 10, 9, 0, 0),
            new DateTime(2003, 7, 19, 9, 0, 0), new DateTime(2006, 1, 1, 9, 0, 0)
        };

        var r = new When("19970101T090000");
        r.freq("yearly").count(10).interval(3).byyearday("1,100,200").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyTen()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2010, 12, 31, 9, 0, 0),
            new DateTime(2011, 6, 15, 9, 0, 0),
            new DateTime(2011, 9, 23, 9, 0, 0),
            new DateTime(2011, 12, 31, 9, 0, 0),
            new DateTime(2012, 6, 15, 9, 0, 0)
        };

        var r = new When("20101231T090000");
        r.freq("yearly").count(5).byyearday("-1, -100, -200").generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyEleven()
    {
        var expected = new List<DateTime>
        {
            new DateTime(1997, 1, 5, 8, 30, 0),
            new DateTime(1997, 1, 5, 9, 30, 0),
            new DateTime(1997, 1, 12, 8, 30, 0),
            new DateTime(1997, 1, 12, 9, 30, 0),
            new DateTime(1997, 1, 19, 8, 30, 0),
            new DateTime(1997, 1, 19, 9, 30, 0),
            new DateTime(1997, 1, 26, 8, 30, 0),
            new DateTime(1997, 1, 26, 9, 30, 0),
            new DateTime(1999, 1, 3, 8, 30, 0),
            new DateTime(1999, 1, 3, 9, 30, 0)
        };

        var r = new When("19970105T083000");
        r.freq("yearly").interval(2).bymonth(1).byday("su")
         .byhour("8,9").byminute("30").count(10)
         .generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }

    [Fact]
    public void TestYearlyTheninthnode()
    {
        var expected = new List<DateTime>
        {
            new DateTime(2015, 9, 17, 0, 0, 0),
            new DateTime(2016, 9, 17, 0, 0, 0),
            new DateTime(2017, 9, 17, 0, 0, 0),
            new DateTime(2018, 9, 17, 0, 0, 0),
            new DateTime(2019, 9, 17, 0, 0, 0)
        };

        var r = new When("20150917T000000");
        r.freq("yearly").interval(1).count(5).generateOccurrences();

        Assert.Equal(expected, r.Occurrences);
    }
}
