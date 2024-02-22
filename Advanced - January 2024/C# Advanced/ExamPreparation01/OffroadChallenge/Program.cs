namespace OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> initialFuel = new Stack<int> (Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Queue<int> consumptionFuel = new Queue<int> (Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Queue<int> neededFuel = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int altitudes = 1;
            bool reachTheTop = true;

            while (initialFuel.Count > 0)
            {
                int actualFuel = initialFuel.Pop() - consumptionFuel.Dequeue();
                int required = neededFuel.Dequeue();

                if (actualFuel >= required)
                {
                    Console.WriteLine($"John has reached: Altitude {altitudes++}");
                } else if (actualFuel < required)
                {
                    Console.WriteLine($"John did not reach: Altitude {altitudes}");
                    reachTheTop = false;
                    break;
                }
            }

            if (reachTheTop == false && altitudes > 1)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.Write("Reached altitudes: ");
                for (int i = 1; i < altitudes; i++)
                {
                    Console.Write($"Altitude {i}");
                    if (i < altitudes - 1)
                    {
                        Console.Write(", ");
                    }
                }
            } else if (reachTheTop == false && altitudes == 1)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            } else if (reachTheTop)
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}