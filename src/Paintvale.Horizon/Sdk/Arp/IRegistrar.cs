using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Ns;

namespace Paintvale.Horizon.Sdk.Arp
{
    public interface IRegistrar
    {
        public Result Issue(out ulong applicationInstanceId);
        public Result SetApplicationLaunchProperty(ApplicationLaunchProperty applicationLaunchProperty);
        public Result SetApplicationControlProperty(in ApplicationControlProperty applicationControlProperty);
    }
}
