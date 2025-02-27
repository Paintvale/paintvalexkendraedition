using Paintvale.Cpu;
using Paintvale.Memory;
using System;

namespace Paintvale.HLE.HOS.Kernel.Process
{
    interface IProcessContext : IDisposable
    {
        IVirtualMemoryManager AddressSpace { get; }

        ulong AddressSpaceSize { get; }

        IExecutionContext CreateExecutionContext(ExceptionCallbacks exceptionCallbacks);
        void Execute(IExecutionContext context, ulong codeAddress);
        void InvalidateCacheRegion(ulong address, ulong size);
    }
}
