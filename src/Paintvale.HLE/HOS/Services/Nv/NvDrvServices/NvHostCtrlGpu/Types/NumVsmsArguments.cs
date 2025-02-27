using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Nv.NvDrvServices.NvHostCtrlGpu.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct NumVsmsArguments
    {
        public uint NumVsms;
        public uint Reserved;
    }
}
