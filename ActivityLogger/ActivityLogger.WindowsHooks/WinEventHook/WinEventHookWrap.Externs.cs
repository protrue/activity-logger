using System;
using System.Runtime.InteropServices;

namespace ActivityLogger.WindowsHooks.WinEventHook
{
    public partial class WinEventHookWrap
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(
            uint eventMin,
            uint eventMax,
            IntPtr hmodWinEventProc,
            WinEventHookCallback lpfnWinEventProc,
            uint idProcess,
            uint idThread,
            uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);
    }
}