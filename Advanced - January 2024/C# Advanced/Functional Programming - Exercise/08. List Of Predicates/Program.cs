using System.Globalization;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, List<int>, List<int>> FindNumbers = (n, dividers) =>
            {
                List<int> divisibleNumbers = new List<int>();

                for (int i = 1; i <= n; i++)
                {
                    bool isDivisible = false;

                    foreach (int divider in dividers)
                    {
                        Predicate<int> match = i => i % divider == 0;

                        if (match(i))
                        {
                            isDivisible = true;
                        } else
                        {
                            isDivisible = false;
                        }
                    }

                    if (isDivisible)
                    {
                        divisibleNumbers.Add(i);
                    }
                }

                return divisibleNumbers;
            };

            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            List<int> result = FindNumbers(n, dividers);
            foreach (int num in result)
            {
                Console.Write($"{num} ");
            }
        }
    }
}