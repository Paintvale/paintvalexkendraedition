using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Ldn.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x60)]
    struct AddressList
    {
        public Array8<AddressEntry> Addresses;
    }
}
