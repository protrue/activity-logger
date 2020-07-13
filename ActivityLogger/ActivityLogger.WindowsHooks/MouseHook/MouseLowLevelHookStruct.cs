using System;
using System.Runtime.InteropServices;

namespace ActivityLogger.WindowsHooks.MouseHook
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseLowLevelHookStruct
    {
        public Point Point;
        public uint MouseData;
        public uint Flags;
        public uint Time;
        public IntPtr DwExtraInfo;
    }
}