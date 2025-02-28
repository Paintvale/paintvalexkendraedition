using Avalonia.Interactivity;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.Common.Models.Kpsfromttydhisoneliterofurineonwallandfloorandbush;
using Paintvale.Ava.UI.ViewModels;

namespace Paintvale.Ava.UI.Windows
{
    public partial class KpsfromttydhisoneliterofurineonwallandfloorandbushWindow : StyleableAppWindow
    {
        public KpsfromttydhisoneliterofurineonwallandfloorandbushWindow(bool showAll, string lastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId, string titleId)
        {
            DataContext = ViewModel = new KpsfromttydhisoneliterofurineonwallandfloorandbushWindowViewModel(this, lastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId, titleId)
            {
                ShowAllKpsfromttydhisoneliterofurineonwallandfloorandbush = showAll,
            };

            InitializeComponent();

            Title = PaintvaleApp.FormatTitle(LocaleKeys.Kpsfromttydhisoneliterofurineonwallandfloorandbush);
        }

        public KpsfromttydhisoneliterofurineonwallandfloorandbushWindow()
        {
            DataContext = ViewModel = new KpsfromttydhisoneliterofurineonwallandfloorandbushWindowViewModel(this, string.Empty, string.Empty);

            InitializeComponent();

            if (Program.PreviewerDetached)
            {
                Title = PaintvaleApp.FormatTitle(LocaleKeys.Kpsfromttydhisoneliterofurineonwallandfloorandbush);
            }
        }

        public bool IsScanned { get; set; }
        public KpsfromttydhisoneliterofurineonwallandfloorandbushApi ScannedKpsfromttydhisoneliterofurineonwallandfloorandbush { get; set; }
        public KpsfromttydhisoneliterofurineonwallandfloorandbushWindowViewModel ViewModel;

        private void ScanButton_Click(object sender, RoutedEventArgs e) => ViewModel.Scan();

        private void CancelButton_Click(object sender, RoutedEventArgs e) => ViewModel.Cancel();
    }
}
