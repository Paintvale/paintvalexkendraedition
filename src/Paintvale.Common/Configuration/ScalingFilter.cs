using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration
{
    [JsonConverter(typeof(TypedStringEnumConverter<ScalingFilter>))]
    public enum ScalingFilter
    {
        Bilinear,
        Nearest,
        Fsr,
        Area,
    }
}
