using System;

namespace ActivityLogger.WindowsHooks.WinEventHook
{
    public partial class WinEventHookWrap : IWindowsHook<WinEventHookArgs>
    {
        public readonly WinEventHookType HookTypeMin;

        public readonly WinEventHookType HookTypeMax;

        public readonly WinEventHookFlag HookFlag;

        public IntPtr HookId { get; private set; }

        public event EventHandler<WinEventHookArgs> Callback;

        private WinEventHookCallback _hookCallback;

        public WinEventHookWrap(WinEventHookType hookTypeMin, WinEventHookType hookTypeMax, WinEventHookFlag hookFlag)
        {
            HookTypeMin = hookTypeMin;
            HookTypeMax = hookTypeMax;
            HookFlag = hookFlag;
            _hookCallback = HookCallback;
        }

        private void HookCallback(
            IntPtr hWinEventHook,
            uint eventType,
            IntPtr hwnd,
            int idObject,
            int idChild,
            uint dwEventThread,
            uint dwmsEventTime)
        {
            Callback?.Invoke(
                this,
                new WinEventHookArgs
                {
                    HWinEventHook = hWinEventHook,
                    EventType = eventType,
                    Hwnd = hwnd,
                    IdObject = idObject,
                    IdChild = idChild,
                    DwEventThread = dwEventThread,
                    DwmsEventTime = dwmsEventTime
                });
        }

        public void Hook()
        {
            HookId = SetWinEventHook(
                (uint) HookTypeMin,
                (uint) HookTypeMax,
                IntPtr.Zero,
                _hookCallback,
                0,
                0,
                (uint) HookFlag);
        }

        public void Unhook()
        {
            UnhookWinEvent(HookId);
        }

        public void Dispose()
        {
            Unhook();
        }
    }
}