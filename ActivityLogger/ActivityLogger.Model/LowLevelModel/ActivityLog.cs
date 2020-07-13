using System;
using System.Collections.Generic;

namespace ActivityLogger.Model.LowLevelModel
{
    public class ActivityLog : IMarkable
    {
        private Dictionary<int, YearLog> YearLogs { get; }

        public ActivityLog()
        {
            YearLogs = new Dictionary<int, YearLog>();
        }

        /// <inheritdoc/>
        public void Mark(DateTime dateTime, bool active)
        {
            if (!YearLogs.ContainsKey(dateTime.Year))
            {
                YearLogs[dateTime.Year] = new YearLog(dateTime.Year);
            }

            YearLogs[dateTime.Year].Mark(dateTime, active);
        }

        /// <inheritdoc/>
        public void Mark(DateTime start, DateTime end, bool active)
        {
            for (var year = start.Year; year < end.Year; year++)
            {
                if (!YearLogs.ContainsKey(year))
                {
                    YearLogs[year] = new YearLog(year);
                }

                var yearLogStart = year != start.Year ? new DateTime(year, 1, 1) : start;
                var yearLogEnd = year != end.Year ? new DateTime(year + 1, 1, 1).Subtract(TimeSpan.MinValue) : end;

                YearLogs[year].Mark(yearLogStart, yearLogEnd, active);
            }
        }
    }
}