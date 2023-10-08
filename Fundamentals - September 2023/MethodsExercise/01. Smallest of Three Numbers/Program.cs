namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = SmallestNumber(firstNum, secondNum, thirdNum);
            Console.WriteLine(result);
        }

        private static int SmallestNumber(int a, int b, int c)
        {
            int result = 0;
            if (a < b && a < c)
            {
                result = a;
            }
            else if (b < a && b < c)
            {
                result = b;
            }
            else if (c < a && c < b)
            {
                result = c;
            }
            return result;
        }
    }
}