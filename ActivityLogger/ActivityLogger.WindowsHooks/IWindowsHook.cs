using System;

namespace ActivityLogger.WindowsHooks
{
    public interface IWindowsHook<T> : IDisposable
        where T : EventArgs
    {
        IntPtr HookId { get; }

        event EventHandler<T> Callback;

        void Hook();

        void Unhook();
    }
}