namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = Power(number, power);
            Console.WriteLine(result);
        }

        private static double Power(double num, double pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result = result * num;
            }
            return result;
        }
    }
}