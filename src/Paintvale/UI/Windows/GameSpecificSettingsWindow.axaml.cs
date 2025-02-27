using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using FluentAvalonia.Core;
using FluentAvalonia.UI.Controls;
using Projektanker.Icons.Avalonia;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.UI.Models;
using Paintvale.Ava.UI.ViewModels;
using Paintvale.Ava.UI.ViewModels.Input;
using Paintvale.Ava.Utilities;
using Paintvale.Ava.Utilities.Configuration;
using Paintvale.Common.Configuration;
using Paintvale.HLE.FileSystem;
using Paintvale.HLE.HOS.SystemState;
using Paintvale.Input;
using System;
using System.IO;
using System.Linq;
using Key = Avalonia.Input.Key;


namespace Paintvale.Ava.UI.Windows
{
    public partial class GameSpecificSettingsWindow : StyleableAppWindow
    {
        internal readonly SettingsViewModel ViewModel;

        public GameSpecificSettingsWindow(MainWindowViewModel viewModel, bool findUserConfigDir = true)
        {
            Title = string.Format(LocaleManager.Instance[LocaleKeys.SettingsWithInfo], viewModel.SelectedApplication.Name, viewModel.SelectedApplication.IdString);

            DataContext = ViewModel = new SettingsViewModel(
                viewModel.VirtualFileSystem, 
                viewModel.ContentManager,
                viewModel.IsGameRunning,
                viewModel.SelectedApplication.Path,
                viewModel.SelectedApplication.Name,
                viewModel.SelectedApplication.IdString,
                viewModel.SelectedApplication.Icon,
                findUserConfigDir);

            ViewModel.CloseWindow += Close;
            ViewModel.SaveSettingsEvent += SaveSettings;

            InitializeComponent();
            Load();
        }

        public void SaveSettings()
        {
            InputPage.InputView?.SaveCurrentProfile();
        }


        private void Load()
        {
            Pages.Children.Clear();
            NavPanel.SelectionChanged += NavPanelOnSelectionChanged;
            NavPanel.SelectedItem = NavPanel.MenuItems.ElementAt(0);
        }

        private void NavPanelOnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
        {
            
            if (e.SelectedItem is NavigationViewItem navItem && navItem.Tag is not null)
            {
                switch (navItem.Tag.ToString())
                {
                    case nameof(UiPage):
                        UiPage.ViewModel = ViewModel;
                        NavPanel.Content = UiPage;
                        break;
                    case nameof(InputPage):
                        NavPanel.Content = InputPage;
                        break;
                    case nameof(SystemPage):
                        SystemPage.ViewModel = ViewModel;
                        NavPanel.Content = SystemPage;
                        break;
                    case nameof(CpuPage):
                        NavPanel.Content = CpuPage;
                        break;
                    case nameof(GraphicsPage):
                        NavPanel.Content = GraphicsPage;
                        break;
                    case nameof(AudioPage):
                        NavPanel.Content = AudioPage;
                        break;
                    case nameof(NetworkPage):
                        NetworkPage.ViewModel = ViewModel;
                        NavPanel.Content = NetworkPage;
                        break;
                    case nameof(LoggingPage):
                        NavPanel.Content = LoggingPage;
                        break;
                    case nameof(HacksPage):
                        HacksPage.DataContext = ViewModel;
                        NavPanel.Content = HacksPage;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }        
        }

        protected override void OnClosing(WindowClosingEventArgs e)
        {
            InputPage.Dispose(); // You need to unload the gamepad settings, otherwise the controls will be blocked
            base.OnClosing(e);
        }
    }
}
