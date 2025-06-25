using System.Xml;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool symbolFound = false;
            int rowFound = 0;
            int colFound = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        symbolFound = true;
                        rowFound = row;
                        colFound = col;
                    }
                }
                if (symbolFound) break;
            }

            if (symbolFound)
            {
                Console.WriteLine($"({rowFound}, {colFound})");
            } else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}