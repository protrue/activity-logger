using System;

namespace ActivityLogger.WindowsHooks.WinEventHook
{
    public class WinEventHookArgs : EventArgs
    {
        public IntPtr HWinEventHook { get; set; }

        public uint EventType { get; set; }

        public IntPtr Hwnd { get; set; }

        public int IdObject { get; set; }

        public int IdChild { get; set; }

        public uint DwEventThread { get; set; }

        public uint DwmsEventTime { get; set; }
    }
}