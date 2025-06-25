namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = int.Parse(Console.ReadLine());
            double secondNum = int.Parse(Console.ReadLine());

            double result = Division(firstNum, secondNum);
            Console.WriteLine($"{result:F2}");

        }

        private static double Division(double firstNum, double secondNum)
        {
            return Factorial(firstNum) / Factorial(secondNum);
        }

        private static double Factorial(double num)
        {
            double factorial = 1;
            for (double i = 1; i <= num; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
    }
}