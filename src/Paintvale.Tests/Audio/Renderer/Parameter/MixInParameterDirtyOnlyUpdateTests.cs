using NUnit.Framework;
using Paintvale.Audio.Renderer.Parameter;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Parameter
{
    class MixInParameterDirtyOnlyUpdateTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x20, Unsafe.SizeOf<MixInParameterDirtyOnlyUpdate>());
        }
    }
}
