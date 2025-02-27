using Avalonia.Controls;
using Avalonia.Interactivity;
using Paintvale.Ava.UI.ViewModels;
using System;

namespace Paintvale.Ava.UI.Views.Settings
{
    public partial class SettingsNetworkView : UserControl
    {
        private readonly Random _random;
        
        public SettingsViewModel ViewModel;

        public SettingsNetworkView()
        {
            _random = new Random();
            InitializeComponent();
        }

        private void GenLdnPassButton_OnClick(object sender, RoutedEventArgs e)
        {
            byte[] code = new byte[4];
            _random.NextBytes(code);
            ViewModel.LdnPassphrase = $"Paintvale-{BitConverter.ToUInt32(code):x8}";
        }

        private void ClearLdnPassButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.LdnPassphrase = string.Empty;
        }
    }
}
