using System.Diagnostics.CodeAnalysis;

namespace _11Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double currentTotal = 0;
            double sum = 0;
            for (int i = 1; i <= orders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int daysInMonth = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                currentTotal = (daysInMonth * capsulesCount) * pricePerCapsule;
                sum += currentTotal;
                Console.WriteLine($"The price for the coffee is: ${currentTotal:F2}");
            }

            Console.WriteLine($"Total: ${sum:F2}");
        }
    }
}