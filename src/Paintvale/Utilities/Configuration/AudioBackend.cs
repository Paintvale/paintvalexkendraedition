using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.Ava.Utilities.Configuration
{
    [JsonConverter(typeof(TypedStringEnumConverter<AudioBackend>))]
    public enum AudioBackend
    {
        Dummy,
        OpenAl,
        SoundIo,
        SDL2,
    }
}
