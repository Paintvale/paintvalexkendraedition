using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer
{
    class AudioRendererConfigurationTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x34, Unsafe.SizeOf<AudioRendererConfiguration>());
        }
    }
}
