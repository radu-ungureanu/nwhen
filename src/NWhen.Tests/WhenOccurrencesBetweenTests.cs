namespace NWhen.Tests;

public class WhenOccurrencesBetweenTests
{
    private static When BuildWeeklyRecurrence()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY");
        return r;
    }

    [Fact]
    public void TestGetWeeklyOccurrencesBetweenEarlySlice()
    {
        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(1997,11,4,9,0,1));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,10,14,9,0,0), new DateTime(1997,10,21,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,4,9,0,0),
        }, occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrencesBetweenLaterSlice()
    {
        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(2016,1,25,9,0,0),
            new DateTime(2016,3,22,9,0,1));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(2016,1,26,9,0,0), new DateTime(2016,2,2,9,0,0),
            new DateTime(2016,2,9,9,0,0), new DateTime(2016,2,16,9,0,0),
            new DateTime(2016,2,23,9,0,0), new DateTime(2016,3,1,9,0,0),
            new DateTime(2016,3,8,9,0,0), new DateTime(2016,3,15,9,0,0),
            new DateTime(2016,3,22,9,0,0),
        }, occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrencesBetweenEarlySliceWithLimit()
    {
        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(1997,11,4,9,0,1),
            3);

        Assert.Equal(new List<DateTime>
        {
            new DateTime(1997,9,2,9,0,0),
            new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0),
        }, occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowBeforeStartDate()
    {
        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(1987,9,2,9,0,0),
            new DateTime(1997,11,4,9,0,1));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,10,14,9,0,0), new DateTime(1997,10,21,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,4,9,0,0),
        }, occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowAfterUntilDate()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY").until(new DateTime(1997,11,5,9,0,0));

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(2007,11,4,9,0,1));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,10,14,9,0,0), new DateTime(1997,10,21,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,4,9,0,0),
        }, occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowBoundedByCount()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY").count(10);

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(2007,11,4,9,0,1));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,10,14,9,0,0), new DateTime(1997,10,21,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,4,9,0,0),
        }, occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowCountAndStartDate()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY").count(10);

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,23,9,0,0),
            new DateTime(2007,11,4,9,0,1));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(1997,9,23,9,0,0), new DateTime(1997,9,30,9,0,0),
            new DateTime(1997,10,7,9,0,0), new DateTime(1997,10,14,9,0,0),
            new DateTime(1997,10,21,9,0,0), new DateTime(1997,10,28,9,0,0),
            new DateTime(1997,11,4,9,0,0),
        }, occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowCountAndStartDateNoResults()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY").count(10);

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,11,5,9,0,0),
            new DateTime(2007,11,4,9,0,1));

        Assert.Empty(occurrences);
    }

    [Fact]
    public void TestGetWeeklyOccurrencesBackwardsDateRange()
    {
        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,11,4,9,0,1),
            new DateTime(1997,9,2,9,0,0));

        Assert.Empty(occurrences);
    }

    /// <summary>Every 2nd Monday monthly between Sept–Dec 1997: FREQ=MONTHLY;BYDAY=MO;BYSETPOS=2</summary>
    [Fact]
    public void TestGetMonthlyOccurrencesBydayBysetpos()
    {
        var r = new When("19970908T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=MO;BYSETPOS=2");

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,1,9,0,0),
            new DateTime(1997,12,1,9,0,0));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(1997,9,8,9,0,0),
            new DateTime(1997,10,13,9,0,0),
            new DateTime(1997,11,10,9,0,0),
        }, occurrences);
    }

    /// <summary>2nd Friday each month between Jul-Nov 2016: FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2</summary>
    [Fact]
    public void TestGetMonthlyOccurrencesBysetposUndefinedOffset()
    {
        var r = new When("20160610T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2");

        var occurrences = r.getOccurrencesBetween(
            new DateTime(2016,7,3,9,0,0),
            new DateTime(2016,11,3,9,0,0));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(2016,7,8,9,0,0), new DateTime(2016,8,12,9,0,0),
            new DateTime(2016,9,9,9,0,0), new DateTime(2016,10,14,9,0,0),
        }, occurrences);
    }

    /// <summary>Same as above but with Aug 12 excluded</summary>
    [Fact]
    public void TestGetOccurrencesBetweenWithExclusions()
    {
        var r = new When("20160610T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2")
         .exclusions(new[] { new DateTime(2016,8,12,9,0,0) });

        var occurrences = r.getOccurrencesBetween(
            new DateTime(2016,7,3,9,0,0),
            new DateTime(2016,11,3,9,0,0));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(2016,7,8,9,0,0),
            new DateTime(2016,9,9,9,0,0),
            new DateTime(2016,10,14,9,0,0),
        }, occurrences);
    }

    /// <summary>Occurrences beyond rangeLimit (200): #201–#205 of weekly from 1997-09-02</summary>
    [Fact]
    public void TestOutsideRangeLimit()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY");

        var occurrences = r.getOccurrencesBetween(
            new DateTime(2001,7,2,9,0,0),
            new DateTime(2001,8,1,9,0,0));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(2001,7,3,9,0,0), new DateTime(2001,7,10,9,0,0),
            new DateTime(2001,7,17,9,0,0), new DateTime(2001,7,24,9,0,0),
            new DateTime(2001,7,31,9,0,0),
        }, occurrences);
    }

    /// <summary>Occurrences within and beyond rangeLimit (200): #195–#205 of weekly from 1997-09-02</summary>
    [Fact]
    public void TestRangeLimit()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY");

        var occurrences = r.getOccurrencesBetween(
            new DateTime(2001,5,21,9,0,0),
            new DateTime(2001,8,1,9,0,0));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(2001,5,22,9,0,0), new DateTime(2001,5,29,9,0,0),
            new DateTime(2001,6,5,9,0,0), new DateTime(2001,6,12,9,0,0),
            new DateTime(2001,6,19,9,0,0), new DateTime(2001,6,26,9,0,0),
            new DateTime(2001,7,3,9,0,0), new DateTime(2001,7,10,9,0,0),
            new DateTime(2001,7,17,9,0,0), new DateTime(2001,7,24,9,0,0),
            new DateTime(2001,7,31,9,0,0),
        }, occurrences);
    }

    /// <summary>Calling getOccurrencesBetween twice doesn''t corrupt results</summary>
    [Fact]
    public void TestCorruptingThis()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY");

        // First call (result discarded)
        r.getOccurrencesBetween(
            new DateTime(2001,5,21,9,0,0),
            new DateTime(2001,6,12,9,0,0));

        // Second call must return correct independent results
        var occurrences = r.getOccurrencesBetween(
            new DateTime(2001,7,2,9,0,0),
            new DateTime(2001,8,1,9,0,0));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(2001,7,3,9,0,0), new DateTime(2001,7,10,9,0,0),
            new DateTime(2001,7,17,9,0,0), new DateTime(2001,7,24,9,0,0),
            new DateTime(2001,7,31,9,0,0),
        }, occurrences);
    }

    /// <summary>Quarterly first Monday via generateOccurrences + getOccurrencesBetween</summary>
    [Fact]
    public void TestGetQuarterlyOccurrencesByDay()
    {
        var r = new When("20190107T170000");
        r.freq("monthly").interval(3).byday("1MO").wkst("MO")
         .until(new DateTime(2021,2,1,18,0,0))
         .generateOccurrences();

        var occurrences = r.getOccurrencesBetween(
            new DateTime(2019,1,1,17,0,0),
            new DateTime(2020,3,1,17,0,0));

        Assert.Equal(new List<DateTime>
        {
            new DateTime(2019,1,7,17,0,0), new DateTime(2019,4,1,17,0,0),
            new DateTime(2019,7,1,17,0,0), new DateTime(2019,10,7,17,0,0),
            new DateTime(2020,1,6,17,0,0),
        }, occurrences);
    }
}
