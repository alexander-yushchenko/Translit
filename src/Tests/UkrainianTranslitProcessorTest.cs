using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AY.Translit.Tests
{
    [TestClass]
    public class UkrainianTranslitProcessorTest
    {
        [TestMethod]
        public void Ukrainian_font_register_test()
        {
            const string input = "реєстр шрифту, Реєстр Шрифту, РЕЄСТР ШРИФТУ";
            const string expected = "reiestr shryftu, Reiestr Shryftu, REIESTR SHRYFTU";

            var processor = new UkrainianTranslitProcessor();
            Assert.AreEqual(expected, processor.Transliterate(input));
        }
    }
}
