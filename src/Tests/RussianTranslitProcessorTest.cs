using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AY.Translit.Tests
{
    [TestClass]
    public class RussianTranslitProcessorTest
    {
        [TestMethod]
        public void Russian_font_register_test()
        {
            const string input = "регистр шрифта, Регистр Шрифта, РЕГИСТР ШРИФТА";
            const string expected = "registr shrifta, Registr Shrifta, REGISTR SHRIFTA";
            
            var processor = new RussianTranslitProcessor();
            Assert.AreEqual(expected, processor.Transliterate(input));
        }
    }
}
