using Avalonia.Threading;
using Paintvale.Ava.UI.ViewModels;

namespace Paintvale.Ava.Common
{
    public static class XCITrimmerLog
    {
        internal class MainWindow : Paintvale.Common.Logging.XCIFileTrimmerLog
        {
            private readonly MainWindowViewModel _viewModel;

            public MainWindow(MainWindowViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public override void Progress(long current, long total, string text, bool complete)
            {
                Dispatcher.UIThread.Post(() =>
                {
                    _viewModel.StatusBarProgressMaximum = (int)(total);
                    _viewModel.StatusBarProgressValue = (int)(current);
                });
            }
        }
        
        internal class TrimmerWindow : Paintvale.Common.Logging.XCIFileTrimmerLog
        {
            private readonly XCITrimmerViewModel _viewModel;

            public TrimmerWindow(XCITrimmerViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public override void Progress(long current, long total, string text, bool complete)
            {
                Dispatcher.UIThread.Post(() =>
                {
                    _viewModel.SetProgress((int)(current), (int)(total));
                });
            }
        }
    }
}
