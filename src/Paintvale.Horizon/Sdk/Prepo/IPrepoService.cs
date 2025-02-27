using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Account;
using Paintvale.Horizon.Sdk.Sf;
using System;
using ApplicationId = Paintvale.Horizon.Sdk.Ncm.ApplicationId;

namespace Paintvale.Horizon.Sdk.Prepo
{
    interface IPrepoService : IServiceObject
    {
        Result SaveReport(ReadOnlySpan<byte> gameRoomBuffer, ReadOnlySpan<byte> reportBuffer, ulong pid);
        Result SaveReportWithUser(Uid userId, ReadOnlySpan<byte> gameRoomBuffer, ReadOnlySpan<byte> reportBuffer, ulong pid);
        Result RequestImmediateTransmission();
        Result GetTransmissionStatus(out int status);
        Result GetSystemSessionId(out ulong systemSessionId);
        Result SaveSystemReport(ReadOnlySpan<byte> gameRoomBuffer, ApplicationId applicationId, ReadOnlySpan<byte> reportBuffer);
        Result SaveSystemReportWithUser(Uid userId, ReadOnlySpan<byte> gameRoomBuffer, ApplicationId applicationId, ReadOnlySpan<byte> reportBuffer);
        Result IsUserAgreementCheckEnabled(out bool enabled);
        Result SetUserAgreementCheckEnabled(bool enabled);
    }
}
