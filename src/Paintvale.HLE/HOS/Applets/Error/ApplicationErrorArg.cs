using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Applets.Error
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ApplicationErrorArg
    {
        public uint ErrorNumber;
        public ulong LanguageCode;
        public ByteArray2048 MessageText;
        public ByteArray2048 DetailsText;
    }
}
