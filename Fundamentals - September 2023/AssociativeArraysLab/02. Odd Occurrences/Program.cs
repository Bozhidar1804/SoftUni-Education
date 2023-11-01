namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ");

            Dictionary<string, int> appearances = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordInLowerCase = word.ToLower();
                if (appearances.ContainsKey(wordInLowerCase))
                {
                    appearances[wordInLowerCase]++;
                } else
                {
                    appearances.Add(wordInLowerCase, 1);
                }
            }

            string result = "";

            foreach (KeyValuePair<string, int> kvp in appearances)
            {
                if (kvp.Value % 2 != 0)
                {
                    result += kvp.Key + " ";
                }
            }

            Console.WriteLine(result);
        }
    }
}