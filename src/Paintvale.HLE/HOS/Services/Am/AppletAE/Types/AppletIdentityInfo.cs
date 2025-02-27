using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Am.AppletAE
{
    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    struct AppletIdentifyInfo
    {
        public AppletId AppletId;
        public uint Padding;
        public ulong TitleId;
    }
}
