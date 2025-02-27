using NUnit.Framework;
using Paintvale.Audio.Renderer.Server.Voice;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Server
{
    class VoiceChannelResourceTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0xD0, Unsafe.SizeOf<VoiceChannelResource>());
        }
    }
}
