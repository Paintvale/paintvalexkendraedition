using Paintvale.Horizon.Bcat.Ipc.Types;
using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Bcat
{
    internal interface IDeliveryCacheProgressService : IServiceObject
    {
        Result GetEvent(out int handle);
        Result GetImpl(out DeliveryCacheProgressImpl deliveryCacheProgressImpl);
    }
}
