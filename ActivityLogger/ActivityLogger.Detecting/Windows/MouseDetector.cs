using System;
using ActivityLogger.Detecting.Common;
using ActivityLogger.Detecting.EventArgs;
using ActivityLogger.WindowsHooks.MouseHook;

namespace ActivityLogger.Detecting.Windows
{
    public class MouseDetector : IMouseDetector
    {
        private readonly MouseLowLevelHook _mouseLowLevelHook;

        public event EventHandler<MouseEventArgs> ActivityDetected;

        public bool IsDetecting { get; private set; }

        public MouseDetector()
        {
            _mouseLowLevelHook = new MouseLowLevelHook();
            _mouseLowLevelHook.Callback += MouseLowLevelHookOnCallback;
        }

        private void MouseLowLevelHookOnCallback(object sender, MouseLowLevelHookArgs e)
        {
            ActivityDetected?.Invoke(this, new MouseEventArgs());
        }

        public void StartDetecting()
        {
            _mouseLowLevelHook.Hook();
            IsDetecting = true;
        }

        public void StopDetecting()
        {
            _mouseLowLevelHook.Unhook();
            IsDetecting = false;
        }

        public void Dispose()
        {
            _mouseLowLevelHook.Dispose();
        }
    }
}