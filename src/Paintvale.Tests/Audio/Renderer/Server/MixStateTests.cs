using NUnit.Framework;
using Paintvale.Audio.Renderer.Server.Mix;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Server
{
    class MixStateTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x940, Unsafe.SizeOf<MixState>());
        }
    }
}
