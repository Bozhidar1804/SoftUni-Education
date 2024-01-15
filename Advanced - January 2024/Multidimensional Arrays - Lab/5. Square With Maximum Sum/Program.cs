namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSum = 0;
            int[] maxRow1 = new int[2];
            int[] maxRow2 = new int[2];
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col+1] + matrix[row+1, col] + matrix[row+1, col+1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow1[0] = matrix[row, col];
                        maxRow1[1] = matrix[row, col + 1];
                        maxRow2[0] = matrix[row + 1, col];
                        maxRow2[1] = matrix[row + 1, col + 1];
                    }
                }
            }

            foreach(int row in maxRow1)
            {
                Console.Write($"{row} ");
            }
            Console.WriteLine();
            foreach(int row in maxRow2)
            {
                Console.Write($"{row} ");
            }
            Console.WriteLine();
            Console.WriteLine($"{maxSum}");
        }
    }
}