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
        public void Should_Find_Word_In_Row()
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
    }
}
