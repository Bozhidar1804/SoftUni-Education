namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Action<string> print = n => Console.WriteLine(n);

            Array.ForEach(input, print);
        }
    }
}