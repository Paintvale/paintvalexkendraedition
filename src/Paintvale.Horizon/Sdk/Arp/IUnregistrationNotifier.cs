using Paintvale.Horizon.Common;

namespace Paintvale.Horizon.Sdk.Arp
{
    public interface IUnregistrationNotifier
    {
        public Result GetReadableHandle(out int readableHandle);
    }
}
