using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration
{
    [JsonConverter(typeof(TypedStringEnumConverter<AntiAliasing>))]
    public enum AntiAliasing
    {
        None,
        Fxaa,
        SmaaLow,
        SmaaMedium,
        SmaaHigh,
        SmaaUltra,
    }
}
