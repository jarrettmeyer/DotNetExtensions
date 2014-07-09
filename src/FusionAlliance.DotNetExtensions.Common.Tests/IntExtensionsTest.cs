using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class IntExtensionsTest
    {
        [Test]
        public void GetBoundedOptionalValue_applies_lower_bound_to_nullableInt_value()
        {
            int? val = -1;
            const int minVal = 1;
            const int maxVal = 100;

            var boundedVal = val.GetBoundedOptionalValue(minVal, maxVal);

            Assert.AreEqual(minVal, boundedVal);
        }

        [Test]
        public void GetBoundedOptionalValue_floor_only_applies_lower_bound_to_nullableInt_value()
        {
            int? val = -1;
            const int minVal = 1;

            var boundedVal = val.GetBoundedOptionalValue(minVal);

            Assert.AreEqual(minVal, boundedVal);
        }

        [Test]
        public void GetBoundedOptionalValue_floor_only_no_change_to_nullableInt_value()
        {
            int? val = 16;
            const int minVal = 1;

            var boundedVal = val.GetBoundedOptionalValue(minVal);

            Assert.AreEqual(val.Value, boundedVal);
        }

        [Test]
        public void GetBoundedOptionalValue_floor_only_nullableInt_value_null()
        {
            int? val = null;
            const int minVal = 1;

            var boundedVal = val.GetBoundedOptionalValue(minVal);

            Assert.IsNull(boundedVal);
        }

        [Test]
        public void GetBoundedOptionalValue_no_change_to_nullableInt_value()
        {
            int? val = 16;
            const int minVal = 1;
            const int maxVal = 100;

            var boundedVal = val.GetBoundedOptionalValue(minVal, maxVal);

            Assert.AreEqual(val.Value, boundedVal);
        }

        [Test]
        public void GetBoundedOptionalValue_nullableInt_value_null()
        {
            int? val = null;
            const int minVal = 1;
            const int maxVal = 100;

            var boundedVal = val.GetBoundedOptionalValue(minVal, maxVal);

            Assert.IsNull(boundedVal);
        }

        [Test]
        public void GetBoundedValue_applies_lower_bound_to_int_value()
        {
            const int val = -44;
            const int minVal = 1;
            const int maxVal = 40;

            var boundedVal = val.GetBoundedValue(minVal, maxVal);

            Assert.AreEqual(minVal, boundedVal);
        }

        [Test]
        public void GetBoundedValue_applies_lower_bound_to_nullableInt_value()
        {
            int? val = -3;
            const int minVal = 1;
            const int maxVal = 40;
            const int defaultVal = 33;

            var boundedVal = val.GetBoundedValue(defaultVal, minVal, maxVal);

            Assert.AreEqual(minVal, boundedVal);
        }

        [Test]
        public void GetBoundedValue_applies_upper_bound_to_int_value()
        {
            const int val = 44;
            const int minVal = 1;
            const int maxVal = 40;

            var boundedVal = val.GetBoundedValue(minVal, maxVal);

            Assert.AreEqual(maxVal, boundedVal);
        }

        [Test]
        public void GetBoundedValue_applies_upper_bound_to_nullableInt_value()
        {
            int? val = 66;
            const int minVal = 1;
            const int maxVal = 40;
            const int defaultVal = 33;

            var boundedVal = val.GetBoundedValue(defaultVal, minVal, maxVal);

            Assert.AreEqual(maxVal, boundedVal);
        }

        [Test]
        public void GetBoundedValue_defaults_nullableInt_value()
        {
            int? val = null;
            const int minVal = 1;
            const int maxVal = 40;
            const int defaultVal = 33;

            var boundedVal = val.GetBoundedValue(defaultVal, minVal, maxVal);

            Assert.AreEqual(defaultVal, boundedVal);
        }

        [Test]
        public void GetBoundedValue_floor_only_applies_lower_bound_to_nullableInt_value()
        {
            int? val = -22;
            const int minVal = 1;
            const int defaultVal = 33;

            var boundedVal = val.GetBoundedValue(defaultVal, minVal);

            Assert.AreEqual(minVal, boundedVal);
        }

        [Test]
        public void GetBoundedValue_floor_only_defaults_nullableInt_value()
        {
            int? val = null;
            const int minVal = 1;
            const int defaultVal = 33;

            var boundedVal = val.GetBoundedValue(defaultVal, minVal);

            Assert.AreEqual(defaultVal, boundedVal);
        }

        [Test]
        public void GetBoundedValue_floor_only_no_change_to_nullableInt_value()
        {
            int? val = 16;
            const int minVal = 1;
            const int defaultVal = 33;

            var boundedVal = val.GetBoundedValue(defaultVal, minVal);

            Assert.AreEqual(val, boundedVal);
        }

        [Test]
        public void GetBoundedValue_no_change_to_int_value()
        {
            const int val = 44;
            const int minVal = 1;
            const int maxVal = 4000;

            var boundedVal = val.GetBoundedValue(minVal, maxVal);

            Assert.AreEqual(val, boundedVal);
        }

        [Test]
        public void GetBoundedValue_no_change_to_nullableInt_value()
        {
            int? val = 5;
            const int minVal = 1;
            const int maxVal = 40;
            const int defaultVal = 33;

            var boundedVal = val.GetBoundedValue(defaultVal, minVal, maxVal);

            Assert.AreEqual(val, boundedVal);
        }
    }
}