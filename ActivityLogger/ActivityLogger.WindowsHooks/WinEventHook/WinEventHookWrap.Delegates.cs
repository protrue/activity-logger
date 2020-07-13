using System;

namespace ActivityLogger.WindowsHooks.WinEventHook
{
    public partial class WinEventHookWrap
    {
        public delegate void WinEventHookCallback(
            IntPtr hWinEventHook,
            uint eventType,
            IntPtr hwnd,
            int idObject,
            int idChild,
            uint dwEventThread,
            uint dwmsEventTime);
    }
}