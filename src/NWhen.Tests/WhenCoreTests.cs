namespace NWhen.Tests;

public class WhenCoreTests
{
    [Fact]
    public void TestValidStartDate()
    {
        var date = new DateTime(2012, 10, 10, 0, 0, 0);
        var test = new When();
        test.startDate(date);
        Assert.Equal(date, test.StartDate);
    }

    [Fact]
    public void TestValidFreq()
    {
        var test = new When();
        test.freq("secondly");
        Assert.Equal("secondly", test.Freq);

        test = new When();
        test.freq("HOURLY");
        Assert.Equal("hourly", test.Freq);
    }

    [Fact]
    public void TestInvalidFreq()
    {
        var test = new When();
        Assert.Throws<ArgumentException>(() => test.freq("monthy"));
    }

    [Fact]
    public void TestValidUntil()
    {
        var date = new DateTime(2024, 12, 31);
        var test = new When();
        test.until(date);
        Assert.Equal(date, test.Until);
    }

    [Fact]
    public void TestValidWkst()
    {
        var test = new When();
        test.wkst("mo");
        Assert.Equal("mo", test.Wkst);
    }

    [Fact]
    public void TestInvalidWkst()
    {
        var test = new When();
        Assert.Throws<ArgumentException>(() => test.wkst("va"));
    }

    [Fact]
    public void TestValidByMonthDay()
    {
        var test = new When();
        test.bymonthday(12);
        Assert.Equal(new List<int> { 12 }, test.Bymonthdays);

        test = new When();
        test.bymonthday(-12);
        Assert.Equal(new List<int> { -12 }, test.Bymonthdays);

        test = new When();
        test.bymonthday("1, 2,3 ");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonthdays);

        test = new When();
        test.bymonthday("1, 2,-3 ,");
        Assert.Equal(new List<int> { 1, 2, -3 }, test.Bymonthdays);

        test = new When();
        test.bymonthday(new[] { -1, 2, 3 });
        Assert.Equal(new List<int> { -1, 2, 3 }, test.Bymonthdays);

        test = new When();
        test.bymonthday("1; 2; 3", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonthdays);

        test = new When();
        test.bymonthday(";1; 2; 3;", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonthdays);
    }

    [Fact]
    public void TestInvalidByMonthDay()
    {
        var test = new When();
        Assert.Throws<ArgumentException>(() => test.bymonthday(32));
    }

    [Fact]
    public void TestValidByYearDay()
    {
        var test = new When();
        test.byyearday(12);
        Assert.Equal(new List<int> { 12 }, test.Byyeardays);

        test = new When();
        test.byyearday(-12);
        Assert.Equal(new List<int> { -12 }, test.Byyeardays);

        test = new When();
        test.byyearday("1, 2,3 ");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Byyeardays);

        test = new When();
        test.byyearday("1, 2,-3 ,");
        Assert.Equal(new List<int> { 1, 2, -3 }, test.Byyeardays);

        test = new When();
        test.byyearday(new[] { -1, 2, 3 });
        Assert.Equal(new List<int> { -1, 2, 3 }, test.Byyeardays);

        test = new When();
        test.byyearday("1; 2; 3", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Byyeardays);

        test = new When();
        test.byyearday(";1; 2; 3;", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Byyeardays);
    }

    [Fact]
    public void TestInvalidByYearDay()
    {
        var test = new When();
        Assert.Throws<ArgumentException>(() => test.byyearday(367));
    }

    [Fact]
    public void TestValidByWeekNo()
    {
        var test = new When();
        test.byweekno(12);
        Assert.Equal(new List<int> { 12 }, test.Byweeknos);

        test = new When();
        test.byweekno(-12);
        Assert.Equal(new List<int> { -12 }, test.Byweeknos);

        test = new When();
        test.byweekno("1, 2,3 ");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Byweeknos);

        test = new When();
        test.byweekno("1, 2,-3 ,");
        Assert.Equal(new List<int> { 1, 2, -3 }, test.Byweeknos);

        test = new When();
        test.byweekno(new[] { -1, 2, 3 });
        Assert.Equal(new List<int> { -1, 2, 3 }, test.Byweeknos);

        test = new When();
        test.byweekno("1; 2; 3", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Byweeknos);

        test = new When();
        test.byweekno(";1; 2; 3;", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Byweeknos);
    }

    [Fact]
    public void TestInvalidByWeekNo()
    {
        var test = new When();
        Assert.Throws<ArgumentException>(() => test.byweekno(55));
    }

    [Fact]
    public void TestValidByMonth()
    {
        var test = new When();
        test.bymonth(12);
        Assert.Equal(new List<int> { 12 }, test.Bymonths);

        test = new When();
        test.bymonth("1, 2,3 ");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonths);

        test = new When();
        test.bymonth("1, 2,3 ,");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonths);

        test = new When();
        test.bymonth(new[] { 1, 2, 3 });
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonths);

        test = new When();
        test.bymonth("1; 2; 3", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonths);

        test = new When();
        test.bymonth(";1; 2; 3;", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bymonths);
    }

    [Fact]
    public void TestInvalidByMonth()
    {
        var test = new When();
        Assert.Throws<ArgumentException>(() => test.bymonth(-1));
    }

    [Fact]
    public void TestValidBySetPos()
    {
        var test = new When();
        test.bysetpos(12);
        Assert.Equal(new List<int> { 12 }, test.Bysetpos);

        test = new When();
        test.bysetpos(-12);
        Assert.Equal(new List<int> { -12 }, test.Bysetpos);

        test = new When();
        test.bysetpos("1, 2,3 ");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bysetpos);

        test = new When();
        test.bysetpos("1, 2,-3 ,");
        Assert.Equal(new List<int> { 1, 2, -3 }, test.Bysetpos);

        test = new When();
        test.bysetpos(new[] { -1, 2, 3 });
        Assert.Equal(new List<int> { -1, 2, 3 }, test.Bysetpos);

        test = new When();
        test.bysetpos("1; 2; 3", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bysetpos);

        test = new When();
        test.bysetpos(";1; 2; 3;", ";");
        Assert.Equal(new List<int> { 1, 2, 3 }, test.Bysetpos);
    }

    [Fact]
    public void TestInvalidBySetPos()
    {
        var test = new When();
        Assert.Throws<ArgumentException>(() => test.bysetpos(367));
    }

    [Fact]
    public void TestValidExclusions()
    {
        var dates = new[] { new DateTime(2019, 1, 1), new DateTime(2019, 01, 02) };

        var test = new When();
        test.exclusions(dates);
        Assert.Equal(dates, test.Exclusions);
    }

    [Fact]
    public void TestInvalidStartDateException_ThrowsWhenStartDateNotFirstOccurrence()
    {
        var r = new When();
        Assert.Throws<InvalidStartDateException>(() =>
        {
            r.startDate(new DateTime(1997, 9, 3, 9, 0, 0))
             .freq("daily")
             .count(3)
             .bymonthday(2)
             .generateOccurrences();
        });
    }

    [Fact]
    public void TestIgnoreModeDoesNotThrow()
    {
        var r = new When();
        r.RFC5545_COMPLIANT = When.IGNORE;
        r.startDate(new DateTime(1997, 9, 3, 9, 0, 0))
         .freq("daily")
         .count(3)
         .bymonthday(2)
         .generateOccurrences();
        // Should not throw
        Assert.True(r.Occurrences.Count >= 0);
    }

    [Fact]
    public void TestFrequencyRequired()
    {
        var r = new When();
        r.startDate(new DateTime(1997, 9, 2, 9, 0, 0))
         .count(5);
        Assert.Throws<FrequencyRequiredException>(() => r.generateOccurrences());
    }

    [Fact]
    public void TestInvalidCombinationByWeekNoNonYearly()
    {
        var r = new When();
        Assert.Throws<InvalidCombinationException>(() =>
            r.startDate(new DateTime(1997, 9, 2))
             .freq("monthly")
             .byweekno(10)
             .count(3)
             .generateOccurrences());
    }
}
