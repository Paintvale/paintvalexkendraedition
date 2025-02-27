using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Ldn.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x30, Pack = 1)]
    struct UserConfig
    {
        public Array33<byte> UserName;
        public Array15<byte> Unknown1;
    }
}
