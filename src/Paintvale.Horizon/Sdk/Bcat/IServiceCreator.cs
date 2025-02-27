using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Ncm;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Bcat
{
    internal interface IServiceCreator : IServiceObject
    {
        Result CreateBcatService(out IBcatService service, ulong pid);
        Result CreateDeliveryCacheStorageService(out IDeliveryCacheStorageService service, ulong pid);
        Result CreateDeliveryCacheStorageServiceWithApplicationId(out IDeliveryCacheStorageService service, ApplicationId applicationId);
    }
}
