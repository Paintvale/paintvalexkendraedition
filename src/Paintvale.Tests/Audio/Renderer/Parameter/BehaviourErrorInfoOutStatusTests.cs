using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Parameter
{
    class BehaviourErrorInfoOutStatusTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0xB0, Unsafe.SizeOf<BehaviourErrorInfoOutStatus>());
        }
    }
}
