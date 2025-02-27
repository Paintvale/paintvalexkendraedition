using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.Horizon.Sdk.Codec.Detail
{
    [StructLayout(LayoutKind.Sequential, Size = 0x118)]
    struct HardwareOpusMultiStreamDecoderParameterInternalEx
    {
        public int SampleRate;
        public int ChannelsCount;
        public int NumberOfStreams;
        public int NumberOfStereoStreams;
        public OpusDecoderFlags Flags;
        public uint Reserved;
        public Array256<byte> ChannelMappings;
    }
}
