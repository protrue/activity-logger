using System;

namespace ActivityLogger.Model.LowLevelModel
{
    public class YearLog : IMarkable
    {
        /// <summary>
        /// Количество месяцев в году
        /// </summary>
        private const int MonthsInYear = 12;

        /// <summary>
        /// Год, которому соответствует этот <see cref="YearLog"/>
        /// </summary>
        public readonly int Year;

        /// <summary>
        /// Массив <see cref="MonthLog"/>
        /// </summary>
        public MonthLog[] MonthLogs { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <summary xml:lang="ru">
        /// Конструктор
        /// </summary>
        /// <param name="year">Год</param>
        public YearLog(int year)
        {
            Year = year;
            MonthLogs = new MonthLog[MonthsInYear];
        }

        /// <inheritdoc/>
        public void Mark(DateTime dateTime, bool active)
        {
            if (MonthLogs[dateTime.Month - 1] == null)
            {
                MonthLogs[dateTime.Month - 1] = new MonthLog(dateTime.Month);
            }

            MonthLogs[dateTime.Month - 1].Mark(dateTime, active);
        }

        /// <inheritdoc/>
        public void Mark(DateTime start, DateTime end, bool active)
        {
            for (var month = start.Month; month < end.Month; month++)
            {
                if (MonthLogs[month] == null)
                {
                    MonthLogs[month] = new MonthLog(month);
                }
                
                var monthLogStart = month != start.Year ? new DateTime(start.Year, month, 1) : start;
                var monthLogEnd = month != end.Year ? new DateTime(end.Year, month + 1, 1).Subtract(TimeSpan.MinValue) : end;
                
                MonthLogs[month].Mark(monthLogStart, monthLogEnd, active);
            }
        }
    }
}