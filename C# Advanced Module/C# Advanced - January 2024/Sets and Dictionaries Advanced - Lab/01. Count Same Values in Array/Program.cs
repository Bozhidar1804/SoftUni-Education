namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            Dictionary<double, int> times = new Dictionary<double, int>();

            foreach (double number in input)
            {
                if (!times.ContainsKey(number))
                {
                    times[number] = 0;
                }
                times[number]++;
            }

            foreach (var number in times)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }

        }
    }
}