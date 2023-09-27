namespace _02SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int result = 0;

            while (num != 0)
            {
                int digit = num % 10;
                result += digit;
                num /= 10;
            }

            Console.WriteLine(result);

        }
    }
}