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
            // El constructor de WordFinder tiene algunas validaciones para poder hacer las
            // búsquedas mas facil, además de evitar errores comunes.

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

            // Se normaliza las mayusculas en minusculas usando linq,
            // de nuevo para hacer las busquedas mas fácil
            this.matrix = ((List<string>)matrix).ConvertAll(x => x.ToLower());
            
            // El tamaño de la matriz me va a servir más adelante para usarlo como offset
            // en las busquedas tanto verticales como diagonales
            matrixSize = this.matrix.FirstOrDefault().Length;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            // Basicamente por cada palabra buscada se utilizan 3 estrategias diferentes,
            // luego se suman los resultados de cada busqueda, y si hubo alguna coincidencia,
            // se agrega a un diccionario junto con el numero de coincidencias
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
            // Este metodo se usa para ordenar de mayor a menor las palabras encontrads,
            // y limitarlas a las primeras 10
            return wordsFound.OrderByDescending(x => x.Value)
                .Take(10)
                .ToDictionary(pair => pair.Key, pair => pair.Value)
                .Keys.ToList();
        }

        private int FindHorizontal(string word)
        {
            // La busqueda horizontal consiste en buscar la palabra buscada en cada fila,
            // si hay coincidencia se suma 1 al contador, y se vuelve a buscar en la misma
            // fila sumando 1 al indice de busqueda en caso de que la misma palabra
            // se encuentre varias veces en la misma fila

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
            // Tanto la busqueda vertical como horizontal utilizan la misma estrategia,
            // solo difieren en el offset del indice en cual comparar los caracteres.
            // La idea es tratar a la matriz como una sola cadena de caracteres. En la
            // búsqueda vertical, los caracteres de la palabra se van a encontrar cada x
            // posiciones, donde x es el ancho de la matriz. La busqueda diagonal es identica
            // salvo que la posición va a estar un caracter menos o un caracter mas que en la
            // búsqueda vertical.

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
