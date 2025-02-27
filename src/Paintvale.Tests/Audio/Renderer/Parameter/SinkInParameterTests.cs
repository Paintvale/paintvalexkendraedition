using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Parameter
{
    class SinkInParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x140, Unsafe.SizeOf<SinkInParameter>());
        }
    }
}
