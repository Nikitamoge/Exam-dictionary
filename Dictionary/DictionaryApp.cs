using System;
using System.Collections;
using System.Collections.Generic;

namespace DictionaryApp
{
    class DictionaryApp
    {
        private static List<Dictionary> dictionaries = new List<Dictionary>();

        static void Main(string[] args)
        {
            Menu.ShowMainMenu();
        }

        public static void AddDictionary(Dictionary dictionary)
        {
            dictionaries.Add(dictionary);
            Console.WriteLine("Dictionary added successfully!");
        }

        public static List<Dictionary> GetDictionaries()
        {
            return dictionaries;
        }

        public static Dictionary GetDictionaryByName(string name)
        {
            Dictionary dictionary = dictionaries.Find(d => d.Name == name);
            if (dictionary == null)
            {
                Console.WriteLine($"Dictionary with name '{name}' not found.");
            }
            return dictionary;
        }
    }
}
