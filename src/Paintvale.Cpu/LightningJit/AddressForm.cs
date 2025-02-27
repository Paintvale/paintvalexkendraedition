
namespace Paintvale.Cpu.LightningJit
{
    enum AddressForm : byte
    {
        None,
        OffsetReg,
        PostIndexed,
        PreIndexed,
        SignedScaled,
        UnsignedScaled,
        BaseRegister,
        BasePlusOffset,
        Literal,
        StructNoOffset,
        StructPostIndexedReg,
    }
}
