using System;

namespace Plugin
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LanguageAttribute : System.Attribute
    {
        public LanguageAttribute(string lang)
        {
            Language = lang;
        }
        public string Language { get; }
    }
}