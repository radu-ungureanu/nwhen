using NWhen.Components;
using System;
using System.Linq;

namespace NWhen;

public class When
{
    public DateTime? StartDate { get; private set; }
    public DateTime? UntilDate { get; private set; }
    public string? Frequency { get; private set; }
    public int? Count { get; private set; }
    public int? Interval { get; private set; }
    public string? WorkWeekStartDay { get; private set; }
    public int[]? BySeconds { get; private set; }
    public int[]? ByMinutes { get; private set; }
    public int[]? ByHours { get; private set; }
    public int[]? ByMonths { get; private set; }
    public int[]? ByWeekNumbers { get; private set; }
    public int[]? ByMonthDays { get; private set; }
    public int[]? ByYearDays { get; private set; }
    public int[]? BySetPositions { get; private set; }
    public string[]? ByDays { get; private set; }
    public bool AdjustMonthEnd { get; private set; }

    /// <summary>
    /// Sets "DTSTART" rule part which contains a date or date-time from which the recurrence rule starts.
    /// </summary>
    /// <param name="date">Start date</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetStartDate(DateTime date)
    {
        StartDate = date;
        return this;
    }

    /// <summary>
    /// Sets "UNTIL" rule part which contains a date or date-time until which the recurrence rule is valid.
    /// </summary>
    /// <param name="date">Limit date</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetUntilDate(DateTime date)
    {
        UntilDate = date;
        return this;
    }

    /// <summary>
    /// Sets "FREQ" rule part which contains the recurrence rule frequency.
    /// </summary>
    /// <param name="frequency">Frequency</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetFrequency(Frequency frequency)
    {
        Frequency = frequency.Value;
        return this;
    }

    /// <summary>
    /// Sets "COUNT" rule part which contains the number of occurrences at which to range-bound the recurrence.
    /// </summary>
    /// <param name="count">Number of occurrences</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetCount(int count)
    {
        Count = count;
        return this;
    }

    /// <summary>
    /// Sets "INTERVAL" rule part which contains a positive integer representing at which intervals the recurrence rule repeats.
    /// </summary>
    /// <param name="interval">Interval</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetInterval(int interval)
    {
        Interval = interval;
        return this;
    }

    /// <summary>
    /// Sets "WKST" rule part which represents the day on which the workweek starts.
    /// </summary>
    /// <param name="weekDay">Day of the week representing the start day of the week</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetWorkWeekStartDay(WeekDay weekDay)
    {
        WorkWeekStartDay = weekDay.Value;
        return this;
    }

    /// <summary>
    /// Sets "BYSECOND" rule part which represents list of seconds within a minute. Valid values are 0 to 60.
    /// </summary>
    /// <param name="seconds">List of seconds</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetBySecond(params Second[] seconds)
    {
        BySeconds = seconds.Select(second => second.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYMINUTE" rule part which represents list of minutes within an hour. Valid values are 0 to 59.
    /// </summary>
    /// <param name="minutes">List of minutes</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetByMinute(params Minute[] minutes)
    {
        ByMinutes = minutes.Select(minute => minute.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYHOUR" rule part which represents list of hours of the day. Valid values are 0 to 23.
    /// </summary>
    /// <param name="hours">List of hours</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetByHour(params Hour[] hours)
    {
        ByHours = hours.Select(hour => hour.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYMONTH" rule part which represents list of months of the year. Valid values are 1 to 12.
    /// </summary>
    /// <param name="months">List of months</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetByMonth(params Month[] months)
    {
        ByMonths = months.Select(month => month.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYWEEKNO" rule part which represents weeks of the year. Valid values are 1 to 53 or -53 to -1.
    /// </summary>
    /// <param name="weekNumbers">List of week numbers</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetByWeekNumber(params WeekNumber[] weekNumbers)
    {
        ByWeekNumbers = weekNumbers.Select(weekNumber => weekNumber.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYMONTHDAY" rule part which represents of days of the month. Valid values are 1 to 31 or -31 to -1.
    /// </summary>
    /// <param name="monthDays">List of month days</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetByMonthDay(params MonthDay[] monthDays)
    {
        ByMonthDays = monthDays.Select(monthDay => monthDay.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYYEARDAY" rule part which represents of days of the year. Valid values are 1 to 366 or -366 to -1.
    /// </summary>
    /// <param name="yearDays">List of year days</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetByYearDay(params YearDay[] yearDays)
    {
        ByYearDays = yearDays.Select(yearDay => yearDay.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYSETPOS" rule part which represents the nth occurrence within the set of recurrence instances specified by the rule. Valid values are 1 to 366 or -366 to -1.
    /// </summary>
    /// <param name="setPos">List of set positions</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetBySetPos(params SetPos[] setPos)
    {
        BySetPositions = setPos.Select(setPos => setPos.Value).ToArray();
        return this;
    }

    /// <summary>
    /// Sets "BYDAY" rule part which represents list of days of the week.
    /// </summary>
    /// <param name="days">List of days</param>
    /// <returns>Current instance of <see cref="When"/></returns>
    public When SetByDay(params Day[] days)
    {
        ByDays = days.Select(day => day.Value).ToArray();
        return this;
    }

    public When SetAdjustMonthEnd(bool adjustMonthEnd)
    {
        AdjustMonthEnd = adjustMonthEnd;
        return this;
    }
}
