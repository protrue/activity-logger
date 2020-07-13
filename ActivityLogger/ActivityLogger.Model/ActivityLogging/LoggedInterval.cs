using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivityLogger.Model.ActivityLogging
{
    [Serializable]
    public class LoggedInterval : DateTimeInterval
    {
        private List<ProgramInfo> _programs;

        public bool IsActivity { get; set; }
        public string Comment { get; set; }

        public IEnumerable<ProgramInfo> Programs => _programs.AsReadOnly();

        public LoggedInterval(DateTime start, DateTime end, bool isActivity = true) : base(start, end)
        {
            _programs = new List<ProgramInfo>();
            IsActivity = isActivity;
        }

        public void AddProgramInfo(ProgramInfo programInfo)
        {
            var last = _programs.LastOrDefault();

            if (last != null && programInfo.Time < last.Time)
                throw new ArgumentException();

            _programs.Add(programInfo);
        }

        public static Tuple<LoggedInterval, LoggedInterval> Split(LoggedInterval interval, DateTime divider)
        {
            var first = new LoggedInterval(interval.Start, divider);

            var second = new LoggedInterval(divider, interval.End);

            foreach (var newInterval in new[] {first, second})
            {
                newInterval.Comment = interval.Comment;
                newInterval.IsActivity = interval.IsActivity;
                newInterval._programs = interval.Programs.Where(x => newInterval.Contains(x.Time)).OrderBy(x => x.Time)
                    .ToList();
            }

            return Tuple.Create(first, second);
        }

        public static LoggedInterval Merge(LoggedInterval first, LoggedInterval second, bool isActivity)
        {
            if (!first.IsAdjacent(second))
                throw new ArgumentException();

            LoggedInterval result;
            string[] comments = {first.Comment, second.Comment};

            if (first.IsAdjacentRight(second))
            {
                result = new LoggedInterval(first.Start, second.End)
                {
                    Comment = string.Join(" ", comments)
                };
            }
            else
            {
                result = new LoggedInterval(second.Start, first.End)
                {
                    Comment = string.Join(" ", comments.Reverse())
                };
            }

            result._programs = new List<ProgramInfo>(first.Programs.Union(second.Programs).OrderBy(x => x.Time));
            result.IsActivity = isActivity;

            return result;
        }

        public new Tuple<LoggedInterval, LoggedInterval> Split(DateTime divider)
        {
            return Split(this, divider);
        }

        public void Merge(LoggedInterval other, bool isActivity)
        {
            var merged = Merge(this, other, isActivity);

            Start = merged.Start;
            End = merged.End;
            IsActivity = merged.IsActivity;
            Comment = merged.Comment;
            _programs = new List<ProgramInfo>(merged.Programs);
        }
    }
}