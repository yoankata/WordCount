using System;
using static WordCount.Util;

namespace WordCount
{
    class Program
    {
        public static void Main()
        {
            var inputFile = GetValidInputFileFromUser();

            var wordCountDictionary = GetWordWithCountFromFile(inputFile);
            
            WriteWordCountToConsole(wordCountDictionary);
        }
    }
}
