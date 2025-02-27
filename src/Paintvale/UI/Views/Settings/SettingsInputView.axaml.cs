using Avalonia.Controls;

namespace Paintvale.Ava.UI.Views.Settings
{
    public partial class SettingsInputView : UserControl
    {
        public SettingsInputView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            InputView.Dispose();
        }
    }
}
