using System;

namespace ActivityLogger.Model.ActivityLogging
{
    public interface IInterval<T> where T : IComparable<T>
    {
        T Start { get; set; }
        T End { get; set; }
    }
}