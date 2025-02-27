using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Nv.NvDrvServices.NvMap
{
    [StructLayout(LayoutKind.Sequential)]
    struct NvMapParam
    {
        public int Handle;
        public NvMapHandleParam Param;
        public int Result;
    }
}
