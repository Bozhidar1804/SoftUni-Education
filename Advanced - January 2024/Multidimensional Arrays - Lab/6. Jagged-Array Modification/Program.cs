using System.Data.Common;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            }

            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArr = command.Split(" ");
                string action = commandArr[0];
                int row = int.Parse(commandArr[1]);
                int col = int.Parse(commandArr[2]);
                int value = int.Parse(commandArr[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (action == "Add")
                {
                    jaggedArray[row][col] += value;
                } else if (action == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}