namespace _07WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 1;

            while (counter <= n)
            {
                int currentInput = int.Parse(Console.ReadLine());
                sum += currentInput;

                if (sum > capacity)
                {
                    sum -= currentInput;
                    Console.WriteLine("Insufficient capacity!");
                }

                counter++;
            }

            Console.WriteLine(sum);
        }
    }
}