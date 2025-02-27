using NUnit.Framework;
using Paintvale.Audio.Renderer.Server.Splitter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Server
{
    class SplitterStateTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x20, Unsafe.SizeOf<SplitterState>());
        }
    }
}
