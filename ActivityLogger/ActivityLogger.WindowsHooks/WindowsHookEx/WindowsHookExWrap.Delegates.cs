using System;

namespace ActivityLogger.WindowsHooks.WindowsHookEx
{
    public partial class WindowsHookExWrap
    {
        public delegate IntPtr WindowsHookExCallback(int nCode, IntPtr wParam, IntPtr lParam);
    }
}