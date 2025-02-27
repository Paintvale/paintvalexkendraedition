using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Ldn.UserServiceCreator.LdnRyu.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x14)]
    struct ProxyDisconnectMessage
    {
        public ProxyInfo Info;
        public int DisconnectReason;
    }
}
