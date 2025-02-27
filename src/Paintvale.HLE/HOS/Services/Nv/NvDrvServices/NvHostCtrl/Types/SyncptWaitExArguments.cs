using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Nv.NvDrvServices.NvHostCtrl.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct SyncptWaitExArguments
    {
        public SyncptWaitArguments Input;
        public uint Value;
    }
}
