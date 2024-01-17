using System.Data.Common;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] currentRow = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
                jaggedArray[row] = currentRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }

                } else if (jaggedArray[row].Length != jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            string command = "";

            while (true)
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] commandArr = command.Split(" ");
                string action = commandArr[0];
                int row = int.Parse(commandArr[1]);
                int col = int.Parse(commandArr[2]);
                int value = int.Parse(commandArr[3]);

                if (row >= 0 && row <= rows && col >= 0 && col <= jaggedArray[row].Length)
                {
                    if (action == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (action == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                } else
                {
                    continue;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                int cols = jaggedArray[row].Length;
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}