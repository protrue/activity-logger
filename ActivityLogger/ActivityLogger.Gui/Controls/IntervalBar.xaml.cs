using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ActivityLogger.Gui.Controls
{
    public class IntervalBar : UserControl
    {
        public IntervalBar()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
