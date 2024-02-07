namespace _02GenericBoxofInteger
{
    public class StartUp
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

            Console.WriteLine(box.ToString());
        }
    }
}