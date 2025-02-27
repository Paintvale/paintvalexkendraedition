using System;

namespace Paintvale.Horizon.Sdk.Settings.System
{
    [Flags]
    enum ServiceDiscoveryControlSettings : uint
    {
        IsChangeEnvironmentIdentifierDisabled = 1 << 0,
    }
}
