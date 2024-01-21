namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> periodicTable = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] inputArr = Console.ReadLine().Split(" ");
                foreach (string element in inputArr)
                {
                    periodicTable.Add(element);
                }
            }

            periodicTable = periodicTable.OrderBy(e => e).ToHashSet();
            foreach (string element in periodicTable)
            {
                Console.Write(element + " ");
            }
        }
    }
}