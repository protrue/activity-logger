using System;

namespace ActivityLogger.Model.ActivityLogging
{
    public static class DateTimeIntervalHelper
    {
        public static Tuple<DateTimeInterval, DateTimeInterval> Split(DateTimeInterval interval, DateTime divider)
        {
            if (!interval.Contains(divider))
                throw new ArgumentException();

            var first = new DateTimeInterval(interval.Start, divider);
            var second = new DateTimeInterval(divider, interval.End);

            return Tuple.Create(first, second);
        }

        public static DateTimeInterval Merge(DateTimeInterval first, DateTimeInterval second)
        {
            if (!first.IsAdjacent(second))
                throw new ArgumentException();

            return first.End == second.Start
                ? new DateTimeInterval(first.Start, second.End)
                : new DateTimeInterval(second.Start, first.End);
        }
    }
}