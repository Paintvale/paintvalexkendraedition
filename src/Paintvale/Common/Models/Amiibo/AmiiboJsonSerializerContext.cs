using System.Text.Json.Serialization;

namespace Paintvale.Ava.Common.Models.Amiibo
{
    [JsonSerializable(typeof(AmiiboJson))]
    public partial class AmiiboJsonSerializerContext : JsonSerializerContext;
}
