using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer
{
    class MemoryPoolParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x20, Unsafe.SizeOf<MemoryPoolInParameter>());
            Assert.AreEqual(0x10, Unsafe.SizeOf<MemoryPoolOutStatus>());
        }
    }
}
