using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;

namespace Paintvale.Horizon.Sdk.Ts
{
    interface ISession : IServiceObject
    {
        Result GetTemperatureRange(out int minimumTemperature, out int maximumTemperature);
        Result GetTemperature(out int temperature);
        Result SetMeasurementMode(byte measurementMode);
    }
}
