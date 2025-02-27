using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer
{
    class VoiceInParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x170, Unsafe.SizeOf<VoiceInParameter>());
        }
    }
}
