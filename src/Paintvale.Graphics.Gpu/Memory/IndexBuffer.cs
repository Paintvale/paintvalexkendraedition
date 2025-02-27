using Paintvale.Graphics.GAL;
using Paintvale.Memory.Range;

namespace Paintvale.Graphics.Gpu.Memory
{
    /// <summary>
    /// GPU Index Buffer information.
    /// </summary>
    struct IndexBuffer
    {
        public MultiRange Range;
        public IndexType Type;
    }
}
