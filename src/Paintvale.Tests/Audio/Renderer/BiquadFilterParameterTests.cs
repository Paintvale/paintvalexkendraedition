using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer
{
    class BiquadFilterParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0xC, Unsafe.SizeOf<BiquadFilterParameter>());
        }
    }
}
