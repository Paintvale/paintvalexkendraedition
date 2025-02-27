using ARMeilleure.Common;
using ARMeilleure.Memory;
using Paintvale.Cpu.LightningJit.Arm32;
using Paintvale.Cpu.LightningJit.Arm64;
using Paintvale.Cpu.LightningJit.State;
using System.Runtime.InteropServices;

namespace Paintvale.Cpu.LightningJit
{
    class AarchCompiler
    {
        public static CompiledFunction Compile(
            CpuPreset cpuPreset,
            IMemoryManager memoryManager,
            ulong address,
            AddressTable<ulong> funcTable,
            nint dispatchStubPtr,
            ExecutionMode executionMode,
            Architecture targetArch)
        {
            if (executionMode == ExecutionMode.Aarch64)
            {
                return A64Compiler.Compile(cpuPreset, memoryManager, address, funcTable, dispatchStubPtr, targetArch);
            }
            else
            {
                return A32Compiler.Compile(cpuPreset, memoryManager, address, funcTable, dispatchStubPtr, executionMode == ExecutionMode.Aarch32Thumb, targetArch);
            }
        }
    }
}
