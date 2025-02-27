using System.Text.Json.Serialization;

namespace Paintvale.Ava.Utilities.Configuration
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ConfigurationFileFormat))]
    internal partial class ConfigurationJsonSerializerContext : JsonSerializerContext;
}
