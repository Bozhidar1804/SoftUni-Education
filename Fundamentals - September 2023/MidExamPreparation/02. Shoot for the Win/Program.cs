using System.Data;

namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = "";
            int shotTargets = 0;

            while (command != "End")
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                int index = int.Parse(command);

                if (index < 0 || index >= sequence.Count)
                {
                    continue;
                }

                int currentNumber = sequence[index];
                sequence[index] = -1;

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] == -1)
                    {
                        continue;
                    }

                    if (sequence[i] > currentNumber)
                    {
                        sequence[i] -= currentNumber;
                    } else if (sequence[i] <= currentNumber)
                    {
                        sequence[i] += currentNumber;
                    }
                }
                shotTargets++;
            }

            string result = "";
            foreach (int i in sequence)
            {
                result += i + " ";
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> {result}");
        }
    }
}