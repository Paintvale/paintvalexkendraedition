using Paintvale.HLE.HOS.Kernel.Common;
using Paintvale.Horizon.Common;

namespace Paintvale.HLE.HOS.Kernel.Threading
{
    class KWritableEvent : KAutoObject
    {
        private readonly KEvent _parent;

        public KWritableEvent(KernelContext context, KEvent parent) : base(context)
        {
            _parent = parent;
        }

        public void Signal()
        {
            _parent.ReadableEvent.Signal();
        }

        public Result Clear()
        {
            return _parent.ReadableEvent.Clear();
        }
    }
}
