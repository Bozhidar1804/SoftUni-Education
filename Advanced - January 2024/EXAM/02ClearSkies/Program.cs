namespace _02ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];
            int jetRow = 0;
            int jetCol = 0;
            int enemies = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'J')
                    {
                        jetRow = row;
                        jetCol = col;
                    } else if (matrix[row, col] == 'E')
                    {
                        enemies++;
                    }
                }
            }

            int armor = 300;
            string command = "";
            while (enemies > 0 && armor > 0)
            {
                command = Console.ReadLine();
                matrix[jetRow, jetCol] = '-';

                if (command == "up")
                {
                    jetRow--;
                } else if (command == "down")
                {
                    jetRow++;
                } else if (command == "left")
                {
                    jetCol--;
                } else if (command == "right")
                {
                    jetCol++;
                }


                if (matrix[jetRow, jetCol] == '-')
                {
                    matrix[jetRow, jetCol] = 'J';
                    continue;
                } else if (matrix[jetRow, jetCol] == 'E')
                {
                    matrix[jetRow, jetCol] = '-';
                    enemies--;
                    if (enemies == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        matrix[jetRow, jetCol] = 'J';
                        break;
                    } else if (enemies > 0)
                    {
                        armor -= 100;
                        if (armor <= 0)
                        {
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
                            matrix[jetRow, jetCol] = 'J';
                            break;
                        }
                    }
                } else if (matrix[jetRow, jetCol] == 'R')
                {
                    armor = 300;
                    matrix[jetRow, jetCol] = 'J';
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}