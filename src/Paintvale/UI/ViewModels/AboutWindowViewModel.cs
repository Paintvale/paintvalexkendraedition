using Avalonia.Media.Imaging;
using Avalonia.Styling;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Gommon;
using Paintvale.Ava.Common;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.Utilities.Configuration;
using System;

namespace Paintvale.Ava.UI.ViewModels
{
    public partial class AboutWindowViewModel : BaseModel, IDisposable
    {
        [ObservableProperty] private Bitmap _githubLogo;
        [ObservableProperty] private Bitmap _discordLogo;
        [ObservableProperty] private string _version;

        public string Developers => "GreemDev";

        public string FormerDevelopers => LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.AboutPageDeveloperListMore, "keeptailabovegroundavoidtouchgroundchallenge, Ac_K, marysaka, rip in peri peri, LDj3SNuD, emmaus, Thealexbarney, GoffyDude, TSRBerry, IsaacMarovitz");

        public AboutWindowViewModel()
        {
            Version = PaintvaleApp.FullAppName + "\n" + Program.Version;
            UpdateLogoTheme(ConfigurationState.Instance.UI.BaseStyle.Value);

            PaintvaleApp.ThemeChanged += Paintvale_ThemeChanged;
        }

        private void Paintvale_ThemeChanged()
        {
            Dispatcher.UIThread.Post(() => UpdateLogoTheme(ConfigurationState.Instance.UI.BaseStyle.Value));
        }

        private const string LogoPathFormat = "resm:Paintvale.Assets.UIImages.Logo_{0}_{1}.png?assembly=Paintvale";

        private void UpdateLogoTheme(string theme)
        {
            bool isDarkTheme = theme == "Dark" || (theme == "Auto" && PaintvaleApp.DetectSystemTheme() == ThemeVariant.Dark);
            
            string themeName = isDarkTheme ? "Dark" : "Light";

            GithubLogo = LoadBitmap(LogoPathFormat.Format("GitHub", themeName));
            DiscordLogo = LoadBitmap(LogoPathFormat.Format("Discord", themeName));
        }

        private static Bitmap LoadBitmap(string uri) => new(Avalonia.Platform.AssetLoader.Open(new Uri(uri)));

        public void Dispose()
        {
            PaintvaleApp.ThemeChanged -= Paintvale_ThemeChanged;
            
            GithubLogo.Dispose();
            DiscordLogo.Dispose();
            
            GC.SuppressFinalize(this);
        }
    }
}
