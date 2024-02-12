namespace _02._Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows, cols];
            int mouseRow = 0;
            int mouseCol = 0;
            int cheeseCounter = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    } else if (matrix[row, col] == 'C')
                    {
                        cheeseCounter++;
                    }
                }
            }

            string command = "";
            while ((command = Console.ReadLine()) != "danger")
            {
                if (command == "up")
                {
                    mouseRow--;
                    if (mouseRow < 0)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                } else if (command == "down")
                {
                    mouseRow++;
                    if (mouseRow > rows - 1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                } else if (command == "right")
                {
                    mouseCol++;
                    if (mouseCol > cols - 1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                } else if (command == "left")
                {
                    mouseCol--;
                    if (mouseCol < 0)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                }

                if (matrix[mouseRow, mouseCol] == 'C')
                {
                    cheeseCounter--;
                    matrix[mouseRow, mouseCol] = 'M';
                    matrix = FixMatrix(matrix, command, mouseRow, mouseCol);
                    if (cheeseCounter == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                } else if (matrix[mouseRow, mouseCol] == 'T')
                {
                    matrix[mouseRow, mouseCol] = 'M';
                    matrix = FixMatrix(matrix, command, mouseRow, mouseCol);
                    Console.WriteLine("Mouse is trapped!");
                    break;
                } else if (matrix[mouseRow, mouseCol] == '@')
                {
                    switch (command)
                    {
                        case "up":
                            mouseRow++;
                            break;
                        case "down":
                            mouseRow--;
                            break;
                        case "right":
                            mouseCol--;
                            break;
                        case "left":
                            mouseCol++;
                            break;
                    }
                    continue;
                } else if (matrix[mouseRow, mouseCol] == '*')
                {
                    matrix[mouseRow, mouseCol] = 'M';
                    matrix = FixMatrix(matrix, command, mouseRow, mouseCol);
                }
            }

            if (command == "danger" && cheeseCounter > 0)
            {
                Console.WriteLine("Mouse will come back later!");
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
        public static char[,] FixMatrix(char[,] matrix, string command, int row, int col)
        {
            if (command == "up")
            {
                row++;
                matrix[row, col] = '*';
            }
            else if (command == "down")
            {
                row--;
                matrix[row, col] = '*';
            }
            else if (command == "right")
            {
                col--;
                matrix[row, col] = '*';
            }
            else if (command == "left")
            {
                col++;
                matrix[row, col] = '*';
            }

            return matrix;
        }
    }
}