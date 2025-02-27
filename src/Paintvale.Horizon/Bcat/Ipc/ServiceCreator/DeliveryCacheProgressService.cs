using Paintvale.Common.Logging;
using Paintvale.Horizon.Bcat.Ipc.Types;
using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Bcat;
using Paintvale.Horizon.Sdk.OsTypes;
using Paintvale.Horizon.Sdk.Sf;
using Paintvale.Horizon.Sdk.Sf.Hipc;
using System;
using System.Threading;

namespace Paintvale.Horizon.Bcat.Ipc
{
    partial class DeliveryCacheProgressService : IDeliveryCacheProgressService, IDisposable
    {
        private int _handle;
        private SystemEventType _systemEvent;
        private int _disposalState;

        [CmifCommand(0)]
        public Result GetEvent([CopyHandle] out int handle)
        {
            if (_handle == 0)
            {
                Os.CreateSystemEvent(out _systemEvent, EventClearMode.ManualClear, true).AbortOnFailure();

                _handle = Os.GetReadableHandleOfSystemEvent(ref _systemEvent);
            }

            handle = _handle;

            Logger.Stub?.PrintStub(LogClass.ServiceBcat);

            return Result.Success;
        }

        [CmifCommand(1)]
        public Result GetImpl([Buffer(HipcBufferFlags.Out | HipcBufferFlags.Pointer, 0x200)] out DeliveryCacheProgressImpl deliveryCacheProgressImpl)
        {
            deliveryCacheProgressImpl = new DeliveryCacheProgressImpl
            {
                State = DeliveryCacheProgressImpl.Status.Done,
                Result = 0,
            };

            Logger.Stub?.PrintStub(LogClass.ServiceBcat);

            return Result.Success;
        }

        public void Dispose()
        {
            if (_handle != 0 && Interlocked.Exchange(ref _disposalState, 1) == 0)
            {
                Os.DestroySystemEvent(ref _systemEvent);
            }
        }
    }
}
