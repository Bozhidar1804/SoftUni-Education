using System.Xml;

namespace _4._Matrix_Shuffling
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
                string[] currentRow = Console.ReadLine().Split(" ").ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArr = command.Split(" ");
                if (commandArr[0] != "swap")
                {
                    Console.WriteLine($"Invalid input!");
                    continue;
                }
                int row1 = int.Parse(commandArr[1]);
                int col1 = int.Parse(commandArr[2]);
                int row2 = int.Parse(commandArr[3]);
                int col2 = int.Parse(commandArr[4]);
                if (commandArr.Length == 5 && commandArr[0] == "swap" && row1 <= rows && row2 <= rows && col1 <= cols && col2 <= cols)
                {
                    string value1 = matrix[row1, col1];
                    string value2 = matrix[row2, col2];
                    matrix[row1, col1] = value2;
                    matrix[row2, col2] = value1;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                } else
                {
                    Console.WriteLine($"Invalid input!");
                }
            }
        }
    }
}