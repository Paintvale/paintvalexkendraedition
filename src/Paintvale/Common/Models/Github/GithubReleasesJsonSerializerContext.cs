using System.Text.Json.Serialization;

namespace Paintvale.Ava.Common.Models.Github
{
    [JsonSerializable(typeof(GithubReleasesJsonResponse), GenerationMode = JsonSourceGenerationMode.Metadata)]
    public partial class GithubReleasesJsonSerializerContext : JsonSerializerContext;
}
