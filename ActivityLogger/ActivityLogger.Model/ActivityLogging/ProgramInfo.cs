using System;

namespace ActivityLogger.Model.ActivityLogging
{
    [Serializable]
    public class ProgramInfo : IComparable<ProgramInfo>, IComparable
    {
        public readonly DateTime Time;
        public readonly string Process;
        public readonly string Title;

        public ProgramInfo(DateTime time, string process, string title)
        {
            Time = time;
            Process = process;
            Title = title;
        }

        protected bool Equals(ProgramInfo other)
        {
            return Time.Equals(other.Time);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProgramInfo) obj);
        }

        public override int GetHashCode()
        {
            return Time.GetHashCode();
        }

        public int CompareTo(ProgramInfo other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var timeComparison = Time.CompareTo(other.Time);
            if (timeComparison != 0) return timeComparison;
            var processComparison = string.Compare(Process, other.Process, StringComparison.Ordinal);
            if (processComparison != 0) return processComparison;
            return string.Compare(Title, other.Title, StringComparison.Ordinal);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is ProgramInfo other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ProgramInfo)}");
        }
    }
}