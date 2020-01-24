using System;

namespace ActivityLogger
{
    [Serializable]
    class DateTimeInterval
    {
        // TODO: End >= Start checks
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeSpan Duration => End - Start;

        public DateTimeInterval(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTimeInterval(DateTime start) : this(start, DateTime.Now)
        {
            Start = start;
        }
    }
}
