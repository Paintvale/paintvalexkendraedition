using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Common.Configuration
{
    [JsonConverter(typeof(TypedStringEnumConverter<MemoryManagerMode>))]
    public enum MemoryManagerMode : byte
    {
        SoftwarePageTable,
        HostMapped,
        HostMappedUnsafe,
    }
}
