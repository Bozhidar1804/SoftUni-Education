namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] inputArr = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();

            foreach (char c in inputArr)
            {
                if (!occurrences.ContainsKey(c))
                {
                    occurrences[c] = 1;
                }
                else if (occurrences.ContainsKey(c))
                {
                    occurrences[c]++;
                }
            }

            foreach (KeyValuePair<char, int> kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}