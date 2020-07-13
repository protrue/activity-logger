using System;
using ActivityLogger.Detecting.EventArgs;
using ActivityLogger.Model.LowLevelModel;

namespace ActivityLogger.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DateTime _lastDetectTime;

        public string Greeting => "Welcome to Avalonia!";

        public ActivityLog ActivityLog { get; set; }

        public Detecting.Common.GeneralDetector Detector { get; set; }

        public MainWindowViewModel()
        {
            ActivityLog = new ActivityLog();
            Detector = new Detecting.Windows.GeneralDetector();
            Detector.ActivityDetected += DetectorOnActivityDetected;
            Detector.IsKeyboardDetectorEnabled = true;
            Detector.IsMouseDetectorEnabled = true;
            Detector.StartDetecting();
        }

        private void DetectorOnActivityDetected(object sender, ActivityEventArgs e)
        {
            ActivityLog.Mark(DateTime.Now, true);
        }
    }
}