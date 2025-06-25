namespace _04GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int item = int.Parse(Console.ReadLine());
                box.Add(item);
            }

            int[] indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box.ToString());
        }
    }
}