using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(TitleUpdateMetadata))]
    public partial class TitleUpdateMetadataJsonSerializerContext : JsonSerializerContext
    {
    }
}
