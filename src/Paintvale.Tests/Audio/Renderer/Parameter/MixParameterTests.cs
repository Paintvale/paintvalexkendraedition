using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Parameter
{
    class MixParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x930, Unsafe.SizeOf<MixParameter>());
        }
    }
}
