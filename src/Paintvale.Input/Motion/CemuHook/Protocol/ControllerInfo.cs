using Paintvale.Common.Memory;
using System.Runtime.InteropServices;

namespace Paintvale.Input.Motion.CemuHook.Protocol
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerInfoResponse
    {
        public SharedResponse Shared;
        private readonly byte _zero;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerInfoRequest
    {
        public MessageType Type;
        public int PortsCount;
        public Array4<byte> PortIndices;
    }
}
