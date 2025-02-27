using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter.Effect;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Parameter.Effect
{
    class LimiterParameterTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x44, Unsafe.SizeOf<LimiterParameter>());
        }
    }
}
