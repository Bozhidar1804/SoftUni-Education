using System.Data;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                int number = command[0];

                if (number == 1)
                {
                    int x = command[1];
                    stack.Push(x);
                } else if (number == 2)
                {
                    stack.Pop();
                } else if (number == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Max());
                } else if (number == 4)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Min());
                }
            }

            while (stack.Count != 0)
            {
                if (stack.Count == 1)
                {
                    Console.Write($"{stack.Pop()}");
                    break;
                }
                Console.Write($"{stack.Pop()}, ");
            }
        }
    }
}