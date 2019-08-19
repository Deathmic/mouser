using Mouser.ExtensionMethods;
using Mouser.ExtensionMethods.Exceptions;
using NUnit.Framework;

namespace MouserTests.ExtensionMethodTests
{
    [TestFixture]
    public class StringExtensionMethodsTests
    {
        [Test]
        [TestCase("HelloWorld", 5, StringExtensionMethods.MaxCutModes.EndWithoutReplacement, "Hello")]
        [TestCase("HelloWorld", 10, StringExtensionMethods.MaxCutModes.EndWithoutReplacement, "HelloWorld")]
        [TestCase("HelloWorld", 15, StringExtensionMethods.MaxCutModes.EndWithoutReplacement, "HelloWorld")]
        [TestCase("HelloWorld", 5, StringExtensionMethods.MaxCutModes.EndEllipse, "He...")]
        [TestCase("HelloWorld", 10, StringExtensionMethods.MaxCutModes.EndEllipse, "HelloWorld")]
        [TestCase("HelloWorld", 15, StringExtensionMethods.MaxCutModes.EndEllipse, "HelloWorld")]
        [TestCase("HelloWorld", 5, StringExtensionMethods.MaxCutModes.MidEllipse, "H...d")]
        [TestCase("HelloWorld", 8, StringExtensionMethods.MaxCutModes.MidEllipse, "Hell...d")]
        [TestCase("HelloWorld", 9, StringExtensionMethods.MaxCutModes.MidEllipse, "Hello...d")]
        [TestCase("HelloWorldHelloWorld", 15, StringExtensionMethods.MaxCutModes.MidEllipse, "HelloWorld...ld")]
        public void Max_ValidLenghthCases_ReturnsCorrectString(
            string sStringRaw,
            int iLength,
            StringExtensionMethods.MaxCutModes mode,
            string sExpected)
        {
            Assert.AreEqual(sExpected, sStringRaw.Max(iLength, mode));
        }

        [Test]
        [TestCase("HelloWorld", 0, StringExtensionMethods.MaxCutModes.EndWithoutReplacement)]
        [TestCase("HelloWorld", 0, StringExtensionMethods.MaxCutModes.EndEllipse)]
        [TestCase("HelloWorld", 0, StringExtensionMethods.MaxCutModes.MidEllipse)]
        [TestCase("HelloWorld", 2, StringExtensionMethods.MaxCutModes.EndEllipse)]
        [TestCase("HelloWorld", 2, StringExtensionMethods.MaxCutModes.MidEllipse)]
        [TestCase("HelloWorld", 4, StringExtensionMethods.MaxCutModes.MidEllipse)]
        public void Max_InvalidLengthCases_ThrowsException(
            string sStringRaw,
            int iLength,
            StringExtensionMethods.MaxCutModes mode)
        {
            Assert.Throws<String_Max_InvalidLengthException>(() => sStringRaw.Max(iLength, mode));
        }
    }
}