using ActivityLogger.Detecting.EventArgs;

namespace ActivityLogger.Detecting.Common
{
    public interface IForegroundDetector : IActivityDetector<ForegroundEventArgs>
    {
    }
}