namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).Where(n => n % 2 == 0).OrderBy(n => n).ToArray();
            Console.WriteLine(String.Join(", ", input));
        }
    }
}