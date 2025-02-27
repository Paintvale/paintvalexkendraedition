using System;
using System.Net;

namespace Paintvale.HLE.HOS.Services.Ldn.UserServiceCreator.LdnMitm.Proxy
{
    internal interface ILdnSocket : IDisposable
    {
        bool SendPacketAsync(EndPoint endpoint, byte[] buffer);
        bool Start();
        bool Stop();
    }
}
