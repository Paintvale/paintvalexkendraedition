using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Applet;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Audio.Detail
{
    partial class FinalOutputRecorderManager : IFinalOutputRecorderManager
    {
        [CmifCommand(0)]
        public Result OpenFinalOutputRecorder(
            out IFinalOutputRecorder recorder,
            FinalOutputRecorderParameter parameter,
            [CopyHandle] int processHandle,
            out FinalOutputRecorderParameterInternal outParameter,
            AppletResourceUserId appletResourceId)
        {
            recorder = new FinalOutputRecorder(processHandle);
            outParameter = new(parameter.SampleRate, 2, 0);

            return Result.Success;
        }
    }
}
