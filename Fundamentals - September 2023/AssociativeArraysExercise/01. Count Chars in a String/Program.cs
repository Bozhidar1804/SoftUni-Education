namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ").ToArray();
            Dictionary<char, int> letterOcc = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];

                foreach (char c in currentWord)
                {
                    if (!letterOcc.ContainsKey(c))
                    {
                        letterOcc.Add(c, 1);
                    } else
                    {
                        letterOcc[c]++;
                    }
                }
            }

            foreach (KeyValuePair<char, int> kvp in letterOcc)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}