using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Account;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Friends.Detail.Ipc
{
    interface IServiceCreator : IServiceObject
    {
        Result CreateFriendService(out IFriendService friendService);
        Result CreateNotificationService(out INotificationService notificationService, Uid userId);
        Result CreateDaemonSuspendSessionService(out IDaemonSuspendSessionService daemonSuspendSessionService);
    }
}
