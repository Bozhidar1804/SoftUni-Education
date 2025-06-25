namespace _09SumofOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            int printedNumbers = 0;

            for (int i = 1; printedNumbers < n; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    printedNumbers++;
                    sum += i;
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}