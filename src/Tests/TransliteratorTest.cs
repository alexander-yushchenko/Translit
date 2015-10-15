using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AY.Translit.Tests
{
    [TestClass]
    public class TransliteratorTest
    {
        [TestMethod]
        public void Unsupported_language_test()
        {
            const string input = "Неподдерживаемый язык транслитерации";

            var сultureInfo = CultureInfo.InvariantCulture;
            var transliterator = new Transliterator(сultureInfo);
            Assert.AreEqual(input, transliterator.Transliterate(input));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CultureInfo_argument_null_test()
        {
            var transliterator = new Transliterator(null);
            transliterator.Transliterate(null);
        }
    }
}
