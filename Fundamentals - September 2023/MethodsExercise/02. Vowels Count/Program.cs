using System.Runtime.Serialization.Formatters;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = VowelsCount(input);
            Console.WriteLine(result);

        }

        private static int VowelsCount(string a)
        {
            int count = 0;
            a = a.ToLower();
            foreach (char c in a)
            {
                if (IsVowel(c))
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsVowel(char c)
        {
            return "aeiou".Contains(c);
        }
    }
}