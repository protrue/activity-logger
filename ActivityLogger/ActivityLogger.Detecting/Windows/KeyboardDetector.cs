using System;
using ActivityLogger.Detecting.Common;
using ActivityLogger.Detecting.EventArgs;
using ActivityLogger.WindowsHooks.KeyboardHook;

namespace ActivityLogger.Detecting.Windows
{
    public class KeyboardDetector : IKeyboardDetector
    {
        private readonly KeyboardLowLevelHook _keyboardLowLevelHook;

        public event EventHandler<KeyboardEventArgs> ActivityDetected;

        public bool IsDetecting { get; private set; }

        public KeyboardDetector()
        {
            _keyboardLowLevelHook = new KeyboardLowLevelHook();
            _keyboardLowLevelHook.Callback += KeyboardLowLevelHookOnCallback;
        }

        private void KeyboardLowLevelHookOnCallback(object sender, KeyboardLowLevelHookArgs keyboardLowLevelHookArgs)
        {
            ActivityDetected?.Invoke(this, new KeyboardEventArgs());
        }

        public void StartDetecting()
        {
            _keyboardLowLevelHook.Hook();
            IsDetecting = true;
        }

        public void StopDetecting()
        {
            _keyboardLowLevelHook.Unhook();
            IsDetecting = false;
        }

        public void Dispose()
        {
            _keyboardLowLevelHook.Dispose();
        }
    }
}