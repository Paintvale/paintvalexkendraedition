using Avalonia.Controls;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.UI.Helpers;
using Paintvale.Ava.UI.Models;
using Paintvale.Ava.UI.ViewModels.Input;

namespace Paintvale.Ava.UI.Views.Input
{
    public partial class InputView : UserControl
    {
        private bool _dialogOpen;
        private InputViewModel ViewModel { get; set; }

        public InputView()
        {
            DataContext = ViewModel = new InputViewModel(this);

            InitializeComponent();
        }

        public void SaveCurrentProfile()
        {
            ViewModel.Save();
        }

        private async void PlayerIndexBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayerIndexBox != null)
            {
                if (PlayerIndexBox.SelectedIndex != (int)ViewModel.PlayerId)
                {
                    PlayerIndexBox.SelectedIndex = (int)ViewModel.PlayerId;
                }
            }

            if (ViewModel.IsModified && !_dialogOpen)
            {
                _dialogOpen = true;

                UserResult result = await ContentDialogHelper.CreateDeniableConfirmationDialog(
                    LocaleManager.Instance[LocaleKeys.DialogControllerSettingsModifiedConfirmMessage],
                    LocaleManager.Instance[LocaleKeys.DialogControllerSettingsModifiedConfirmSubMessage],
                    LocaleManager.Instance[LocaleKeys.InputDialogYes],
                    LocaleManager.Instance[LocaleKeys.InputDialogNo],
                    LocaleManager.Instance[LocaleKeys.Cancel],
                    LocaleManager.Instance[LocaleKeys.PaintvaleConfirm]);


                if (result == UserResult.Yes)
                {
                    ViewModel.Save();
                }

                _dialogOpen = false;

                if (result == UserResult.Cancel)
                {
                    if (e.AddedItems.Count > 0)
                    {
                        ViewModel.IsModified = true;
                        ViewModel.PlayerId = ((PlayerModel)e.AddedItems[0])!.Id;
                    }
                    return;
                }
                
                ViewModel.PlayerId = ViewModel.PlayerIdChoose;

                ViewModel.IsModified = false;
            }
            
        }

        public void Dispose()
        {
            ViewModel.Dispose();
        }
    }
}
