using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class DoubleExtensionsTests
    {
        [Test]
        [TestCase(0, Result = 0)]
        [TestCase(1, Result = 86400000)]
        public double Days_returns_expected_time_span(double value)
        {
            return value.Days().TotalMilliseconds;
        }

        [Test]
        [TestCase(0, Result = 0)]
        [TestCase(1, Result = 3600000)]
        public double Hours_returns_expected_time_span(double value)
        {
            return value.Hours().TotalMilliseconds;
        }

        [Test]
        [TestCase(0, Result = 0)]
        [TestCase(1, Result = 1)]
        public double Milliseconds_returns_expected_time_span(double value)
        {
            return value.Milliseconds().TotalMilliseconds;
        }

        [Test]
        [TestCase(0, Result = 0)]
        [TestCase(1, Result = 60000)]
        public double Minutes_returns_expected_time_span(double value)
        {
            return value.Minutes().TotalMilliseconds;
        }

        [Test]
        [TestCase(0, Result = 0)]
        [TestCase(1, Result = 1000)]
        public double Seconds_returns_expected_time_span(double value)
        {
            return value.Seconds().TotalMilliseconds;
        }
    }
}