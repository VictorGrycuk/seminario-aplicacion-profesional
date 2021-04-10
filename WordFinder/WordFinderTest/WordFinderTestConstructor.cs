using System;
using System.Collections.Generic;
using WordFinderChallenge;
using Xunit;

namespace WordFinderTest
{
    public class WordFinderTestConstructor
    {
        [Fact]
        public void Constructor_Should_Not_Accept_Null_List()
        {
            var exception = Assert.Throws<ArgumentException>(() => new WordFinder(null));
            Assert.Equal("The value of the matrix cannot be empty", exception.Message);
        }

        [Fact]
        public void Constructor_Should_Not_Accept_Empty_List()
        {
            var emptyMatrix = new List<string>();

            var exception = Assert.Throws<ArgumentException>(() => new WordFinder(emptyMatrix));
            Assert.Equal("The value of the matrix cannot be empty", exception.Message);
        }

        [Fact]
        public void Constructor_Should_Only_Accept_Strings_of_Equal_Length()
        {
            var unevenMatrix = new List<string>
            {
                "abc",
                "def",
                "gh",
            };

            var exception = Assert.Throws<ArgumentException>(() => new WordFinder(unevenMatrix));
            Assert.Equal("All the rows of the matrix must have the same length", exception.Message);
        }

        [Fact]
        public void Constructor_Should_Only_Not_Accept_Non_Square_Matrix()
        {
            var unevenMatrix1 = new List<string>
            {
                "abc",
                "def",
                "ghi",
                "jkl",
            };

            var unevenMatrix2 = new List<string>
            {
                "abcd",
                "efgh",
                "ijkl",
            };

            var exception1 = Assert.Throws<ArgumentException>(() => new WordFinder(unevenMatrix1));
            var exception2 = Assert.Throws<ArgumentException>(() => new WordFinder(unevenMatrix2));
            Assert.Equal("The matrix has to be square", exception1.Message);
            Assert.Equal("The matrix has to be square", exception2.Message);
        }

        [Fact]
        public void Constructor_Should_Initialize()
        {
            var matrix = new List<string>
            {
                "abc",
                "def",
                "ghi"
            };

            new WordFinder(matrix);
        }
    }
}
