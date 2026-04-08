namespace NWhen;

public static class Valid
{
    public static readonly string[] Frequencies =
        { "secondly", "minutely", "hourly", "daily", "weekly", "monthly", "yearly" };

    public static readonly string[] WeekDays =
        { "su", "mo", "tu", "we", "th", "fr", "sa" };

    public static bool Freq(string frequency) =>
        Array.Exists(Frequencies, f => f == frequency.ToLowerInvariant());

    public static bool WeekDay(string? weekDay) =>
        weekDay != null && Array.Exists(WeekDays, d => d == weekDay.ToLowerInvariant());

    /// <summary>
    /// Validates an array of BYDAY values like "1FR", "-2MO", "SU".
    /// </summary>
    public static bool DaysList(IEnumerable<string> days)
    {
        foreach (var rawDay in days)
        {
            var day = rawDay.TrimStart('+').TrimStart('0').Trim();

            string abbrev;
            if (day.Length == 2)
            {
                abbrev = day;
            }
            else
            {
                // Parse leading signed integer + 2-char abbrev
                int i = 0;
                if (i < day.Length && (day[i] == '-')) i++;
                while (i < day.Length && char.IsDigit(day[i])) i++;
                abbrev = day[i..];
                var ordStr = day[..i];
                if (!int.TryParse(ordStr.Length == 0 ? "0" : ordStr, out int ord)) return false;
                if (!OrdWk(Math.Abs(ord == 0 ? 1 : ord))) return false;
            }

            if (!WeekDay(abbrev)) return false;
        }
        return true;
    }

    public static bool ItemsList(IEnumerable<int> items, Func<int, bool> validator) =>
        items.All(validator);

    public static bool DateTimeObject(object? dt) => dt is DateTime;

    public static bool DateTimeList(IEnumerable<object> dateTimes) =>
        dateTimes.Any(DateTimeObject);

    /// <summary>
    /// Throws <see cref="InvalidCombinationException"/> when BYWEEKNO/BYYEARDAY/BYMONTHDAY
    /// are used with incompatible frequencies.
    /// </summary>
    public static bool ByFreqValid(string? freq, IList<int>? byweeknos, IList<int>? byyeardays, IList<int>? bymonthdays)
    {
        if (byweeknos != null && freq != "yearly")
            throw new InvalidCombinationException();

        if (byyeardays != null && freq != null &&
            (freq == "daily" || freq == "weekly" || freq == "monthly"))
            throw new InvalidCombinationException();

        if (bymonthdays != null && freq == "weekly")
            throw new InvalidCombinationException();

        return true;
    }

    // ── Range validators ─────────────────────────────────────────────────────

    public static bool Second(int s) => s >= 0 && s <= 60;
    public static bool Minute(int m) => m >= 0 && m <= 59;
    public static bool Hour(int h) => h >= 0 && h <= 23;
    public static bool MonthNum(int m) => m >= 1 && m <= 12;
    public static bool OrdMoDay(int d) => d >= 1 && d <= 31;
    public static bool MonthDayNum(int d) => OrdMoDay(Math.Abs(d));
    public static bool OrdYrDay(int d) => d >= 1 && d <= 366;
    public static bool YearDayNum(int d) => OrdYrDay(Math.Abs(d));
    public static bool SetPosDay(int d) => YearDayNum(d);
    public static bool OrdWk(int w) => w >= 1 && w <= 53;
    public static bool WeekNum(int w) => OrdWk(Math.Abs(w));
}
