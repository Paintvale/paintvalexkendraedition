using LibHac.Bcat;
using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;
using System;

namespace Paintvale.Horizon.Sdk.Bcat
{
    internal interface IDeliveryCacheStorageService : IServiceObject
    {
        Result CreateDirectoryService(out IDeliveryCacheDirectoryService service);
        Result CreateFileService(out IDeliveryCacheFileService service);
        Result EnumerateDeliveryCacheDirectory(out int count, Span<DirectoryName> directoryNames);
    }
}
