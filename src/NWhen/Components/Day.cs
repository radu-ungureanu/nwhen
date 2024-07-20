using NWhen.Components.Base;
using NWhen.Exceptions;
using ScanFormatted;
using System;

namespace NWhen.Components;

public class Day(string day) : CustomStringValidationComponent<InvalidDayException>(day)
{
    protected override bool IsValid(string value)
    {
        var trimmed = value.TrimStart('+').TrimStart('0').Trim();

        var ordwk = 1;
        string weekday;

        if (trimmed.Length == 2)
        {
            weekday = trimmed;
        }
        else
        {
            var scanf = new ScanF();
            try
            {
                scanf.Parse(trimmed, "%d%s");
                ordwk = (int)scanf.Results[0];
                weekday = (string)scanf.Results[1];
            }
            catch
            {
                return false;
            }
        }

        try
        {
            new WeekDay(weekday);
            new WeekNumber(ordwk);
        }
        catch (Exception ex) when (ex is InvalidWeekDayException or InvalidWeekNumberException)
        {
            return false;
        }

        return true;
    }

    protected override string TransformValue(string value)
    {
        var trimmed = value.TrimStart('+').TrimStart('0').Trim();

        var ordwk = 0;
        string weekday;

        if (trimmed.Length == 2)
        {
            weekday = trimmed;
        }
        else
        {
            var scanf = new ScanF();
            scanf.Parse(trimmed, "%d%s");
            ordwk = (int)scanf.Results[0];
            weekday = (string)scanf.Results[1];
        }

        return $"{ordwk}{weekday.ToLower()}";
    }

    public static implicit operator Day(string day) => new(day);
}
