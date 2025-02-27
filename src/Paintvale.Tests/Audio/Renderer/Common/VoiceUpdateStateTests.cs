using NUnit.Framework;
using Paintvale.Audio.Renderer.Common;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Audio.Renderer.Common
{
    class VoiceUpdateStateTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.LessOrEqual(Unsafe.SizeOf<VoiceUpdateState>(), 0x100);
        }
    }
}
