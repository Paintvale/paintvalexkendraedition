using Paintvale.Horizon.Bcat.Types;
using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Bcat;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Bcat.Ipc
{
    partial class BcatService : IBcatService
    {
        public BcatService(BcatServicePermissionLevel permissionLevel) { }

        [CmifCommand(10100)]
        public Result RequestSyncDeliveryCache(out IDeliveryCacheProgressService deliveryCacheProgressService)
        {
            deliveryCacheProgressService = new DeliveryCacheProgressService();

            return Result.Success;
        }
    }
}
