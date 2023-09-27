namespace _04ReverseArrayofStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] items = input.Split(" ").ToArray();

            for (int i = items.Length - 1; i >= 0; i--)
            {
                Console.Write($"{items[i]} ");
            }

        }
    }
}