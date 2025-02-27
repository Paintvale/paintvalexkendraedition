using LibHac.Bcat;
using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;
using System;

namespace Paintvale.Horizon.Sdk.Bcat
{
    internal interface IDeliveryCacheDirectoryService : IServiceObject
    {
        Result GetCount(out int count);
        Result Open(DirectoryName directoryName);
        Result Read(out int entriesRead, Span<DeliveryCacheDirectoryEntry> entriesBuffer);
    }
}
