namespace _04SumofChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int sum = 0;

            while (counter <= n)
            {
                char currentInput = char.Parse(Console.ReadLine());
                sum += (int)currentInput;
                counter++;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}