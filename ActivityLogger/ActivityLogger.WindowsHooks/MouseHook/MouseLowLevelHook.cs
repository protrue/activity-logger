using System;
using System.Runtime.InteropServices;
using ActivityLogger.WindowsHooks.WindowsHookEx;

namespace ActivityLogger.WindowsHooks.MouseHook
{
    public class MouseLowLevelHook : IWindowsHook<MouseLowLevelHookArgs>
    {
        public event EventHandler<MouseLowLevelHookArgs> Callback;

        public IntPtr HookId => _windowsHookExWrap.HookId;

        private readonly WindowsHookExWrap _windowsHookExWrap;

        public MouseLowLevelHook()
        {
            _windowsHookExWrap = new WindowsHookExWrap(WindowsHookExType.WH_MOUSE_LL);
            _windowsHookExWrap.Callback += WindowsHookExWrapOnCallback;
        }

        private void WindowsHookExWrapOnCallback(object sender, WindowsHookExWrapArgs parameters)
        {
            var mouseMessage = (MouseMessage) parameters.WordParameter;
            var mouseLowLevelHookStruct = Marshal.PtrToStructure<MouseLowLevelHookStruct>(parameters.LongParameter);

            Callback?.Invoke(this, new MouseLowLevelHookArgs());
        }

        public void Hook()
        {
            _windowsHookExWrap.Hook();
        }

        public void Unhook()
        {
            _windowsHookExWrap.Unhook();
        }

        public void Dispose()
        {
            _windowsHookExWrap.Dispose();
        }
    }
}