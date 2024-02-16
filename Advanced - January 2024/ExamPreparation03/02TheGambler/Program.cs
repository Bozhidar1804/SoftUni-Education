namespace _02TheGambler
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
            int money = 100;
            
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'G')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool leftBoundaries = false;
            bool lostMoney = false;
            bool jackpotWon = false;
            bool programStopped = false;
            string command = "";
            while (true)
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    programStopped = true;
                    break;
                }

                matrix[playerRow, playerCol] = '-';
                if (command == "up")
                {
                    playerRow--;
                } else if (command == "down")
                {
                    playerRow++;
                } else if (command == "left")
                {
                    playerCol--;
                } else if (command == "right")
                {
                    playerCol++;
                }

                if (playerRow < 0 || playerRow > rows - 1 || playerCol < 0 || playerCol > cols)
                {
                    leftBoundaries = true;
                    break;
                }

                if (matrix[playerRow, playerCol] == '-')
                {
                    matrix[playerRow, playerCol] = 'G';
                    continue;
                } else if (matrix[playerRow, playerCol] == 'W')
                {
                    money += 100;
                    matrix[playerRow, playerCol] = 'G';
                } else if (matrix[playerRow, playerCol] == 'P')
                {
                    money -= 200;
                    matrix[playerRow, playerCol] = 'G';
                    if (money <= 0)
                    {
                        lostMoney = true;
                        break;
                    }
                } else if (matrix[playerRow, playerCol] == 'J')
                {
                    money += 100000;
                    jackpotWon = true;
                    matrix[playerRow, playerCol] = 'G';
                    break;
                }
            }

            if (leftBoundaries || lostMoney)
            {
                Console.WriteLine("Game over! You lost everything!");
            } else if (jackpotWon)
            {
                Console.WriteLine("You win the Jackpot!");
                Console.WriteLine($"End of the game. Total amount: {money}$");
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write($"{matrix[row, col]}");
                    }
                    Console.WriteLine();
                }
            } else if (programStopped)
            {
                Console.WriteLine($"End of the game. Total amount: {money}$");
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
}