using System.Diagnostics.CodeAnalysis;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (operation == "add")
            {
                Add(a, b);
            } else if (operation == "subtract")
            {
                Subtract(a, b);
            } else if (operation == "multiply")
            {
                Multiply(a, b);
            } else if (operation == "divide")
            {
                Divide(a, b);
            }
        }

        private static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        private static void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        private static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        private static void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}