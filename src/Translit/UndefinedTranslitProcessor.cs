namespace AY.Translit
{
    internal class UndefinedTranslitProcessor : ITranslitProcessor
    {
        public string Transliterate(string input)
        {
            return input;
        }
    }
}
