using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Audio.Detail
{
    interface IAudioSnoopManager : IServiceObject
    {
        Result EnableDspUsageMeasurement();
        Result DisableDspUsageMeasurement();
        Result GetDspUsage(out uint usage);
    }
}
