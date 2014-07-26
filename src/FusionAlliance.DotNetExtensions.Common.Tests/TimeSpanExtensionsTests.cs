using System;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class TimeSpanExtensionsTests
    {
        [Test]
        public void Ago_returns_expected_value()
        {
            var date = 7.Days().Ago();
            var delta = (date - (DateTime.UtcNow - TimeSpan.FromDays(7))).TotalMilliseconds;
            Assert.LessOrEqual(delta, 1);
        }

        [Test]
        public void FromNow_returns_expectd_value()
        {
            var date = 7.Days().FromNow();
            var delta = (date - (DateTime.UtcNow + TimeSpan.FromDays(7))).TotalMilliseconds;
            Assert.LessOrEqual(delta, 1);
        }
    }
}