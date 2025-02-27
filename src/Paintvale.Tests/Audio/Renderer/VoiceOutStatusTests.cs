using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer
{
    class VoiceOutStatusTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x10, Unsafe.SizeOf<VoiceOutStatus>());
        }
    }
}
