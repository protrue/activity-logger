namespace ActivityLogger.WindowsHooks.KeyboardHook
{
    public enum KeyboardMessage
    {
        Activate = 0x0006,
        ApplicationCommand = 0x0319,
        Character = 0x0102,
        DeadCharacter = 0x0103,
        HotKey = 0x0312,
        KeyDown = 0x0100,
        KeyUp = 0x0101,
        KillFocus = 0x0008,
        SetFocus = 0x0007,
        SystemDeadCharacter = 0x0107,
        SystemKeyDown = 0x0104,
        SystemKeyUp = 0x0105,
        UniChar = 0x0109,
    }
}