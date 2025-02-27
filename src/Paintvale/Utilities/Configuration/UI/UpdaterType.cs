using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Ava.Utilities.Configuration.UI
{
    [JsonConverter(typeof(TypedStringEnumConverter<UpdaterType>))]
    public enum UpdaterType
    {
        Off,
        PromptAtStartup,
        CheckInBackground
    }
}
