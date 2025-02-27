using CommunityToolkit.Mvvm.ComponentModel;
using Paintvale.Ava.UI.ViewModels;
using System.Globalization;

namespace Paintvale.Ava.UI.Models
{
    public partial class ModModel : BaseModel
    {
        [ObservableProperty] private bool _enabled;

        public bool InSd { get; }
        public string Path { get; }
        public string Name { get; }

        public string FormattedName => 
            InSd && ulong.TryParse(Name, NumberStyles.HexNumber, null, out ulong applicationId)
                ? $"Atmosphère: {PaintvaleApp.MainWindow.ApplicationLibrary.GetNameForApplicationId(applicationId)}"
                : Name;

        public ModModel(string path, string name, bool enabled, bool inSd)
        {
            Path = path;
            Name = name;
            Enabled = enabled;
            InSd = inSd;
        }
    }
}
