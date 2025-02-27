using LibHac.Bcat;
using Paintvale.Horizon.Common;
using Paintvale.Horizon.Sdk.Sf;
using System;

namespace Paintvale.Horizon.Sdk.Bcat
{
    internal interface IDeliveryCacheFileService : IServiceObject
    {
        Result GetDigest(out Digest digest);
        Result GetSize(out long size);
        Result Open(DirectoryName directoryName, FileName fileName);
        Result Read(long offset, out long bytesRead, Span<byte> data);
    }
}
