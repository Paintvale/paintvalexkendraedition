namespace Paintvale.Graphics.Vulkan
{
    internal enum BufferAllocationType
    {
        Auto = 0,

        HostMappedNoCache,
        HostMapped,
        DeviceLocal,
        DeviceLocalMapped,
        Sparse,
    }
}
