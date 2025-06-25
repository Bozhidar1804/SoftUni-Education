namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> stations = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] currentStation = new int[2];
                currentStation = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                stations.Enqueue(currentStation);
            }

            int position = 0;

            while (true)
            {
                int fuel = 0;

                foreach (int[] station in stations)
                {
                    fuel += station[0] - station[1];

                    if (fuel < 0)
                    {
                        position++;
                        stations.Enqueue(stations.Dequeue());
                        break;
                    }
                }
                if (fuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(position);
        }
    }
}