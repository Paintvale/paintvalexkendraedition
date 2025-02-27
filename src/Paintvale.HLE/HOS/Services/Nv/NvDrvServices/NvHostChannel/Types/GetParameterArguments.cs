using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct GetParameterArguments
    {
        public uint Parameter;
        public uint Value;
    }
}
