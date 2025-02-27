using System;

namespace Paintvale.Horizon.Sdk.Lm
{
    [Flags]
    enum LogPacketFlags : byte
    {
        IsHead = 1 << 0,
        IsTail = 1 << 1,
        IsLittleEndian = 1 << 2,
    }
}
