using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration
{
    [JsonConverter(typeof(TypedStringEnumConverter<GraphicsDebugLevel>))]
    public enum GraphicsDebugLevel
    {
        None,
        Error,
        Slowdowns,
        All,
    }
}
