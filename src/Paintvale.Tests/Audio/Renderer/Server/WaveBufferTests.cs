using NUnit.Framework;
using Paintvale.Audio.Renderer.Server.Voice;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Server
{
    class WaveBufferTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x58, Unsafe.SizeOf<WaveBuffer>());
        }
    }
}
