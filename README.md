# NWhen
Date Recursion library for .NET

Based on https://github.com/tplaner/When

https://stackoverflow.com/questions/246498/creating-a-datetime-in-a-specific-time-zone-in-c-sharp
similar in c# - https://github.com/gavynriebau/Dates.Recurring

https://stackoverflow.com/questions/4517376/recurrence-library-for-date-calculations-for-net
https://doc3.webdavsystem.com/ITHit.Collab.Calendar.IRecurrenceRule.htm

# Ideas
1. new name for When
2. check open issues / PRs to see for problems
3. check all forks for new commits, and if anything can be integrated

# Tests
1. Valid.freq method - handle null values
2. Valid.weekDay - handle null values
3. Valid. second,minute,hour string methods - handle non number values
4. Replace tests for rrule to just test that the properties are set correctly, not that the whole generation works
5. In tests, when there is a "results" array of dates, generate those dates automatically, not manually (use a foreach or something)
6. Make app work with DateTime written as 19970917T090000. Is it needed?

# Todo

- Create a rename When to WhenBuilder class
    - it should have a Build() method that returns a When object
    - the Build method should implement the checks and preparations like the "prepareDateElements" method
