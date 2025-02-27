using Paintvale.Common.Memory;

namespace Paintvale.Graphics.Nvdec.Vp9.Types
{
    internal struct VpxCodecFrameBuffer
    {
        public ArrayPtr<byte> Data;
        public Ptr<InternalFrameBuffer> Priv;
    }
}