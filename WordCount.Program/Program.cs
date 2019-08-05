using static WordCount.Util;

namespace WordCount
{
    class Program
    {
        public static void Main()
        {
            var inputFile = GetValidInputFileFromUser();

            var wordCountDictionary = GetWordCountFromFile(inputFile);
            
            WriteWordCountToConsole(wordCountDictionary);
        }
    }
}
