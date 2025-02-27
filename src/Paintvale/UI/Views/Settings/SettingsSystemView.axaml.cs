using Avalonia.Controls;
using Paintvale.Ava.UI.ViewModels;
using TimeZone = Paintvale.Ava.UI.Models.TimeZone;

namespace Paintvale.Ava.UI.Views.Settings
{
    public partial class SettingsSystemView : UserControl
    {
        public SettingsViewModel ViewModel;

        public SettingsSystemView()
        {
            InitializeComponent();
        }

        private void TimeZoneBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is TimeZone timeZone)
                {
                    e.Handled = true;

                    ViewModel.ValidateAndSetTimeZone(timeZone.Location);
                }
            }
        }

        private void TimeZoneBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is AutoCompleteBox box && box.SelectedItem is TimeZone timeZone)
            {
                ViewModel.ValidateAndSetTimeZone(timeZone.Location);
            }
        }
    }
}
