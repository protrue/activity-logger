using System;

namespace ActivityLogger.Model.LowLevelModel
{
    /// <summary>
    /// Provides marking time as active or inactive functionality
    /// </summary>
    public interface IMarkable
    {
        /// <summary>
        /// Marks <paramref name="dateTime"/> as activity or inactivity, depending on <paramref name="active"/>
        /// </summary>
        /// <param name="dateTime">Time</param>
        /// <param name="active">Activity if true, inactivity otherwise</param>
        void Mark(DateTime dateTime, bool active);

        /// <summary>
        /// Marks interval from <paramref name="start"/> to <paramref name="end"/> as activity or inactivity, depending on <paramref name="active"/>
        /// </summary>
        /// <param name="start">Interval start time</param>
        /// <param name="end">Interval end time</param>
        /// <param name="active">Activity if true, inactivity otherwise</param>
        void Mark(DateTime start, DateTime end, bool active);
    }
}
