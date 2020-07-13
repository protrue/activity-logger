using System;

namespace ActivityLogger.WindowsHooks.WindowsHookEx
{
    public class WindowsHookExWrapArgs : EventArgs
    {
        public int NCode { get; set; }

        public IntPtr WordParameter { get; set; }

        public IntPtr LongParameter { get; set; }
    }
}