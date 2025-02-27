using Avalonia.Interactivity;
using Paintvale.Ava.Utilities.AppLibrary;

namespace Paintvale.Ava.UI.Helpers
{
    public class ApplicationOpenedEventArgs : RoutedEventArgs
    {
        public ApplicationData Application { get; }

        public ApplicationOpenedEventArgs(ApplicationData application, RoutedEvent routedEvent)
        {
            Application = application;
            RoutedEvent = routedEvent;
        }
    }
}
