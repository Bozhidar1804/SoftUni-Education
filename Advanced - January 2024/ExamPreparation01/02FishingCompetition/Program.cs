namespace _02FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;
            bool whirlpoolFound = false;
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                char[] charInput = input.ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = charInput[col];
                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row; playerCol = col;
                    }
                }
            }

            int sum = 0;
            string command = "";
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                matrix[playerRow, playerCol] = '-';
                if (command == "up")
                {
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = n - 1;
                    }
                } else if (command == "down")
                {
                    playerRow++;
                    if (playerRow > n - 1)
                    {
                        playerRow = 0;
                    }
                } else if (command == "left")
                {
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = n - 1;
                    }
                } else if (command == "right")
                {
                    playerCol++;
                    if (playerCol > n - 1)
                    {
                        playerCol = 0;
                    }
                }

                if (matrix[playerRow, playerCol] != '-')
                {
                    if (matrix[playerRow, playerCol] == 'W')
                    {
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{playerRow},{playerCol}]");
                        whirlpoolFound = true;
                        break;
                    } else
                    {
                        int fishPassage = int.Parse(matrix[playerRow, playerCol].ToString());
                        sum += fishPassage;
                        matrix[playerRow, playerCol] = 'S';
                    }
                } else if (matrix[playerRow, playerCol] == '-')
                {
                    matrix[playerRow, playerCol] = 'S';
                }
            }

            if (sum >= 20 && !whirlpoolFound)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
                Console.WriteLine($"Amount of fish caught: {sum} tons.");
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            } else if (sum < 20 && !whirlpoolFound)
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - sum} tons of fish more.");
                if (sum > 0)
                {
                    Console.WriteLine($"Amount of fish caught: {sum} tons.");
                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}