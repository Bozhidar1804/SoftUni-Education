namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = input[0];
            int s = input[1];
            int x = input[2];

            Queue<int> q = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            for (int i = 0; i < s; i++)
            {
                q.Dequeue();
            }
            
            if (q.Contains(x))
            {
                Console.WriteLine("true");
            } else if (q.Count == 0)
            {
                Console.WriteLine(0);
            } else
            {
                Console.WriteLine(q.Min());
            }
        }
    }
}