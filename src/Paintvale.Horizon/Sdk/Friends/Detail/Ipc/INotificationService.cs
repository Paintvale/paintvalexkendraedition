using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Friends.Detail.Ipc
{
    interface INotificationService : IServiceObject
    {
        Result GetEvent(out int eventHandle);
        Result Clear();
        Result Pop(out SizedNotificationInfo sizedNotificationInfo);
    }
}
