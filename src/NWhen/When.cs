using System;

namespace NWhen
{
    public class When
    {
        public DateTime StartDate { get; private set; }

        public When SetStartDate(DateTime date)
        {
            StartDate = date;
            return this;
        }
    }
}
