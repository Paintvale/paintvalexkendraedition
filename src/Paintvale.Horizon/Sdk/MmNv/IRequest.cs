using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.MmNv
{
    interface IRequest : IServiceObject
    {
        Result InitializeOld(Module module, uint fgmPriority, uint autoClearEvent);
        Result FinalizeOld(Module module);
        Result SetAndWaitOld(Module module, uint clockRateMin, int clockRateMax);
        Result GetOld(out uint clockRateActual, Module module);
        Result Initialize(out uint requestId, Module module, uint fgmPriority, uint autoClearEvent);
        Result Finalize(uint requestId);
        Result SetAndWait(uint requestId, uint clockRateMin, int clockRateMax);
        Result Get(out uint clockRateActual, uint requestId);
    }
}
