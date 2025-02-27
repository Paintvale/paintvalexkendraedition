using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Arp;
using Paintvale.Horizon.Sdk.Arp.Detail;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Arp.Ipc
{
    partial class UnregistrationNotifier : IUnregistrationNotifier, IServiceObject
    {
        private readonly ApplicationInstanceManager _applicationInstanceManager;

        public UnregistrationNotifier(ApplicationInstanceManager applicationInstanceManager)
        {
            _applicationInstanceManager = applicationInstanceManager;
        }

        [CmifCommand(0)]
        public Result GetReadableHandle([CopyHandle] out int readableHandle)
        {
            readableHandle = _applicationInstanceManager.EventHandle;

            return Result.Success;
        }
    }
}
