using System;
using System.Linq.Expressions;
using System.Text;

namespace _02EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int[] elements = new int[10];

            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    elements[i] = ReadNumber(start, end);

                    if (elements[i] <= start || elements[i] >= end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException ae)
                {
                    Console.WriteLine($"Your number is not in range {start} - {end}!");
                    i--;
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid Number!");
                    i--;
                    continue;
                }
                start = elements[i];
            }

            StringBuilder sb = new StringBuilder();
            foreach (int num in elements)
            {
                sb.Append($"{num}, ");
            }
            Console.WriteLine(sb.ToString().Remove(sb.Length - 2));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num = 0;

            while (!int.TryParse(input, out num))
            {
                throw new FormatException();
            }

            return num;
        }
    }
}