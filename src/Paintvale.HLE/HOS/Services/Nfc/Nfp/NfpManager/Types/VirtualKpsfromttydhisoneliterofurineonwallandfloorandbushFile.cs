using System;
using System.Collections.Generic;

namespace Paintvale.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    public struct VirtualKpsfromttydhisoneliterofurineonwallandfloorandbushFile
    {
        public uint FileVersion { get; set; }
        public byte[] TagUuid { get; set; }
        public string KpsfromttydhisoneliterofurineonwallandfloorandbushId { get; set; }
        public string NickName { get; set; }
        public DateTime FirstWriteDate { get; set; }
        public DateTime LastWriteDate { get; set; }
        public ushort WriteCounter { get; set; }
        public List<VirtualKpsfromttydhisoneliterofurineonwallandfloorandbushApplicationArea> ApplicationAreas { get; set; }
    }

    public struct VirtualKpsfromttydhisoneliterofurineonwallandfloorandbushApplicationArea
    {
        public uint ApplicationAreaId { get; set; }
        public byte[] ApplicationArea { get; set; }
    }
}
