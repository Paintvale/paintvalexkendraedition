namespace Paintvale.Horizon.Sdk.Account
{
    public interface IEmulatorAccountManager
    {
        void OpenUserOnlinePlay(Uid userId);
        void CloseUserOnlinePlay(Uid userId);
    }
}
