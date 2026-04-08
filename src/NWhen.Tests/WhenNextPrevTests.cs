using Xunit;
using When;
using System;

namespace When.Tests;

public class WhenNextPrevTests
{
    /// <summary>
    /// Weekly recurrence: 1997-09-02, 09, 16, 23, 30, 10-07, 14, 21, 28, 11-04 (at 09:00)
    /// </summary>
    private static When BuildWeeklyRecurrence()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY");
        return r;
    }

    private static When BuildBoundedWeekly()
    {
        var r = new When("19970902T090000");
        r.rrule("FREQ=WEEKLY").until(new DateTime(1997, 11, 4, 9, 0, 0));
        return r;
    }

    [Fact]
    public void TestGetNextOccurrence()
    {
        var r = BuildWeeklyRecurrence();
        var expected = new DateTime(1997, 9, 23, 9, 0, 0);
        var result = r.getNextOccurrence(new DateTime(1997, 9, 17, 9, 0, 0));
        Assert.NotNull(result);
        Assert.Equal(expected, result!.Value);
    }

    /// <summary>getNextOccurrence with strictlyAfter=false when date exactly matches a recurrence</summary>
    [Fact]
    public void TestGetNextOccurrenceNotStrictlyAfterMatchingDateTime()
    {
        var r = BuildWeeklyRecurrence();
        var expected = new DateTime(1997, 9, 16, 9, 0, 0);
        var result = r.getNextOccurrence(new DateTime(1997, 9, 16, 9, 0, 0), strictlyAfter: false);
        Assert.NotNull(result);
        Assert.Equal(expected, result!.Value);
    }

    /// <summary>getNextOccurrence with strictlyAfter=false but mismatched time — still returns next</summary>
    [Fact]
    public void TestGetNextOccurrenceNotStrictlyAfterMatchingDateMismatchedTime()
    {
        var r = BuildWeeklyRecurrence();
        var expected = new DateTime(1997, 9, 23, 9, 0, 0);
        // 09:30 is after the 09:00 occurrence on 9/16, so even with strictlyAfter=false we skip it
        var result = r.getNextOccurrence(new DateTime(1997, 9, 16, 9, 30, 0), strictlyAfter: false);
        Assert.NotNull(result);
        Assert.Equal(expected, result!.Value);
    }

    /// <summary>getNextOccurrence strictly after a matching date returns the NEXT occurrence</summary>
    [Fact]
    public void TestGetNextOccurrenceStrictlyAfterMatchingDate()
    {
        var r = BuildWeeklyRecurrence();
        var expected = new DateTime(1997, 9, 23, 9, 0, 0);
        var result = r.getNextOccurrence(new DateTime(1997, 9, 16, 9, 0, 0));
        Assert.NotNull(result);
        Assert.Equal(expected, result!.Value);
    }

    /// <summary>getNextOccurrence after the last occurrence returns null (PHP returns false)</summary>
    [Fact]
    public void TestGetNextOccurrenceFromLastOccurrence()
    {
        var r = BuildBoundedWeekly();
        var result = r.getNextOccurrence(new DateTime(1997, 11, 4, 9, 0, 0));
        Assert.Null(result);
    }

    /// <summary>getPrevOccurrence from the last occurrence returns the second-to-last</summary>
    [Fact]
    public void TestGetPrevOccurrenceFromLastOccurrence()
    {
        var r = BuildBoundedWeekly();
        var expected = new DateTime(1997, 10, 28, 9, 0, 0);
        var result = r.getPrevOccurrence(new DateTime(1997, 11, 4, 9, 0, 0));
        Assert.NotNull(result);
        Assert.Equal(expected, result!.Value);
    }

    /// <summary>getPrevOccurrence from the first occurrence returns null (PHP returns false)</summary>
    [Fact]
    public void TestGetPrevOccurrenceFromFirstOccurrence()
    {
        var r = BuildBoundedWeekly();
        var result = r.getPrevOccurrence(new DateTime(1997, 9, 2, 9, 0, 0));
        Assert.Null(result);
    }
}
