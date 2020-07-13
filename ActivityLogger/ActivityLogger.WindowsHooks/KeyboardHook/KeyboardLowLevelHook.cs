using System;
using ActivityLogger.WindowsHooks.WindowsHookEx;

namespace ActivityLogger.WindowsHooks.KeyboardHook
{
    public class KeyboardLowLevelHook : IWindowsHook<KeyboardLowLevelHookArgs>
    {
        public event EventHandler<KeyboardLowLevelHookArgs> Callback;

        public IntPtr HookId => _windowsHookExWrap.HookId;

        private readonly WindowsHookExWrap _windowsHookExWrap;

        public KeyboardLowLevelHook()
        {
            _windowsHookExWrap = new WindowsHookExWrap(WindowsHookExType.WH_KEYBOARD_LL);
            _windowsHookExWrap.Callback += WindowsHookExWrapCallback;
        }

        private void WindowsHookExWrapCallback(object sender, WindowsHookExWrapArgs parameters)
        {
            Callback?.Invoke(this, new KeyboardLowLevelHookArgs());
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