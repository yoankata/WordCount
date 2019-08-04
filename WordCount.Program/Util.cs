using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public static class Util
    {
        public static void WriteWordCountToConsole(IDictionary<string, int> dictionary)
        {
            var maxLength = dictionary.Keys.OrderByDescending(k => k.Length).First().Length + 3;
            var formatStr = "{0, -" + maxLength + "} {1, 5}";

            Console.WriteLine("The word count in alphabetical order is:");
            foreach (var word in dictionary)
            {
                Console.WriteLine(String.Format(formatStr, word.Key, word.Value));
            }
        }

        public static IDictionary<string, int> GetWordWithCountFromFile(string inputFile)
        {
            char separator = ' ';
            var wordCountDictionary = new SortedDictionary<string, int>();
            var nonWordCharRegex = new Regex("[^a-zA-Z0-9]");

            // process input file line by line ot avoid memory issues with huge files
            using (var sr = new StreamReader(inputFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // replace non word characters and split input line into words
                    var text = nonWordCharRegex.Replace(line, separator.ToString());
                    var words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        // add to count if entry exists or add entry
                        if (wordCountDictionary.ContainsKey(word))
                        {
                            wordCountDictionary[word]++;
                        }
                        else
                        {
                            wordCountDictionary.Add(word, 1);
                        }
                    }
                }
            }

            return wordCountDictionary;
        }

        public static string GetValidInputFileFromUser()
        {
            do
            {
                Console.WriteLine("Enter the name of the file to process followed by Enter or Esc to exit:");
                var inputFile = Console.ReadLine();
                try
                {
                    var stream = new StreamReader(inputFile);
                    return inputFile;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Environment.Exit(0);
            return null;
        }
    }
}
