using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ActivityLogger.WindowsHooks.ForegroundWindowHook
{
    public partial class ForegroundWindowHook
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    }
}