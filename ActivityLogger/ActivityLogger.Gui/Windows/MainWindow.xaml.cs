using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ActivityLogger.Gui.Windows
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
