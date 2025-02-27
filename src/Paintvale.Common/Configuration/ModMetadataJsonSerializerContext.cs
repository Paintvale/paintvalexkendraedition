using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ModMetadata))]
    public partial class ModMetadataJsonSerializerContext : JsonSerializerContext
    {
    }
}
