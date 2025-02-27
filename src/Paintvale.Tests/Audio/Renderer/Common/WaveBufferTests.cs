using NUnit.Framework;
using Paintvale.Audio.Renderer.Common;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Common
{
    class WaveBufferTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x30, Unsafe.SizeOf<WaveBuffer>());
        }
    }
}
