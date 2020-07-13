using System;

namespace ActivityLogger.Model.LowLevelModel
{
    /// <summary>
    /// Activity log of the month
    /// </summary>
    /// <remarks>
    /// Contains array of <see cref="DayLog"/>
    /// <para> Contained in <see cref="YearLog"/> </para> 
    /// </remarks>
    public class MonthLog : IMarkable
    {
        /// <summary>
        /// Максимальное количество дней в месяце
        /// </summary>
        private const int MaxDaysInMonth = 31;
        
        /// <summary>
        /// Номер месяца года
        /// </summary>
        public int Month { get; }
        
        /// <summary>
        /// Логи активности дней 
        /// </summary>
        public DayLog[] DayLogs { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="month">Номер месяца в году</param>
        public MonthLog(int month)
        {
            Month = month;
            DayLogs = new DayLog[MaxDaysInMonth];
        }

        /// <inheritdoc/>
        public void Mark(DateTime dateTime, bool active)
        {
            if (DayLogs[dateTime.Day] == null)
            {
                DayLogs[dateTime.Day] = new DayLog(dateTime.Day);
            }
            
            DayLogs[dateTime.Day].Mark(dateTime, active);
        }

        /// <inheritdoc/>
        public void Mark(DateTime start, DateTime end, bool active)
        {
            for (var day = start.Day; day < end.Day; day++)
            {
                if (DayLogs[day] == null)
                {
                    DayLogs[day] = new DayLog(day);
                }
                
                var dayLogStart = day != start.Day ? new DateTime(start.Year, start.Month, 1) : start;
                var dayLogEnd = day != end.Day ? new DateTime(end.Year, end.Month, end.Day + 1).Subtract(TimeSpan.MinValue) : end;
                
                DayLogs[day].Mark(dayLogStart, dayLogEnd, active);
            }
        }
    }
}