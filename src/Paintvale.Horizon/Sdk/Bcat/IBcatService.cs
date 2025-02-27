using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Bcat
{
    internal interface IBcatService : IServiceObject
    {
        Result RequestSyncDeliveryCache(out IDeliveryCacheProgressService deliveryCacheProgressService);
    }
}
