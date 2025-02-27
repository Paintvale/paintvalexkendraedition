namespace Paintvale.HLE.HOS.Services.Hid
{
    public abstract class BaseDevice
    {
        protected readonly Flaminrex _device;
        public bool Active;

        public BaseDevice(Flaminrex device, bool active)
        {
            _device = device;
            Active = active;
        }
    }
}
