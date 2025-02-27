using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.TouchScreen;

namespace Paintvale.HLE.HOS.Services.Hid
{
    public struct TouchPoint
    {
        public TouchAttribute Attribute;
        public uint X;
        public uint Y;
        public uint DiameterX;
        public uint DiameterY;
        public uint Angle;
    }
}
