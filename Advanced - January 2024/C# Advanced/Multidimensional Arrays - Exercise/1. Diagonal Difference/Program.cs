namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int sumLeftToRight = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == col)
                    {
                        sumLeftToRight += matrix[row, col];
                    }
                }
            }

            int sumRightToLeft = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    if (col == n - 1 - row)
                    {
                        sumRightToLeft += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumLeftToRight - sumRightToLeft));
        }
    }
}