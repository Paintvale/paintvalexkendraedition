using System.Text.Json.Serialization;

namespace Paintvale.Common.Logging
{
    [JsonSerializable(typeof(LogEventArgsJson))]
    internal partial class LogEventJsonSerializerContext : JsonSerializerContext
    {
    }
}
