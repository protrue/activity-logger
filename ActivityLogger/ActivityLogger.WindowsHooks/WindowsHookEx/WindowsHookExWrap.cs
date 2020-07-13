using System;
using System.Diagnostics;

namespace ActivityLogger.WindowsHooks.WindowsHookEx
{
    public partial class WindowsHookExWrap : IWindowsHook<WindowsHookExWrapArgs>
    {
        public readonly WindowsHookExType HookType;

        public IntPtr HookId { get; private set; }

        public event EventHandler<WindowsHookExWrapArgs> Callback;

        private Process _process;

        private ProcessModule _processModule;

        private WindowsHookExCallback _hookCallback;

        public WindowsHookExWrap(WindowsHookExType hookType)
        {
            HookType = hookType;
            HookId = IntPtr.Zero;
            _hookCallback = HookCallback;
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Callback?.Invoke(
                this,
                new WindowsHookExWrapArgs
                {
                    NCode = nCode,
                    WordParameter = wParam,
                    LongParameter = lParam
                });

            return CallNextHookEx(HookId, nCode, wParam, lParam);
        }

        public void Hook()
        {
            _process = Process.GetCurrentProcess();
            _processModule = _process.MainModule;
            HookId = SetWindowsHookEx((int) HookType, _hookCallback, GetModuleHandle(_processModule.ModuleName), 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(HookId);
            _processModule.Dispose();
            _process.Dispose();
        }

        public void Dispose()
        {
            Unhook();
        }
    }
}