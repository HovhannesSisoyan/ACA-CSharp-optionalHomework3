using Plugin;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            string[] PluginNames = config["Plugins"].Split(",");
            Assembly asselbly = null;
            foreach (string pluginName in PluginNames)
            {
                try
                {
                    asselbly = Assembly.LoadFrom($"Plugins/{pluginName}");
                    Type[] translators = asselbly.GetTypes();

                    translators = translators
                        .Select(item => item)
                        .Where(item => item.IsSubclassOf(typeof(Plugin.TranslatorBase)))
                        .ToArray();

                    foreach (var translator in translators)
                    {
                        object translatorInstance = Activator.CreateInstance(translator);
                        MethodInfo translate = translator.GetMethod("Translate");
                        Console.Write(translate.Invoke(translatorInstance, null));

                        var languageInfo = translator
                            .GetCustomAttributes(false)
                            .Where(customAttr => (customAttr is LanguageAttribute));

                        if (languageInfo.Any()) {
                            foreach (LanguageAttribute langAttr in languageInfo)
                            {
                                Console.Write($" ({langAttr.Language})");
                            }
                        }
                        else
                            {
                                Console.Write(" (n/a)");
                            }
    
                        Console.WriteLine();
                    }
                }
            catch(FileNotFoundException ex)
            {
              Console.WriteLine(ex.Message);
              return;
            } 
            }
            Console.ReadLine();
        }
    }
}
