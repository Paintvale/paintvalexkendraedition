using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter.Performance;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Parameter
{
    class PerformanceInParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x10, Unsafe.SizeOf<PerformanceInParameter>());
        }
    }
}
