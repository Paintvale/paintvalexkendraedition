using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Platform;
using FluentAvalonia.UI.Windowing;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.UI.ViewModels;
using System.Threading.Tasks;

namespace Paintvale.Ava.UI.Windows
{
    public abstract class StyleableAppWindow : AppWindow
    {
        public static async Task ShowAsync(StyleableAppWindow appWindow, Window owner = null)
        {
#if DEBUG
            appWindow.AttachDevTools(new KeyGesture(Key.F12, KeyModifiers.Control));   
#endif
            await appWindow.ShowDialog(owner ?? PaintvaleApp.MainWindow);
        }
        
        protected StyleableAppWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            TransparencyLevelHint = [WindowTransparencyLevel.None];

            LocaleManager.Instance.LocaleChanged += LocaleChanged;
            LocaleChanged();

            Icon = MainWindowViewModel.IconBitmap;
        }

        private void LocaleChanged()
        {
            FlowDirection = LocaleManager.Instance.IsRTL() ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.SystemChrome | ExtendClientAreaChromeHints.OSXThickTitleBar;
        }
    }

    public abstract class StyleableWindow : Window
    {
        public static async Task ShowAsync(StyleableWindow window, Window owner = null)
        {
#if DEBUG
            window.AttachDevTools(new KeyGesture(Key.F12, KeyModifiers.Control));   
#endif
            await window.ShowDialog(owner ?? PaintvaleApp.MainWindow);
        }

        protected StyleableWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            TransparencyLevelHint = [WindowTransparencyLevel.None];

            LocaleManager.Instance.LocaleChanged += LocaleChanged;
            LocaleChanged();

            Icon = new WindowIcon(MainWindowViewModel.IconBitmap);
        }

        private void LocaleChanged()
        {
            FlowDirection = LocaleManager.Instance.IsRTL() ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.SystemChrome | ExtendClientAreaChromeHints.OSXThickTitleBar;
        }
    }
}
