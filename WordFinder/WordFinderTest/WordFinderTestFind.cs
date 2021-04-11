using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
