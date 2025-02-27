using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration.Hid.Controller.Motion
{
    [JsonConverter(typeof(TypedStringEnumConverter<MotionInputBackendType>))]
    public enum MotionInputBackendType : byte
    {
        Invalid,
        GamepadDriver,
        CemuHook,
    }
}
