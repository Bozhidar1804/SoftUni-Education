namespace _01Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagons = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
            }

            foreach (int wagon in wagons)
            {
                Console.Write($"{wagon} ");
                sum += wagon;
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}