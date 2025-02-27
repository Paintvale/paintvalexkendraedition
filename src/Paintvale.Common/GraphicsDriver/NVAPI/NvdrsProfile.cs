using System.Runtime.InteropServices;

namespace Paintvale.Common.GraphicsDriver.NVAPI
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct NvdrsProfile
    {
        public uint Version;
        public NvapiUnicodeString ProfileName;
        public uint GpuSupport;
        public uint IsPredefined;
        public uint NumOfApps;
        public uint NumOfSettings;
    }
}
