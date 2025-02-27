using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;
using System;

namespace Paintvale.Horizon.Sdk.Lm
{
    interface ILmLogger : IServiceObject
    {
        Result Log(Span<byte> message);
        Result SetDestination(LogDestination destination);
    }
}
