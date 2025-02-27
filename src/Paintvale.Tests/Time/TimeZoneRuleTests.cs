using NUnit.Framework;
using Paintvale.HLE.HOS.Services.Time.TimeZone;
using System.Runtime.CompilerServices;

namespace Paintvale.Tests.Time
{
    internal class TimeZoneRuleTests
    {
        class EffectInfoParameterTests
        {
            [Test]
            public void EnsureTypeSize()
            {
                Assert.AreEqual(0x4000, Unsafe.SizeOf<TimeZoneRule>());
            }
        }
    }
}
