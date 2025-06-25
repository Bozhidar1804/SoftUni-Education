namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rangeNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string condition = Console.ReadLine();

            Func<int, int, List<int>> generateRange = (start, end) =>
            {
                List<int> range = new List<int>();
                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }
                return range;
            };

            Func<string, int, bool> evenOddMatch = (condition, number) =>
            {
                if (condition == "even")
                {
                    return number % 2 == 0;
                }
                else
                {
                    return number % 2 != 0;
                }
            };

            List<int> numbers = generateRange(rangeNumbers[0], rangeNumbers[1]);

            foreach (int number in numbers)
            {
                if (evenOddMatch(condition, number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}