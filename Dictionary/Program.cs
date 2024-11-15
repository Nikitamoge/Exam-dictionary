using System;
using System.Collections.Generic;

namespace DictionaryApp
{
    class Menu
    {
        private static Dictionary selectedDictionary;

        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Create Dictionary ");
                Console.WriteLine("2. Select Dictionary ");
                Console.WriteLine("3. Add Word ");
                Console.WriteLine("4. Replace Word ");
                Console.WriteLine("5. Remove Word ");
                Console.WriteLine("6. Search Translation ");
                Console.WriteLine("7. Export Dictionary ");
                Console.WriteLine("8. Exit ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateDictionary();
                        break;
                    case "2":
                        SelectDictionary();
                        break;
                    case "3":
                        AddWord();
                        break;
                    case "4":
                        ReplaceWord();
                        break;
                    case "5":
                        RemoveWord();
                        break;
                    case "6":
                        SearchTranslation();
                        break;
                    case "7":
                        ExportDictionary();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid action. Please select a valid option.");
                        break;
                }
            }
        }

        private static void CreateDictionary()
        {
            Console.WriteLine("Enter dictionary name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter dictionary type: ");
            string type = Console.ReadLine();

            Dictionary dictionary = new Dictionary(name, type);
            DictionaryApp.AddDictionary(dictionary);
        }

        private static void SelectDictionary()
        {
            var dictionaries = DictionaryApp.GetDictionaries();
            if (dictionaries.Count == 0)
            {
                Console.WriteLine("No dictionaries available. Please create one first.");
                return;
            }

            Console.WriteLine("Available dictionaries: ");
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].Name} ({dictionaries[i].Type})");
            }

            if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex > 0 && selectedIndex <= dictionaries.Count)
            {
                selectedDictionary = dictionaries[selectedIndex - 1];
                Console.WriteLine($"Selected dictionary: {selectedDictionary.Name}");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        private static void AddWord()
        {
            if (selectedDictionary == null)
            {
                Console.WriteLine("No dictionary selected. Please select a dictionary first.");
                return;
            }

            Console.WriteLine("Enter word: ");
            string word = Console.ReadLine();
            Console.WriteLine("Enter translation: ");
            string translation = Console.ReadLine();
            selectedDictionary.AddWord(word, translation);
        }

        private static void ReplaceWord()
        {
            if (selectedDictionary == null)
            {
                Console.WriteLine("No dictionary selected. Please select a dictionary first.");
                return;
            }

            Console.WriteLine("Enter word: ");
            string word = Console.ReadLine();
            Console.WriteLine("Enter new translation: ");
            string translation = Console.ReadLine();
            selectedDictionary.ReplaceWord(word, translation);
        }

        private static void RemoveWord()
        {
            var dictionaries = DictionaryApp.GetDictionaries();
            if (dictionaries.Count == 0)
            {
                Console.WriteLine("No dictionaries available. Please create one first.");
                return;
            }

            Console.WriteLine("Enter word: ");
            string word = Console.ReadLine();
            selectedDictionary.RemoveWord(word);
        }

        private static void SearchTranslation()
        {
            var dictionaries = DictionaryApp.GetDictionaries();
            if (dictionaries.Count == 0)
            {
                Console.WriteLine("No dictionaries available. Please create one first.");
                return;
            }

            Console.WriteLine("Available dictionaries: ");
            for (int i = 0; i < dictionaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dictionaries[i].Name} ({dictionaries[i].Type})");
            }

            if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex > 0 && selectedIndex <= dictionaries.Count)
            {
                var dictionary = dictionaries[selectedIndex - 1];
                while (true)
                {
                    Console.WriteLine("Enter word:");
                    string word = Console.ReadLine();
                    var translations = dictionary.GetTranslations(word);
                    if (translations.Count == 0)
                    {
                        Console.WriteLine("Translation not found. Do you want to: ");
                        Console.WriteLine("1. Search again");
                        Console.WriteLine("2. Return to main menu");

                        if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
                        {
                            if (choice == 2)
                            {
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid action. Please select a valid option.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Translations: ");
                        foreach (var translation in translations)
                        {
                            Console.WriteLine(translation);
                        }
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        private static void ExportDictionary()
        {
            if (selectedDictionary == null)
            {
                Console.WriteLine("No dictionary selected. Please select a dictionary first.");
                return;
            }

            Console.WriteLine("Enter file name: ");
            string fileName = Console.ReadLine();
            selectedDictionary.ExportToFile(fileName);
        }
    }
}
