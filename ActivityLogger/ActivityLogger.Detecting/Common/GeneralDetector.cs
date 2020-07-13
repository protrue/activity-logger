using System;
using ActivityLogger.Detecting.EventArgs;

namespace ActivityLogger.Detecting.Common
{
    public abstract class GeneralDetector : IActivityDetector<ActivityEventArgs>
    {
        private readonly IForegroundDetector _foregroundDetector;
        private readonly IMouseDetector _mouseDetector;
        private readonly IKeyboardDetector _keyboardDetector;

        public bool IsForegroundDetectorEnabled { get; set; }

        public bool IsMouseDetectorEnabled { get; set; }

        public bool IsKeyboardDetectorEnabled { get; set; }

        public bool IsDetecting { get; private set; }

        public event EventHandler<ActivityEventArgs> ActivityDetected;

        protected GeneralDetector(
            IForegroundDetector foregroundDetector,
            IMouseDetector mouseDetector,
            IKeyboardDetector keyboardDetector)
        {
            _foregroundDetector = foregroundDetector;
            _mouseDetector = mouseDetector;
            _keyboardDetector = keyboardDetector;

            _foregroundDetector.ActivityDetected += DetectorOnActivityDetected;
            _mouseDetector.ActivityDetected += DetectorOnActivityDetected;
            _keyboardDetector.ActivityDetected += DetectorOnActivityDetected;
        }

        private void DetectorOnActivityDetected(object sender, ActivityEventArgs activityEventArgs)
        {
            ActivityDetected?.Invoke(this, activityEventArgs);
        }

        public void StartDetecting()
        {
            if (IsForegroundDetectorEnabled && !_foregroundDetector.IsDetecting)
                _foregroundDetector.StartDetecting();

            if (IsMouseDetectorEnabled && !_mouseDetector.IsDetecting)
                _mouseDetector.StartDetecting();

            if (IsKeyboardDetectorEnabled && !_keyboardDetector.IsDetecting)
                _keyboardDetector.StartDetecting();

            IsDetecting = true;
        }

        public void StopDetecting()
        {
            if (_foregroundDetector.IsDetecting)
                _foregroundDetector.StopDetecting();

            if (_mouseDetector.IsDetecting)
                _mouseDetector.StopDetecting();

            if (_keyboardDetector.IsDetecting)
                _keyboardDetector.StopDetecting();

            IsDetecting = false;
        }

        public void Dispose()
        {
            _foregroundDetector.Dispose();
            _mouseDetector.Dispose();
            _keyboardDetector.Dispose();
        }

        protected virtual void OnActivityDetected(ActivityEventArgs e)
        {
            ActivityDetected?.Invoke(this, e);
        }
    }
}