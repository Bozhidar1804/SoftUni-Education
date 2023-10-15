using System.Data;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            Train(wagons, maxCapacity);
        }

        private static void Train(List<int> wagons, int maxCapacity)
        {
            string command = "";

            while (command != "end")
            {
                command = Console.ReadLine();
                if (command == "end")
                {
                    continue;
                }
                if (command.Contains("Add"))
                {
                    string[] splitCommand = command.Split();
                    int newWagon = int.Parse(splitCommand[1]);
                    wagons.Add(newWagon);
                }
                else
                {
                    int passengers = int.Parse(command);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
            }

            foreach (int i in wagons)
            {
                Console.Write($"{i} ");
            }
        }
    }
}