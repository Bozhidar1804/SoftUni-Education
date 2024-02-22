namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine($"Sir {n}");

            Array.ForEach(input, print);
        }
    }
}