using Paintvale.Common.Utilities;

namespace Paintvale.Ava.Utilities.Configuration
{
    internal static class ConfigurationFileFormatSettings
    {
        public static readonly ConfigurationJsonSerializerContext SerializerContext = new(JsonHelper.GetDefaultSerializerOptions());
    }
}
