using System;
using System.Collections.Generic;
using ActivityLogger.Model.ActivityLogging;

namespace ActivityLogger.Model.ActivityStatistics
{
    public class IntervalsStatistics
    {
        public IEnumerable<LoggedInterval> Intervals { get; set; }

        public TimeSpan InactivityThreshold { get; set; }

        public IntervalsStatistics(IEnumerable<LoggedInterval> intervals, TimeSpan inactivityThreshold)
        {
            Intervals = intervals;
            InactivityThreshold = inactivityThreshold;
        }
        
        public DateTime Begin { get; }
        public DateTime End { get; }
        public TimeSpan Activity { get; }
        public TimeSpan Inactivity { get; }
        public TimeSpan Total { get; }
        public double InactivityPercent { get; }
        public double ActivityPercent { get; }
        public TimeSpan InactivityAverage { get; }
        public TimeSpan ActivityAverage { get; }
    }
}