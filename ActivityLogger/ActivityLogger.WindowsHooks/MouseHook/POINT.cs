using System.Runtime.InteropServices;

namespace ActivityLogger.WindowsHooks.MouseHook
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }
}