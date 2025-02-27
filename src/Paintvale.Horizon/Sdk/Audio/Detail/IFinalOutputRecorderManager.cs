using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Applet;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Audio.Detail
{
    interface IFinalOutputRecorderManager : IServiceObject
    {
        Result OpenFinalOutputRecorder(
            out IFinalOutputRecorder recorder,
            FinalOutputRecorderParameter parameter,
            int processHandle,
            out FinalOutputRecorderParameterInternal outParameter,
            AppletResourceUserId appletResourceId);
    }
}
