using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivityLogger.Model.ActivityLogging
{
    public class DayLog
    {
        private readonly List<LoggedInterval> _loggedIntervals;

        public DateTime? Date => _loggedIntervals.FirstOrDefault()?.Start.Date;

        public IEnumerable<LoggedInterval> LoggedIntervals => _loggedIntervals.AsReadOnly();

        public string Summary { get; set; }

        public DayLog()
        {
            _loggedIntervals = new List<LoggedInterval>();
        }

        public void Add(DateTime intervalEnd, bool isActivity)
        {
            if (_loggedIntervals.Count == 0)
            {
                _loggedIntervals.Add(new LoggedInterval(intervalEnd.Date, intervalEnd, isActivity));
                return;
            }

            var lastLoggedIntervalEnd = _loggedIntervals.Last().End;
            var newLoggedInterval = new LoggedInterval(lastLoggedIntervalEnd.AddTicks(1), intervalEnd, isActivity);
            _loggedIntervals.Add(newLoggedInterval);
        }
        
        public void Add(LoggedInterval loggedInterval)
        {
            _loggedIntervals.Add(loggedInterval);
        }

        protected bool Equals(DayLog other)
        {
            return Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DayLog) obj);
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode();
        }
    }
}