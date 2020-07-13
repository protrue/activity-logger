using System;
using ActivityLogger.Detecting.Common;
using ActivityLogger.Detecting.EventArgs;
using ActivityLogger.WindowsHooks.ForegroundWindowHook;

namespace ActivityLogger.Detecting.Windows
{
    public class ForegroundDetector : IForegroundDetector
    {
        public event EventHandler<ForegroundEventArgs> ActivityDetected;

        private readonly ForegroundWindowHook _foregroundWindowHook;

        public bool IsDetecting { get; private set; }

        public ForegroundDetector()
        {
            _foregroundWindowHook = new ForegroundWindowHook();
            _foregroundWindowHook.Callback += ForegroundWindowHookOnCallback;
        }

        private void ForegroundWindowHookOnCallback(object sender, ForegroundWindowHookArgs foregroundWindowHookArgs)
        {
            ActivityDetected?.Invoke(this, new ForegroundEventArgs());
        }

        public void StartDetecting()
        {
            _foregroundWindowHook.Hook();
            IsDetecting = true;
        }

        public void StopDetecting()
        {
            _foregroundWindowHook.Unhook();
            IsDetecting = false;
        }

        public void Dispose()
        {
            _foregroundWindowHook.Dispose();
        }
    }
}