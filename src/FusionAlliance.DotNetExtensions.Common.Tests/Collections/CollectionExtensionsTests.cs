using FusionAlliance.DotNetExtensions.Common.Collections;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests.Collections
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void IsNullOrEmpty_returns_false_when_collection_has_items()
        {
            var collection = new[] { 1, 2, 3 };
            Assert.IsFalse(collection.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_returns_true_when_collection_is_empty()
        {
            var collection = new int[] { };
            Assert.IsTrue(collection.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_returns_true_when_collection_is_null()
        {
            int[] collection = null;
            Assert.IsTrue(collection.IsNullOrEmpty());
        }
    }
}
