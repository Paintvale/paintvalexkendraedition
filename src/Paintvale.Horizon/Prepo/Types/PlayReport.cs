using MsgPack;
using Paintvale.Horizon.Sdk.Account;
using Paintvale.Horizon.Sdk.Ncm;

namespace Paintvale.Horizon.Prepo.Types
{
    public struct PlayReport
    {
        public PlayReportKind Kind { get; init; }
        public string Room { get; init; }
        public MessagePackObject ReportData { get; init; }
        
        public ApplicationId? AppId;
        public ulong? Pid;
        public uint Version;
        public Uid? UserId;
    }
    
    public enum PlayReportKind
    {
        Normal,
        System,
    }
}
