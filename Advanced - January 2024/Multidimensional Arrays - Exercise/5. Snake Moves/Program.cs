namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            string snake = Console.ReadLine();
            int snakeCounter = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[snakeCounter].ToString();
                        snakeCounter = GetSnakeValue(snake, snakeCounter);
                    }
                } else if (row % 2 != 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeCounter].ToString();
                        snakeCounter = GetSnakeValue(snake, snakeCounter);
                    }
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

        static int GetSnakeValue(string snake, int snakeCounter)
        {
            snakeCounter++;
            if (snakeCounter >= snake.Length)
            {
                snakeCounter = 0;
            }
            return snakeCounter;
        }
    }
}