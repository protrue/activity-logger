namespace ActivityLogger.Detecting.Windows
{
    public class GeneralDetector : Common.GeneralDetector
    {
        public GeneralDetector() : base(new ForegroundDetector(), new MouseDetector(), new KeyboardDetector())
        {
        }
    }
}