using ActivityLogger.Model.ActivityLogging;

namespace ActivityLogger.Model.ActivityStatistics
{
    public class ActivityLogStatistics
    {
        public ActivityLog ActivityLog { get; set; }

        public ActivityLogStatistics(ActivityLog activityLog)
        {
            ActivityLog = activityLog;
        }
    }
}
