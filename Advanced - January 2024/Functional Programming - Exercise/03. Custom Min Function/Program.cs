namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> input = Console.ReadLine().Split(" ").Select(int.Parse).ToHashSet();

            Func<HashSet<int>, int> PrintMin = input =>
            {
                int min = int.MaxValue;

                foreach (int n in input)
                {
                    if (n < min)
                    {
                        min = n;
                    }
                }

                return min;
            };

            Console.WriteLine(PrintMin(input));
        }
    }
}