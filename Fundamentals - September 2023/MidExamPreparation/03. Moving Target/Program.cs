namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                if (command.Contains("Shoot"))
                {
                    string[] commandArr = command.Split(' ');
                    int index = int.Parse(commandArr[1]);
                    int power = int.Parse(commandArr[2]);

                    sequence[index] -= power;
                    if (sequence[index] <= 0)
                    {
                        sequence.RemoveAt(index);
                    }
                } else if (command.Contains("Add"))
                {
                    string[] commandArr = command.Split(' ');
                    int index = int.Parse(commandArr[1]);
                    int value = int.Parse(commandArr[2]);

                    if (index < sequence.Count && index >= 0)
                    {
                        sequence.Insert(index, value);
                    } else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                } else if (command.Contains("Strike"))
                {
                    string[] commandArr = command.Split(' ');
                    int index = int.Parse(commandArr[1]);
                    int radius = int.Parse(commandArr[2]);

                    if ((index + radius) < sequence.Count && (index - radius) >= 0)
                    {
                        for (int i = 1; i <= radius; i++)
                        {
                            sequence.RemoveAt(index + i);
                            sequence.RemoveAt(index - i);
                            index--;
                        }
                        sequence.RemoveAt(index);
                    } else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }
            int print = 0;

            Console.WriteLine(string.Join("|", sequence));

            /* foreach(int i in sequence)
            {
                if (print < sequence.Count - 1)
                {
                    Console.Write($"{i}|");
                    print++;
                } else if (print == sequence.Count - 1)
                {
                    Console.WriteLine($"{i}");
                }
                
            } */
        }
    }
}