using System;
using System.Diagnostics;
using ActivityLogger.WindowsHooks.WinEventHook;

namespace ActivityLogger.WindowsHooks.ForegroundWindowHook
{
    public partial class ForegroundWindowHook : IWindowsHook<ForegroundWindowHookArgs>
    {
        public event EventHandler<ForegroundWindowHookArgs> Callback;

        public IntPtr HookId => _winEventHookWrap.HookId;

        private readonly WinEventHookWrap _winEventHookWrap;

        public ForegroundWindowHook()
        {
            _winEventHookWrap = new WinEventHookWrap(
                WinEventHookType.EVENT_SYSTEM_FOREGROUND,
                WinEventHookType.EVENT_SYSTEM_FOREGROUND,
                WinEventHookFlag.WINEVENT_OUTOFCONTEXT);
            _winEventHookWrap.Callback += WinEventHookWrapOnCallback;
        }

        private void WinEventHookWrapOnCallback(object sender, WinEventHookArgs parameters)
        {
            var foregroundWindowHandle = GetForegroundWindow();
            GetWindowThreadProcessId(foregroundWindowHandle, out var processId);
            var process = Process.GetProcessById((int) processId);

            Callback?.Invoke(this, new ForegroundWindowHookArgs());
        }

        public void Hook()
        {
            _winEventHookWrap.Hook();
        }

        public void Unhook()
        {
            _winEventHookWrap.Unhook();
        }

        public void Dispose()
        {
            _winEventHookWrap.Dispose();
        }
    }
}