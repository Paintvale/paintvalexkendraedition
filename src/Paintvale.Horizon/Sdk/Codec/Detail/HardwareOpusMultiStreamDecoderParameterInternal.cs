using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.Horizon.Sdk.Codec.Detail
{
    [StructLayout(LayoutKind.Sequential, Size = 0x110)]
    struct HardwareOpusMultiStreamDecoderParameterInternal
    {
        public int SampleRate;
        public int ChannelsCount;
        public int NumberOfStreams;
        public int NumberOfStereoStreams;
        public Array256<byte> ChannelMappings;
    }
}
