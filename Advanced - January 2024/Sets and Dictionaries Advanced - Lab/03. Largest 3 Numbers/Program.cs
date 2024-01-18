namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] sorted = input.OrderByDescending(n => n).ToArray();

            if (sorted.Length < 3)
            {
                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            } else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
        }
    }
}