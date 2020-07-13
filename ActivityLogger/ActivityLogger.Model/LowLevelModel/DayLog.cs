using System;

namespace ActivityLogger.Model.LowLevelModel
{
    /// <summary>
    /// Activity log of the day
    /// </summary>
    public class DayLog : IMarkable
    {
        /// <summary>
        /// Number of seconds in a minute
        /// </summary>
        private const int SecondsInMinute = 60;

        /// <summary>
        /// Number of minutes in a hour
        /// </summary>
        private const int MinutesInHour = 60;

        /// <summary>
        /// Number of seconds in an hour
        /// </summary>
        private const int SecondsInHour = SecondsInMinute * MinutesInHour;

        /// <summary>
        /// Number of hours in a day
        /// </summary>
        private const int HoursInDay = 24;

        /// <summary>
        /// Number of seconds in a day
        /// </summary>
        private const int SecondsInDay = SecondsInHour * HoursInDay;

        /// <summary>
        /// Day of the month
        /// </summary>
        /// <remarks>
        /// From 1 to 31
        /// </remarks>
        public readonly int Day;

        /// <summary>
        /// Activity bits array.
        /// Index is a second of the day.
        /// True means activity, false - inactivity
        /// </summary>
        /// <remarks>
        /// Size is always 86 400 (number of seconds in a day, 60 * 60 * 24)
        /// </remarks>
        public bool[] ActivityBits { get; }

        /// <summary>
        /// Initializes new instance of <see cref="DayLog"/>
        /// </summary>
        /// <param name="day">Day of the month</param>
        public DayLog(int day)
        {
            if (day < 1 || day > 31)
                throw new ArgumentOutOfRangeException(nameof(day), day, "Day should be between 1 and 31");

            Day = day;
            ActivityBits = new bool[SecondsInDay];
        }

        /// <summary>
        /// Calculates second of the day using <see cref="DateTime.Hour"/>, <see cref="DateTime.Minute"/>, <see cref="DateTime.Second"/>
        /// </summary>
        /// <remarks>
        /// 13:37:59 = 13 * 60 * 60 + 37 * 60 + 59 = 49079
        /// </remarks>
        /// <param name="time">Время</param>
        /// <returns>Second of the day</returns>
        private static int GetSecondsNumber(DateTime time) =>
            time.Hour * SecondsInHour + time.Minute * SecondsInMinute + time.Second;

        /// <inheritdoc/>
        public void Mark(DateTime time, bool active)
        {
            var secondNumber = GetSecondsNumber(time);
            ActivityBits[secondNumber] = active;
        }

        /// <inheritdoc/>
        public void Mark(DateTime startTime, DateTime endTime, bool active)
        {
            var startSecond = GetSecondsNumber(startTime);
            var endSecond = GetSecondsNumber(endTime);

            for (var i = startSecond; i < endSecond; i++)
            {
                ActivityBits[i] = active;
            }
        }
    }
}