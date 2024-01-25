namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToArray();

            foreach (double number in numbers)
            {
                Console.WriteLine($"{number:F2}");
            }


        }
    }
}