using CommunityToolkit.Mvvm.ComponentModel;
using Paintvale.HLE.HOS.Services.Account.Acc;
using System.Collections.ObjectModel;

namespace Paintvale.Ava.UI.ViewModels
{
    public partial class ProfileSelectorDialogViewModel : BaseModel
    {

        [ObservableProperty] private UserId _selectedUserId;

        [ObservableProperty] private ObservableCollection<BaseModel> _profiles = [];
    }
}
