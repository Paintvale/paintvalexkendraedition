using Paintvale.HLE.HOS.Kernel.Threading;
using Paintvale.HLE.HOS.Services.Hid;

namespace Paintvale.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    class NfpDevice
    {
        public KEvent ActivateEvent;
        public KEvent DeactivateEvent;

        public void SignalActivate() => ActivateEvent.ReadableEvent.Signal();
        public void SignalDeactivate() => DeactivateEvent.ReadableEvent.Signal();

        public NfpDeviceState State = NfpDeviceState.Unavailable;

        public PlayerIndex Handle;
        public NpadIdType NpadIdType;

        public string AmiiboId;

        public bool UseRandomUuid;
    }
}
