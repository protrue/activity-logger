using System;

namespace ActivityLogger.Model.ActivityLogging
{
    [Serializable]
    public class DateTimeInterval :
        IInterval<DateTime>,
        IComparable,
        IComparable<DateTimeInterval>,
        IComparable<DateTime>
    {
        private DateTime _start;

        private DateTime _end;

        public DateTime Start
        {
            get => _start;
            set
            {
                if (value > End)
                    throw new ArgumentException();
                _start = value;
            }
        }

        public DateTime End
        {
            get => _end;
            set
            {
                if (value < Start)
                    throw new ArgumentException();
                _end = value;
            }
        }

        public TimeSpan Duration => End - Start;

        public DateTimeInterval(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public Tuple<DateTimeInterval, DateTimeInterval> Split(DateTime divider)
        {
            return DateTimeIntervalHelper.Split(this, divider);
        }

        public void Merge(DateTimeInterval other)
        {
            var merged = DateTimeIntervalHelper.Merge(this, other);
            Start = merged.Start;
            End = merged.End;
        }

        public bool Contains(DateTime dateTime) =>
            dateTime > Start && dateTime < End;

        public bool Contains(DateTimeInterval interval) =>
            interval.Start >= Start && interval.End <= End;

        public bool Overlays(DateTimeInterval interval) =>
            Contains(interval.Start) || Contains(interval.End);

        public bool IsAdjacentRight(DateTimeInterval other) =>
            End == other.Start;

        public bool IsAdjacentLeft(DateTimeInterval other) =>
            Start == other.End;

        public bool IsAdjacent(DateTimeInterval other) =>
            IsAdjacentRight(other) || IsAdjacentLeft(other);

        public static bool operator <(DateTimeInterval first, DateTimeInterval second) =>
            first.End < second.Start;

        public static bool operator >(DateTimeInterval first, DateTimeInterval second) =>
            first.Start < second.End;

        public static bool operator <=(DateTimeInterval first, DateTimeInterval second) =>
            first.End <= second.Start;

        public static bool operator >=(DateTimeInterval first, DateTimeInterval second) =>
            first.Start <= second.End;

        public static bool operator ==(DateTimeInterval first, DateTimeInterval second) =>
            first.Start == second.Start
            && first.End == second.End;

        public static bool operator !=(DateTimeInterval first, DateTimeInterval second) =>
            !(first == second);

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is DateTimeInterval other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(DateTimeInterval)}");
        }

        public int CompareTo(DateTimeInterval other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            if (Start > other.End) return 1;
            if (End < other.Start) return -1;
            return 0;
        }

        public int CompareTo(DateTime dateTime)
        {
            if (dateTime < Start) return -1;
            if (dateTime > End) return 1;
            return 0;
        }

        protected bool Equals(DateTimeInterval other)
        {
            return _start.Equals(other._start) && _end.Equals(other._end);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DateTimeInterval) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_start.GetHashCode() * 397) ^ _end.GetHashCode();
            }
        }
    }
}