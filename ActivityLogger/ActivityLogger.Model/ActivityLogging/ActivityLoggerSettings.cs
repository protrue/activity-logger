using System;

namespace ActivityLogger.Model.ActivityLogging
{
    [Serializable]
    public class ActivityLoggerSettings
    {
        public TimeSpan MinInactivity { get; set; }
        public TimeSpan MaxInactivity { get; set; }
    }
}
