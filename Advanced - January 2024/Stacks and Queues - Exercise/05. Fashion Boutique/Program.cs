using System.Text.RegularExpressions;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = capacity;
            int sum = 0;
            int racks = 0;

            if (clothes.Any())
            {
                racks++;
            }

            while (clothes.Any())
            {
                if (clothes.Peek() <= currentRackCapacity)
                {
                    currentRackCapacity -= clothes.Pop();
                } else
                {
                    racks++;
                    currentRackCapacity = capacity;
                }
            }

            Console.WriteLine(racks);
        }
    }
}