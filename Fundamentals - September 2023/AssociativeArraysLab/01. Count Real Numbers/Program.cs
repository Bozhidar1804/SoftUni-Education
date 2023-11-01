namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            foreach (int number in numbers)
            {
                if(!counts.ContainsKey(number))
                {
                    counts[number] = 1;
                } else
                {
                    counts[number]++;
                }
            }

            foreach (KeyValuePair<double, int> kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}