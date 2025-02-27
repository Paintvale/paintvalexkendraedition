using NUnit.Framework;
using Paintvale.Audio.Renderer.Server.Voice;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Server
{
    class VoiceStateTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.LessOrEqual(Unsafe.SizeOf<VoiceState>(), 0x220);
        }
    }
}
