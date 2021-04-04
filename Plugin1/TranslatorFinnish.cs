using System;
using Plugin;

namespace Plugin1
{
    [LanguageAttribute("Finnish")]
    public class TranslatorFinnish : TranslatorBase
    {
        public override string Translate()
        {
            return "Hei maailma";
        }
    }
}
