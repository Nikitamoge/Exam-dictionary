using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryApp
{
    class Dictionary
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        private Dictionary<string, List<string>> words;

        public Dictionary(string name, string type)
        {
            Name = name;
            Type = type;
            words = new Dictionary<string, List<string>>();
        }

        public void AddWord(string word, string translation)
        {
            if (!words.ContainsKey(word))
            {
                words[word] = new List<string>();
            }
            words[word].Add(translation);
            Console.WriteLine($"Word '{word}' added with translation '{translation}'.");
        }

        public void ReplaceWord(string word, string newTranslation)
        {
            if (words.ContainsKey(word))
            {
                words[word] = new List<string> { newTranslation };
                Console.WriteLine($"The word '{word}' has been replaced with the new translation '{newTranslation}'.");
            }
            else
            {
                Console.WriteLine($"The word '{word}' does not exist in the dictionary.");
            }
        }

        public void RemoveWord(string word)
        {
            if (words.ContainsKey(word))
            {
                words.Remove(word);
                Console.WriteLine($"The word '{word}' has been removed from the dictionary.");
            }
            else
            {
                Console.WriteLine($"The word '{word}' does not exist in the dictionary.");
            }
        }

        public void RemoveTranslation(string word, string translation)
        {
            if (words.ContainsKey(word))
            {
                if (words[word].Count > 1)
                {
                    words[word].Remove(translation);
                    Console.WriteLine($"Translation '{translation}' has been removed from the word '{word}'.");
                }
                else
                {
                    words.Remove(word);
                    Console.WriteLine($"Word '{word}' has been removed from the dictionary.");
                }
            }
        }

        public void RemoveWordByTranslation(string translation)
        {
            var wordToRemove = words.FirstOrDefault(w => w.Value.Contains(translation)).Key;
            if (wordToRemove != null)
            {
                RemoveWord(wordToRemove);
            }
            else
            {
                Console.WriteLine($"No word found with the translation '{translation}'.");
            }
        }

        public List<string> GetTranslations(string word)
        {
            return words.ContainsKey(word) ? words[word] : new List<string>();
        }

        public void ExportToFile(string fileName)
        {
            FileManager.ExportToFile(this, fileName);
        }

        public List<string> GetAllWords()
        {
            return words.Keys.ToList();
        }

        public void ReplaceTranslation(string word, string oldTranslation, string newTranslation)
        {
            if (words.ContainsKey(word))
            {
                var translations = words[word];
                var index = translations.IndexOf(oldTranslation);
                if (index != -1)
                {
                    translations[index] = newTranslation;
                }
            }
        }
    }
}

