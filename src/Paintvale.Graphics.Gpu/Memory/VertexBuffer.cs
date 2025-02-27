using Paintvale.Memory.Range;

namespace Paintvale.Graphics.Gpu.Memory
{
    /// <summary>
    /// GPU Vertex Buffer information.
    /// </summary>
    struct VertexBuffer
    {
        public MultiRange Range;
        public int Stride;
        public int Divisor;
    }
}
