using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Ldn.UserServiceCreator.LdnRyu.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x4)]
    struct DisconnectMessage
    {
        public uint DisconnectIP;
    }
}
