using Xunit;
using When;
using System;
using System.Collections.Generic;

namespace When.Tests;

public class WhenOccurrencesBetweenTests
{
    private static string Fmt(DateTime d) => d.ToString("yyyy-MM-dd HH:mm:ss");

    private static When BuildWeeklyRecurrence()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY");
        return r;
    }

    [Fact]
    public void TestGetWeeklyOccurrencesBetweenEarlySlice()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,10,14,9,0,0), new DateTime(1997,10,21,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,4,9,0,0),
        };

        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(1997,11,4,9,0,1));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }

    [Fact]
    public void TestGetWeeklyOccurrencesBetweenLaterSlice()
    {
        var results = new[]
        {
            new DateTime(2016,1,26,9,0,0), new DateTime(2016,2,2,9,0,0),
            new DateTime(2016,2,9,9,0,0), new DateTime(2016,2,16,9,0,0),
            new DateTime(2016,2,23,9,0,0), new DateTime(2016,3,1,9,0,0),
            new DateTime(2016,3,8,9,0,0), new DateTime(2016,3,15,9,0,0),
            new DateTime(2016,3,22,9,0,0),
        };

        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(2016,1,25,9,0,0),
            new DateTime(2016,3,22,9,0,1));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }

    [Fact]
    public void TestGetWeeklyOccurrencesBetweenEarlySliceWithLimit()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0),
            new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0),
        };

        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(1997,11,4,9,0,1),
            3);

        Assert.Equal(3, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowBeforeStartDate()
    {
        var results = new[]
        {
            new DateTime(1997,9,2,9,0,0), new DateTime(1997,9,9,9,0,0),
            new DateTime(1997,9,16,9,0,0), new DateTime(1997,9,23,9,0,0),
            new DateTime(1997,9,30,9,0,0), new DateTime(1997,10,7,9,0,0),
            new DateTime(1997,10,14,9,0,0), new DateTime(1997,10,21,9,0,0),
            new DateTime(1997,10,28,9,0,0), new DateTime(1997,11,4,9,0,0),
        };

        var r = BuildWeeklyRecurrence();
        var occurrences = r.getOccurrencesBetween(
            new DateTime(1987,9,2,9,0,0),
            new DateTime(1997,11,4,9,0,1));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowAfterUntilDate()
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
        r.rrule("FREQ=WEEKLY").until(new DateTime(1997,11,5,9,0,0));

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(2007,11,4,9,0,1));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowBoundedByCount()
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
        r.rrule("FREQ=WEEKLY").count(10);

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,2,9,0,0),
            new DateTime(2007,11,4,9,0,1));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }

    [Fact]
    public void TestGetWeeklyOccurrenceWindowCountAndStartDate()
    {
        var results = new[]
        {
            new DateTime(1997,9,23,9,0,0), new DateTime(1997,9,30,9,0,0),
            new DateTime(1997,10,7,9,0,0), new DateTime(1997,10,14,9,0,0),
            new DateTime(1997,10,21,9,0,0), new DateTime(1997,10,28,9,0,0),
            new DateTime(1997,11,4,9,0,0),
        };

        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY").count(10);

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,23,9,0,0),
            new DateTime(2007,11,4,9,0,1));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
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
        var results = new[]
        {
            new DateTime(1997,9,8,9,0,0),
            new DateTime(1997,10,13,9,0,0),
            new DateTime(1997,11,10,9,0,0),
        };

        var r = new When("19970908T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=MO;BYSETPOS=2");

        var occurrences = r.getOccurrencesBetween(
            new DateTime(1997,9,1,9,0,0),
            new DateTime(1997,12,1,9,0,0));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }

    /// <summary>2nd Friday each month between Jul-Nov 2016: FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2</summary>
    [Fact]
    public void TestGetMonthlyOccurrencesBysetposUndefinedOffset()
    {
        var results = new[]
        {
            new DateTime(2016,7,8,9,0,0), new DateTime(2016,8,12,9,0,0),
            new DateTime(2016,9,9,9,0,0), new DateTime(2016,10,14,9,0,0),
        };

        var r = new When("20160610T090000");
        r.rrule("FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2");

        var occurrences = r.getOccurrencesBetween(
            new DateTime(2016,7,3,9,0,0),
            new DateTime(2016,11,3,9,0,0));

        Assert.Equal(results.Length, occurrences.Count);
        for (int i = 0; i < results.Length; i++)
            Assert.Equal(Fmt(results[i]), Fmt(occurrences[i]));
    }
}
