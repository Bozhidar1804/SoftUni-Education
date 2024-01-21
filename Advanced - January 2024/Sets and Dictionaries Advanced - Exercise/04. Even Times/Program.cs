namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!occurrences.ContainsKey(input))
                {
                    occurrences[input] = 1;
                } else if (occurrences.ContainsKey(input))
                {
                    occurrences[input]++;
                }
            }
            int evenTimesNumber = 0;
            foreach (KeyValuePair<int, int> kvp in occurrences)
            {
                if (kvp.Value % 2 == 0)
                {
                    evenTimesNumber = kvp.Key;
                }
            }
            Console.WriteLine(evenTimesNumber);
        }
    }
}