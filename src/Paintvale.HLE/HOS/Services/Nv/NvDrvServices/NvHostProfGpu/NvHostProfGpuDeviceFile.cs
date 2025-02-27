using Paintvale.Memory;

namespace Paintvale.HLE.HOS.Services.Nv.NvDrvServices.NvHostProfGpu
{
    class NvHostProfGpuDeviceFile : NvDeviceFile
    {
        public NvHostProfGpuDeviceFile(ServiceCtx context, IVirtualMemoryManager memory, ulong owner) : base(context, owner) { }

        public override void Close() { }
    }
}
