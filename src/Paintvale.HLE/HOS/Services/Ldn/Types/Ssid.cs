using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Ldn.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x22)]
    struct Ssid
    {
        public byte Length;
        public Array33<byte> Name;
    }
}
