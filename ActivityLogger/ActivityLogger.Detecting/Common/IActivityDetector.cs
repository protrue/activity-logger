using System;
using ActivityLogger.Detecting.EventArgs;

namespace ActivityLogger.Detecting.Common
{
    public interface IActivityDetector<T> : IDisposable
        where T : ActivityEventArgs
    {
        event EventHandler<T> ActivityDetected;

        bool IsDetecting { get; }

        void StartDetecting();

        void StopDetecting();
    }
}