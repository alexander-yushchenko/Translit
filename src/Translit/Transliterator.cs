using System;
using System.Globalization;

namespace AY.Translit
{
    public class Transliterator
    {
        private readonly ITranslitProcessor _processor;
        public Transliterator(CultureInfo cultureInfo)
        {
            if (cultureInfo == null) 
                throw new ArgumentNullException("cultureInfo");

            _processor = TranslitProcessorFactory.GetProcessor(cultureInfo);
        }

        public string Transliterate(string input)
        {
            return _processor.Transliterate(input);
        }
    }
}
