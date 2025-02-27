using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Hid
{
    [StructLayout(LayoutKind.Sequential)]
    struct BusHandle
    {
        public int AbstractedPadId;
        public byte InternalIndex;
        public byte PlayerNumber;
        public byte BusTypeId;
        public byte IsValid;
    }
}
