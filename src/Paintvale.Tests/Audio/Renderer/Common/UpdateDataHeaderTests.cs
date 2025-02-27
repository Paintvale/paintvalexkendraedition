using NUnit.Framework;
using Paintvale.Audio.Renderer.Common;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Common
{
    class UpdateDataHeaderTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x40, Unsafe.SizeOf<UpdateDataHeader>());
        }
    }
}
