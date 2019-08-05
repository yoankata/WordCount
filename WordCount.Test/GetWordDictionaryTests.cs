using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static WordCount.Util;

namespace WordCount.Test
{
    [TestClass]
    public class GetWordDictionaryTests
    {
        private const string ValidTestFile = "../../../text1.txt";
        private const string EmptyTestFile = "../../../text_empty.txt";

        [TestMethod]
        public void GetWordDictionary_ParsesValidFileCorectly()
        {
            var expected = new SortedDictionary<string, int>
            {
                { "a"       , 1 },
                { "again"   , 4 },
                { "and"     , 2 },
                { "are"     , 1 },
                { "Console" , 1 },
                { "few"     , 1 },
                { "file"    , 1 },
                { "input"   , 2 },
                { "repeated", 3 },
                { "that"    , 3 },
                { "thing"   , 2 },
                { "times"   , 1 },
                { "wee"     , 1 },
                { "with"    , 1 },
                { "word"    , 1 },
                { "words"   , 1 }
            };

            var actual = GetWordCountFromFile(ValidTestFile);

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual((ICollection)expected, (ICollection)actual);
        }


        [TestMethod]
        public void GetWordDictionary_ParsesEmptyFileCorectly()
        {
            var expected = new SortedDictionary<string, int>();

            var actual = GetWordCountFromFile(EmptyTestFile);

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual((ICollection)expected, (ICollection)actual);
        }
    }
}
