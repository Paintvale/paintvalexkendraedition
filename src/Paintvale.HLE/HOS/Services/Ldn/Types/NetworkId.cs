using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Ldn.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x20)]
    struct NetworkId
    {
        public IntentId IntentId;
        public Array16<byte> SessionId;
    }
}
