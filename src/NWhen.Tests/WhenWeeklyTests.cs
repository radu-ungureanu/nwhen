namespace NWhen.Tests;

public class WhenWeeklyTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>Weekly for 10 occurrences: FREQ=WEEKLY;COUNT=10</summary>
    [Fact]
    public void TestWeeklyOne()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,10,14,9,0,0), new DateTime(1997,10,21,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,4,9,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("weekly").count(10).generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Weekly until December 24, 1997</summary>
    [Fact]
    public void TestWeeklyTwo()
    {
        var r = new When("19970902T090000");
        r.freq("weekly").until(new DateTime(1997,12,24,0,0,0)).generateOccurrences();

        Assert.Equal("1997-09-02 09:00:00", Fmt(r.Occurrences[0]));
        Assert.Equal("1997-12-23 09:00:00", Fmt(r.Occurrences[^1]));
        Assert.Equal(17, r.Occurrences.Count);
    }

    /// <summary>Every other week, WKST=SU, count=13</summary>
    [Fact]
    public void TestWeeklyThree()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,16,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,14,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,11,9,0,0),
            new DateTime(1997,11,25,9,0,0), new DateTime(1997,12,9,9,0,0),
            new DateTime(1997,12,23,9,0,0), new DateTime(1998,1,6,9,0,0),
            new DateTime(1998,1,20,9,0,0), new DateTime(1998,2,3,9,0,0),
            new DateTime(1998,2,17,9,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("weekly").count(13).interval(2).wkst("SU").generateOccurrences();

        Assert.Equal(13, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Weekly on Tuesday and Thursday for five weeks: BYDAY=TU,TH</summary>
    [Fact]
    public void TestWeeklyFour()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,4,9,0,0),
            new DateTime(1997,9,9,9,0,0), new DateTime(1997,9,11,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,18,9,0,0),
            new DateTime(1997,9,23,9,0,0), new DateTime(1997,9,25,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,2,9,0,0),
        };

        var r = new When("19970902T090000");
        r.freq("weekly").until(new DateTime(1997,10,7,0,0,0)).wkst("SU")
         .byday(new[] { "TU", "TH" }).generateOccurrences();

        Assert.Equal(10, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));

        // Same via count
        var r2 = new When("19970902T090000");
        r2.freq("weekly").count(10).wkst("SU").byday(new[] { "TU", "TH" }).generateOccurrences();
        Assert.Equal(10, r2.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r2.Occurrences[i]));
    }

    /// <summary>Every other week on MO,WE,FR with WKST=SU until Dec 24, 1997</summary>
    [Fact]
    public void TestWeeklyFive()
    {
        var results = new[]
        {
            new DateTime(1997,9,1,9,0,0), new DateTime(1997,9,3,9,0,0),
            new DateTime(1997,9,5,9,0,0), new DateTime(1997,9,15,9,0,0),
            new DateTime(1997,9,17,9,0,0), new DateTime(1997,9,19,9,0,0),
            new DateTime(1997,9,29,9,0,0), new DateTime(1997,10,1,9,0,0),
            new DateTime(1997,10,3,9,0,0), new DateTime(1997,10,13,9,0,0),
            new DateTime(1997,10,15,9,0,0), new DateTime(1997,10,17,9,0,0),
            new DateTime(1997,10,27,9,0,0), new DateTime(1997,10,29,9,0,0),
            new DateTime(1997,10,31,9,0,0), new DateTime(1997,11,10,9,0,0),
            new DateTime(1997,11,12,9,0,0), new DateTime(1997,11,14,9,0,0),
            new DateTime(1997,11,24,9,0,0), new DateTime(1997,11,26,9,0,0),
            new DateTime(1997,11,28,9,0,0), new DateTime(1997,12,8,9,0,0),
            new DateTime(1997,12,10,9,0,0), new DateTime(1997,12,12,9,0,0),
            new DateTime(1997,12,22,9,0,0),
        };

        var r = new When("19970901T090000");
        r.freq("weekly").interval(2).until(new DateTime(1997,12,24,0,0,0))
         .wkst("SU").byday(new[] { "MO", "WE", "FR" }).generateOccurrences();

        Assert.Equal(results.Length, r.Occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(r.Occurrences[i]));
    }

    /// <summary>Mon-Fri for 4 weeks: FREQ=WEEKLY;COUNT=20;BYDAY=MO,TU,WE,TH,FR</summary>
    [Fact]
    public void TestWeeklySix()
    {
        var r = new When("19970902T090000");
        r.freq("weekly").count(20).byday(new[] { "MO", "TU", "WE", "TH", "FR" }).generateOccurrences();

        Assert.Equal(20, r.Occurrences.Count);
        Assert.Equal("1997-09-02 09:00:00", Fmt(r.Occurrences[0]));
        Assert.Equal("1997-09-03 09:00:00", Fmt(r.Occurrences[1]));
        Assert.Equal("1997-09-04 09:00:00", Fmt(r.Occurrences[2]));
        Assert.Equal("1997-09-05 09:00:00", Fmt(r.Occurrences[3]));
        Assert.Equal("1997-09-29 09:00:00", Fmt(r.Occurrences[19]));
    }
}
