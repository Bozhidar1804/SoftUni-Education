namespace _03GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                list.Add(item);
            }

            int[] indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Swap(list, indexes[0], indexes[1]);

            foreach (string item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            (list[index1], list[index2]) = (list[index2], list[index1]);
        }
    }
}