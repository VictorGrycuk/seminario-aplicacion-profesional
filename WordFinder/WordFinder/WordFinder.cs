using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinderChallenge
{
    public class WordFinder
    {
        private readonly List<string> matrix;
        private readonly int matrixSize;
        private readonly Dictionary<string, int> wordsFound = new Dictionary<string, int>();

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

            this.matrix = (List<string>)matrix;
            matrixSize = this.matrix.FirstOrDefault().Length;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            if (wordstream.Count() != wordstream.Distinct().Count())
            {
                throw new ArgumentException("Don't use duplicated words");
            }

            foreach (var word in wordstream)
            {
                var timesFound = FindHorizontal(word);
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
            }

            return timesFound;
        }
    }
}
