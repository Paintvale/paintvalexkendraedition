namespace Paintvale.HLE.HOS.Services.Ldn.UserServiceCreator.LdnMitm.Proxy
{
    internal interface ILdnTcpSocket : ILdnSocket
    {
        bool Connect();
        void DisconnectAndStop();
    }
}
