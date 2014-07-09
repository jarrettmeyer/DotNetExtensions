using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void ConvertCamelCaseToPascalCase()
        {
            const string input = "helloWorld";
            const string expected = "HelloWorld";

            var actual = input.ConvertCamelCaseToPascalCase();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConvertPascalCaseToCamelCase()
        {
            const string input = "HelloWorld";
            const string expected = "helloWorld";

            var actual = input.ConvertPascalCaseToCamelCase();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubstringSafe_empty_string()
        {
            var theString = string.Empty;
            var actual = theString.SubstringSafe(4);
            Assert.AreEqual(theString, actual);
        }

        [Test]
        public void SubstringSafe_valid_index()
        {
            const string theString = "hello world";
            var expected = theString.Substring(4);
            var actual = theString.SubstringSafe(4);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_empty_string()
        {
            var phoneString = string.Empty;
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_formats_string()
        {
            const string phoneString = "6536584678";
            const string expected = "653-658-4678";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_string_contains_alphas()
        {
            const string phoneString = "65C6584A78";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_string_too_long()
        {
            const string phoneString = "1245658994478";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberNoParens_string_too_short()
        {
            const string phoneString = "6584478";
            var actual = phoneString.ToPhoneNumberNoParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_empty_string()
        {
            var phoneString = string.Empty;
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_formats_string()
        {
            const string phoneString = "6536584678";
            const string expected = "(653) 658-4678";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_string_contains_alphas()
        {
            const string phoneString = "65C6584A78";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_string_too_long()
        {
            const string phoneString = "1245658994478";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }

        [Test]
        public void ToPhoneNumberWithParens_string_too_short()
        {
            const string phoneString = "6584478";
            var actual = phoneString.ToPhoneNumberWithParens();
            Assert.AreEqual(phoneString, actual);
        }
    }
}