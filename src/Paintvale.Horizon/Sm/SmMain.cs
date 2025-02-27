using Paintvale.Horizon.Sdk.Sf.Hipc;
using Paintvale.Horizon.Sdk.Sm;
using Paintvale.Horizon.Sm.Impl;
using Paintvale.Horizon.Sm.Types;

namespace Paintvale.Horizon.Sm
{
    public class SmMain
    {
        private const int SmMaxSessionsCount = 64;
        private const int SmmMaxSessionsCount = 1;
        private const int SmTotalMaxSessionsCount = SmMaxSessionsCount + SmmMaxSessionsCount;

        private const int MaxPortsCount = 2;

        private SmServerManager _serverManager;

        private readonly ServiceManager _serviceManager = new();

        public void Main()
        {
            HorizonStatic.Syscall.ManageNamedPort(out int smHandle, "sm:", SmMaxSessionsCount).AbortOnFailure();

            _serverManager = new SmServerManager(_serviceManager, null, null, MaxPortsCount, ManagerOptions.Default, SmTotalMaxSessionsCount);

            _serverManager.RegisterServer((int)SmPortIndex.User, smHandle);
            _serviceManager.RegisterServiceForSelf(out int smmHandle, ServiceName.Encode("sm:m"), SmmMaxSessionsCount).AbortOnFailure();
            _serverManager.RegisterServer((int)SmPortIndex.Manager, smmHandle);
            _serverManager.ServiceRequests();
        }
    }
}
