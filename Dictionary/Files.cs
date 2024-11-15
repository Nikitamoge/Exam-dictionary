using System;
using System.IO;
using System.Linq;

namespace DictionaryApp
{
    static class FileManager
    {
        public static void ExportToFile(Dictionary dictionary, string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                var words = dictionary.GetAllWords();
                foreach (var word in words)
                {
                    var translations = dictionary.GetTranslations(word);
                    writer.WriteLine($"{word}: {string.Join(", ", translations)}");
                }
            }
            Console.WriteLine($"Dictionary exported to file: {filePath}");
        }
    }
}
