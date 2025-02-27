using Paintvale.Horizon.Sdk.Ns;

namespace Paintvale.Horizon.Sdk.Arp.Detail
{
    class ApplicationInstance
    {
        public ulong Pid { get; set; }
        public ApplicationLaunchProperty? LaunchProperty { get; set; }
        public ApplicationProcessProperty? ProcessProperty { get; set; }
        public ApplicationControlProperty? ControlProperty { get; set; }
        public ApplicationCertificate? Certificate { get; set; }
    }
}
