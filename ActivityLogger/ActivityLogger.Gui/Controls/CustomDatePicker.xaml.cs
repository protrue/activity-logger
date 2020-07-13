using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ActivityLogger.Gui.Controls
{
    public class CustomDatePicker : UserControl
    {
        public CustomDatePicker()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
