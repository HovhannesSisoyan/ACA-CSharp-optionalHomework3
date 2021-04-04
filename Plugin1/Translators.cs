using System;
using Plugin;

namespace Plugin1
{
    [LanguageAttribute("Spanish")]
    public class TranslatorSpanish : TranslatorBase
    {
        public override string Translate()
        {
            return "Hola Mundo";
        }
    }
    [LanguageAttribute("Armenian")]
    public class TranslatorArmenian : TranslatorBase
    {
        public override string Translate()
        {
            return "Բարև աշխարհ";
        }
    }
}
