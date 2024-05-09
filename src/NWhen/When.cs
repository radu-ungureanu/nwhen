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

    public When SetStartDate(DateTime date)
    {
        StartDate = date;
        return this;
    }

    public When SetUntilDate(DateTime date)
    {
        UntilDate = date;
        return this;
    }

    public When SetFrequency(Frequency frequency)
    {
        Frequency = frequency.Value;
        return this;
    }

    public When SetCount(int count)
    {
        Count = count;
        return this;
    }

    public When SetInterval(int interval)
    {
        Interval = interval;
        return this;
    }

    public When SetWorkWeekStartDay(WeekDay weekDay)
    {
        WorkWeekStartDay = weekDay.Value;
        return this;
    }

    public When SetBySecond(params Second[] seconds)
    {
        BySeconds = seconds.Select(second => second.Value).ToArray();
        return this;
    }

    public When SetByMinute(params Minute[] minutes)
    {
        ByMinutes = minutes.Select(minute => minute.Value).ToArray();
        return this;
    }

    public When SetByHour(params Hour[] hours)
    {
        ByHours = hours.Select(hour => hour.Value).ToArray();
        return this;
    }

    public When SetByMonth(params Month[] months)
    {
        ByMonths = months.Select(month => month.Value).ToArray();
        return this;
    }
}
