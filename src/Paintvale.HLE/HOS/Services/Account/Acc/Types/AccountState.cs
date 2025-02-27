using Paintvale.Common.Utilities;
using System.Text.Json.Serialization;

namespace Paintvale.HLE.HOS.Services.Account.Acc
{
    [JsonConverter(typeof(TypedStringEnumConverter<AccountState>))]
    public enum AccountState
    {
        Closed,
        Open,
    }
}
