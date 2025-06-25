using System;
using System.Text;

namespace _05PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int exceptionsCount = 0;

            int[] array = input;
            while (exceptionsCount < 3)
            {
                string[] tokens = Console.ReadLine().Split(" ");

                try
                {
                    if (tokens[0] == "Replace")
                    {
                        int index = int.Parse(tokens[1]);
                        int element = int.Parse(tokens[2]);
                        array[index] = element;
                    }
                    else if (tokens[0] == "Print")
                    {
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);

                        StringBuilder sb = new StringBuilder();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sb.Append(array[i] + ", ");
                        }
                        Console.WriteLine(sb.ToString().Remove(sb.Length - 2));
                    }
                    else if (tokens[0] == "Show")
                    {
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(array[index]);
                    }
                } catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                } catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write($"{array[i]}");
                } else
                {
                    Console.Write($"{array[i]}, ");
                }
            }
        }
    }
}