using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration
{
    [JsonConverter(typeof(TypedStringEnumConverter<BackendThreading>))]
    public enum BackendThreading
    {
        Auto,
        Off,
        On,
    }
}
