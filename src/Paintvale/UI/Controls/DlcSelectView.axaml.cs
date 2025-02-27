using Avalonia.Controls;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.Common.Models;
using Paintvale.Ava.UI.Helpers;
using Paintvale.Ava.UI.ViewModels;
using Paintvale.Ava.Utilities.AppLibrary;
using System.Threading.Tasks;

namespace Paintvale.Ava.UI.Controls
{
    public partial class DlcSelectView : UserControl
    {
        public DlcSelectView()
        {
            InitializeComponent();
        }

#nullable enable
        public static async Task<DownloadableContentModel?> Show(ulong selectedTitleId, ApplicationLibrary appLibrary)
#nullable disable
        {
            DlcSelectViewModel viewModel = new(selectedTitleId, appLibrary);

            ContentDialog contentDialog = new()
            {
                PrimaryButtonText = LocaleManager.Instance[LocaleKeys.Continue],
                SecondaryButtonText = string.Empty,
                CloseButtonText = string.Empty,
                Content = new DlcSelectView { DataContext = viewModel }
            };

            Style closeButton = new(x => x.Name("CloseButton"));
            closeButton.Setters.Add(new Setter(WidthProperty, 80d));

            Style closeButtonParent = new(x => x.Name("CommandSpace"));
            closeButtonParent.Setters.Add(new Setter(HorizontalAlignmentProperty,
                Avalonia.Layout.HorizontalAlignment.Right));

            contentDialog.Styles.Add(closeButton);
            contentDialog.Styles.Add(closeButtonParent);

            await ContentDialogHelper.ShowAsync(contentDialog);

            return viewModel.SelectedDlc;
        }
    }
}
