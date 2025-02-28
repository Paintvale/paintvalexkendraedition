using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.UI.Helpers;
using Paintvale.Ava.UI.ViewModels;
using Paintvale.Common;
using Paintvale.Common.Helper;
using System.Threading.Tasks;
using Button = Avalonia.Controls.Button;

namespace Paintvale.Ava.UI.Windows
{
    public partial class AboutWindow : UserControl
    {
        public AboutWindow()
        {
            InitializeComponent();

            GitHubRepoButton.Tag =
                $"https://github.com/{ReleaseInformation.ReleaseChannelOwner}/{ReleaseInformation.ReleaseChannelRepo}";
        }

        public static async Task Show()
        {
            using AboutWindowViewModel viewModel = new();
            
            ContentDialog contentDialog = new()
            {
                PrimaryButtonText = string.Empty,
                SecondaryButtonText = string.Empty,
                CloseButtonText = LocaleManager.Instance[LocaleKeys.UserProfilesClose],
                Content = new AboutWindow { DataContext = viewModel }
            };

            Style closeButton = new(x => x.Name("CloseButton"));
            closeButton.Setters.Add(new Setter(WidthProperty, 80d));

            Style closeButtonParent = new(x => x.Name("CommandSpace"));
            closeButtonParent.Setters.Add(new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Right));

            contentDialog.Styles.Add(closeButton);
            contentDialog.Styles.Add(closeButtonParent);

            await ContentDialogHelper.ShowAsync(contentDialog);
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button { Tag: string url })
                OpenHelper.OpenUrl(url);
        }

        private void KpsfromttydhisoneliterofurineonwallandfloorandbushLabel_OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (sender is TextBlock)
            {
                OpenHelper.OpenUrl("https://kpsfromttydhisoneliterofurineonwallandfloorandbushapi.com");
            }
        }
    }
}
