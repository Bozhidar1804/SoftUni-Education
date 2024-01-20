namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            HashSet<int> firstSet = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            firstSet.IntersectWith(secondSet);
            foreach (int number in firstSet)
            {
                Console.Write($"{number} ");
            }
            /* Dictionary<int, int> numbers = new Dictionary<int, int>();
            int lines = n + m;
            for (int i = 0; i < lines; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 1);
                } else if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
            }

            foreach (var number in numbers)
            {
                if (number.Value > 1)
                {
                    Console.Write(number.Key + " ");
                }
            } */
        }
    }
}