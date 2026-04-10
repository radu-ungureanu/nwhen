using System.Globalization;

namespace NWhen;

public class When
{
    // ── RFC 5545 compliance modes ───────────────────────────────────────────
    public const int EXCEPTION = 0;
    public const int IGNORE = 2;

    // ── Public properties ───────────────────────────────────────────────────
    public int RFC5545_COMPLIANT = EXCEPTION;
    public DateTime? StartDate;
    public string? Freq;          // lowercase: "secondly"|"minutely"|"hourly"|"daily"|"weekly"|"monthly"|"yearly"
    public DateTime? Until;
    public int? Count;
    public int? Interval;
    public List<DateTime> Exclusions = new();

    public List<int>? Byseconds;
    public List<int>? Byminutes;
    public List<int>? Byhours;
    public List<string>? Bydays;      // "{ordinal}{abbrev}" e.g. "0fr", "1mo", "-1su"
    public List<int>? Bymonthdays;
    public List<int>? Byyeardays;
    public List<int>? Byweeknos;
    public List<int>? Bymonths;
    public List<int>? Bysetpos;
    public string? Wkst;
    public bool ShouldAdjustMonthEnd = false;

    public List<DateTime> Occurrences = new();
    public int RangeLimit = 200;

    // ── Constructors ────────────────────────────────────────────────────────

    public When()
    {
        StartDate = DateTime.Now;
    }

    public When(string dateTimeStr)
    {
        StartDate = ParseDateTime(dateTimeStr);
    }

    public When(DateTime dt)
    {
        StartDate = dt;
    }

    // ── Fluent setters ──────────────────────────────────────────────────────

    public When SetStartDate(DateTime startDate)
    {
        StartDate = startDate;
        return this;
    }

    /// <summary>Accepts a DateTime object — mirrors PHP startDate($dt).</summary>
    public When startDate(DateTime startDate) => SetStartDate(startDate);

    public When freq(string frequency)
    {
        if (!Valid.Freq(frequency))
            throw new ArgumentException($"freq: Accepts {string.Join(", ", Valid.Frequencies)}");
        Freq = frequency.ToLowerInvariant();
        return this;
    }

    public When until(DateTime endDate)
    {
        Until = endDate;
        return this;
    }

    public When count(int c)
    {
        Count = c;
        return this;
    }

    public When count(string c)
    {
        if (!int.TryParse(c, out int parsed))
            throw new ArgumentException("count: Accepts numeric values");
        Count = parsed;
        return this;
    }

    public When interval(int i)
    {
        Interval = i;
        return this;
    }

    public When interval(string i)
    {
        if (!int.TryParse(i, out int parsed))
            throw new ArgumentException("interval: Accepts numeric values");
        Interval = parsed;
        return this;
    }

    public When bysecond(int second)
    {
        if (!Valid.Second(second))
            throw new ArgumentException("bysecond: Accepts numeric values between 0 and 60");
        Byseconds = new List<int> { second };
        return this;
    }

    public When bysecond(IEnumerable<int> seconds)
    {
        var list = seconds.ToList();
        if (!Valid.ItemsList(list, Valid.Second))
            throw new ArgumentException("bysecond: Accepts numeric values between 0 and 60");
        Byseconds = list;
        return this;
    }

    public When bysecond(string seconds, string delimiter = ",")
    {
        Byseconds = PrepareItemsList(seconds, delimiter, Valid.Second,
            "bysecond: Accepts numeric values between 0 and 60");
        return this;
    }

    public When byminute(int minute)
    {
        if (!Valid.Minute(minute))
            throw new ArgumentException("byminute: Accepts numeric values between 0 and 59");
        Byminutes = new List<int> { minute };
        return this;
    }

    public When byminute(IEnumerable<int> minutes)
    {
        var list = minutes.ToList();
        if (!Valid.ItemsList(list, Valid.Minute))
            throw new ArgumentException("byminute: Accepts numeric values between 0 and 59");
        Byminutes = list;
        return this;
    }

    public When byminute(string minutes, string delimiter = ",")
    {
        Byminutes = PrepareItemsList(minutes, delimiter, Valid.Minute,
            "byminute: Accepts numeric values between 0 and 59");
        return this;
    }

    public When byhour(int hour)
    {
        if (!Valid.Hour(hour))
            throw new ArgumentException("byhour: Accepts numeric values between 0 and 23");
        Byhours = new List<int> { hour };
        return this;
    }

    public When byhour(IEnumerable<int> hours)
    {
        var list = hours.ToList();
        if (!Valid.ItemsList(list, Valid.Hour))
            throw new ArgumentException("byhour: Accepts numeric values between 0 and 23");
        Byhours = list;
        return this;
    }

    public When byhour(string hours, string delimiter = ",")
    {
        Byhours = PrepareItemsList(hours, delimiter, Valid.Hour,
            "byhour: Accepts numeric values between 0 and 23");
        return this;
    }

    public When byday(string bywdaylist, string delimiter = ",")
    {
        var parts = SplitAndTrim(bywdaylist, delimiter);
        if (!Valid.DaysList(parts))
            throw new ArgumentException("bydays: Accepts (optional) positive and negative values between -53 and 53 followed by a valid week day");
        Bydays = CreateDaysList(parts);
        return this;
    }

    public When byday(IEnumerable<string> days)
    {
        var list = days.ToList();
        if (!Valid.DaysList(list))
            throw new ArgumentException("bydays: Accepts (optional) positive and negative values between -53 and 53 followed by a valid week day");
        Bydays = CreateDaysList(list);
        return this;
    }

    public When exclusions(IEnumerable<DateTime> exclusionList)
    {
        Exclusions = exclusionList.ToList();
        return this;
    }

    public When exclusions(string exclusionList, string delimiter = ",")
    {
        var parts = SplitAndTrim(exclusionList, delimiter);
        Exclusions = parts.Select(p => DateTime.Parse(p)).ToList();
        return this;
    }

    public When bymonthday(int day)
    {
        if (!Valid.MonthDayNum(day))
            throw new ArgumentException("bymonthday: Accepts positive and negative values between 1 and 31");
        Bymonthdays = new List<int> { day };
        return this;
    }

    public When bymonthday(IEnumerable<int> days)
    {
        var list = days.ToList();
        if (!Valid.ItemsList(list, Valid.MonthDayNum))
            throw new ArgumentException("bymonthday: Accepts positive and negative values between 1 and 31");
        Bymonthdays = list;
        return this;
    }

    public When bymonthday(string days, string delimiter = ",")
    {
        Bymonthdays = PrepareItemsList(days, delimiter, Valid.MonthDayNum,
            "bymonthday: Accepts positive and negative values between 1 and 31");
        return this;
    }

    public When byyearday(int day)
    {
        if (!Valid.YearDayNum(day))
            throw new ArgumentException("byyearday: Accepts positive and negative values between 1 and 366");
        Byyeardays = new List<int> { day };
        return this;
    }

    public When byyearday(IEnumerable<int> days)
    {
        var list = days.ToList();
        if (!Valid.ItemsList(list, Valid.YearDayNum))
            throw new ArgumentException("byyearday: Accepts positive and negative values between 1 and 366");
        Byyeardays = list;
        return this;
    }

    public When byyearday(string days, string delimiter = ",")
    {
        Byyeardays = PrepareItemsList(days, delimiter, Valid.YearDayNum,
            "byyearday: Accepts positive and negative values between 1 and 366");
        return this;
    }

    public When byweekno(int week)
    {
        if (!Valid.WeekNum(week))
            throw new ArgumentException("byweekno: Accepts positive and negative values between 1 and 53");
        Byweeknos = new List<int> { week };
        return this;
    }

    public When byweekno(IEnumerable<int> weeks)
    {
        var list = weeks.ToList();
        if (!Valid.ItemsList(list, Valid.WeekNum))
            throw new ArgumentException("byweekno: Accepts positive and negative values between 1 and 53");
        Byweeknos = list;
        return this;
    }

    public When byweekno(string weeks, string delimiter = ",")
    {
        Byweeknos = PrepareItemsList(weeks, delimiter, Valid.WeekNum,
            "byweekno: Accepts positive and negative values between 1 and 53");
        return this;
    }

    public When bymonth(int month)
    {
        if (!Valid.MonthNum(month))
            throw new ArgumentException("bymonth: Accepts values between 1 and 12");
        Bymonths = new List<int> { month };
        return this;
    }

    public When bymonth(IEnumerable<int> months)
    {
        var list = months.ToList();
        if (!Valid.ItemsList(list, Valid.MonthNum))
            throw new ArgumentException("bymonth: Accepts values between 1 and 12");
        Bymonths = list;
        return this;
    }

    public When bymonth(string months, string delimiter = ",")
    {
        Bymonths = PrepareItemsList(months, delimiter, Valid.MonthNum,
            "bymonth: Accepts values between 1 and 12");
        return this;
    }

    // Internal helper used by prepareDateElements (mirrors PHP $this->bymonth(...))
    private void setBymonth(int month)
    {
        Bymonths = new List<int> { month };
    }

    public When bysetpos(int pos)
    {
        if (!Valid.SetPosDay(pos))
            throw new ArgumentException("bysetpos: Accepts positive and negative values between 1 and 366");
        Bysetpos = new List<int> { pos };
        return this;
    }

    public When bysetpos(IEnumerable<int> positions)
    {
        var list = positions.ToList();
        if (!Valid.ItemsList(list, Valid.SetPosDay))
            throw new ArgumentException("bysetpos: Accepts positive and negative values between 1 and 366");
        Bysetpos = list;
        return this;
    }

    public When bysetpos(string positions, string delimiter = ",")
    {
        Bysetpos = PrepareItemsList(positions, delimiter, Valid.SetPosDay,
            "bysetpos: Accepts positive and negative values between 1 and 366");
        return this;
    }

    public When wkst(string weekDay)
    {
        if (!Valid.WeekDay(weekDay))
            throw new ArgumentException($"wkst: Accepts {string.Join(", ", Valid.WeekDays)}");
        Wkst = weekDay.ToLowerInvariant();
        return this;
    }

    /// <summary>Non-fluent — mirrors PHP adjustmonthend(bool).</summary>
    public void adjustmonthend(bool adjust)
    {
        ShouldAdjustMonthEnd = adjust;
    }

    // ── RRULE parser ────────────────────────────────────────────────────────

    public When rrule(string rruleStr)
    {
        rruleStr = rruleStr.TrimEnd(';');

        const string prefix = "rrule:";
        if (rruleStr.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            rruleStr = rruleStr[prefix.Length..];

        var parts = rruleStr.Split(';');
        foreach (var part in parts)
        {
            var eqIdx = part.IndexOf('=');
            if (eqIdx < 0) continue;
            var rule = part[..eqIdx].ToUpperInvariant();
            var param = part[(eqIdx + 1)..];

            switch (rule)
            {
                case "DTSTART":
                    startDate(ParseDateTime(param));
                    break;
                case "UNTIL":
                    until(ParseDateTime(param.ToUpperInvariant()));
                    break;
                case "FREQ":
                    freq(param.ToLowerInvariant());
                    break;
                case "COUNT":
                    count(int.Parse(param));
                    break;
                case "INTERVAL":
                    interval(int.Parse(param));
                    break;
                case "WKST":
                    wkst(param.ToLowerInvariant());
                    break;
                case "ADJUSTMONTHEND":
                    adjustmonthend(param.ToUpperInvariant() is "1" or "TRUE");
                    break;
                case "BYDAY":
                    byday(param.ToUpperInvariant().Split(','));
                    break;
                case "BYMONTHDAY":
                    Bymonthdays = param.Split(',').Select(int.Parse).ToList();
                    break;
                case "BYYEARDAY":
                    Byyeardays = param.Split(',').Select(int.Parse).ToList();
                    break;
                case "BYWEEKNO":
                    Byweeknos = param.Split(',').Select(int.Parse).ToList();
                    break;
                case "BYMONTH":
                    Bymonths = param.Split(',').Select(int.Parse).ToList();
                    break;
                case "BYSETPOS":
                    Bysetpos = param.Split(',').Select(int.Parse).ToList();
                    break;
                case "BYHOUR":
                    Byhours = param.Split(',').Select(int.Parse).ToList();
                    break;
                case "BYMINUTE":
                    Byminutes = param.Split(',').Select(int.Parse).ToList();
                    break;
                case "BYSECOND":
                    Byseconds = param.Split(',').Select(int.Parse).ToList();
                    break;
            }
        }

        return this;
    }

    // ── ToRrule serializer ──────────────────────────────────────────────────

    public string toRrule(string glue = ";")
    {
        var parts = new List<string>();
        if (StartDate.HasValue) parts.Add($"DTSTART={StartDate.Value:yyyyMMdd\\THHmmss\\Z}");
        if (Freq != null) parts.Add($"FREQ={Freq}");
        if (Until.HasValue) parts.Add($"UNTIL={Until.Value:yyyyMMdd\\THHmmss\\Z}");
        if (Count.HasValue) parts.Add($"COUNT={Count.Value}");
        if (Interval.HasValue) parts.Add($"INTERVAL={Interval.Value}");
        if (Bydays != null) parts.Add($"BYDAY={string.Join(",", Bydays)}");
        if (Byhours != null) parts.Add($"BYHOUR={string.Join(",", Byhours)}");
        if (Byminutes != null) parts.Add($"BYMINUTE={string.Join(",", Byminutes)}");
        if (Byseconds != null) parts.Add($"BYSECOND={string.Join(",", Byseconds)}");
        if (Bymonthdays != null) parts.Add($"BYMONTHDAY={string.Join(",", Bymonthdays)}");
        if (Byyeardays != null) parts.Add($"BYYEARDAY={string.Join(",", Byyeardays)}");
        if (Byweeknos != null) parts.Add($"BYWEEKNO={string.Join(",", Byweeknos)}");
        if (Bymonths != null) parts.Add($"BYMONTH={string.Join(",", Bymonths)}");
        if (Bysetpos != null) parts.Add($"BYSETPOS={string.Join(",", Bysetpos)}");
        if (Wkst != null) parts.Add($"WKST={Wkst}");
        return string.Join(glue, parts);
    }

    // ── OccursOn / OccursAt ─────────────────────────────────────────────────

    public bool occursOn(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        int daysInMonth = DateTime.DaysInMonth(year, month);
        int dayFromEndOfMonth = -(daysInMonth + 1 - day);

        bool leapYear = DateTime.IsLeapYear(year);

        // Day-of-year (1-based)
        int yearDay = date.DayOfYear;
        int yearDaysTotal = leapYear ? 366 : 365;
        int yearDayNeg = yearDay - yearDaysTotal - 1;

        // nth occurrence of weekday in month (e.g. 2nd Monday)
        int occur = (int)Math.Ceiling(day / 7.0);
        int occurNeg = -(int)Math.Ceiling(Math.Abs(dayFromEndOfMonth) / 7.0);

        // ISO week number
        int week = ISOWeekNumber(date);

        var dayOfWeekAbr = DayOfWeekAbbrev(date.DayOfWeek);

        // date must be >= startDate
        if (StartDate.HasValue && date < StartDate.Value)
            return false;

        if (Until.HasValue && date > Until.Value)
            return false;

        if (Bymonths != null && !Bymonths.Contains(month))
            return false;

        if (Bydays != null)
        {
            if (!Bydays.Contains("0" + dayOfWeekAbr) &&
                !Bydays.Contains(occur + dayOfWeekAbr) &&
                !Bydays.Contains(occurNeg + dayOfWeekAbr))
                return false;
        }

        if (Byweeknos != null && !Byweeknos.Contains(week))
            return false;

        if (Bymonthdays != null)
        {
            var days = Bymonthdays;
            List<int>? realDays = null;

            if (ShouldAdjustMonthEnd)
            {
                realDays = new List<int>(days);
                days = days.Select(d => d > daysInMonth ? daysInMonth : d).ToList();
            }

            bool ok = days.Contains(day) || days.Contains(dayFromEndOfMonth);

            if (realDays != null)
                Bymonthdays = realDays;

            return ok;
        }

        if (Byyeardays != null)
        {
            if (!Byyeardays.Contains(yearDay) && !Byyeardays.Contains(yearDayNeg))
                return false;
        }

        // interval check
        if (Interval > 1 && StartDate.HasValue)
        {
            int numPeriods;
            switch (Freq)
            {
                case "yearly":
                {
                    var start = new DateTime(StartDate.Value.Year, 1, 1,
                        StartDate.Value.Hour, StartDate.Value.Minute, StartDate.Value.Second);
                    numPeriods = date.Year - start.Year;
                    break;
                }
                case "monthly":
                {
                    numPeriods = (date.Year - StartDate.Value.Year) * 12
                               + (date.Month - StartDate.Value.Month);
                    break;
                }
                case "weekly":
                {
                    DateTime weekStartDate;
                    if (Bydays != null)
                        weekStartDate = GetFirstWeekStartDate(StartDate.Value, Wkst ?? "mo");
                    else
                        weekStartDate = StartDate.Value;
                    var diff = date - weekStartDate;
                    numPeriods = (int)Math.Floor(diff.TotalDays / 7);
                    break;
                }
                case "daily":
                {
                    numPeriods = (int)(date - StartDate.Value).TotalDays;
                    break;
                }
                case "hourly":
                {
                    var diff = date - StartDate.Value;
                    numPeriods = (int)(diff.TotalDays * 24 + diff.Hours);
                    break;
                }
                case "minutely":
                {
                    var diff = date - StartDate.Value;
                    numPeriods = (int)(diff.TotalMinutes);
                    break;
                }
                case "secondly":
                {
                    var diff = date - StartDate.Value;
                    numPeriods = (int)(diff.TotalSeconds);
                    break;
                }
                default:
                    numPeriods = 0;
                    break;
            }

            return numPeriods % Interval == 0;
        }

        return true;
    }

    public bool occursAt(DateTime date)
    {
        if (Byhours != null && !Byhours.Contains(date.Hour)) return false;
        if (Byminutes != null && !Byminutes.Contains(date.Minute)) return false;
        if (Byseconds != null && !Byseconds.Contains(date.Second)) return false;
        return true;
    }

    // ── GenerateOccurrences ─────────────────────────────────────────────────

    public void generateOccurrences()
    {
        prepareDateElements();

        int count = 0;
        var dateLooper = StartDate!.Value;

        // Add start date if it matches the rule
        if (occursOn(dateLooper))
        {
            AddOccurrence(GenerateTimeOccurrences(dateLooper));
        }
        else
        {
            if (RFC5545_COMPLIANT == EXCEPTION)
                throw new InvalidStartDateException();
            // else IGNORE — continue without throwing
        }

        while (dateLooper < Until!.Value && Occurrences.Count < Count!.Value)
        {
            var occurrences = new List<DateTime>();

            if (Freq == "yearly")
            {
                if (Bymonths != null)
                {
                    foreach (var month in Bymonths)
                    {
                        if (Bydays != null)
                        {
                            var loopDate = new DateTime(dateLooper.Year, month, 1,
                                dateLooper.Hour, dateLooper.Minute, dateLooper.Second);
                            int totalDays = DateTime.DaysInMonth(loopDate.Year, month);
                            for (int d = 0; d < totalDays; d++)
                            {
                                if (occursOn(loopDate))
                                    occurrences.AddRange(GenerateTimeOccurrences(loopDate));
                                loopDate = loopDate.AddDays(1);
                            }
                        }
                        else
                        {
                            int safeDay = Math.Min(dateLooper.Day, DateTime.DaysInMonth(dateLooper.Year, month));
                            var loopDate = new DateTime(dateLooper.Year, month, safeDay,
                                dateLooper.Hour, dateLooper.Minute, dateLooper.Second);
                            if (occursOn(loopDate))
                                occurrences.AddRange(GenerateTimeOccurrences(loopDate));
                        }
                    }
                }
                else
                {
                    // iterate every day of the year (for byyeardays / byweeknos etc.)
                    var loopDate = new DateTime(dateLooper.Year, 1, 1,
                        dateLooper.Hour, dateLooper.Minute, dateLooper.Second);
                    int days = DateTime.IsLeapYear(dateLooper.Year) ? 366 : 365;
                    for (int d = 0; d < days; d++)
                    {
                        if (occursOn(loopDate))
                            occurrences.AddRange(GenerateTimeOccurrences(loopDate));
                        loopDate = loopDate.AddDays(1);
                    }
                }

                occurrences = PrepareOccurrences(occurrences, count);
                AddOccurrence(occurrences);

                // leap-year Feb-29 correction
                bool correctForLeap = StartDate.Value.Month == 2 && StartDate.Value.Day == 29
                    && Bymonths != null && Bymonths.Contains(2)
                    && Bymonthdays != null && Bymonthdays.Contains(-1);

                count++;
                dateLooper = StartDate.Value.AddYears(Interval!.Value * count);
                if (correctForLeap)
                {
                    int y = dateLooper.Year;
                    dateLooper = new DateTime(y, 2, DateTime.DaysInMonth(y, 2),
                        dateLooper.Hour, dateLooper.Minute, dateLooper.Second);
                }
            }
            else if (Freq == "monthly")
            {
                int totalDays = DateTime.DaysInMonth(dateLooper.Year, dateLooper.Month);
                int dayStart = dateLooper.Day;
                var loopDate = dateLooper;

                while (loopDate.Day <= totalDays && loopDate.Month == dateLooper.Month)
                {
                    if (occursOn(loopDate))
                        occurrences.AddRange(GenerateTimeOccurrences(loopDate));
                    loopDate = loopDate.AddDays(1);
                }

                occurrences = PrepareOccurrences(occurrences, count);
                AddOccurrence(occurrences);

                count++;
                // Jump to 1st of next interval month
                var next = new DateTime(StartDate.Value.Year, StartDate.Value.Month, 1,
                    StartDate.Value.Hour, StartDate.Value.Minute, StartDate.Value.Second)
                    .AddMonths(Interval!.Value * count);
                dateLooper = next;
            }
            else if (Freq == "weekly")
            {
                // Always anchor from the first week start (mirrors PHP: $startWeekDay is set once
                // at count==0 and reused for all subsequent iterations via the closure).
                var firstWeekStart = GetFirstWeekStartDate(StartDate.Value, Wkst ?? "mo");

                int daysLeft = 7;
                if (count == 0)
                {
                    // Partial first week: scan only from StartDate to the wkst boundary.
                    var nextWkst = GetNextWeekday(dateLooper, Wkst ?? "mo");
                    daysLeft = (int)(nextWkst - dateLooper).TotalDays;
                }

                var loopDate = dateLooper;
                while (daysLeft > 0)
                {
                    if (occursOn(loopDate))
                        occurrences.AddRange(GenerateTimeOccurrences(loopDate));
                    loopDate = loopDate.AddDays(1);
                    daysLeft--;
                }

                occurrences = PrepareOccurrences(occurrences, count);
                AddOccurrence(occurrences);

                count++;
                dateLooper = new DateTime(firstWeekStart.Year, firstWeekStart.Month, firstWeekStart.Day,
                    StartDate.Value.Hour, StartDate.Value.Minute, StartDate.Value.Second)
                    .AddDays(Interval!.Value * (count * 7));
            }
            else if (Freq == "daily")
            {
                if (occursOn(dateLooper))
                    AddOccurrence(GenerateTimeOccurrences(dateLooper));

                count++;
                dateLooper = StartDate.Value.AddDays(Interval!.Value * count);
            }
            else if (Freq == "hourly")
            {
                if (occursOn(dateLooper))
                    AddOccurrence(new List<DateTime> { dateLooper });

                count++;
                dateLooper = StartDate.Value.AddHours(Interval!.Value * count);
            }
            else if (Freq == "minutely")
            {
                if (occursOn(dateLooper))
                    AddOccurrence(new List<DateTime> { dateLooper });

                count++;
                dateLooper = StartDate.Value.AddMinutes(Interval!.Value * count);
            }
            else if (Freq == "secondly")
            {
                if (occursOn(dateLooper))
                    AddOccurrence(new List<DateTime> { dateLooper });

                count++;
                dateLooper = StartDate.Value.AddSeconds(Interval!.Value * count);
            }
        }

        // generateTimeOccurrences can overshoot Count — trim
        if (Count.HasValue && Occurrences.Count > Count.Value)
            Occurrences = Occurrences.Take(Count.Value).ToList();
    }

    // ── Query methods ───────────────────────────────────────────────────────

    public List<DateTime> getOccurrencesBetween(DateTime startDate, DateTime endDate, int? limit = null)
    {
        var clone = DeepClone();

        // Enforce time zones not applicable (DateTime), but maintain consistency
        var result = new List<DateTime>();

        if (endDate <= startDate)
            return result;

        if (clone.Until.HasValue && clone.Until.Value < startDate)
            return result;

        if (!clone.Until.HasValue)
            clone.Until = endDate;

        clone.generateOccurrences();
        var allOccurrences = clone.Occurrences;

        if (allOccurrences.Count == 0)
            return result;

        var lastOccurrence = allOccurrences[^1];

        // if we hit rangeLimit, page forward
        if (clone.RangeLimit == allOccurrences.Count && clone.StartDate != lastOccurrence)
        {
            clone.StartDate = lastOccurrence;
            clone.Occurrences.RemoveAll(o => o < startDate);
            return clone.getOccurrencesBetween(startDate, endDate, limit);
        }

        if (lastOccurrence < startDate)
            return result;

        int countLocal = 0;
        foreach (var occ in allOccurrences)
        {
            if (occ < startDate) continue;
            if (occ > endDate) break;
            if (limit.HasValue && ++countLocal > limit.Value) break;
            result.Add(occ);
        }

        return result;
    }

    public DateTime? getNextOccurrence(DateTime occurDate, bool strictlyAfter = true)
    {
        prepareDateElements(false);

        if (!strictlyAfter && occursOn(occurDate) && occursAt(occurDate))
            return occurDate;

        var endDate = occurDate.AddYears(400);
        var candidates = getOccurrencesBetween(occurDate, endDate, 2);
        foreach (var candidate in candidates)
        {
            if (!strictlyAfter) return candidate;
            if (candidate > occurDate) return candidate;
        }

        return null;
    }

    public DateTime? getPrevOccurrence(DateTime occurDate)
    {
        prepareDateElements(false);

        var candidates = getOccurrencesBetween(StartDate!.Value, occurDate);
        if (candidates.Count > 0)
        {
            var last = candidates[^1];
            if (last == occurDate && candidates.Count > 1)
                return candidates[^2];
            if (last == occurDate)
                return null;
            return last;
        }

        return null;
    }

    // ── Static helpers ──────────────────────────────────────────────────────

    public static DateTime GetFirstWeekStartDate(DateTime startDate, string wkst)
    {
        // Get first wkst boundary on or before startDate (mirrors PHP logic)
        var next = GetNextWeekday(startDate, wkst);
        return GetPrevWeekday(next, wkst);
    }

    // ── Protected/internal helpers ──────────────────────────────────────────

    protected void prepareDateElements(bool limitRange = true)
    {
        if (!Interval.HasValue)
            Interval = 1;

        // must have a frequency (or at least attempt byFreqValid check)
        Valid.ByFreqValid(Freq, Byweeknos, Byyeardays, Bymonthdays);
        if (Freq == null)
            throw new FrequencyRequiredException();

        if (limitRange && !Count.HasValue)
            Count = RangeLimit;

        if (!StartDate.HasValue)
            StartDate = DateTime.Now;

        if (limitRange && !Until.HasValue)
            Until = StartDate.Value.AddYears(400);

        if (Byminutes == null)
            Byminutes = new List<int> { StartDate.Value.Minute };

        if (Byhours == null)
            Byhours = new List<int> { StartDate.Value.Hour };

        if (Byseconds == null)
            Byseconds = new List<int> { StartDate.Value.Second };

        if (Wkst == null)
            Wkst = "mo";

        if (Freq == "monthly" && Bymonthdays == null && Bydays == null)
            Bymonthdays = new List<int> { StartDate.Value.Day };

        if (Freq == "weekly" && Bymonthdays == null && Bydays == null)
        {
            var abbr = DayOfWeekAbbrev(StartDate.Value.DayOfWeek);
            Bydays = new List<string> { "0" + abbr };
        }

        if (Freq == "yearly" &&
            Bydays == null && Bymonths == null && Bymonthdays == null &&
            Byyeardays == null && Byweeknos == null && Bysetpos == null)
        {
            setBymonth(StartDate.Value.Month);
            Bymonthdays = new List<int> { StartDate.Value.Day };
        }
    }

    protected List<DateTime> GenerateTimeOccurrences(DateTime dateLooper)
    {
        var occurrences = new List<DateTime>();
        foreach (var hour in Byhours!)
        {
            foreach (var minute in Byminutes!)
            {
                foreach (var second in Byseconds!)
                {
                    var occ = new DateTime(dateLooper.Year, dateLooper.Month, dateLooper.Day,
                        hour, minute, second, dateLooper.Kind);
                    if (occ <= Until!.Value)
                        occurrences.Add(occ);
                }
            }
        }
        return occurrences;
    }

    protected List<DateTime> PrepareOccurrences(List<DateTime> occurrences, int count)
    {
        if (Bysetpos == null) return occurrences;

        var filtered = new List<DateTime>();
        if (count > 0)
        {
            int occCount = occurrences.Count;
            foreach (var setpos in Bysetpos)
            {
                if (setpos > 0 && setpos - 1 < occCount)
                    filtered.Add(occurrences[setpos - 1]);
                else if (setpos < 0)
                {
                    int idx = occCount + setpos;
                    if (idx >= 0 && idx < occCount)
                        filtered.Add(occurrences[idx]);
                }
            }
        }
        return filtered;
    }

    protected void AddOccurrence(List<DateTime> occurrences)
    {
        foreach (var occ in occurrences)
        {
            if (!Occurrences.Contains(occ) &&
                (Exclusions.Count == 0 || !Exclusions.Contains(occ)))
            {
                Occurrences.Add(occ);
            }
        }
    }

    // ── Private helpers ─────────────────────────────────────────────────────

    /// <summary>Deep clone this instance so query methods don't mutate state.</summary>
    private When DeepClone()
    {
        var c = (When)MemberwiseClone();
        c.Exclusions = new List<DateTime>(Exclusions);
        c.Occurrences = new List<DateTime>(Occurrences);
        if (Byseconds != null) c.Byseconds = new List<int>(Byseconds);
        if (Byminutes != null) c.Byminutes = new List<int>(Byminutes);
        if (Byhours != null) c.Byhours = new List<int>(Byhours);
        if (Bydays != null) c.Bydays = new List<string>(Bydays);
        if (Bymonthdays != null) c.Bymonthdays = new List<int>(Bymonthdays);
        if (Byyeardays != null) c.Byyeardays = new List<int>(Byyeardays);
        if (Byweeknos != null) c.Byweeknos = new List<int>(Byweeknos);
        if (Bymonths != null) c.Bymonths = new List<int>(Bymonths);
        if (Bysetpos != null) c.Bysetpos = new List<int>(Bysetpos);
        return c;
    }

    private static string DayOfWeekAbbrev(DayOfWeek dow) => dow switch
    {
        DayOfWeek.Sunday    => "su",
        DayOfWeek.Monday    => "mo",
        DayOfWeek.Tuesday   => "tu",
        DayOfWeek.Wednesday => "we",
        DayOfWeek.Thursday  => "th",
        DayOfWeek.Friday    => "fr",
        DayOfWeek.Saturday  => "sa",
        _ => throw new ArgumentOutOfRangeException(nameof(dow))
    };

    private static string AbbrevToDayName(string abbrev) => abbrev.ToLowerInvariant() switch
    {
        "su" => "Sunday",
        "mo" => "Monday",
        "tu" => "Tuesday",
        "we" => "Wednesday",
        "th" => "Thursday",
        "fr" => "Friday",
        "sa" => "Saturday",
        _ => throw new ArgumentException($"Unknown day abbreviation: {abbrev}")
    };

    private static DayOfWeek AbbrevToDayOfWeek(string abbrev) => abbrev.ToLowerInvariant() switch
    {
        "su" => DayOfWeek.Sunday,
        "mo" => DayOfWeek.Monday,
        "tu" => DayOfWeek.Tuesday,
        "we" => DayOfWeek.Wednesday,
        "th" => DayOfWeek.Thursday,
        "fr" => DayOfWeek.Friday,
        "sa" => DayOfWeek.Saturday,
        _ => throw new ArgumentException($"Unknown day abbreviation: {abbrev}")
    };

    /// <summary>Returns the next occurrence of the given weekday on or after the given date.</summary>
    private static DateTime GetNextWeekday(DateTime date, string wkstAbbrev)
    {
        var target = AbbrevToDayOfWeek(wkstAbbrev);
        int diff = ((int)target - (int)date.DayOfWeek + 7) % 7;
        if (diff == 0) diff = 7;
        return date.AddDays(diff);
    }

    /// <summary>Returns the most-recent occurrence of the given weekday strictly before baseDate.</summary>
    private static DateTime GetPrevWeekday(DateTime date, string wkstAbbrev)
    {
        var target = AbbrevToDayOfWeek(wkstAbbrev);
        int diff = ((int)date.DayOfWeek - (int)target + 7) % 7;
        if (diff == 0) diff = 7;
        return date.AddDays(-diff);
    }

    private static int ISOWeekNumber(DateTime date)
    {
        return ISOWeek.GetWeekOfYear(date);
    }

    private static DateTime ParseDateTime(string s)
    {
        // Try compact ISO 8601 formats first: yyyyMMddTHHmmssZ, yyyyMMddTHHmmss
        s = s.Trim();
        if (s.Length >= 15 && s[8] == 'T')
        {
            var datePart = s[..8];
            var timePart = s[9..15];
            bool utc = s.EndsWith("Z", StringComparison.OrdinalIgnoreCase);
            var dt = DateTime.ParseExact(
                datePart + "T" + timePart,
                "yyyyMMdd'T'HHmmss",
                CultureInfo.InvariantCulture,
                utc ? DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
                    : DateTimeStyles.None);
            return dt;
        }
        return DateTime.Parse(s, CultureInfo.InvariantCulture);
    }

    private static List<string> SplitAndTrim(string input, string delimiter)
    {
        return input.Trim(delimiter[0])
                    .Split(delimiter[0])
                    .Select(s => s.Trim())
                    .Where(s => s.Length > 0)
                    .ToList();
    }

    private static List<int> PrepareItemsList(string items, string delimiter,
        Func<int, bool> validator, string errorMsg)
    {
        var parts = SplitAndTrim(items, delimiter);
        var list = parts.Select(int.Parse).ToList();
        if (!Valid.ItemsList(list, validator))
            throw new ArgumentException(errorMsg);
        return list;
    }

    private static List<string> CreateDaysList(IEnumerable<string> days)
    {
        var result = new List<string>();
        foreach (var rawDay in days)
        {
            var day = rawDay.TrimStart('+').Trim();
            string abbrev;
            int ordwk = 0;

            if (day.Length == 2)
            {
                abbrev = day.ToLowerInvariant();
            }
            else
            {
                // Parse optional leading signed integer
                int i = 0;
                if (i < day.Length && day[i] == '-') i++;
                while (i < day.Length && char.IsDigit(day[i])) i++;
                abbrev = day[i..].ToLowerInvariant();
                var ordStr = day[..i];
                ordwk = ordStr.Length == 0 ? 0 : int.Parse(ordStr);
            }

            result.Add(ordwk + abbrev);
        }
        return result;
    }
}
