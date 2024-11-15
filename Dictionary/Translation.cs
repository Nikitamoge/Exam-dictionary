using System;
using System.Collections.Generic;

namespace DictionaryApp
{
    static class Translator
    {
        public static List<string> FindTranslations(Dictionary<string, List<string>> dictionary, string word)
        {
            return dictionary.ContainsKey(word) ? dictionary[word] : new List<string>();
        }
    }
}

