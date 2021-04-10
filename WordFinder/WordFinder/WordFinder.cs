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
                FindHorizontal(word);
            }

            throw new NotImplementedException();
        }
    }
}
