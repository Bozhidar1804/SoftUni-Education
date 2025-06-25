using System.Runtime.InteropServices;

namespace _06TriplesofLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char first;
            char second;
            char third;

            for (int i = 0; i < n; i++)
            {
                first = (char)('a' + i);
                second = (char)('a' + i);
                third = (char)('a' + i);
                Console.WriteLine($"{first}{second}{third} ");
                for (int j = 0; j < n; j++)
                {
                    first = (char)('a' + j);
                    second = (char)('a' + j);
                    third = (char)('a' + j + 1);
                    Console.WriteLine($"{first}{second}{third} ");
                    for (int k = 0; k < n; k++)
                    {
                        first = (char)('a' + k);
                        second = (char)('a' + k);
                        third = (char)('a' + k + 2);
                        Console.WriteLine($"{first}{second}{third} ");
                    }
                }
            }
        }
    }
}