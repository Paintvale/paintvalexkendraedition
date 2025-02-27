using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Ava.Utilities.Configuration.UI
{
    [JsonConverter(typeof(TypedStringEnumConverter<FocusLostType>))]
    public enum FocusLostType
    {
        DoNothing,
        BlockInput,
        MuteAudio,
        BlockInputAndMuteAudio,
        PauseEmulation
    }
}
