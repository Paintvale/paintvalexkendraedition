using Paintvale.HLE.HOS.Services.Ldn.Types;
using System.Runtime.InteropServices;

namespace Paintvale.HLE.HOS.Services.Ldn.UserServiceCreator.LdnRyu.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x1, Pack = 1)]
    struct SetAcceptPolicyRequest
    {
        public AcceptPolicy StationAcceptPolicy;
    }
}
