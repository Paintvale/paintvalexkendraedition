using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Ava.Utilities.Configuration.System
{
    [JsonConverter(typeof(TypedStringEnumConverter<Region>))]
    public enum Region
    {
        Japan,
        USA,
        Europe,
        Australia,
        China,
        Korea,
        Taiwan,
    }
}
