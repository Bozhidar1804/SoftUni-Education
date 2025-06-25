namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = "";

            while (command != "End")
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    continue;
                }

                if (command.Contains("Add"))
                {
                    string[] splittedCommand = command.Split();
                    int number = int.Parse(splittedCommand[1]);
                    numbers.Add(number);
                } 
                else if (command.Contains("Insert"))
                {
                    string[] splittedCommand = command.Split();
                    int number = int.Parse(splittedCommand[1]);
                    int position = int.Parse(splittedCommand[2]);
                    if (!IsValid(position, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(position, number);
                } 
                else if (command.Contains("Remove"))
                {
                    string[] splittedCommand = command.Split();
                    int index = int.Parse(splittedCommand[1]);
                    if (!IsValid(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(index);
                } 
                else if (command.Contains("Shift left"))
                {
                    string[] splittedCommand = command.Split();
                    int times = int.Parse(splittedCommand[2]);

                    for (int i = 0; i < times; i++)
                    {
                        int firstNumber = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(firstNumber);
                    }

                } 
                else if (command.Contains("Shift right"))
                {
                    string[] splittedCommand = command.Split();
                    int times = int.Parse(splittedCommand[2]);

                    for (int i = 0; i < times; i++)
                    {
                        int lastNumber = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, lastNumber);
                    }
                }
            }
            foreach (int n in numbers)
            {
                Console.Write($"{n} ");
            }
        }

        private static bool IsValid(int index, int maxCapacity)
        {
            return index >= 0 && index < maxCapacity;
        }
    }
}