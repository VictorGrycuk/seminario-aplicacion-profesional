using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinderChallenge
{
    public class WordFinder
    {
        private readonly List<string> matrix;
        private readonly int matrixSize;
        private readonly Dictionary<string, int> wordsFound = new Dictionary<string, int>();

        private enum Orientation
        {
            NONE,
            LEFT,
            RIGHT
        }

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix == null || matrix.Count() == 0)
            {
                throw new ArgumentException("The value of the matrix cannot be empty");
            }

            if (matrix.Any(x => x.Length != matrix.First().Length))
            {
                throw new ArgumentException("All the rows of the matrix must have the same length");
            }

            if (matrix.Count() != matrix.First().Length)
            {
                throw new ArgumentException("The matrix has to be square");
            }

            this.matrix = ((List<string>)matrix).ConvertAll(x => x.ToLower());
            matrixSize = this.matrix.FirstOrDefault().Length;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            wordsFound.Clear();

            if (wordstream.Count() == 0)
            {
                throw new ArgumentException("You must pass at least one word to each");
            }
            
            if (wordstream.Count() != wordstream.Distinct().Count())
            {
                throw new ArgumentException("Don't use duplicated words");
            }

            foreach (var word in wordstream)
            {
                var timesFound = FindHorizontal(word) + FindVertical(word) + FindDiagonal(word);
                if (timesFound > 0)
                {
                    wordsFound.Add(word, timesFound);
                }
            }

            return SortWordList();
        }

        private IEnumerable<string> SortWordList()
        {
            return wordsFound.OrderByDescending(x => x.Value)
                .Take(10)
                .ToDictionary(pair => pair.Key, pair => pair.Value)
                .Keys.ToList();
        }

        private int FindHorizontal(string word)
        {
            word = word.ToLower();
            if (word.Length > matrixSize) return 0;

            int index = 0;
            int timesFound = 0;

            foreach (var row in matrix)
            {
                while (index + word.Length <= row.Length)
                {
                    var wordIndex = row.IndexOf(word, index);
                    timesFound += wordIndex != -1 ? 1 : 0;
                    
                    if (wordIndex != -1)
                    {
                        index += ++wordIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                index = 0;
            }

            return timesFound;
        }

        private int FindVertical(string word) => FindInFlattenedMatrix(word);

        private int FindDiagonal(string word)
        {
            return FindInFlattenedMatrix(word, Orientation.RIGHT) + FindInFlattenedMatrix(word, Orientation.LEFT);
        }

        private int FindInFlattenedMatrix(string word, Orientation orientation = Orientation.NONE)
        {
            word = word.ToLower();
            int timesFound = 0;
            var flattenedMatrix = string.Join(null, matrix);
            var index = flattenedMatrix.IndexOf(word[0]);
            var offset = orientation == Orientation.NONE
                ? 0
                : orientation == Orientation.LEFT
                    ? -1
                    : 1;

            while (index != -1)
            {
                var wholeWord = true;
                var initialIndex = index;
                foreach (var letter in word)
                {
                    if (index >= flattenedMatrix.Length || letter != flattenedMatrix[index])
                    {
                        wholeWord = false;
                        break;
                    }

                    index += matrixSize + offset;
                }

                timesFound += wholeWord ? 1 : 0;
                index = flattenedMatrix.IndexOf(word[0], initialIndex + 1);
            }

            return timesFound;
        }
    }
}
