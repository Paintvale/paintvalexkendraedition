using Paintvale.HLE.HOS.Kernel.Memory;
using Paintvale.HLE.HOS.Kernel.Process;
using Paintvale.HLE.HOS.Kernel.Threading;
using Paintvale.Horizon.Common;
using System;
using System.Threading;

namespace Paintvale.HLE.HOS.Kernel
{
    static class KernelStatic
    {
        [ThreadStatic]
        private static KernelContext _context;

        [ThreadStatic]
        private static KThread _currentThread;

        public static Result StartInitialProcess(
            KernelContext context,
            ProcessCreationInfo creationInfo,
            ReadOnlySpan<uint> capabilities,
            int mainThreadPriority,
            ThreadStart customThreadStart)
        {
            KProcess process = new(context);

            Result result = process.Initialize(
                creationInfo,
                capabilities,
                context.ResourceLimit,
                MemoryRegion.Service,
                null,
                customThreadStart);

            if (result != Result.Success)
            {
                return result;
            }

            process.DefaultCpuCore = KScheduler.CpuCoresCount - 1;

            context.Processes.TryAdd(process.Pid, process);

            return process.Start(mainThreadPriority, 0x1000UL);
        }

        internal static void SetKernelContext(KernelContext context, KThread thread)
        {
            _context = context;
            _currentThread = thread;
        }

        internal static KThread GetCurrentThread()
        {
            return _currentThread;
        }

        internal static KProcess GetCurrentProcess()
        {
            return GetCurrentThread().Owner;
        }

        internal static KProcess GetProcessByPid(ulong pid)
        {
            if (_context.Processes.TryGetValue(pid, out KProcess process))
            {
                return process;
            }

            return null;
        }
    }
}
