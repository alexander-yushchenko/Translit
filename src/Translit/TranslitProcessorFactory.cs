using System.Globalization;

namespace AY.Translit
{
    internal static class TranslitProcessorFactory
    {
        internal static ITranslitProcessor GetProcessor(CultureInfo cultureInfo)
        {
            if (cultureInfo == null) 
                return new UndefinedTranslitProcessor();

            var lcid = cultureInfo.LCID;

            switch (lcid)
            {
                case 1049:
                    return new RussianTranslitProcessor();

                case 1058:
                    return new UkrainianTranslitProcessor();
                
                default:
                    return new UndefinedTranslitProcessor();
            }
        }
    }
}
