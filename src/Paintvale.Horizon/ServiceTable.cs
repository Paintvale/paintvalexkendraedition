using Paintvale.Horizon.Arp;
using Paintvale.Horizon.Audio;
using Paintvale.Horizon.Bcat;
using Paintvale.Horizon.Friends;
using Paintvale.Horizon.Hshl;
using Paintvale.Horizon.Ins;
using Paintvale.Horizon.Lbl;
using Paintvale.Horizon.LogManager;
using Paintvale.Horizon.MmNv;
using Paintvale.Horizon.Ngc;
using Paintvale.Horizon.Ovln;
using Paintvale.Horizon.Prepo;
using Paintvale.Horizon.Psc;
using Paintvale.Horizon.Ptm;
using Paintvale.Horizon.Sdk.Arp;
using Paintvale.Horizon.Srepo;
using Paintvale.Horizon.Usb;
using Paintvale.Horizon.Wlan;
using System.Collections.Generic;
using System.Threading;

namespace Paintvale.Horizon
{
    public class ServiceTable
    {
        private int _readyServices;
        private int _totalServices;

        private readonly ManualResetEvent _servicesReadyEvent = new(false);

        public IReader ArpReader { get; internal set; }
        public IWriter ArpWriter { get; internal set; }

        public IEnumerable<ServiceEntry> GetServices(HorizonOptions options)
        {
            List<ServiceEntry> entries = [];

            void RegisterService<T>() where T : IService
            {
                entries.Add(new ServiceEntry(T.Main, this, options));
            }

            RegisterService<ArpMain>();
            RegisterService<AudioMain>();
            RegisterService<BcatMain>();
            RegisterService<FriendsMain>();
            RegisterService<HshlMain>();
            RegisterService<HwopusMain>(); // TODO: Merge with audio once we can start multiple threads.
            RegisterService<InsMain>();
            RegisterService<LblMain>();
            RegisterService<LmMain>();
            RegisterService<MmNvMain>();
            RegisterService<NgcMain>();
            RegisterService<OvlnMain>();
            RegisterService<PrepoMain>();
            RegisterService<PscMain>();
            RegisterService<SrepoMain>();
            RegisterService<TsMain>();
            RegisterService<UsbMain>();
            RegisterService<WlanMain>();

            _totalServices = entries.Count;

            return entries;
        }

        internal void SignalServiceReady()
        {
            if (Interlocked.Increment(ref _readyServices) == _totalServices)
            {
                _servicesReadyEvent.Set();
            }
        }

        public void WaitServicesReady()
        {
            _servicesReadyEvent.WaitOne();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _servicesReadyEvent.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
