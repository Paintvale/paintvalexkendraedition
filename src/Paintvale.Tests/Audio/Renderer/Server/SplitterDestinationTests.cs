using NUnit.Framework;
using Paintvale.Audio.Renderer.Server.Splitter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Server
{
    class SplitterDestinationTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0xE0, Unsafe.SizeOf<SplitterDestinationVersion1>());
            Assert.AreEqual(0x110, Unsafe.SizeOf<SplitterDestinationVersion2>());
        }
    }
}
