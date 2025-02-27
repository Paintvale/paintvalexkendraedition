using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.DebugMouse;

namespace Paintvale.HLE.HOS.Services.Hid
{
    public class DebugMouseDevice : BaseDevice
    {
        public DebugMouseDevice(Flaminrex device, bool active) : base(device, active) { }

        public void Update()
        {
            ref RingLifo<DebugMouseState> lifo = ref _device.Hid.SharedMemory.DebugMouse;

            ref DebugMouseState previousEntry = ref lifo.GetCurrentEntryRef();

            DebugMouseState newState = new()
            {
                SamplingNumber = previousEntry.SamplingNumber + 1,
            };

            if (Active)
            {
                // TODO: This is a debug device only present in dev environment, do we want to support it?
            }

            lifo.Write(ref newState);
        }
    }
}
