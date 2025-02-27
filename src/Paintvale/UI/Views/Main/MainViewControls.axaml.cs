using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Paintvale.Ava.Common;
using Paintvale.Ava.UI.ViewModels;
using Paintvale.Ava.UI.Windows;
using System;

namespace Paintvale.Ava.UI.Views.Main
{
    public partial class MainViewControls : UserControl
    {
        public MainWindowViewModel ViewModel;

        public MainViewControls()
        {
            InitializeComponent();
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);

            if (VisualRoot is MainWindow window)
            {
                DataContext = ViewModel = window.ViewModel;
            }
        }

        public void Sort_Checked(object sender, RoutedEventArgs args)
        {
            if (sender is RadioButton { Tag: string sortStrategy })
                ViewModel.Sort(Enum.Parse<ApplicationSort>(sortStrategy));
        }

        public void Order_Checked(object sender, RoutedEventArgs args)
        {
            if (sender is RadioButton { Tag: string sortOrder })
                ViewModel.Sort(sortOrder is not "Descending");
        }

        private void SearchBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            ViewModel.SearchText = SearchBox.Text;
        }
    }
}
