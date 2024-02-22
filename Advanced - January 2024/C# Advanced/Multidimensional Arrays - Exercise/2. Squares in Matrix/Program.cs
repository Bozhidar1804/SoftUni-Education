namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ");
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int equalCells = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col+1] && matrix[row, col] == matrix[row +1, col] && matrix[row+1, col] == matrix[row+1, col+1])
                    {
                        equalCells++;
                    }
                }
            }

            if (equalCells == 0)
            {
                Console.WriteLine(0);
            } else
            {
                Console.WriteLine(equalCells);
            }
        }
    }
}