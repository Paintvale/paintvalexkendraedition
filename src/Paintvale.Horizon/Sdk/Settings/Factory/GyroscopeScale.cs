using System.Runtime.InteropServices;

namespace Paintvale.Horizon.Sdk.Settings.Factory
{
    [StructLayout(LayoutKind.Sequential, Size = 0x6, Pack = 0x2)]
    struct GyroscopeScale
    {
        public ushort X;
        public ushort Y;
        public ushort Z;
    }
}
