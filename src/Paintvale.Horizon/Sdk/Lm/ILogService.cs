using Paintvale.Horizon.Common;
using Paintvale.Horizon.LogManager.Ipc;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Lm
{
    interface ILogService : IServiceObject
    {
        Result OpenLogger(out LmLogger logger, ulong pid);
    }
}
