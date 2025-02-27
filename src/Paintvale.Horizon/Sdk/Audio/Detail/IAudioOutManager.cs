using Paintvale.Audio.Common;
using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Applet;
using Paintvale.Horizon.Sdk.Sf;
using System;

namespace Paintvale.Horizon.Sdk.Audio.Detail
{
    interface IAudioOutManager : IServiceObject
    {
        Result ListAudioOuts(out int count, Span<DeviceName> names);
        Result OpenAudioOut(
            out AudioOutputConfiguration outputConfig,
            out IAudioOut audioOut,
            Span<DeviceName> outName,
            AudioInputConfiguration inputConfig,
            AppletResourceUserId appletResourceId,
            int processHandle,
            ReadOnlySpan<DeviceName> name,
            ulong pid);
        Result ListAudioOutsAuto(out int count, Span<DeviceName> names);
        Result OpenAudioOutAuto(
            out AudioOutputConfiguration outputConfig,
            out IAudioOut audioOut,
            Span<DeviceName> outName,
            AudioInputConfiguration inputConfig,
            AppletResourceUserId appletResourceId,
            int processHandle,
            ReadOnlySpan<DeviceName> name,
            ulong pid);
    }
}
