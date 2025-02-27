using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration.Hid
{
    [JsonConverter(typeof(TypedStringEnumConverter<InputBackendType>))]
    public enum InputBackendType
    {
        Invalid,
        WindowKeyboard,
        GamepadSDL2,
    }
}
