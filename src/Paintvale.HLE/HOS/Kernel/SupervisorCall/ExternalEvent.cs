using Paintvale.HLE.HOS.Kernel.Threading;
using Paintvale.Horizon.Common;

namespace Paintvale.HLE.HOS.Kernel.SupervisorCall
{
    readonly struct ExternalEvent : IExternalEvent
    {
        private readonly KWritableEvent _writableEvent;

        public ExternalEvent(KWritableEvent writableEvent)
        {
            _writableEvent = writableEvent;
        }

        public readonly void Signal()
        {
            _writableEvent.Signal();
        }

        public readonly void Clear()
        {
            _writableEvent.Clear();
        }
    }
}
