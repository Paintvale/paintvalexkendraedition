using System;

namespace Paintvale.Horizon.Sdk.Codec.Detail
{
    [Flags]
    enum OpusDecoderFlags : uint
    {
        None,
        LargeFrameSize = 1 << 0,
    }
}
