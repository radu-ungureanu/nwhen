using Xunit;
using When;
using System;
using System.Collections.Generic;

namespace When.Tests;

public class WhenValidTests
{
    // ---- Freq ----

    [Fact]
    public void TestValidFreq()
    {
        Assert.True(Valid.Freq("Secondly"));
        Assert.True(Valid.Freq("minuTely"));
        Assert.True(Valid.Freq("HOURLY"));
        Assert.True(Valid.Freq("daily"));
        Assert.True(Valid.Freq("weekly"));
        Assert.True(Valid.Freq("monthly"));
        Assert.True(Valid.Freq("yearly"));
    }

    [Fact]
    public void TestInvalidFreq()
    {
        Assert.False(Valid.Freq("month"));
        Assert.False(Valid.Freq(""));
        Assert.False(Valid.Freq("biweekly"));
    }

    // ---- WeekDay ----

    [Fact]
    public void TestValidWeekDay()
    {
        Assert.True(Valid.WeekDay("SU"));
        Assert.True(Valid.WeekDay("MO"));
        Assert.True(Valid.WeekDay("tu"));
        Assert.True(Valid.WeekDay("We"));
        Assert.True(Valid.WeekDay("th"));
        Assert.True(Valid.WeekDay("FR"));
        Assert.True(Valid.WeekDay("sa"));
    }

    [Fact]
    public void TestInvalidWeekDay()
    {
        Assert.False(Valid.WeekDay("va"));
        Assert.False(Valid.WeekDay("XX"));
    }

    // ---- Second ----

    [Fact]
    public void TestValidSecond()
    {
        Assert.True(Valid.Second(0));
        Assert.True(Valid.Second(1));
        Assert.True(Valid.Second(59));
        Assert.True(Valid.Second(60));
    }

    [Fact]
    public void TestInvalidSecond()
    {
        Assert.False(Valid.Second(-1));
        Assert.False(Valid.Second(90));
        Assert.False(Valid.Second(-60));
    }

    // ---- Minute ----

    [Fact]
    public void TestValidMinute()
    {
        Assert.True(Valid.Minute(0));
        Assert.True(Valid.Minute(21));
        Assert.True(Valid.Minute(59));
    }

    [Fact]
    public void TestInvalidMinute()
    {
        Assert.False(Valid.Minute(-1));
        Assert.False(Valid.Minute(99));
        Assert.False(Valid.Minute(60));
    }

    // ---- Hour ----

    [Fact]
    public void TestValidHour()
    {
        Assert.True(Valid.Hour(0));
        Assert.True(Valid.Hour(5));
        Assert.True(Valid.Hour(23));
    }

    [Fact]
    public void TestInvalidHour()
    {
        Assert.False(Valid.Hour(-1));
        Assert.False(Valid.Hour(24));
        Assert.False(Valid.Hour(1000));
    }

    // ---- WeekNum ----

    [Fact]
    public void TestValidWeekNum()
    {
        Assert.True(Valid.WeekNum(1));
        Assert.True(Valid.WeekNum(-1));
        Assert.True(Valid.WeekNum(52));
        Assert.True(Valid.WeekNum(-53));
    }

    [Fact]
    public void TestInvalidWeekNum()
    {
        Assert.False(Valid.WeekNum(0));
        Assert.False(Valid.WeekNum(-54));
        Assert.False(Valid.WeekNum(54));
        Assert.False(Valid.WeekNum(93));
    }

    // ---- OrdWk ----

    [Fact]
    public void TestValidOrdWk()
    {
        Assert.True(Valid.OrdWk(1));
        Assert.True(Valid.OrdWk(52));
        Assert.True(Valid.OrdWk(53));
    }

    [Fact]
    public void TestInvalidOrdWk()
    {
        Assert.False(Valid.OrdWk(0));
        Assert.False(Valid.OrdWk(-1));
        Assert.False(Valid.OrdWk(54));
    }

    // ---- YearDayNum ----

    [Fact]
    public void TestValidYearDayNum()
    {
        Assert.True(Valid.YearDayNum(1));
        Assert.True(Valid.YearDayNum(-1));
        Assert.True(Valid.YearDayNum(90));
        Assert.True(Valid.YearDayNum(-366));
    }

    [Fact]
    public void TestInvalidYearDayNum()
    {
        Assert.False(Valid.YearDayNum(0));
        Assert.False(Valid.YearDayNum(-367));
        Assert.False(Valid.YearDayNum(380));
        Assert.False(Valid.YearDayNum(399));
    }

    // ---- SetPosDay ----

    [Fact]
    public void TestValidSetPosDay()
    {
        Assert.True(Valid.SetPosDay(1));
        Assert.True(Valid.SetPosDay(-1));
        Assert.True(Valid.SetPosDay(150));
        Assert.True(Valid.SetPosDay(-366));
    }

    [Fact]
    public void TestInvalidSetPosDay()
    {
        Assert.False(Valid.SetPosDay(0));
        Assert.False(Valid.SetPosDay(-367));
        Assert.False(Valid.SetPosDay(380));
        Assert.False(Valid.SetPosDay(399));
    }

    // ---- MonthNum ----

    [Fact]
    public void TestValidMonthNum()
    {
        Assert.True(Valid.MonthNum(1));
        Assert.True(Valid.MonthNum(9));
        Assert.True(Valid.MonthNum(12));
    }

    [Fact]
    public void TestInvalidMonthNum()
    {
        Assert.False(Valid.MonthNum(-1));
        Assert.False(Valid.MonthNum(0));
        Assert.False(Valid.MonthNum(99));
    }

    // ---- OrdYrDay ----

    [Fact]
    public void TestValidOrdYrDay()
    {
        Assert.True(Valid.OrdYrDay(1));
        Assert.True(Valid.OrdYrDay(366));
        Assert.True(Valid.OrdYrDay(365));
    }

    [Fact]
    public void TestInvalidOrdYrDay()
    {
        Assert.False(Valid.OrdYrDay(0));
        Assert.False(Valid.OrdYrDay(-1));
        Assert.False(Valid.OrdYrDay(367));
    }

    // ---- ItemsList ----

    [Fact]
    public void TestValidItemsList()
    {
        Assert.True(Valid.ItemsList(new List<int> { 1, 3, 5 }, Valid.Second));
        Assert.True(Valid.ItemsList(new List<int> { 1, 3, 5 }, Valid.Minute));
        Assert.True(Valid.ItemsList(new List<int> { 1, 3, 5 }, Valid.Hour));
        Assert.True(Valid.ItemsList(new List<int> { -1, -3, -5, 5, 30 }, Valid.MonthDayNum));
        Assert.True(Valid.ItemsList(new List<int> { -300, -3, -5, 5, 366 }, Valid.YearDayNum));
    }

    [Fact]
    public void TestInvalidItemsList()
    {
        Assert.False(Valid.ItemsList(new List<int> { 1, 3, 99 }, Valid.Second));
        Assert.False(Valid.ItemsList(new List<int> { 1, -3, 51 }, Valid.Minute));
        Assert.False(Valid.ItemsList(new List<int> { -1, 3, 24 }, Valid.Hour));
        Assert.False(Valid.ItemsList(new List<int> { -1, -3, -5, 5, 55 }, Valid.MonthDayNum));
        Assert.False(Valid.ItemsList(new List<int> { -300, -3, -5, 5, 367 }, Valid.YearDayNum));
    }

    // ---- DaysList ----

    [Fact]
    public void TestValidDaysList()
    {
        Assert.True(Valid.DaysList(new List<string> { "-52MO", "-2TU", "+1WE", "SA", "40TU" }));
        Assert.True(Valid.DaysList(new List<string> { "-52Mo", "-2tU", "+1WE", "SA", "40TU" }));
    }

    [Fact]
    public void TestInvalidDaysList()
    {
        Assert.False(Valid.DaysList(new List<string> { "-asdf" }));
        Assert.False(Valid.DaysList(new List<string> { "-54mo" }));
        Assert.False(Valid.DaysList(new List<string> { "-54TA" }));
        Assert.False(Valid.DaysList(new List<string> { "-52MO", "+1WA" }));
    }

    // ---- MonthDayNum ----

    [Fact]
    public void TestValidMonthDayNum()
    {
        Assert.True(Valid.MonthDayNum(1));
        Assert.True(Valid.MonthDayNum(-1));
        Assert.True(Valid.MonthDayNum(-23));
        Assert.True(Valid.MonthDayNum(31));
    }

    [Fact]
    public void TestInvalidMonthDayNum()
    {
        Assert.False(Valid.MonthDayNum(0));
        Assert.False(Valid.MonthDayNum(-32));
        Assert.False(Valid.MonthDayNum(99));
        Assert.False(Valid.MonthDayNum(32));
    }

    // ---- OrdMoDay ----

    [Fact]
    public void TestValidOrdMoDay()
    {
        Assert.True(Valid.OrdMoDay(1));
        Assert.True(Valid.OrdMoDay(23));
        Assert.True(Valid.OrdMoDay(31));
    }

    [Fact]
    public void TestInvalidOrdMoDay()
    {
        Assert.False(Valid.OrdMoDay(0));
        Assert.False(Valid.OrdMoDay(-1));
        Assert.False(Valid.OrdMoDay(99));
        Assert.False(Valid.OrdMoDay(32));
    }

    // ---- DateTimeList ----

    [Fact]
    public void TestValidDateTimeList()
    {
        Assert.True(Valid.DateTimeList(new List<object> { DateTime.Now }));
        Assert.True(Valid.DateTimeList(new List<object> { DateTime.Now, DateTime.Now }));
        // PHP: assertTrue([date_create(), 'string']) — true because ANY element is a DateTime
        Assert.True(Valid.DateTimeList(new List<object> { DateTime.Now, "string" }));
    }

    [Fact]
    public void TestInvalidDateTimeList()
    {
        Assert.False(Valid.DateTimeList(Array.Empty<object>()));
        Assert.False(Valid.DateTimeList(new List<object> { "string" }));
        Assert.False(Valid.DateTimeList(new List<object> { "string", "string2" }));
    }
}
