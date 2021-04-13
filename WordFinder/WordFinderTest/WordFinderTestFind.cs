using System;
using System.Collections.Generic;
using System.Linq;
using WordFinderChallenge;
using Xunit;

namespace WordFinderTest
{
    public class WordFinderTestFind
    {
        [Fact]
        public void Should_Not_Allow_Empty_Strings_To_Search()
        {
            var words = new List<string>();
            var matrix = new List<string>
            {
                "abc",
                "def",
                "ghi",
            };

            var exception = Assert.Throws<ArgumentException>(() => new WordFinder(matrix).Find(words));
            Assert.Equal("You must pass at least one word to earch", exception.Message);
        }

        [Fact]
        public void Should_Find_Words_In_Rows()
        {
            var words = new List<string> { "cat", "eye", "dad", "dog" };
            var matrix = new List<string>
            {
                "eyexx",
                "xcatx",
                "xxdad",
                "xxxxy",
                "xxxxz"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("cat", wordsFound.ToList()[0]);
            Assert.Equal("eye", wordsFound.ToList()[1]);
            Assert.Equal("dad", wordsFound.ToList()[2]);
            Assert.Equal(3, wordsFound.Count());
        }

        [Fact]
        public void Should_Find_Words_In_Columns()
        {
            var words = new List<string> { "cat", "eye", "dad", "dog" };
            var matrix = new List<string>
            {
                "cxxxx",
                "aexxx",
                "tydxx",
                "xeaxx",
                "xxdxx"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("cat", wordsFound.ToList()[0]);
            Assert.Equal("eye", wordsFound.ToList()[1]);
            Assert.Equal("dad", wordsFound.ToList()[2]);
            Assert.Equal(3, wordsFound.Count());
        }

        [Fact]
        public void Should_Find_Words_In_Diagonal()
        {
            var words = new List<string> { "cat", "dad" };
            var matrix = new List<string>
            {
                "cxd",
                "xax",
                "dxt"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("cat", wordsFound.ToList()[0]);
            Assert.Equal("dad", wordsFound.ToList()[1]);
        }

        [Fact]
        public void Should_Find_Overlapped_Words_In_Rows()
        {
            var words = new List<string> { "dad", "dog" };
            var matrix = new List<string>
            {
                "dadog",
                "xcatx",
                "xxdad",
                "xxxxy",
                "xxxxz"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("dad", wordsFound.ToList()[0]);
            Assert.Equal(2, wordsFound.Count());
        }

        [Fact]
        public void Should_Find_Overlapped_Words_In_Columns()
        {
            var words = new List<string> { "dad", "dog" };
            var matrix = new List<string>
            {
                "dxxxx",
                "axxxx",
                "dxxxx",
                "oxxxx",
                "gxxxx"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("dad", wordsFound.ToList()[0]);
            Assert.Equal(2, wordsFound.Count());
        }

        [Fact]
        public void Should_Return_Words_Ordered_By_Occurrence()
        {
            var words = new List<string> { "cat", "eye", "dog" };
            var matrix = new List<string>
            {
                "dogxx",
                "xcatx",
                "xxdog",
                "eyeye",
                "xeyex"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("eye", wordsFound.ToList()[0]);
            Assert.Equal("dog", wordsFound.ToList()[1]);
            Assert.Equal("cat", wordsFound.ToList()[2]);
        }

        [Fact]
        public void Should_Return_Empty_String_List_When_No_Word_Is_Found()
        {
            var words = new List<string> { "cold" };
            var matrix = new List<string>
            {
                "dogxx",
                "xcatx",
                "xxdog",
                "eyeye",
                "xeyex"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Empty(wordsFound);
        }

        [Fact]
        public void Should_Find_Words_In_64x64_Matrix()
        {
            var words = new List<string> { "eye", "eve" };
            var matrix = new List<string>
            {
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxe",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxv",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxeye"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("eye", wordsFound.ToList()[0]);
            Assert.Equal("eve", wordsFound.ToList()[1]);
        }

        [Fact]
        public void Should_Limit_To_The_10_Topmost_Found_Words()
        {
            var words = new List<string>
            {
                "second",
                "fourth",
                "first",
                "sixth",
                "fifth",
                "third",
                "elevent",
                "eighth",
                "ninth",
                "seventh",
                "tenth",
            };
            var matrix = new List<string>
            {
                "firstxxxxxxxfifthxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxeleventhxxxxxxxxxx",
                "ixxxxxxxxxxxxxfifthxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "rxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "sxxxxxxxxxxxxxxxxxfxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "tfirstxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxfxxxxxxxxxxxxfxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxixxxxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxrxxxxxxxxxxxxhfifthxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxfxxsxxxxxxxxxxxxxxxxxfifthxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxixxtfirstxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxrxxxxxxxxxxxxxxxxxxxxfifthxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxsxxfirstfxxxxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxtxxxxxxxixxxxxxxxsixthsixthxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxrxxxxxxxxxxxxxxxxxsxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxsxxxxxxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxfirstxxxxxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxfxxxxxxxxxxxxxhsixthsxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxrxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxfirstsecondxxxxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxtxxxxxsecondxxxxxxxxhsixthxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxexxxxxxxxxxxxxxseventhsxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxcxxxxxxxxxxxxxxxxxxxxxexxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxoxxxxxxxxxxxxxxxxxxxxxvxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxnsecondsxxxxxxxxxxxxxxexxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxdxxxxxxexxsxxxxxxxxxxxnxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxcxxexxxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxoxxcxxxxxxxxxxxhxxxsxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxnxxoxxxxxxxxxxxxseventhxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxsdxxnxxxxxxxxxxxxxxxvxxxxxxxxxxxexxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxsecondxxxxxxxxxxxxxxxexxxxxxxxxxxixxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxcxxxxxxxxxxxxxxxxxxxnxxxxxxxxxexgxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxoxxxxxxxxxxxxxxxxxxxtxxxxxxxxxixhxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxnxxxxxxxxxxxxxxxxxxxhseventhxxgxtxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxdxxxxxxxxxtxxxxxxxxxxxxxxxxeighthxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxsecondxxxxxxxhxxxxxxxxxxxxxxxxxxxtxxeighth",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxsecondthirdxxxxxxxxxxxxxxxxxhxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxthirdxxxxxxxxxxxxxxxxxxnxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxthirdxxxxxxxxxxxxxxxxxxxixxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxhxxxxxxxxxxxxxxxxxxxxxxxnxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxtxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxrxxxxxxxxxxxxxxxxxxxninthxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxdxxxxxxxxxxxxxxxxxxxxninthxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxthirdxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxtxxxxxxxxxxxxxxxxxxxxxtxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxhxxxxxxxxxxxxxxxxxxxxxexxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxnxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxrxxxxxxxxxxxxxxxxxxxxxtxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxdthirdtxxxxxxxxxxxxxxxhtenthxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxhxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxixxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxfourthxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxoxxdxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxuxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxrxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxfourthfxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxhxxoxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxuxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxrxxxxxxxfxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxtxxxxxxxoxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxhxxxxxxxuxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxfourthxxxxxxxrxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxfourthxxxxtxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxfourthxxxxxxxxxxxxxxxxx"
            };

            var wordsFound = new WordFinder(matrix).Find(words);

            Assert.Equal("first", wordsFound.ToList()[0]);
            Assert.Equal("second", wordsFound.ToList()[1]);
            Assert.Equal("third", wordsFound.ToList()[2]);
            Assert.Equal("fourth", wordsFound.ToList()[3]);
            Assert.Equal("fifth", wordsFound.ToList()[4]);
            Assert.Equal("sixth", wordsFound.ToList()[5]);
            Assert.Equal("seventh", wordsFound.ToList()[6]);
            Assert.Equal("eighth", wordsFound.ToList()[7]);
            Assert.Equal("ninth", wordsFound.ToList()[8]);
            Assert.Equal("tenth", wordsFound.ToList()[9]);
            Assert.Equal(10, wordsFound.Count());
        }
    }
}
