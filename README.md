# NWhen

> **This is a .NET/C# port of [tplaner/When](https://github.com/tplaner/When), a Date/Calendar recurrence library originally written in PHP.**

Date/Calendar recurrence library for .NET 10+

[![Build Status](https://github.com/radu-ungureanu/nwhen/actions/workflows/test.yml/badge.svg)](https://github.com/radu-ungureanu/nwhen/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Installation

Add the project to your solution or reference the `NWhen` library directly:

```bash
dotnet add reference path/to/NWhen/NWhen.csproj
```

Then add the namespace:

```csharp
using NWhen;
```

## Current Features

NWhen offers full support for [RFC 5545 Recurrence Rule](https://datatracker.ietf.org/doc/html/rfc5545#section-3.8.5) features (and some bonus features). Please check the [unit tests](src/NWhen.Tests/) for information and examples about how to use it.

Here are some basic examples.

```csharp
// friday the 13th for the next 5 occurrences
var r = new When();
r.startDate(new DateTime(1998, 2, 13, 9, 0, 0))
 .freq("monthly")
 .count(5)
 .byday("fr")
 .bymonthday(13)
 .generateOccurrences();

Console.WriteLine(r.Occurrences);
```

```csharp
// friday the 13th for the next 5 occurrences using rrule string
var r = new When();
r.startDate(new DateTime(1998, 2, 13, 9, 0, 0))
 .rrule("FREQ=MONTHLY;BYDAY=FR;BYMONTHDAY=13;COUNT=5")
 .generateOccurrences();

Console.WriteLine(r.Occurrences);
```

```csharp
// friday the 13th for the next 5 occurrences, skipping known friday the 13ths
var r = new When();
r.startDate(new DateTime(1998, 2, 13, 9, 0, 0))
 .freq("monthly")
 .count(5)
 .byday("fr")
 .bymonthday(13)
 .exclusions("19990813T090000,20001013T090000")
 .generateOccurrences();

Console.WriteLine(r.Occurrences);
```

```csharp
// friday the 13th forever; see which ones occur in 2018
var r = new When();
r.startDate(new DateTime(1998, 2, 13, 9, 0, 0))
 .rrule("FREQ=MONTHLY;BYDAY=FR;BYMONTHDAY=13");

var occurrences = r.getOccurrencesBetween(
    new DateTime(2018, 1, 1, 9, 0, 0),
    new DateTime(2019, 1, 1, 9, 0, 0));

Console.WriteLine(occurrences);
```

## InvalidStartDate Exception: The start date must be the first occurrence

According to [the specification](https://datatracker.ietf.org/doc/html/rfc5545) the starting date should be the first recurring date. This can often be troublesome, especially if you're generating the recurring dates from user input as it will throw an exception. You can disable this functionality easily:

```csharp
var r = new When();
r.RFC5545_COMPLIANT = When.IGNORE;

// get the last Friday of the month for the next 5 occurrences
r.startDate(DateTime.Now)
 .rrule("FREQ=MONTHLY;BYDAY=-1FR;COUNT=5")
 .generateOccurrences();

Console.WriteLine(r.Occurrences);
```

## Additional examples

```csharp
var r = new When();
r.RFC5545_COMPLIANT = When.IGNORE;

// second to last day of the month
r.startDate(DateTime.Now)
 .rrule("FREQ=MONTHLY;BYMONTHDAY=-2;COUNT=5")
 .generateOccurrences();

Console.WriteLine(r.Occurrences);
```

```csharp
var r = new When();
r.RFC5545_COMPLIANT = When.IGNORE;

// every other week
r.startDate(DateTime.Now)
 .rrule("FREQ=WEEKLY;INTERVAL=2;COUNT=10")
 .generateOccurrences();

Console.WriteLine(r.Occurrences);
```

```csharp
var r1 = new When();
var r2 = new When();
r1.RFC5545_COMPLIANT = When.IGNORE;
r2.RFC5545_COMPLIANT = When.IGNORE;

// complex example of a payment schedule
// borrowed from:
// https://www.mikeyroy.com/2019/10/25/google-calendar-recurring-event-for-twice-monthly-payroll-only-on-weekdays/
//
// you're paid on the 15th (or closest to it, but only on a weekday)
r1.startDate(DateTime.Now)
  .rrule("FREQ=MONTHLY;INTERVAL=1;BYSETPOS=-1;BYDAY=MO,TU,WE,TH,FR;BYMONTHDAY=13,14,15;COUNT=12")
  .generateOccurrences();

// you're also paid on the last weekday of the month
r2.startDate(DateTime.Now)
  .rrule("FREQ=MONTHLY;INTERVAL=1;BYSETPOS=-1;BYDAY=MO,TU,WE,TH,FR;BYMONTHDAY=26,27,28,29,30,31;COUNT=12")
  .generateOccurrences();

int totalPaydays = r1.Occurrences.Count;
for (int i = 0; i < totalPaydays; i++)
{
    Console.WriteLine("You'll be paid on: " + r1.Occurrences[i].ToString("MMMM dd, yyyy"));
    Console.WriteLine("You'll be paid on: " + r2.Occurrences[i].ToString("MMMM dd, yyyy"));
}
```

## Getting next/previous occurrences

```csharp
var r = new When("19970902T090000");
r.rrule("FREQ=WEEKLY");

// get the next occurrence strictly after a given date
DateTime? next = r.getNextOccurrence(new DateTime(1997, 9, 17, 9, 0, 0));

// get the next occurrence on or after a given date (strictlyAfter: false)
DateTime? nextOrSame = r.getNextOccurrence(new DateTime(1997, 9, 16, 9, 0, 0), strictlyAfter: false);

// get the previous occurrence before a given date
DateTime? prev = r.getPrevOccurrence(new DateTime(1997, 9, 23, 9, 0, 0));
```

## Performance

NWhen is pretty fast, and shouldn't be able to loop infinitely. This is because the Gregorian calendar actually repeats fully every 400 years. Therefore, this is an imposed upper limit — it will not generate occurrences more than 400 years into the future, and if it can't find a match in the next 400 years the pattern just doesn't exist.

By default, no more than 200 occurrences are generated, though this can be configured simply by specifying a higher `COUNT` or by modifying the `RangeLimit` prior to calling `generateOccurrences()`:

```csharp
var r = new When();
r.RFC5545_COMPLIANT = When.IGNORE;

r.startDate(DateTime.Now)
 .rrule("FREQ=MONTHLY;BYDAY=FR;BYMONTHDAY=13")
 .generateOccurrences();

// will generate a list of 200
Console.WriteLine(r.Occurrences);
```

The following is a pretty intensive benchmark — the final occurrence is in the year 2254:

```csharp
var r = new When();
r.RFC5545_COMPLIANT = When.IGNORE;

r.startDate(new DateTime(2021, 1, 1))
 .rrule("FREQ=MONTHLY;BYDAY=FR;BYMONTHDAY=13;COUNT=400")
 .generateOccurrences();

// will generate a list of 400
Console.WriteLine(r.Occurrences);
```

`COUNT` with an `UNTIL` — only 5 Friday the 13ths from 2021 to 2025:

```csharp
var r = new When();
r.RFC5545_COMPLIANT = When.IGNORE;

r.startDate(new DateTime(2021, 1, 1))
 .rrule("FREQ=MONTHLY;BYDAY=FR;BYMONTHDAY=13;COUNT=400;UNTIL=20250101")
 .generateOccurrences();

// will generate until 2025-01-01 or 400, whichever comes first
Console.WriteLine(r.Occurrences);
```

Limiting by `RangeLimit`:

```csharp
var r = new When();
r.RFC5545_COMPLIANT = When.IGNORE;

r.RangeLimit = 400;

r.startDate(DateTime.Now)
 .rrule("FREQ=MONTHLY;BYDAY=-1FR")
 .generateOccurrences();

// 400 occurrences, limited by RangeLimit
Console.WriteLine(r.Occurrences);
```
